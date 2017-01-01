using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Config
{
    public static class Database
    {
        public static string DataSource = "DESKTOP-23E4P5O";
        public static string InitialCatalog = "irrigation_dispatching";
        public static string PersistSecurityInfo = "True";
        public static string UserId = "irrigation_dispatching";
        public static string Pwd = "Irrigationdispatching";

        public static List<Dictionary<string, object>> TableList = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>() { { "tableName", "account" }, { "attribute", "账户" }, { "needNotAdmin", false } },
            new Dictionary<string, object>() { { "tableName", "admin_dept" }, { "attribute", "行政单位" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "crop" }, { "attribute", "农作物" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "crop_round_order" }, { "attribute", "农作物所属灌溉轮次" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "dry_earth" }, { "attribute", "干地" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "inflow_history" }, { "attribute", "来水历史" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "inflow_prediction" }, { "attribute", "每旬来水预测" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "irrigation_area" }, { "attribute", "灌溉面积" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "irrigation_institution" }, { "attribute", "灌溉制度" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "irrigation_method" }, { "attribute", "灌溉方法" }, { "needNotAdmin", true } },
            new Dictionary<string, object>() { { "tableName", "round_order_info" }, { "attribute", "灌溉轮次信息" }, { "needNotAdmin", true } }
        };

        public const string TableAccount = "account";
        public const string TableAdminDept = "admin_dept";
        public const string TableCrop = "crop";
        public const string TableCropRoundOrder = "crop_round_order";
        public const string TableDryEarth = "dry_earth";
        public const string TableInflowHistory = "inflow_history";
        public const string TableInflowPrediction = "inflow_prediction";
        public const string TableIrrigationArea = "irrigation_area";
        public const string TableIrrigationInstitution = "irrigation_institution";
        public const string TableIrrigationMethod = "irrigation_method";
        public const string TableRoundOrderInfo = "round_order_info";

        public static string ItemAccountAccountId = "account_id";
        public static string ItemAccountAccountName = "account_name";
        public static string ItemAccountPasswd = "passwd";
        public static string ItemAccountRegisterTime = "register_time";
        public static string ItemAccountPrivilege = "privilege";
        public static string ItemAccountAvailable = "available";

        public static string ItemAdminDeptDeptId = "dept_id";
        public static string ItemAdminDeptDeptName = "dept_name";
        public static string ItemAdminDeptFatherId = "father_id";
        public static string ItemAdminDeptAvailable = "available";

        public static string ItemCropCropId = "crop_id";
        public static string ItemCropCropName = "crop_name";
        public static string ItemCropCropType = "crop_type";
        public static string ItemCropAvailable = "available";

        public static string ItemCropRoundOrderRoundOrder = "round_order";
        public static string ItemCropRoundOrderCropId = "crop_id";
        public static string ItemCropRoundOrderAvailable = "available";

        public static string ItemDryEarthRoundOrder = "round_order";
        public static string ItemDryEarthArea = "area";
        public static string ItemDryEarthAvailable = "available";

        public static string ItemInflowHistoryYear = "year";
        public static string ItemInflowHistoryAverageFlow = "average_inflow";
        public static string ItemInflowHistoryAvailable = "available";

        public static string ItemInflowPredictionPeriodOrder = "period_order";
        public static string ItemInflowPredictionAverageFlow = "average_flow";

        public static string ItemIrrigationAreaDeptId = "dept_id";
        public static string ItemIrrigationAreaCropId = "crop_id";
        public static string ItemIrrigationAreaArea = "area";
        public static string ItemIrrigationAreaAvailable = "available";

        public static string ItemIrrigationInstitutionInstitutionId = "institution_id";
        public static string ItemIrrigationInstitutionCropId = "crop_id";
        public static string ItemIrrigationInstitutionIrrigationNumber = "irrigation_number";
        public static string ItemIrrigationInstitutionRoundOrder = "round_order";
        public static string ItemIrrigationInstitutionQuata = "quata";
        public static string ItemIrrigationInstitutionStage = "stage";
        public static string ItemIrrigationInstitutionAvailable = "available";

        public static string ItemIrrigationMethodMethodId = "method_id";
        public static string ItemIrrigationMethodCropId = "crop_id";
        public static string ItemIrrigationMethodMethod = "method";
        public static string ItemIrrigationMethodDesignedOutputMin = "designed_output_min";
        public static string ItemIrrigationMethodDesignedOUtputMax = "designed_output_max";
        public static string ItemIrrigationMethodAvailable = "available";

        public static string ItemRoundOrderInfoRoundOrder = "round_order";
        public static string ItemRoundOrderInfoSeason = "season";
        public static string ItemRoundOrderInfoStartTime = "start_time";
        public static string ItemRoundOrderInfoEndTime = "end_time";
        public static string ItemRoundOrderInfoQouta = "qouta";
        public static string ItemRoundOrderInfoAvailable = "available";

        public static int AvailableTrue = 1;
        public static int AvailableFalse = 0;

        public static int AccountPrivilegeAdmin = 0;
        public static int AccountPrivilegeUser = 1;
        public static int InflowExpandTimes = 100;
    }
}
