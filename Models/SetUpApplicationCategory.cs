﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// 申請書類別
/// </summary>
public partial class SetUpApplicationCategory
{
    /// <summary>
    /// 申請書類別代碼，範例: AF00002
    /// </summary>
    public string ApplicationCategoryCode { get; set; }

    /// <summary>
    /// 申請書類別名稱
    /// </summary>
    public string ApplicationCategoryName { get; set; }

    /// <summary>
    /// 是否為OCR表單，Y | N
    /// </summary>
    public string IsOcrform { get; set; }

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