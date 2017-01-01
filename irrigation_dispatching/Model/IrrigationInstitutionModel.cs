using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Config;
using irrigation_dispatching.Core;

namespace irrigation_dispatching.Model
{
    public class IrrigationInstitutionModel : Model
    {

        public IrrigationInstitutionModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {

        }

        public override void SetTable()
        {
            tableName = Database.TableIrrigationInstitution;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemIrrigationInstitutionInstitutionId.ToString() +
                ", " + Database.ItemIrrigationInstitutionRoundOrder.ToString() +
                ", " + Database.ItemIrrigationInstitutionCropId.ToString() +
                ", " + Database.ItemIrrigationInstitutionStage.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemIrrigationMethodAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> irrigationInstitutionInfo = databaseDriver.Get();
            return irrigationInstitutionInfo;
        }
    }
}
