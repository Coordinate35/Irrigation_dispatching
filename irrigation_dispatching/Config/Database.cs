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

        public static string TableAccount = "account";
        public static string TableAdminDept = "admin_dept";
        public static string TableCrop = "crop";
        public static string TableCropRoundOrder = "crop_round_order";
        public static string TableDryEarth = "dry_earth";
        public static string TableInflowHistory = "inflow_history";
        public static string TableInflowPrediction = "inflow_prediction";
        public static string TableIrrigationArea = "irrigation_area";
        public static string TableIrrigationInstitution = "irrigation_institution";
        public static string TableIrrigationMethod = "irrigation_method";
        public static string TableRoundOrderInfo = "round_order_info";

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
