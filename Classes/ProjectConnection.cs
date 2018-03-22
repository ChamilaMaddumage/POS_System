using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class ProjectConnection
    {
        public static SqlConnection conn = null;
        public static readonly object Newconnection;

        public void Connection_Today()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
            // conn = new SqlConnection("Data Source=tcp:treset.database.windows.net,1433;Initial Catalog=Treset_POS;Persist Security Info=False;User ID=Treset;Password=POS@#$2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            conn.Open();
        }
    }
}
