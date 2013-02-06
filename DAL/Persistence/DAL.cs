using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class DAL
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        public void OpenConnection()
        {
            Con = new SqlConnection("Data Source=THIAGONOTE;Initial Catalog=Manager;Integrated Security=True");
            Con.Open();
        }

        public void CloseConnection()
        {
            if (Con != null)
            {
                Con.Close();
            }
        }
    }
}
