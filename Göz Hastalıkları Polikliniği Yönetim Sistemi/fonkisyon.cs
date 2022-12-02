using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Göz_Hastalıkları_Polikliniği_Yönetim_Sistemi
{
    internal class fonkisyon
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string constr;
        public fonkisyon()
        {
            constr = @"Data Source=DESKTOP-MDN807P;Initial Catalog=GözPol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, constr);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(String Quary)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Quary;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }




    }
}
