using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using irrigation_dispatching.Core;
using irrigation_dispatching.Config;

namespace irrigation_dispatching.Model
{
    public class AdminDeptModel : Model
    {

        public AdminDeptModel(ref DatabaseDriver databaseDriver) : base(ref databaseDriver)
        {
        }

        public override void SetTable()
        {
            tableName = Database.TableAdminDept;
        }

        public override Dictionary<int, Dictionary<string, object>> GetAllValidData()
        {
            string selectContent = Database.ItemAdminDeptDeptId.ToString() +
                ", " + Database.ItemAdminDeptDeptName.ToString() +
                ", " + Database.ItemAdminDeptFatherId.ToString();
            databaseDriver.SetSelect(selectContent);
            databaseDriver.SetFrom(tableName);
            databaseDriver.SetAndWhere(Database.ItemAdminDeptAvailable, Database.AvailableTrue);
            Dictionary<int, Dictionary<string, object>> deptInfo = databaseDriver.Get();
            return deptInfo;
        }
    }
}
