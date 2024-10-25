﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// 製卡失敗原因
/// </summary>
public partial class SetUpMakeCardFailedReason
{
    /// <summary>
    /// 製卡失敗原因代碼，範例: 01、AZ
    /// </summary>
    public string MakeCardFailedReasonCode { get; set; }

    /// <summary>
    /// 製卡失敗原因名稱
    /// </summary>
    public string MakeCardFailedReasonName { get; set; }

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