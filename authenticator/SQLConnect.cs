using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authenticator
{
    

    public class SQLConnect
    {
        string connection; 
        public SQLConnect()
        {
            connection = "Data Source=ACER\\SQLEXPRESS; Initial Catalog=AUTHENTICATION; Integrated Security=True";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(connection);
        }
    }   
}
