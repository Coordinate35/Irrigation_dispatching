using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class RoundOrderInfoModel : Model
    {

        public RoundOrderInfoModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableRoundOrderInfo;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemRoundOrderInfoRoundOrder.ToString() +
                ", " + Database.ItemRoundOrderInfoSeason.ToString() +
                ", " + Database.ItemRoundOrderInfoStartTime.ToString() +
                ", " + Database.ItemRoundOrderInfoEndTime.ToString() +
                ", " + Database.ItemRoundOrderInfoQouta.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemRoundOrderInfoAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> roundOrderInfo = databaseDriver.Get();
            return roundOrderInfo;
        }
    }
}
