using Bogus;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ScoreSharpTestData.Entity;
using ScoreSharpTestData.Models;
using System.Reflection;
using static Bogus.DataSets.Name;

namespace ScoreSharpTestData.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestDataController : Controller
    {

        private readonly ScoreSharpContext _context;
        public TestDataController(ScoreSharpContext scoreSharpContext)
        {
            _context = scoreSharpContext;
        }

        [HttpGet]
        public EcardNewCaseRequest GenerateTestData()
        {

            var 身分證換發地點多筆代碼 = _context.SetUpIdcardRenewalLocations.ToList().Where(x => x.IsActive == "Y").Select(x => x.IdcardRenewalLocationName);
            var AML職級別多筆代碼 = _context.SetUpAmljobLevels.ToList().Where(x => x.IsActive == "Y").Select(s => s.AmljobLevelCode);
            var AML職業別多筆代碼 = _context.SetUpAmlprofessions.ToList().Where(x => x.IsActive == "Y").Select(s => s.AmlprofessionCode);
            var 主要所得及資金來源多筆代碼 = _context.SetUpMainIncomeAndFunds.ToList().Where(x => x.IsActive == "Y").Select(s => s.MainIncomeAndFundCode);
            var 地址 = _context.SetUpAddressInfos.ToList();
            var 多筆縣市 = 地址.Select(i => i.City).Distinct();
            var 縣市_區域 = 地址
                            .GroupBy(x => x.City)
                            .Select(i => new
                            {
                                City = i.Key,
                                Areas = i.ToList().Select(a => a.Area).Distinct()
                            })
                            .ToDictionary(t => t.City, t => t.Areas);


            var 縣市_區域_街道 = 地址
                                .GroupBy(i => new { City = i.City, Area = i.Area })
                                .Select(i => new
                                {
                                    City = i.Key.City,
                                    Area = i.Key.Area,
                                    Roads = i.ToList().Select(a => a.Road).Distinct()
                                }).ToDictionary(t => t.City + t.Area, t => t.Roads);




            var 非卡友假資料 = new Faker<EcardNewCaseRequest>("zh_TW")

                // 卡片資訊
                .RuleFor(o => o.CREDIT_ID, f => "") // 徵信代碼為空為非卡友     
                .RuleFor(o => o.ID_TYPE, f => f.PickRandom(new[] { "存戶", "" }))
                .RuleFor(o => o.APPLY_NO, (f, s) => 產生申請書編號(f, s.ID_TYPE))
                .RuleFor(o => o.CARD_OWNER, f => "1") // 網路進件只有 1. 正卡  
                .RuleFor(o => o.MCARD_SER, (f, s) => s.ID_TYPE == "存戶" ? "JS59" : "JST59")
                .RuleFor(o => o.FORM_ID, (f, s) => 取得表單代碼(s.ID_TYPE))

                // 正卡人資訊
                .RuleFor(o => o.SEX, f => f.PickRandom(new[] { "1", "2" })) // 1.男 2.女 
                .RuleFor(o => o.CH_NAME, (f, s) => 給予性別產生中文姓名(f, s.SEX))
                .RuleFor(o => o.BIRTHDAY, f => 產生民國生日(f))
                .RuleFor(o => o.ENG_NAME, (f, s) => 給予性別產生英文姓名(s.SEX))
                .RuleFor(o => o.BIRTH_PLACE, f => f.PickRandom(多筆縣市)) // 這邊目前很怪，徵審系統明明出生地設定就是 1. 中華民國 2.其他 ，但ECARD過來的是縣市地區  
                .RuleFor(o => o.BIRTH_PLACE_OTHER, f => "") // 目前不確定值有哪些 
                .RuleFor(o => o.NATIONALITY, f => f.PickRandom(new[] { "TW" })) // 讀取國籍設定，目前先寫死台灣 
                .RuleFor(o => o.P_ID, (f, s) => 給予性別產生身分證字號(f, s.SEX))
                .RuleFor(o => o.P_ID_GETDATE, (f, s) => 產生身分證發證日(s.BIRTHDAY))
                .RuleFor(o => o.P_ID_GETADDRNAME, f => f.PickRandom(身分證換發地點多筆代碼)) // 讀取身分證領證地點 
                .RuleFor(o => o.P_ID_STATUS, f => f.PickRandom(new[] { "1", "2", "3" })) // 1. 初發、2. 補發、3. 換發 

                // 戶籍地址 
                .RuleFor(o => o.REG_ZIP, (f, s) => f.Address.ZipCode())
                .RuleFor(o => o.REG_ADDR_CITY, f => f.PickRandom(多筆縣市))
                .RuleFor(o => o.REG_ADDR_DIST, (f, s) => f.PickRandom(縣市_區域[s.REG_ADDR_CITY]))
                .RuleFor(o => o.REG_ADDR_RD, (f, s) => f.PickRandom(縣市_區域_街道[s.REG_ADDR_CITY + s.REG_ADDR_DIST]))
                .RuleFor(o => o.REG_ADDR_LN, (f, s) => f.Address.BuildingNumber())
                .RuleFor(o => o.REG_ADDR_ALY, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.REG_ADDR_NO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.REG_ADDR_SUBNO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.REG_ADDR_F, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.REG_ADDR_OTHER, (f, s) => "")

                // 住家地址 
                .RuleFor(o => o.HOME_ZIP, (f, s) => f.Address.ZipCode())
                .RuleFor(o => o.HOME_ADDR_CITY, f => f.PickRandom(多筆縣市))
                .RuleFor(o => o.HOME_ADDR_DIST, (f, s) => f.PickRandom(縣市_區域[s.REG_ADDR_CITY]))
                .RuleFor(o => o.HOME_ADDR_RD, (f, s) => f.PickRandom(縣市_區域_街道[s.REG_ADDR_CITY + s.REG_ADDR_DIST]))
                .RuleFor(o => o.HOME_ADDR_LN, (f, s) => f.Address.BuildingNumber())
                .RuleFor(o => o.HOME_ADDR_ALY, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.HOME_ADDR_NO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.HOME_ADDR_SUBNO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.HOME_ADDR_F, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.HOME_ADDR_OTHER, (f, s) => "")

                .RuleFor(o => o.BILL_TO_ADDR, f => f.PickRandom(new[] { "1", "2", "3" })) //１同戶籍２同居住３同公司 
                .RuleFor(o => o.CARD_TO_ADDR, f => f.PickRandom(new[] { "1", "2", "3" })) // １同戶籍２同居住３同公司 

                .RuleFor(o => o.CELL_PHONE_NO, f => f.Phone.PhoneNumber("09########"))
                .RuleFor(o => o.EMAIL, f => f.Internet.Email())
                .RuleFor(o => o.JOB_TYPE, f => f.PickRandom(AML職業別多筆代碼)) // 讀取AML職業類別設定 
                .RuleFor(o => o.JOB_TYPE_OTHER, f => "") // TODO 其他的話這邊要隨便填 
                .RuleFor(o => o.JOB_LV, f => f.PickRandom(AML職級別多筆代碼)) // 讀取AML職級別設定 

                .RuleFor(o => o.COMP_NAME, f => "聯邦測試公司")
                .RuleFor(o => o.COMP_TEL_NO, f => f.Phone.PhoneNumber("02-########"))
                .RuleFor(o => o.COMP_ID, (f, s) => !String.IsNullOrEmpty(s.COMP_NAME) ? f.Random.String2(8, "0123456789") : "")
                .RuleFor(o => o.JOB_TITLE, f => f.Name.JobTitle())
                .RuleFor(o => o.JOB_YEAR, (f, s) => isAldult(CalculateAgeFromMinguo(s.BIRTHDAY)) ? f.Random.Number(0, 40).ToString() : f.Random.Number(0, 4).ToString())

                // 公司地址 
                .RuleFor(o => o.COMP_ZIP, f => f.Address.ZipCode())
                .RuleFor(o => o.COMP_ADDR_CITY, f => f.PickRandom(多筆縣市))
                .RuleFor(o => o.COMP_ADDR_DIST, (f, s) => f.PickRandom(縣市_區域[s.REG_ADDR_CITY]))
                .RuleFor(o => o.COMP_ADDR_RD, (f, s) => f.PickRandom(縣市_區域_街道[s.REG_ADDR_CITY + s.REG_ADDR_DIST]))
                .RuleFor(o => o.COMP_ADDR_LN, (f, s) => f.Address.BuildingNumber())
                .RuleFor(o => o.COMP_ADDR_ALY, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.COMP_ADDR_NO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.COMP_ADDR_SUBNO, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.COMP_ADDR_F, (f, s) => f.Random.String2(2, "123456789"))
                .RuleFor(o => o.COMP_ADDR_OTHER, (f, s) => "")

                .RuleFor(o => o.SALARY, f => Convert.ToInt32(f.Finance.Amount(30000, 100000, 0)).ToString())
                .RuleFor(o => o.MAIN_INCOME, f => String.Join(",", f.PickRandom(主要所得及資金來源多筆代碼, 2))) // 讀取主要所得及資金來源設定 
                .RuleFor(o => o.MAIN_INCOME_OTHER, f => "") // TODO 選取其他這個值要填寫 
                .RuleFor(o => o.ACCEPT_DM_FLG, f => f.PickRandom(new[] { "0", "1" })) // 0. 否 1.是 
                .RuleFor(o => o.M_PROJECT_CODE_ID, (f, s) => 產生專案代號(s.ID_TYPE))
                .RuleFor(o => o.PROM_UNIT_SER, f => "911T")
                .RuleFor(o => o.PROM_USER_NAME, f => "1001234")
                .RuleFor(o => o.AGREE_MARKETING_FLG, f => "1")
                .RuleFor(o => o.NOT_ACCEPT_EPAPAER_FLG, f => "1")
                .RuleFor(o => o.FAMILY6_AGE, f => "11") // 首刷禮代碼? 
                .RuleFor(o => o.CHG_CARD_ADDR, f => "")
                .RuleFor(o => o.BILL_TYPE, f => f.PickRandom(new[] { "1", "2", "3", "4" })) // 1. 電子帳單、2. 簡訊帳單、3. 紙本帳單、4. LINE帳單 
                .RuleFor(o => o.AUTO_FLG, f => "")
                .RuleFor(o => o.ACCT_NO, f => "")
                .RuleFor(o => o.PAY_WAY, f => "")
                .RuleFor(o => o.SOURCE_TYPE, f => f.PickRandom(new[] { "ECARD" }))
                .RuleFor(o => o.SOURCE_IP, f => f.Internet.IpAddress().ToString())
                .RuleFor(o => o.OTP_MOBILE_PHONE, f => f.Phone.PhoneNumber("09########"))
                .RuleFor(o => o.OTP_TIME, f => f.Date.Recent().ToString("yyyy/MM/dd HH:mm:ss"))
                .RuleFor(o => o.DIGI_CARD_FLG, f => f.PickRandom(new[] { "Y", "N" }))
                .RuleFor(o => o.CARD_KIND, f => f.PickRandom(new[] { "1", "2", "3" })) //  1.實體 2.數位 3.實體 + 數位 
                .RuleFor(o => o.APPLICATION_FILE_NAME, f => f.System.FileName())
                .RuleFor(o => o.APPENDIX_FLG, f => "") // f.PickRandom(new[] { "", "1", "2" } 
                .RuleFor(o => o.MYDATA_NO, (f, s) => s.APPENDIX_FLG == "2" ? f.Random.String2(10, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789") : "")
                .RuleFor(o => o.CARD_ADDR, (f, s) =>
                {
                    var random = new Random();
                    var randomAddress = 地址.OrderBy(i => random.Next()).First();
                    return 格式化完整地址(randomAddress.City, randomAddress.Area, randomAddress.Road, "7", "7", "7", "7", "7");
                })
                .RuleFor(o => o.KYC_CHG_FLG, (f, s) => s.ID_TYPE == "卡友" ? f.PickRandom(new[] { "Y", "N" }) : "")
                .RuleFor(o => o.CONSUM_NOTICE_FLG, f => "Y")
                .RuleFor(o => o.UUID, f => f.Random.Uuid().ToString())
                .RuleFor(o => o.DEMAND_CURR_BAL, f => Convert.ToInt32(f.Finance.Amount(10000, 1000000, 0)).ToString())
                .RuleFor(o => o.TIME_CURR_BAL, f => Convert.ToInt32(f.Finance.Amount(10000, 1000000, 0)).ToString())
                .RuleFor(o => o.DEMAND_90DAY_BAL, f => Convert.ToInt32(f.Finance.Amount(10000, 1000000, 0)).ToString())
                .RuleFor(o => o.TIME_90DAY_BAL, f => Convert.ToInt32(f.Finance.Amount(10000, 1000000, 0)).ToString())
                .RuleFor(o => o.BAL_UPD_DATE, f => f.Date.Past().ToString("yyyy/MM/dd HH:mm:ss"))

                // 是否為學生身份 
                // .RuleFor(o => o.STUDENT_FLG, (f, s) => isAldult(CalculateAgeFromMinguo(s.BIRTHDAY)) ? "N" : "Y") 
                .RuleFor(o => o.STUDENT_FLG, (f, s) => "N")
                .RuleFor(o => o.PARENT_NAME, (f, s) => s.STUDENT_FLG == "Y" ? f.Name.FullName() : "")
                .RuleFor(o => o.PARENT_HOME_TEL_NO, (f, s) => s.STUDENT_FLG == "Y" ? f.Phone.PhoneNumber("########") : "")
                .RuleFor(o => o.PARENT_HOME_ZIP, (f, s) => s.STUDENT_FLG == "Y" ? f.Address.ZipCode() : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_CITY, (f, s) => s.STUDENT_FLG == "Y" ? f.PickRandom(多筆縣市) : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_DIST, (f, s) => s.STUDENT_FLG == "Y" ? f.PickRandom(縣市_區域[s.REG_ADDR_CITY]) : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_RD, (f, s) => s.STUDENT_FLG == "Y" ? f.PickRandom(縣市_區域_街道[s.REG_ADDR_CITY + s.REG_ADDR_DIST]) : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_LN, (f, s) => s.STUDENT_FLG == "Y" ? f.Address.BuildingNumber() : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_ALY, (f, s) => s.STUDENT_FLG == "Y" ? f.Address.StreetSuffix() : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_NO, (f, s) => s.STUDENT_FLG == "Y" ? f.Random.String2(2, "123456789") : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_SUBNO, (f, s) => s.STUDENT_FLG == "Y" ? f.Random.String2(2, "123456789") : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_F, (f, s) => s.STUDENT_FLG == "Y" ? f.Random.String2(2, "123456789") : "")
                .RuleFor(o => o.PARENT_HOME_ADDR_OTHER, (f) => "")

                .RuleFor(o => o.EDUCATION, (f, s) => CalculateAgeFromMinguo(s.BIRTHDAY) > 22 ? f.PickRandom(new[] { "1", "2", "3", "4", "5", "6" }) : "5") // 1：博士、2：碩士、3：大學、4：專科、5：高中高職、6：其他 
                .RuleFor(o => o.REG_TEL_NO, f => f.Phone.PhoneNumber("########"))
                .RuleFor(o => o.HOME_TEL_NO, f => f.Phone.PhoneNumber("########"))
                .RuleFor(o => o.HOME_ADDR_COND, f => f.PickRandom(new[] { "1", "2", "3", "4", "5", "6", "7" })) // 1：本人、2：配偶、3：父母親、4：親屬、5：宿舍、6：租貸、7：其他 
                .RuleFor(o => o.PRIMARY_SCHOOL, f => "聯邦國小")
                .RuleFor(o => o.AL_NO, f => "")

                .RuleFor(o => o.APPENDIX_FILE_NAME_01, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_02, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_03, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_04, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_05, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_06, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_07, f => "")
                .RuleFor(o => o.APPENDIX_FILE_NAME_08, f => "");

            var 非卡友fakerInfo = 非卡友假資料.Generate();

            JsonConvert.SerializeObject(非卡友fakerInfo);


            return 非卡友fakerInfo;
        }

        string 產生民國生日(Faker faker)
        {
            var date = faker.Date.Past(50, DateTime.Now.AddYears(-18));
            var taiwanYear = date.Year - 1911;
            var taiwanDate = $"{taiwanYear:D3}{date:MMdd}";
            return taiwanDate;
        }

        string 產生身分證發證日(string birthday, int addYear = 18)
        {
            // 取得民國年 
            int taiwanYear = int.Parse(birthday.Substring(0, 3));
            // 取得月份 
            int month = int.Parse(birthday.Substring(3, 2));
            // 取得日 
            int day = int.Parse(birthday.Substring(5, 2));
            // 將民國年轉換為西元年 
            int gregorianYear = taiwanYear + 1911;
            // 加上18年 
            int newGregorianYear = gregorianYear + addYear;
            // 將新西元年轉回民國年 
            int newTaiwanYear = newGregorianYear - 1911;
            // 格式化回民國日期格式 
            string taiwanDate = newTaiwanYear.ToString("000") + month.ToString("00") + day.ToString("00");
            return taiwanDate;
        }

        string 產生申請書編號(Faker faker, string id_type)
        {
            var datePart = DateTime.Now.ToString("yyyyMMdd");
            var fixedChar = (id_type == "存戶" || id_type == "卡友") ? "B" : "X";
            var serialNumber = faker.Random.Int(1, 9999).ToString("D4");
            return $"{datePart}{fixedChar}{serialNumber}";
        }

        string 取得表單代碼(string id_type) => id_type switch
        {
            "" => "AP00A169",
            "卡友" => "AP00A170",
            "存戶" => "AP00A171",
            _ => throw new ArgumentException($"取得表單代碼 type 錯誤:{id_type}")
        };

        string 給予性別產生中文姓名(Faker faker, string sex) => faker.Name.LastName(sex == "1" ? Gender.Male : Gender.Female) + faker.Name.FirstName(sex == "1" ? Gender.Male : Gender.Female);
        string 給予性別產生英文姓名(string sex)
        {
            var englishFaker = new Faker("en");
            return englishFaker.Name.LastName(sex == "1" ? Gender.Male : Gender.Female) + englishFaker.Name.FirstName(sex == "1" ? Gender.Male : Gender.Female);
        }

        string 給予性別產生身分證字號(Faker faker, string sex)
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(c => c.ToString()).ToArray();
            var firstLetter = faker.PickRandom(letters); // 隨機選擇一個英文字母 
            var digits = faker.Random.ReplaceNumbers("########"); // 生成八位隨機數字 
            var secondDigit = sex; // 第二個數字只能是1或2（1代表男性，2代表女性）
            return firstLetter + secondDigit + digits; // 組合成台灣身份證字號 
        }


        string 格式化完整地址(
            string city,
            string district,
            string road,
            string alley,
            string lane,
            string number,
            string subNumber,
            string floor)
        => $"{city}{district}{road}{alley}弄{lane}號之{subNumber}號{floor}樓";

        string 產生專案代號(string id_type) => id_type switch
        {
            "卡友" => "OTN",
            "存戶" => "ETU",
            "" => "ENP",
        };

        bool isAldult(int age) => (age > 22);

        int CalculateAgeFromMinguo(string minguoDate)
        {
            // 確認日期格式為7位數 (民國年MMDD) 
            if (minguoDate.Length != 7)
            {
                throw new ArgumentException("日期格式不正確，應該是7位數格式 (民國年MMDD)。");
            }

            // 解析民國年 
            int minguoYear = int.Parse(minguoDate.Substring(0, 3));
            int month = int.Parse(minguoDate.Substring(3, 2));
            int day = int.Parse(minguoDate.Substring(5, 2));

            // 將民國年轉為西元年 
            int year = minguoYear + 1911;

            // 創建西元日期 
            DateTime birthDate = new DateTime(year, month, day);
            DateTime today = DateTime.Today;

            // 計算年齡 
            int age = today.Year - birthDate.Year;

            // 如果還沒有過今年的生日，年齡 -1 
            if (today < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// 產生卡友假資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public EcardNewCaseRequest GenerateTestDataForA02()
        {
            var 身分證換發地點多筆代碼 = _context.SetUpIdcardRenewalLocations.ToList().Where(x => x.IsActive == "Y").Select(x => x.IdcardRenewalLocationName);
            var AML職級別多筆代碼 = _context.SetUpAmljobLevels.ToList().Where(x => x.IsActive == "Y").Select(s => s.AmljobLevelCode);
            var AML職業別多筆代碼 = _context.SetUpAmlprofessions.ToList().Where(x => x.IsActive == "Y").Select(s => s.AmlprofessionCode);
            var 主要所得及資金來源多筆代碼 = _context.SetUpMainIncomeAndFunds.ToList().Where(x => x.IsActive == "Y").Select(s => s.MainIncomeAndFundCode);
            var 地址 = _context.SetUpAddressInfos.ToList();
            var 多筆縣市 = 地址.Select(i => i.City).Distinct();
            var 縣市_區域 = 地址
                            .GroupBy(x => x.City)
                            .Select(i => new
                            {
                                City = i.Key,
                                Areas = i.ToList().Select(a => a.Area).Distinct()
                            })
                            .ToDictionary(t => t.City, t => t.Areas);


            var 縣市_區域_街道 = 地址
                                .GroupBy(i => new { City = i.City, Area = i.Area })
                                .Select(i => new
                                {
                                    City = i.Key.City,
                                    Area = i.Key.Area,
                                    Roads = i.ToList().Select(a => a.Road).Distinct()
                                }).ToDictionary(t => t.City + t.Area, t => t.Roads);

            var 卡友假資料 = new Faker<EcardNewCaseRequest>("zh_TW")
                .CustomInstantiator(f => new EcardNewCaseRequest());

            foreach (var property in typeof(EcardNewCaseRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string)))
            {
                卡友假資料.RuleFor(property.Name, f => ""); // 初始化為空字符串
            }

            卡友假資料
           .RuleFor(o => o.CREDIT_ID, f => "A02") // 徵信代碼為A02為卡友     
           .RuleFor(o => o.ID_TYPE, f => "卡友")
           .RuleFor(o => o.APPLY_NO, (f, s) => 產生申請書編號(f, s.ID_TYPE))
           .RuleFor(o => o.CARD_OWNER, f => "1") // 網路進件只有 1. 正卡  
           .RuleFor(o => o.MCARD_SER, (f, s) => s.ID_TYPE == "存戶" ? "JS59" : "JST59")
           .RuleFor(o => o.FORM_ID, (f, s) => 取得表單代碼(s.ID_TYPE))

           .RuleFor(o => o.SEX, f => f.PickRandom(new[] { "1", "2" })) // 1.男 2.女 
           .RuleFor(o => o.CH_NAME, (f, s) => 給予性別產生中文姓名(f, s.SEX))
           .RuleFor(o => o.BIRTHDAY, f => 產生民國生日(f))
           .RuleFor(o => o.ENG_NAME, (f, s) => 給予性別產生英文姓名(s.SEX))
           .RuleFor(o => o.BIRTH_PLACE, f => f.PickRandom(多筆縣市)) // 這邊目前很怪，徵審系統明明出生地設定就是 1. 中華民國 2.其他 ，但ECARD過來的是縣市地區  
           .RuleFor(o => o.BIRTH_PLACE_OTHER, f => "") // 目前不確定值有哪些 
           .RuleFor(o => o.NATIONALITY, f => f.PickRandom(new[] { "TW" }))
           .RuleFor(o => o.P_ID, (f, s) => 給予性別產生身分證字號(f, s.SEX))

           .RuleFor(o => o.REG_ZIP, (f, s) => f.Address.ZipCode())
           .RuleFor(o => o.REG_ADDR_OTHER, (f, s) =>
           {
               var random = new Random();
               var randomAddress = 地址.OrderBy(i => random.Next()).First();
               return 格式化完整地址(randomAddress.City, randomAddress.Area, randomAddress.Road, "7", "7", "7", "7", "7");
           })
           .RuleFor(o => o.CELL_PHONE_NO, f => f.Phone.PhoneNumber("09########"))
           .RuleFor(o => o.EMAIL, f => f.Internet.Email())
           .RuleFor(o => o.JOB_TYPE, f => f.PickRandom(AML職業別多筆代碼)) // 讀取AML職業類別設定 
           .RuleFor(o => o.JOB_TYPE_OTHER, f => "") // TODO 其他的話這邊要隨便填 
           .RuleFor(o => o.JOB_LV, f => f.PickRandom(AML職級別多筆代碼)) // 讀取AML職級別設定 

           .RuleFor(o => o.MAIN_INCOME, f => String.Join(",", f.PickRandom(主要所得及資金來源多筆代碼, 2))) // 讀取主要所得及資金來源設定 
           .RuleFor(o => o.MAIN_INCOME_OTHER, f => "") // TODO 選取其他這個值要填寫 
           .RuleFor(o => o.ACCEPT_DM_FLG, f => f.PickRandom(new[] { "0", "1" })) // 0. 否 1.是 
           .RuleFor(o => o.M_PROJECT_CODE_ID, (f, s) => 產生專案代號(s.ID_TYPE))
           .RuleFor(o => o.PROM_UNIT_SER, f => "911T")
           .RuleFor(o => o.PROM_USER_NAME, f => "1001234")
           .RuleFor(o => o.AGREE_MARKETING_FLG, f => "1")
           .RuleFor(o => o.NOT_ACCEPT_EPAPAER_FLG, f => "1")
           .RuleFor(o => o.BILL_TYPE, f => f.PickRandom(new[] { "1", "2", "3", "4" }))
           .RuleFor(o => o.SOURCE_TYPE, f => f.PickRandom(new[] { "ECARD" }))
           .RuleFor(o => o.SOURCE_IP, f => f.Internet.IpAddress().ToString())
           .RuleFor(o => o.OTP_MOBILE_PHONE, f => f.Phone.PhoneNumber("09########"))
           .RuleFor(o => o.OTP_TIME, f => f.Date.Recent().ToString("yyyy/MM/dd HH:mm:ss"))
           .RuleFor(o => o.DIGI_CARD_FLG, f => f.PickRandom(new[] { "Y", "N" }))
           .RuleFor(o => o.CARD_KIND, f => f.PickRandom(new[] { "1", "2", "3" })) //  1.實體 2.數位 3.實體 + 數位 
           .RuleFor(o => o.APPLICATION_FILE_NAME, f => f.System.FileName())
           .RuleFor(o => o.CARD_ADDR, (f, s) =>
           {
               var random = new Random();
               var randomAddress = 地址.OrderBy(i => random.Next()).First();
               return 格式化完整地址(randomAddress.City, randomAddress.Area, randomAddress.Road, "7", "7", "7", "7", "7");
           })
           .RuleFor(o => o.KYC_CHG_FLG, (f, s) => s.ID_TYPE == "卡友" ? f.PickRandom(new[] { "Y", "N" }) : "")
           .RuleFor(o => o.CONSUM_NOTICE_FLG, f => "Y")
           .RuleFor(o => o.STUDENT_FLG, (f, s) => "N");

            var 卡友fakerInfo = 卡友假資料.Generate();


            JsonConvert.SerializeObject(卡友fakerInfo);

            return 卡友fakerInfo;
        }
    }
}
