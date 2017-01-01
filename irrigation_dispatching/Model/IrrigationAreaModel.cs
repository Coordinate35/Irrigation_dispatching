using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class IrrigationAreaModel : Model
    {

        public IrrigationAreaModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableIrrigationArea;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemIrrigationAreaDeptId.ToString() +
                ", " + Database.ItemIrrigationAreaCropId.ToString() +
                ", " + Database.ItemIrrigationAreaArea.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemIrrigationAreaAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> irrigationAreaInfo = databaseDriver.Get();
            return irrigationAreaInfo;
        }
    }
}
