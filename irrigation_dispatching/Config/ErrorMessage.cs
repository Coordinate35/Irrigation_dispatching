using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irrigation_dispatching.Config
{
    public static class ErrorMessage
    {
        public static string NoSuchDatabaseDriver = "没找到指定的数据库驱动";
        public static string ConnectDatabaseError = "连接数据库失败";
        public static string SetAdminFailed = "设置管理员账号失败";
        public static string AcountNameExists = "账户名已存在";
        public static string AccountNamePasswdNotMatch = "用户名和密码不匹配";
    }
}
