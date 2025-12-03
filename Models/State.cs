using System;
using System.Collections.Generic;

namespace usa.Models;

/// <summary>
/// 州
/// </summary>
public partial class State
{
    /// <summary>
    /// 主键
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 州名
    /// </summary>
    public string StateName { get; set; } = null!;

    /// <summary>
    /// 首府
    /// </summary>
    public string StateCapital { get; set; } = null!;

    /// <summary>
    /// 州长
    /// </summary>
    public string Governor { get; set; } = null!;

    /// <summary>
    /// 党派，0：摇摆州
    /// </summary>
    public long PartyId { get; set; }

    /// <summary>
    /// 缩写
    /// </summary>
    public string Abbreviation { get; set; } = null!;

    /// <summary>
    /// 经济排名
    /// </summary>
    public sbyte Rank { get; set; }

    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// 独立倾向, 0:不独立；1:独立
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 代表人数
    /// </summary>
    public sbyte NumberOfReps { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
}
