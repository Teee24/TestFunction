﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// 卡片種類
/// </summary>
public partial class SetUpCard
{
    /// <summary>
    /// BIN，長度8碼
    /// </summary>
    public string Bincode { get; set; }

    /// <summary>
    /// 卡片代碼，範例：JST65
    /// </summary>
    public string CardCode { get; set; }

    /// <summary>
    /// 卡片名稱
    /// </summary>
    public string CardName { get; set; }

    /// <summary>
    /// 卡片類別，一般發卡、國民現金卡、消、現金卡代償
    /// </summary>
    public int CardCategory { get; set; }

    /// <summary>
    /// 拒件函樣板，拒件函 (信用卡) 、拒件函 (消貸)、拒件函 (代償)
    /// </summary>
    public int SampleRejectionLetter { get; set; }

    /// <summary>
    /// 預設帳單日，關聯 SetUp_BillDay
    /// </summary>
    public string DefaultBillDay { get; set; }

    /// <summary>
    /// 銷貸類別，0:代償、1:銷貸、2:其他
    /// </summary>
    public int SaleLoanCategory { get; set; }

    /// <summary>
    /// 預設優惠辦法，關聯 SetUp_CardPromotion
    /// </summary>
    public string DefaultDiscount { get; set; }

    /// <summary>
    /// 是否啟用，Y | N
    /// </summary>
    public string IsActive { get; set; }

    /// <summary>
    /// 主卡額度上限，範例：3000000
    /// </summary>
    public int PrimaryCardQuotaUpperlimit { get; set; }

    /// <summary>
    /// 主卡額度下限，範例：10000
    /// </summary>
    public int PrimaryCardQuotaLowerlimit { get; set; }

    /// <summary>
    /// 主卡年齡上限，範例：20
    /// </summary>
    public int PrimaryCardYearUpperlimit { get; set; }

    /// <summary>
    /// 主卡年齡下限，範例：99
    /// </summary>
    public int PrimaryCardYearLowerlimit { get; set; }

    /// <summary>
    /// 附卡額度上限，範例：3000000
    /// </summary>
    public int SupplementaryCardQuotaUpperlimit { get; set; }

    /// <summary>
    /// 附卡額度下限，範例：10000
    /// </summary>
    public int SupplementaryCardQuotaLowerlimit { get; set; }

    /// <summary>
    /// 附卡年齡上限，範例：20
    /// </summary>
    public int SupplementaryCardYearUpperlimit { get; set; }

    /// <summary>
    /// 附卡年齡下限，範例：99
    /// </summary>
    public int SupplementaryCardYearLowerlimit { get; set; }

    /// <summary>
    /// 是否不大於CARDPAC額度限制，Y | N
    /// </summary>
    public string IsCardpaunderLimit { get; set; }

    /// <summary>
    /// CARDPAC額度限制，20
    /// </summary>
    public int CardpacquotaLimit { get; set; }

    /// <summary>
    /// 不得申請辦附卡，Y | N，Y :  是不能申請
    /// </summary>
    public string IsApplyAdditionalCard { get; set; }

    /// <summary>
    /// 是否獨立卡別，Y | N
    /// </summary>
    public string IsIndependentCard { get; set; }

    /// <summary>
    /// 是否作IVR/CTI查詢，Y | N
    /// </summary>
    public string IsIvrvCtiquery { get; set; }

    /// <summary>
    /// 國旅卡，Y | N
    /// </summary>
    public string IsCitscard { get; set; }

    /// <summary>
    /// 快速發卡，Y | N
    /// </summary>
    public string IsQuickCardIssuance { get; set; }

    /// <summary>
    /// 票證功能，Y | N
    /// </summary>
    public string IsTicket { get; set; }

    /// <summary>
    /// 聯名集團，Y | N
    /// </summary>
    public string IsJointGroup { get; set; }

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