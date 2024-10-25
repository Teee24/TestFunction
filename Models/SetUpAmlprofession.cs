﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// AML職業別
/// </summary>
public partial class SetUpAmlprofession
{
    /// <summary>
    /// PK
    /// </summary>
    public string SeqNo { get; set; }

    /// <summary>
    /// AML職業別代碼
    /// </summary>
    public string AmlprofessionCode { get; set; }

    /// <summary>
    /// 版本，範例: 20240102，用於切分上線時間點
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// AML職業別名稱
    /// </summary>
    public string AmlprofessionName { get; set; }

    /// <summary>
    /// AML職業別比對結果，Y | N
    /// </summary>
    public string AmlprofessionCompareResult { get; set; }

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