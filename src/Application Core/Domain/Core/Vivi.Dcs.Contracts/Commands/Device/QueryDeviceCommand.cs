namespace Vivi.Dcs.Contracts.Commands;

public class QueryDeviceCommand : SearchPagedDto
{
    public string? name { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }

    public DateTime? FormattedStartTime
    {
        get => startTime?.Date;// 取开始时间的日期部分，即当天的凌晨时间
        set => startTime = value.HasValue && startTime.HasValue ? value.Value.Date + startTime.Value.TimeOfDay : value;//  将开始时间的日期部分替换为指定日期，时间部分不变 如果 value 为 null，则直接将 startTime 赋值为 null
    }

    public DateTime? FormattedEndTime
    {
        get => endTime?.Date.AddDays(1).AddTicks(-1); // 取结束时间的日期部分，加上一天再减去一刻钟的时间，即当天的最后一刻钟时间
        set => endTime = value.HasValue && endTime.HasValue ? value.Value.Date + endTime.Value.TimeOfDay : value;// 将结束时间的日期部分替换为指定日期，时间部分不变 如果 value 为 null，则直接将 endTime 赋值为 null
    }
}