using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class InflowPredictionModel : Model
    {

        public InflowPredictionModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver) 
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableInflowPrediction;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemInflowPredictionPeriodOrder.ToString() +
                ", " + Database.ItemInflowPredictionAverageFlow.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            Dictionary<int, Dictionary<string, object>> inflowPredictionData = databaseDriver.Get();
            return inflowPredictionData;
        }
    }
}
