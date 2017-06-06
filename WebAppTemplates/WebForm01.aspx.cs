using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTemplates
{
    public partial class WebForm01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void processBtn_Click(object sender, EventArgs e)
        {
            var dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                connection.Open();

                //Create Table First
                using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM Table WHERE Id = @Input", connection))
                {
                    cmd.Parameters.Add("Input", SqlDbType.Int).Value = 1;

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            tempRepeater.DataSource = dataTable;
            tempRepeater.DataBind();
        }
    }
}