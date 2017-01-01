using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model
{
    public class CropModel : Model
    {

        public CropModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
        }

        public override void SetTable()
        {
            tableName = Database.TableCrop;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemCropCropId.ToString() +
                ", " + Database.ItemCropCropName.ToString() +
                ", " + Database.ItemCropCropType.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemCropAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> cropInfo = databaseDriver.Get();
            return cropInfo;
        }
    }
}
