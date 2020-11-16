using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace BrowserProducts
{
    public class DataAccess
    {
        // method to getProducts into DataGridView by a stored procedure
        public void GetProducts(DataGridView dgv,string language)
        {
            //SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016"));
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter($"dbo.spProducts_GetAll '{language}'", connection);

            //da.Fill(dt);
            //dgv.DataSource = dt;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter($"dbo.spProducts_GetAll @language", (SqlConnection) connection);
                da.SelectCommand.Parameters.AddWithValue("@language", language);

                da.Fill(dt);
                dgv.DataSource = dt;
            }
        }
    }
}

