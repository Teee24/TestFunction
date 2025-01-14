﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScoreSharpTestData.Models;

/// <summary>
/// 徵審待辦_申請信用卡正卡人資料
/// </summary>
public partial class ReviewerPeddingApplyCreditCardInfoPrimary
{
    /// <summary>
    /// E-CARD申請書編號，
    /// 對應 E-CARD = APPLY_NO
    /// IDType = 空白= 金融小白，受理編號中會有 X
    /// IDType = 存戶與卡友，受理編號中會有 B
    /// </summary>
    public string ApplyNo { get; set; }

    /// <summary>
    /// 身份別，
    /// 1.卡友
    /// 2.存戶
    /// 3.持他行卡
    /// 4.自然人憑證
    /// E-CARD提供-卡友、存戶、持他行卡、自然人憑證
    /// 對應 E-CARD = ID_TYPE
    /// 
    /// </summary>
    public string Idtype { get; set; }

    /// <summary>
    /// 徵信代碼，
    /// 如是E-CARD帶入為原卡友值為A02，否則為空值
    /// 關聯 SetUp_CreditCheckCode
    /// 對應 E-CARD = CREDIT_ID
    /// </summary>
    public string CreditCheckCode { get; set; }

    /// <summary>
    /// 正附卡，
    /// 依客人申請帶出，現網路申請僅能申請正卡
    /// 對應 E-CARD = CARD_OWNER
    /// 1.正卡
    /// 2.附卡
    /// 3.正卡+附卡
    /// 4.附卡2
    /// 5.正卡+附卡2
    /// </summary>
    public string CardOwner { get; set; }

    /// <summary>
    /// 申請卡別，
    /// E-CARD 帶入可多選欄位，如多選資料以/相隔，例如：JA00/JC00。
    /// 關聯 SetUp_Card
    /// 對應 E-CARD = MCARD_SER
    /// </summary>
    public string ApplyCardType { get; set; }

    /// <summary>
    /// 表單代碼，
    /// E-CARD提供
    /// 表單學習用，由資處定義
    /// 對應 E-CARD = FORM_ID
    /// </summary>
    public string FormCode { get; set; }

    /// <summary>
    /// 正卡_中文姓名，對應 E-CARD = CH_NAME
    /// </summary>
    public string Chname { get; set; }

    /// <summary>
    /// 正卡_性別，
    /// 1.男
    /// 2.女 
    /// 對應 E-CARD = SEX
    /// </summary>
    public string Sex { get; set; }

    /// <summary>
    /// 正卡_出生年月日，
    /// 目前系統是請他提供YYYMMDD
    /// 對應 E-CARD = BIRTHDAY
    /// </summary>
    public string BirthDay { get; set; }

    /// <summary>
    /// 正卡_英文姓名，對應 E-CARD = ENG_NAME
    /// </summary>
    public string Enname { get; set; }

    /// <summary>
    /// 正卡_出生地，
    /// ECARD 值如果是台灣要對應台灣縣市，如果是外國人則是其他
    /// 對應 E-CARD = BIRTH_PLACE
    /// </summary>
    public string BirthPlace { get; set; }

    /// <summary>
    /// 正卡_出生地_其他，
    /// 當出生地為其他時候需要有值
    /// 關聯 SetUp_Citizenship
    /// 對應 E-CARD = BIRTH_PLACE_OTHER
    /// </summary>
    public string BirthPlaceOther { get; set; }

    /// <summary>
    /// 正卡_國籍，
    /// 由徵審系統提供值給E-CARD
    /// 關聯 SetUp_Citizenship
    /// 對應 E-CARD = NATIONALITY
    /// </summary>
    public string CitizenshipCode { get; set; }

    /// <summary>
    /// 正卡_身分證字號，對應 E-CARD = P_ID
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 正卡_身分證發證日期，
    /// 民國 YYYMMDD 
    /// 對應 E-CARD = P_ID_GETDATE
    /// </summary>
    public string IdissueDate { get; set; }

    /// <summary>
    /// 正卡_身分證發證地點，
    /// Ecard給中文
    /// 關聯 SetUp_IDCardRenewalLocation
    /// 對應 E-CARD = P_ID_GETADDRNAME
    /// </summary>
    public string IdcardRenewalLocationName { get; set; }

