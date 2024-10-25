﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// 徵審待辦_申請信用卡任務非原卡友
/// </summary>
public partial class ReviewerPeddingApplyCardCheckJobForNotA02
{
    /// <summary>
    /// E-CARD申請書編號，
    /// 對應 E-CARD = APPLY_NO
    /// IDType = 空白= 金融小白，受理編號中會有 X
    /// IDType = 存戶與卡友，受理編號中會有 B
    /// 
    /// </summary>
    public string ApplyNo { get; set; }

    /// <summary>
    /// 是否檢查鎖住，
    /// 排程每次執行需鎖住Y，如果檢驗失敗須將此表還原為Ｎ
    /// 預設 N
    /// Y｜N
    /// 
    /// </summary>
    public string IsCheckLock { get; set; }

    /// <summary>
    /// 是否發查敦陽姓名檢核，
    /// Y｜N
    /// 預設 N
    /// 
    /// </summary>
    public string IsCheckName { get; set; }

    /// <summary>
    /// 查敦陽姓名檢核最後時間
    /// </summary>
    public DateTime CheckNameLastTime { get; set; }

    /// <summary>
    /// 是否查詢分行資訊，
    /// Y｜N
    /// 預設 N
    /// </summary>
    public string IsQueryBranchInfo { get; set; }

    /// <summary>
    /// 查詢分行資訊最後時間
    /// </summary>
    public DateTime QueryBranchInfoLastTime { get; set; }

    /// <summary>
    /// 是否發查929，
    /// Y｜N
    /// 預設 N
    /// </summary>
    public string IsCheck929 { get; set; }

    /// <summary>
    /// 發查929最後時間
    /// </summary>
    public DateTime Check929LastTime { get; set; }

    /// <summary>
    /// 是否發查告誡，
    /// Y｜N
    /// 預設 N
    /// </summary>
    public string IsCheckWarningList { get; set; }

    /// <summary>
    /// 發查告誡最後時間
    /// </summary>
    public DateTime CheckWarningListLastTime { get; set; }

    /// <summary>
    /// 是否檢查相同IP，
    /// Y｜N
    /// 預設 N
    /// </summary>
    public string IsCheckSameIp { get; set; }

    /// <summary>
    /// 檢查相同IP最後時間
    /// </summary>
    public DateTime CheckSameIplastTime { get; set; }

    /// <summary>
    /// 是否檢查行內IP，
    /// Y｜N
    /// 預設 N
    /// </summary>
    public string IsCheckEqualInternalIp { get; set; }

    /// <summary>
    /// 檢查行內IP最後時間
    /// </summary>
    public DateTime CheckEqualInternalIplastTime { get; set; }

    /// <summary>
    /// 國旅人士名冊確認，Y｜N
    /// </summary>
    public string 國旅人士名冊確認 { get; set; }

    /// <summary>
    /// 國旅人士名冊確認最後時間
    /// </summary>
    public DateTime? 國旅人士名冊確認最後時間 { get; set; }

    /// <summary>
    /// 是否需要取得MyData，Y｜N
    /// </summary>
    public string IsNeedGetMydata { get; set; }

    /// <summary>
    /// MyData是否取得成功，Y｜N
    /// </summary>
    public string IsGetMydatasuccess { get; set; }

    /// <summary>
    /// 取得MyData最後時間
    /// </summary>
    public DateTime? GetMydatalastTime { get; set; }

    /// <summary>
    /// 是否檢驗完畢，
    /// Y｜N
    /// 預設Ｎ
    /// </summary>
    public string IsChecked { get; set; }

    /// <summary>
    /// 是否取得檔案鎖住，
    /// Y｜N
    /// 預設Ｎ
    /// </summary>
    public string IsGetFileLock { get; set; }

    /// <summary>
    /// 是否取得檔案，
    /// Y｜N
    /// 需儲存所有申請書附件
    /// 預設Ｎ
    /// </summary>
    public string IsGetFile { get; set; }

    /// <summary>
    /// 取得檔案最後時間
    /// </summary>
    public DateTime? GetFileLastTime { get; set; }

    /// <summary>
    /// 錯誤鎖定，
    /// Y｜N
    /// 預設 N
    /// 當錯誤達2次鎖定,需人工打開才能繼續檢核
    /// 
    /// </summary>
    public string IsErrorLock { get; set; }

    /// <summary>
    /// 是否轉移，
    /// Y｜N
    /// 預設 N
    /// 此為結案意思
    /// 
    /// </summary>
    public string IsTransfer { get; set; }

    /// <summary>
    /// 轉移時間
    /// </summary>
    public DateTime? IsTransferTime { get; set; }

    /// <summary>
    /// 創建時間
    /// </summary>
    public DateTime AddTime { get; set; }
}