using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace Vivi.Dcs.Application.Implements;

public class UnitRecordsAppService : AbstractAppService, IUnitRecordsAppService
{
    private readonly IEfRepository<UnitRecordsEntity> _unitRecordsRepository;
    private readonly IObjectMapper _mapper;

    public UnitRecordsAppService(ILogger<UnitRecordsAppService> logger,
         IEfRepository<UnitRecordsEntity> unitRecordsRepository,
         IObjectMapper mapper
        )
    {
        _mapper = mapper;
        _unitRecordsRepository = unitRecordsRepository;
    }

    public async Task<AppSrvResult<long>> CreateAsync(UnitRecordsRequestDto input)
    {
        var unitRecordsEntity = _mapper.Map<UnitRecordsEntity>(input);
        return await _unitRecordsRepository.InsertAsync(unitRecordsEntity);
    }

    public async Task<AppSrvResult> DeleteAsync(Guid id)
    {
        await _unitRecordsRepository.DeleteAsync(id);
        return AppSrvResult();
    }

    public async Task<SearchPage<UnitRecordsDto>> GetPagedAsync(UnitRecordsQueryDto input)
    {
        var search = new QueryUnitRecordsCommand()
        {
            UnitId = input.UnitId,
            CapabId = input.CapabId,
            Value = input.Value,
            pageIndex = input.pageIndex,
            pageSize = input.pageSize,
        };

        var whereExpression = ExpressionCreator
       .New<UnitRecordsEntity>()
        // .NotDeleted();
        ;

        return await _unitRecordsRepository.QueryableAsync(
             // _mapper.Map 仅作为演示，实际项目请使用 => new DeviceDto { Name = x.Name, Model = x.Model }
             search, whereExpression, x => _mapper.Map<UnitRecordsDto>(x)
          );
    }

    public async Task<AppSrvResult> UpdateAsync(UnitRecordsRequestDto input)
    {
        var device = _mapper.Map<UnitRecordsEntity>(input);
        var rwoAdd = await _unitRecordsRepository.UpdateAsync(device, UpdatingProps<UnitRecordsEntity>(x =>
         x.Equals(device)
         ));
        if (rwoAdd is 0)
            return Problem(HttpStatusCode.InternalServerError, "数据修改失败");
        return AppSrvResult();
    }
}