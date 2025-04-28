using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class AreaAppService : AbstractAppService, IAreaAppService
{
    private readonly IEfRepository<AreaEntity> _areaRepository;
    private readonly IObjectMapper _mapper;

    public AreaAppService(ILogger<AreaAppService> logger,
         IEfRepository<AreaEntity> areaRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _areaRepository = areaRepository;
    }

    public async Task<AppSrvResult<IdDTO>> CreateAsync(AreaRequestDTO input)
    {
        var entity = _mapper.Map<AreaEntity>(input);
        await _areaRepository.InsertAsync(entity);
        return new IdDTO(entity.Id);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _areaRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<List<AreaDTO>> GetListAsync(AreaQueryDTO input)
    {

        var search = new QueryAreaCommand()
        {
            name = input.Name,
            code = input.Code,
            type = input.Type,
        };

        var whereExpression = ExpressionCreator
       .New<AreaEntity>()
       .AndIf(!string.IsNullOrWhiteSpace(search.name), x => x.Name.Contains(search!.name!))
       .AndIf(!string.IsNullOrWhiteSpace(search.code), x => x.Code != null && x.Code.Contains(search!.code!))
       .AndIf(!string.IsNullOrWhiteSpace(search.type), x => x.Type != null && x.Type.Contains(search!.type!))
        // .NotDeleted();
        ;
        var list = await _areaRepository.Where(whereExpression).ToArrayAsync();
        //return [.. list.Select(l => _mapper.Map<AreaDTO>(l))];
        return _mapper.Map<List<AreaDTO>>(list);
    }

    public async Task<AppSrvResult> UpdateAsync(AreaRequestDTO input)
    {
        var area = _mapper.Map<AreaEntity>(input);
        var rwoAdd = await _areaRepository.UpdateAsync(area, UpdatingProps<AreaEntity>(x =>
            x.Name,
            x => x.Code,
            x => x.Type,
            x => x.Position,
            x => x.BlockCode
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }

    public async Task<AppSrvResult<IdDTO[]>> AddOrUpdateRangeAsync(AreaTreeNodeDTO[] input)
    {
        // 扁平化一次
        var treeNodes = input.SelectMany(node => node.Flatten()).ToList();
        var treeNodeIds = treeNodes.Select(x => x.Id).ToList();

        // 直接查询所有相关的 areaEntitys
        var areaEntitys = _areaRepository.Where(x => treeNodeIds.Contains(x.Id)).ToList();

        // 直接构建 updateDict
        var areaEntityIds = areaEntitys.Select(x => x.Id).ToHashSet(); // 使用 HashSet 提高查找性能
        var updateDict = treeNodes
            .Where(dto => areaEntityIds.Contains(dto.Id))
            .ToDictionary(
                dto => dto.Id,
                dto => new List<(string, dynamic)>
                {
                ("Pid", dto.Pid),
                ("Name", dto.Name),
                ("Code", dto.Code),
                ("Type", dto.Type),
                ("Level", dto.Level),
                ("Position", dto.Position),
                ("BlockCode", dto.BlockCode)
                }
            );

        // 更新操作
        var affectedRows = await _areaRepository.UpdateRangeAsync(updateDict);
        if (affectedRows == 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");

        // 获取需要新增的节点
        var addEntitys = _mapper.Map<AreaEntity[]>(treeNodes.Where(x => !areaEntityIds.Contains(x.Id)).ToArray());
        if (addEntitys.Length > 0)
        {
            await _areaRepository.InsertRangeAsync(addEntitys);
            return addEntitys.Select(entity => new IdDTO(entity.Id)).ToArray();
        }

        return AppSrvResult();
    }


    public async Task<AppSrvResult> DeleteOrUpdateRangeAsync(AreaRequestDTO[] input)
    {
        var areas = _mapper.Map<AreaEntity[]>(input);

        // 查找现有的区域实体
        var areaEntitys = _areaRepository.Where(x => areas.Select(a => a.Id).Contains(x.Id));

        // 找到需要更新的区域，生成更新字典
        var updateDict = input
             .Where(dto => areaEntitys.Select(a => a.Id).Contains(dto.Id))
             .ToDictionary(
                 dto => dto.Id,
                 dto => new List<(string, dynamic)>
                 {
                    ("Pid", dto.Pid),
                 }
        );

        // 执行更新操作
        var affectedRows = await _areaRepository.UpdateRangeAsync(updateDict);
        if (affectedRows == 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");

        // 查找需要删除的区域
        var deleteIds = _areaRepository
            .Where(entity => !areaEntitys.Select(a => a.Id).Contains(entity.Id))  // 找出在 input 中没有的区域
            ;

        // 如果有需要删除的区域
        if (deleteIds.Any())
        {
            var deleteResult = await deleteIds.ExecuteDeleteAsync();
            if (deleteResult == 0)
                return Problem(HttpStatusCode.InternalServerError, "数据删除失败");
        }

        return AppSrvResult();
    }


    public async Task<List<AreaTreeNodeDTO>> GetNodesAsync(AreaQueryDTO input)
    {
        var whereList = await GetListAsync(input);
        // 将 AreaDTO 转换为 AreaTreeNodeDTO，同时初始化 Children
        var areaTreeNodes = whereList.Select(area => new AreaTreeNodeDTO
        {
            Id = area.Id,
            Name = area.Name,
            Code = area.Code,
            Type = area.Type,
            Level = area.Level,
            Position = area.Position,
            BlockCode = area.BlockCode,
            Pid = area.Pid,
            Children = [] // 初始化 Children
        }).ToList();

        // 获取根节点 (Pid == null 或 0)
        var rootNodes = areaTreeNodes.Where(n => n.Pid == null).ToList();
        rootNodes.ForEach(node => node.Build(areaTreeNodes)); // 构建树形结构
        return rootNodes;
    }

    public async Task<AppSrvResult> DeleteNodesAsync(AreaTreeNodeDTO[] input)
    {
        var deleteIds = input.SelectMany(node => node.Flatten().Select(a => a.Id));
        var areaEntitys = _areaRepository.Where(x => deleteIds.Contains(x.Id));
        if (deleteIds.Any())
        {
            var deleteResult = await areaEntitys.ExecuteDeleteAsync();
            if (deleteResult == 0)
                return Problem(HttpStatusCode.InternalServerError, "数据删除失败");
        }
        return AppSrvResult();
    }

}