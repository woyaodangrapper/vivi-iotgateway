using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class UnitCapabMapAppService : AbstractAppService, IUnitCapabMapAppService
{
    private readonly IEfRepository<UnitCapabMapEntity> _unitCapabMapRepository;
    private readonly IObjectMapper _mapper;

    public UnitCapabMapAppService(ILogger<UnitCapabMapAppService> logger,
         IEfRepository<UnitCapabMapEntity> unitCapabMapRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _unitCapabMapRepository = unitCapabMapRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(UnitCapabMapRequestDto input)
    {
        var unitCapabMapMapEntity = _mapper.Map<UnitCapabMapEntity>(input);
        return await _unitCapabMapRepository.InsertAsync(unitCapabMapMapEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _unitCapabMapRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<UnitCapabMapDto>> GetPagedAsync(UnitCapabMapQueryDto input)
    {
        var search = new QueryUnitCapabMapCommand()
        {
            UnitId = input.UnitId,
            CapabId = input.CapabId,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<UnitCapabMapEntity>()
        // .NotDeleted();
        ;

        return await _unitCapabMapRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<UnitCapabMapDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(UnitCapabMapRequestDto input)
    {
        var device = _mapper.Map<UnitCapabMapEntity>(input);
        var rwoAdd = await _unitCapabMapRepository.UpdateAsync(device, UpdatingProps<UnitCapabMapEntity>(x =>
            x.Equals(device)
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}