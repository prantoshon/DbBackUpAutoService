using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAutoBackupService
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=localhost;Initial Catalog=Interview;User ID=sa; pwd=sa*1209");
           

            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            string destdir = "D:\\dbBackup";
            if (!System.IO.Directory.Exists(destdir))
            {
                System.IO.Directory.CreateDirectory("D:\\dbBackup");
            }
            // check if backup folder exist, otherwise create it.

            try
            {
                sqlconn.Open();

                sqlcmd = new SqlCommand("backup database Interview to disk='" + destdir + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", sqlconn);


                sqlcmd.ExecuteNonQuery();
                //Close connection
                sqlconn.Close();
                Console.WriteLine("Backup database successfully");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Console.ReadLine();
            }
        }
    }
}