    /// <summary>
    /// 正卡_身分證請領狀態，
    /// 1.初發
    /// 2.補發
    /// 3.換發
    /// 對應 E-CARD = P_ID_STATUS
    /// </summary>
    public string IdtakeStatus { get; set; }

    /// <summary>
    /// 正卡_身分證請領狀態，
    /// 1.同戶籍
    /// 2.同居住
    /// 3.同公司
    /// 對應 E-CARD = BILL_TO_ADDR
    /// </summary>
    public string BillAddress { get; set; }

    /// <summary>
    /// 正卡_寄卡地址，
    /// 1.同戶籍
    /// 2.同居住
    /// 3.同公司
    /// 對應 E-CARD = CARD_TO_ADDR
    /// </summary>
    public string SendCardAddress { get; set; }

    /// <summary>
    /// 行動電話，對應 E-CARD = CELL_PHONE_NO
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 正卡_E-MAIL，對應 E-CARD = EMAIL
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// AML職業別，
    /// 由徵審系統提供值給E-CARD
    /// 關聯 SetUp_AMLProfession
    /// 對應 E-CARD = JOB_TYPE
    /// </summary>
    public string AmlprofessionCode { get; set; }

    /// <summary>
    /// AML職業別_其他，對應 E-CARD = JOB_TYPE_OTHER
    /// </summary>
    public string AmlprofessionOther { get; set; }

    /// <summary>
    /// AML職級別，
    /// 由徵審系統提供值給E-CARD
    /// 關聯 SetUp_AMLJobLevel
    /// 對應 E-CARD = JOB_LV
    /// </summary>
    public string AmljobLevelCode { get; set; }

    /// <summary>
    /// 公司名稱，對應 E-CARD = COMP_NAME
    /// </summary>
    public string CompName { get; set; }

    /// <summary>
    /// 公司電話，對應 E-CARD = COMP_TEL_NO
    /// 
    /// 
    /// </summary>
    public string CompPhone { get; set; }

    /// <summary>
    /// 現職月收入(元)
    /// 對應 E-CARD = SALARY
    /// 檢驗數字
    /// </summary>
    public string CurrentMonthIncome { get; set; }

    /// <summary>
    /// 所得及資金來源，
    /// 關聯SetUp_MainIncomeAndFund
    /// 用, 串接
    /// 需符合Paperless「主要所得及資金來源設定」。多選時中間以逗號(,)區隔
    /// 對應 E-CARD = MAIN_INCOME
    /// </summary>
    public string MainIncomeAndFundCodes { get; set; }

    /// <summary>
    /// 主要所得_其他，對應 E-CARD = MAIN_INCOME_OTHER
    /// </summary>
    public string MainIncomeAndFundOther { get; set; }

    /// <summary>
    /// 本人是否同意提供資料予聯名認同集團，
    /// 1：是
    /// 0：否
    /// 對應 E-CARD = ACCEPT_DM_FLG
    /// 
    /// 
    /// </summary>
    public string IsAgreeDataOpen { get; set; }

    /// <summary>
    /// 專案代號，
    /// 關聯 SetUp_ ProjectCode
    /// 對應 E-CARD = M_PROJECT_CODE_ID
    /// </summary>
    public string ProjectCode { get; set; }

    /// <summary>
    /// 推廣單位，
    /// 對應 E-CARD = PROM_UNIT_SER
    /// 
    /// 
    /// </summary>
    public string PromotionUnit { get; set; }

    /// <summary>
    /// 推廣人員，
    /// 對應 E-CARD = PROM_USER_NAME
    /// </summary>
    public string PromotionUser { get; set; }

    /// <summary>
    /// 是否同意提供資料於第三人行銷，
    /// 1：是
    /// 0：否
    /// 對應 E-CARD = AGREE_MARKETING_FLG
    /// </summary>
    public string IsAgreeMarketing { get; set; }

    /// <summary>
    /// 是否同意悠遊卡自動加值預設開啟，
    /// 1：是
    /// 0：否
    /// 對應 E-CARD = NOT_ACCEPT_EPAPAER_FLG
    /// </summary>
    public string IsAcceptEasyCardDefaultBonus { get; set; }

    /// <summary>
    /// 首刷禮代碼，
    /// 原系統是使用家庭成員6年齡
    /// 對應 E-CARD = FAMILY6_AGE
    /// </summary>
    public string FirstBrushingGiftCode { get; set; }

