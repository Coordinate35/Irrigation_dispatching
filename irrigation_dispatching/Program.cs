using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace irrigation_dispatching
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string cs = "Data Source=DESKTOP-23E4P5O;Initial Catalog=irrigation_dispatching;Persist Security Info=True;User ID=irrigation_dispatching;Pwd=Irrigationdispatching";
            SqlConnection con = new SqlConnection(cs);
            string sql = "SELECT * FROM account";
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection error", e.Message);
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sdr = null;
            try
            {
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["account_id"] + " " + sdr["account_name"]);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
