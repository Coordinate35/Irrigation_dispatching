using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Model;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Service
{
    public class HydroService : Service
    {

        private AccountModel accountModel;
        private AdminDeptModel adminDeptModel;
        private CropModel cropModel;
        private DryEarthModel dryEarthModel;
        private InflowPredictionModel inflowPredictionModel;
        private IrrigationAreaModel irrigationAreaModel;
        private IrrigationInstitutionModel irrigationInstitutionModel;
        private RoundOrderInfoModel roundOrderInfoModel;

        public List<Dictionary<string, int>> DeptCropArea
        {
            get;
            private set;
        }

        public List<int> DryEarth
        {
            get;
            private set;
        }

        public List<Dictionary<string, int>> IrrigationInstitution
        {
            get;
            private set;
        }

        public List<Dictionary<string, int>> RoundOrderInfo
        {
            get;
            private set;
        }

        public List<Dictionary<string, double>> InflowPrediction
        {
            get;
            private set;
        }

        public List<Dictionary<string, object>> Account
        {
            get;
            private set;
        }

        public List<Dictionary<string, object>> AdminDept
        {
            get;
            private set;
        }

        public List<Dictionary<string, object>> Crop
        {
            get;
            private set;
        }

        public HydroService(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
            accountModel = new AccountModel(ref databaseDriver);
            adminDeptModel = new AdminDeptModel(ref databaseDriver);
            cropModel = new CropModel(ref databaseDriver);
            dryEarthModel = new DryEarthModel(ref databaseDriver);
            irrigationAreaModel = new IrrigationAreaModel(ref databaseDriver);
            inflowPredictionModel = new InflowPredictionModel(ref databaseDriver);
            irrigationInstitutionModel = new IrrigationInstitutionModel(ref databaseDriver);
            roundOrderInfoModel = new RoundOrderInfoModel(ref databaseDriver);
        }

        public Dictionary<int, Dictionary<string, object>> GetDeptCropArea()
        {
            Dictionary<int, Dictionary<string, object>> irrigationArea = irrigationAreaModel.GetAllValidData();
            List<Dictionary<string, int>> deptCropArea = new List<Dictionary<string, int>>();
            for (int i = 0; i < irrigationArea.Count; i++)
            {
                Dictionary<string, int> deptCropAreaItem = new Dictionary<string, int>()
                {
                    { "dept_id", Convert.ToInt32(irrigationArea[i][Database.ItemIrrigationAreaDeptId]) },
                    { "crop_id", Convert.ToInt32(irrigationArea[i][Database.ItemIrrigationAreaCropId]) },
                    { "area", Convert.ToInt32(irrigationArea[i][Database.ItemIrrigationAreaArea]) }
                };
                deptCropArea.Insert(i, deptCropAreaItem);
            }
            DeptCropArea = deptCropArea;
            return irrigationArea;
        }

        public Dictionary<int, Dictionary<string, object>> GetDryEarth()
        {
            Dictionary<int, Dictionary<string, object>> dryEarthData = dryEarthModel.GetAllValidData();
            List<int> dryEarth = new List<int>();
            for (int i = 0; i < dryEarthData.Count; i++)
            {
                dryEarth.Insert(Convert.ToInt32(dryEarthData[i][Database.ItemDryEarthRoundOrder]), Convert.ToInt32(dryEarthData[i][Database.ItemDryEarthArea]));
            }
            DryEarth = dryEarth;
            return dryEarthData;
        }

        public Dictionary<int, Dictionary<string, object>> GetIrrigationInstitution()
        {
            Dictionary<int, Dictionary<string, object>> irrigationInstitutionData = irrigationInstitutionModel.GetAllValidData();
            List<Dictionary<string, int>> irrigationInstitution = new List<Dictionary<string, int>>();
            for (int i = 0; i < irrigationInstitutionData.Count; i++)
            {
                Dictionary<string, int> institutionItem = new Dictionary<string, int>()
                {
                    { "round_order", Convert.ToInt32(irrigationInstitutionData[i][Database.ItemIrrigationInstitutionRoundOrder]) },
                    { "crop_id",  Convert.ToInt32(irrigationInstitutionData[i][Database.ItemIrrigationInstitutionCropId]) }
                };
                irrigationInstitution.Insert(i, institutionItem);
            }
            IrrigationInstitution = irrigationInstitution;
            return irrigationInstitutionData;
        }

        public Dictionary<int, Dictionary<string, object>> GetRoundOrderInfo()
        {
            Dictionary<int, Dictionary<string, object>> roundOrderInfoData = roundOrderInfoModel.GetAllValidData();
            List<Dictionary<string, int>> roundOrderInfo = new List<Dictionary<string, int>>();
            for (int i = 0; i < roundOrderInfoData.Count; i++)
            {
                Dictionary<string, int> roundOrderInfoItem = new Dictionary<string, int>()
                {
                    { "start_time", Convert.ToInt32(roundOrderInfoData[i][Database.ItemRoundOrderInfoStartTime]) },
                    { "end_time", Convert.ToInt32(roundOrderInfoData[i][Database.ItemRoundOrderInfoEndTime]) },
                    { "qouta", Convert.ToInt32(roundOrderInfoData[i][Database.ItemRoundOrderInfoQouta]) }
                };
                roundOrderInfo.Insert(Convert.ToInt32(roundOrderInfoData[i][Database.ItemRoundOrderInfoRoundOrder]), roundOrderInfoItem);
            }
            RoundOrderInfo = roundOrderInfo;
            return roundOrderInfoData;
        }

        public Dictionary<int, Dictionary<string, object>> GetInflowPrediction()
        {
            Dictionary<int, Dictionary<string, object>> inflowPredictionData = inflowPredictionModel.GetAllValidData();
            List<Dictionary<string, double>> inflowPrediction = new List<Dictionary<string, double>>();
            for (int i = 0; i < inflowPredictionData.Count; i++)
            {
                Dictionary<string, double> inflowPredictionItem = new Dictionary<string, double>()
                {
                    {  "average_flow", (double)inflowPredictionData[i][Database.ItemInflowPredictionAverageFlow] / Database.InflowExpandTimes }
                };
                inflowPrediction.Insert(Convert.ToInt32(inflowPredictionData[i][Database.ItemInflowPredictionPeriodOrder]), inflowPredictionItem);
            }
            InflowPrediction = inflowPrediction;
            return inflowPredictionData;
        }

        public Dictionary<int, Dictionary<string, object>> GetAccount()
        {
            Dictionary<int, Dictionary<string, object>> accountData = accountModel.GetAllValidData();
            List<Dictionary<string, object>> account = new List<Dictionary<string, object>>();
            for (int i = 0; i < accountData.Count; i++)
            {
                account.Insert(i, accountData[i]);
            }
            Account = account;
            return accountData;
        }

        public Dictionary<int, Dictionary<string, object>> GetAdminDept()
        {
            Dictionary<int, Dictionary<string, object>> adminDeptData = adminDeptModel.GetAllValidData();
            List<Dictionary<string, object>> adminDept = new List<Dictionary<string, object>>();
            for (int i = 0; i < adminDeptData.Count; i++)
            {
                adminDept.Insert(i, adminDeptData[i]);
            }
            AdminDept = adminDept;
            return adminDeptData;
        }

        public Dictionary<int, Dictionary<string, object>> GetCrop()
        {
            Dictionary<int, Dictionary<string, object>> cropData = cropModel.GetAllValidData();
            List<Dictionary<string, object>> crop = new List<Dictionary<string, object>>();
            for (int i = 0; i < cropData.Count; i++)
            {
                crop.Insert(i, cropData[i]);
            }
            Crop = crop;
            return cropData;
        }

        public Dictionary<int, Dictionary<string, object>> GetTableDataByTableName(string tableName)
        {
            switch (tableName)
            {
                case Database.TableAccount:
                    return GetAccount();
                case Database.TableAdminDept:
                    return GetAdminDept();
                case Database.TableCrop:
                    return GetCrop();
                case Database.TableCropRoundOrder:
                    return GetRoundOrderInfo();
                case Database.TableDryEarth:
                    return GetDryEarth();
                case Database.TableInflowPrediction:
                    return GetInflowPrediction();
                case Database.TableIrrigationArea:
                    return GetDeptCropArea();
                case Database.TableIrrigationInstitution:
                    return GetIrrigationInstitution();
                default:
                    return null;
            }
        }

        public void GetHydroData()
        {
            this.GetAccount();
            this.GetAdminDept();
            this.GetCrop();
            this.GetDeptCropArea();
            this.GetDryEarth();
            this.GetInflowPrediction();
            this.GetIrrigationInstitution();
            this.GetRoundOrderInfo();
        }
    }
}
