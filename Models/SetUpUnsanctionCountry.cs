﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// UN制裁國家
/// </summary>
public partial class SetUpUnsanctionCountry
{
    /// <summary>
    /// UN制裁國家代碼，範例 : TW
    /// </summary>
    public string UnsanctionCountryCode { get; set; }

    /// <summary>
    /// UN制裁國家名稱
    /// </summary>
    public string UnsanctionCountryName { get; set; }

    /// <summary>
    /// 是否啟用，Y | N
    /// </summary>
    public string IsActive { get; set; }

    /// <summary>
    /// 新增員工
    /// </summary>
    public string AddUserId { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime AddTime { get; set; }

    /// <summary>
    /// 修正員工
    /// </summary>
    public string UpdateUserId { get; set; }

    /// <summary>
    /// 修正時間
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}