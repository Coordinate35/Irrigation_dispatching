using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class InflowHistoryModel : Model
    {

        public InflowHistoryModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableInflowHistory;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemInflowHistoryYear.ToString() +
                ", " + Database.ItemInflowHistoryAverageFlow.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemInflowHistoryAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> inflowHistory = databaseDriver.Get();
            return inflowHistory;
        }
    }
}
