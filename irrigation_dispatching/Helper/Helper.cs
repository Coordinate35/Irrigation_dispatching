using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Helper
{
    public static class Helper
    {
        public static int time()
        {
            DateTime timeStamp = new DateTime(1970, 1, 1);  //得到1970年的时间戳  
            long now = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000;
            return Convert.ToInt32(now);
        }
    }
}
