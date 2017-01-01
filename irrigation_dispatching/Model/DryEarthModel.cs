using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class DryEarthModel : Model
    {

        public DryEarthModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
        }

        public override void SetTable()
        {
            tableName = Database.TableDryEarth;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemDryEarthRoundOrder.ToString() +
                ", " + Database.ItemDryEarthArea.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemDryEarthAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> dryEarthInfo = databaseDriver.Get();
            return dryEarthInfo;
        }
    }
}
