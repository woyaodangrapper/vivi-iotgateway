﻿namespace Vivi.Dcs.Contracts.Commands;

public class QueryAreaCommand : SearchPagedDTO
{

    public string? name { get; set; }
    public string? code { get; set; }
    public string? type { get; set; }

    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }

    public DateTime? FormattedStartTime
    {
        // 取开始时间的日期部分，即当天的凌晨时间
        get => startTime?.Date;
        //  将开始时间的日期部分替换为指定日期，时间部分不变 如果 value 为 null，则直接将 startTime 赋值为 null
        set => startTime = value.HasValue && startTime.HasValue ? value.Value.Date + startTime.Value.TimeOfDay : value;
    }

    public DateTime? FormattedEndTime
    {
        // 取结束时间的日期部分，加上一天再减去一刻钟的时间，即当天的最后一刻钟时间
        get => endTime?.Date.AddDays(1).AddTicks(-1);
        // 将结束时间的日期部分替换为指定日期，时间部分不变 如果 value 为 null，则直接将 endTime 赋值为 null
        set => endTime = value.HasValue && endTime.HasValue ? value.Value.Date + endTime.Value.TimeOfDay : value;
    }
}