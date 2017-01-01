using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Service;

namespace irrigation_dispatching.Controller
{
    public class HydroController : Controller
    {
        private HydroService hydroService;

        public HydroController(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
            hydroService = new HydroService(ref databaseDriver);
        }

        public Dictionary<int, Dictionary<string, object>> GetDeptCropArea()
        {
            return hydroService.GetDeptCropArea();
        }

        public Dictionary<int, Dictionary<string, object>> GetDryEarth()
        {
            return hydroService.GetDryEarth();
        }

        public Dictionary<int, Dictionary<string, object>> GetIrrigationInstitution()
        {
            return hydroService.GetIrrigationInstitution();
        }

        public Dictionary<int, Dictionary<string, object>> GetRoundOrderInfo()
        {
            return hydroService.GetRoundOrderInfo();
        }

        public Dictionary<int, Dictionary<string, object>> GetInflowPrediction()
        {
            return hydroService.GetInflowPrediction();
        }

        public Dictionary<int, Dictionary<string, object>> GetAccount()
        {
            return hydroService.GetAccount();
        }

        public Dictionary<int, Dictionary<string, object>> GetAdminDept()
        {
            return hydroService.GetAdminDept();
        }

        public Dictionary<int, Dictionary<string, object>> GetCrop()
        {
            return hydroService.GetCrop();
        }

        public Dictionary<int, Dictionary<string, object>> GetTableDataByTableName(string tableName)
        {
            return hydroService.GetTableDataByTableName(tableName);
        }
    }
}