    /// <summary>
    /// 戶籍遷出轉卡（桃園市民卡用），
    /// Y：同意
    /// N：不同意
    /// 對應 E-CARD = CHG_CARD_ADDR
    /// 
    /// 
    /// </summary>
    public string HouseholdRegTransferCardForTaoyuanCitizenCard { get; set; }

    /// <summary>
    /// 帳單形式，
    /// 1：電子帳單
    /// 2：簡訊帳單
    /// 3：紙本帳單
    /// 4：LINE帳單
    /// 對應 E-CARD = BILL_TYPE
    /// 
    /// 
    /// </summary>
    public string BillType { get; set; }

    /// <summary>
    /// 是否申辦自動扣款，
    /// Y：是
    /// N：否
    /// 對應 E-CARD = AUTO_FLG
    /// </summary>
    public string IsApplyAutoDeduction { get; set; }

    /// <summary>
    /// 自動扣繳用戶＿銀行存款帳號，
    /// 對應 E-CARD = ACCT_NO
    /// Y：是
    /// N：否
    /// </summary>
    public string AutoDeductionBankAccount { get; set; }

    /// <summary>
    /// 自動扣繳用戶＿繳款方式，
    /// 對應 E-CARD = PAY_WAY
    /// 10.最低
    /// 20.全額
    /// </summary>
    public string AutoDeductionPayType { get; set; }

    /// <summary>
    /// 進件方式，
    /// 對應 E-CARD = SOURCE_TYPE
    /// 1.Ecard
    /// 2.APP
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// 使用者來源IP位置，對應 E-CARD = SOURCE_IP
    /// </summary>
    public string UserSourceIp { get; set; }

    /// <summary>
    /// OTP手機號碼，對應 E-CARD = OTP_MOBILE_PHONE
    /// </summary>
    public string Otpmobile { get; set; }

    /// <summary>
    /// OTP時間，對應 E-CARD = OTP_TIME
    /// </summary>
    public DateTime? Otptime { get; set; }

    /// <summary>
    /// 是否申請數位卡，對應 E-CARD = DIGI_CARD_FLG
    /// Y：是
    /// N：否
    /// </summary>
    public string IsApplyDigtalCard { get; set; }

    /// <summary>
    /// 申請卡種，
    /// 對應 E-CARD = CARD_KIND
    /// 1.實體
    /// 2.數位
    /// 3.實體+數位
    /// 
    /// 
    /// </summary>
    public string ApplyCardKind { get; set; }

    /// <summary>
    /// 申請書檔名，對應 E-CARD = APPLICATION_FILE_NAME
    /// </summary>
    public string ApplicationFileName { get; set; }

    /// <summary>
    /// 附件註記，對應 E-CARD = APPENDIX_FLG
    /// 1.附件異常
    /// 2.MYDATA後補
    /// </summary>
    public string AttachmentNotes { get; set; }

    /// <summary>
    /// MyData案件編號，
    /// 當附件註記為2：MYDATA後補時，本欄位必定有值
    /// 對應 E-CARD = MYDATA_NO
    /// </summary>
    public string MyDataCaseNo { get; set; }

    /// <summary>
    /// 正卡地址，
    /// 對應 E-CARD = CARD_ADDR
    /// </summary>
    public string CardAddr { get; set; }

    /// <summary>
    /// KYC資料是否變動，
    /// 對應 E-CARD = KYC_CHG_FLG
    /// Y：是
    /// N：否
    /// </summary>
    public string IsKycchange { get; set; }

    /// <summary>
    /// 是否綁定消費通知，對應 E-CARD = CONSUM_NOTICE_FLG
    /// Y：是
    /// N：否
    /// </summary>
    public string IsPayNoticeBind { get; set; }

    /// <summary>
    /// ECARD_UUID，對應 E-CARD = UUID
    /// 
    /// 
    /// </summary>
    public Guid? EcardUuid { get; set; }

    /// <summary>
    /// 活存目前餘額，對應 E-CARD = DEMAND_CURR_BAL
    /// 檢驗要為數字
    /// </summary>
    public string HuocunBalance { get; set; }

    /// <summary>
    /// 定存目前餘額，對應 E-CARD =TIME_CURR_BAL
    /// 檢驗要為數字
    /// </summary>
    public string DingcunBalance { get; set; }

    /// <summary>
    /// 活存90天平均餘額，對應 E-CARD = DEMAND_90DAY_BAL
    /// 檢驗要為數字
    /// </summary>
    public string HuocunBalance90 { get; set; }

