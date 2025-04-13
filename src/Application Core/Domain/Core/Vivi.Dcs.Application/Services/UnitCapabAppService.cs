﻿using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class UnitCapabAppService : AbstractAppService, IUnitCapabAppService
{
    private readonly IEfRepository<UnitCapabEntity> _unitCapabRepository;
    private readonly IObjectMapper _mapper;

    public UnitCapabAppService(ILogger<UnitCapabAppService> logger,
         IEfRepository<UnitCapabEntity> unitCapabRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _unitCapabRepository = unitCapabRepository;
    }

    public async Task<AppSrvResult<IdDTO>> CreateAsync(UnitCapabRequestDTO input)
    {
        var entity = _mapper.Map<UnitCapabEntity>(input);
        await _unitCapabRepository.InsertAsync(entity);
        return new IdDTO(entity.Id);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _unitCapabRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<UnitCapabDTO>> GetPagedAsync(UnitCapabQueryDTO input)
    {
        var search = new QueryUnitCapabCommand()
        {
            Name = input.Name,
            Unit = input.Unit,
            Description = input.Description,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<UnitCapabEntity>()
       .AndIf(search.Name is not null, x => x.Name.Contains(search.Name!))
       .AndIf(search.Unit is not null, x => x.Name.Contains(search.Unit!))
       .AndIf(search.Description is not null, x => x.Name.Contains(search.Description!))
        // .NotDeleted();
        ;

        return await _unitCapabRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDTO { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<UnitCapabDTO>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(UnitCapabRequestDTO input)
    {
        var device = _mapper.Map<UnitCapabEntity>(input);
        var rwoAdd = await _unitCapabRepository.UpdateAsync(device, UpdatingProps<UnitCapabEntity>(x =>
            x.Name
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}