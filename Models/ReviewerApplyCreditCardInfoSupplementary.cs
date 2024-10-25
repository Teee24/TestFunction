﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

public partial class ReviewerApplyCreditCardInfoSupplementary
{
    /// <summary>
    /// 申請書編號
    /// </summary>
    public string ApplyNo { get; set; }

    /// <summary>
    /// 身分證字號
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 中文姓名
    /// </summary>
    public string Chname { get; set; }

    /// <summary>
    /// 性別：1.男生 2. 女生
    /// </summary>
    public int Sex { get; set; }

    /// <summary>
    /// 生日：民國格式為 YYYMMDD
    /// </summary>
    public string BirthDay { get; set; }

    /// <summary>
    /// 英文姓名
    /// </summary>
    public string Enname { get; set; }

    /// <summary>
    /// 身分證發證日期：民國格式為 YYYMMDD
    /// </summary>
    public string IdissueDate { get; set; }

    /// <summary>
    /// 身分證發證地點：關聯 SetUp_IDCardRenewalLocation
    /// </summary>
    public string IdcardRenewalLocationCode { get; set; }

    /// <summary>
    /// 身分證護照種類：1. 初發, 2. 補發, 3. 換發
    /// </summary>
    public int IdtakeStatus { get; set; }

    /// <summary>
    /// 國籍：關聯 SetUp_Citizenship
    /// </summary>
    public string CitizenshipCode { get; set; }

    /// <summary>
    /// 出生地國籍：1. 中華民國 2. 其他
    /// </summary>
    public string BirthCitizenshipCode { get; set; }

    /// <summary>
    /// 出生地國籍_其他：當出生地國籍為其他時使用
    /// </summary>
    public string BirthCitizenshipOther { get; set; }

    /// <summary>
    /// 婚姻狀況：1. 已婚, 2. 未婚, 3. 其他
    /// </summary>
    public int MarriageState { get; set; }

    /// <summary>
    /// 行動電話
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 與正卡人關係
    /// </summary>
    public int ApplicantRelationship { get; set; }

    /// <summary>
    /// 電話，可手機 / 行動電話
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 居居留證發證日期 (格式: YYYYMMDD)
    /// </summary>
    public string ResidencePermitIssueDate { get; set; }

    /// <summary>
    /// 護照號碼
    /// </summary>
    public string PassportNo { get; set; }

    /// <summary>
    /// 護照日期 (格式: YYYYMMDD)
    /// </summary>
    public string PassportDate { get; set; }

    /// <summary>
    /// 外籍人士准居效期
    /// </summary>
    public string ExpatValidityPeriod { get; set; }

    /// <summary>
    /// 敦陽系統黑名單是否符合(Y/N)
    /// </summary>
    public string IsDunyangBlackList { get; set; }

    /// <summary>
    /// 是否FATCA身份 (Y/N)
    /// </summary>
    public string IsFatcaidentity { get; set; }

    /// <summary>
    /// 社會安全碼
    /// </summary>
    public string SocialSecurityCode { get; set; }

    /// <summary>
    /// 理由碼
    /// </summary>
    public string ReasonCode { get; set; }
}