    /// <summary>
    /// 定存90天平均餘額，對應 E-CARD = TIME_90DAY_BAL
    /// 檢驗要為數字
    /// </summary>
    public string DingcunBalance90 { get; set; }

    /// <summary>
    /// 餘額更新日期，對應 E-CARD = BAL_UPD_DATE
    /// </summary>
    public DateTime? BalanceUpdateDate { get; set; }

    /// <summary>
    /// 是否學生身份，對應 E-CARD = STUDENT_FLG
    /// Y：是
    /// N：否
    /// </summary>
    public string IsStudent { get; set; }

    /// <summary>
    /// 家長姓名，對應 E-CARD = PARENT_NAME
    /// </summary>
    public string ParentName { get; set; }

    /// <summary>
    /// 家長電話，對應 E-CARD = PARENT_HOME_TEL_NO
    /// 可以行動電話或者家電
    /// </summary>
    public string ParentPhone { get; set; }

    /// <summary>
    /// 教育程度，
    /// 1.博士
    /// 2.碩士
    /// 3.大學
    /// 4.專科
    /// 5.高中高職
    /// 6.其他
    /// 對應 E-CARD = EDUCATION
    /// </summary>
    public string Education { get; set; }

    /// <summary>
    /// 戶籍電話，對應 E-CARD = REG_TEL_NO
    /// </summary>
    public string HouseRegPhone { get; set; }

    /// <summary>
    /// 居住電話，對應 E-CARD = HOME_TEL_NO
    /// 
    /// 
    /// </summary>
    public string LivePhone { get; set; }

    /// <summary>
    /// 居住地所有權人
    /// 1.本人
    /// 2.配偶
    /// 3.父母親
    /// 4.親屬
    /// 5.宿舍
    /// 6.租貸
    /// 7.其他
    /// 對應 E-CARD = HOME_ADDR_COND
    /// </summary>
    public string LiveOwner { get; set; }

    /// <summary>
    /// 畢業國小，對應 E-CARD = PRIMARY_SCHOOL
    /// </summary>
    public string GraduatedElementarySchool { get; set; }

    /// <summary>
    /// 統一編號，對應 E-CARD = COMP_ID
    /// 8位數字
    /// </summary>
    public string CompId { get; set; }

    /// <summary>
    /// 職稱，對應 E-CARD = JOB_TITLE
    /// </summary>
    public string CompJobTitle { get; set; }

    /// <summary>
    /// 年資，對應 E-CARD = JOB_YEAR
    /// 檢驗為數字
    /// </summary>
    public string CompSeniority { get; set; }

    /// <summary>
    /// 安麗直銷商編號，對應 E-CARD = AL_NO
    /// </summary>
    public string AnliNo { get; set; }

    /// <summary>
    /// 附件檔名1，
    /// 空值，上述申請書檔名對應到後，ApplyFile.idPic1二進位資料即為附件1檔案。
    /// 
    /// 
    /// </summary>
    public string AppendixFileName01 { get; set; }

    /// <summary>
    /// 附件檔名2，
    /// 空值，上述申請書檔名對應到後，ApplyFile.idPic2二進位資料即為附件2檔案。
    /// 
    /// 
    /// </summary>
    public string AppendixFileName02 { get; set; }

    /// <summary>
    /// 附件檔名3，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload1二進位資料即為附件3檔案。
    /// 
    /// 
    /// </summary>
    public string AppendixFileName03 { get; set; }

    /// <summary>
    /// 附件檔名4，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload2二進位資料即為附件4檔案。
    /// 
    /// 
    /// </summary>
    public string AppendixFileName04 { get; set; }

    /// <summary>
    /// 附件檔名5，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload3二進位資料即為附件5檔案。
    /// </summary>
    public string AppendixFileName05 { get; set; }

    /// <summary>
    /// 附件檔名6，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload4二進位資料即為附件6檔案。
    /// </summary>
    public string AppendixFileName06 { get; set; }

    /// <summary>
    /// 附件檔名7，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload5二進位資料即為附件7檔案。
    /// </summary>
    public string AppendixFileName07 { get; set; }

    /// <summary>
    /// 附件檔名8，
    /// 空值，上述申請書檔名對應到後，ApplyFile.upload6二進位資料即為附件8檔案。
    /// </summary>
    public string AppendixFileName08 { get; set; }
}