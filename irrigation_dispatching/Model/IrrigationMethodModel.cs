using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class IrrigationMethodModel : Model
    {

        public IrrigationMethodModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableIrrigationMethod;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemIrrigationMethodMethodId.ToString() +
                ", " + Database.ItemIrrigationMethodMethod.ToString() +
                ", " + Database.ItemIrrigationMethodCropId.ToString() +
                ", " + Database.ItemIrrigationMethodDesignedOutputMin.ToString() +
                ", " + Database.ItemIrrigationMethodDesignedOUtputMax.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemIrrigationMethodAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> irrigationMethodInfo = databaseDriver.Get();
            return irrigationMethodInfo;
        }
    }
}
