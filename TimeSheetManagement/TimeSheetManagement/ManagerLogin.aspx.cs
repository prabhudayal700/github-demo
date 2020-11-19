using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheetManagement
{
    public partial class ManagerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid username or password')", true);
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            try
            {
                SqlCommand sqlComm = new SqlCommand("ManagerLogin", conn);
                sqlComm.Parameters.AddWithValue("@mail", TextBox1.Text);
                sqlComm.Parameters.AddWithValue("@password", TextBox2.Text);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = sqlComm.ExecuteReader();
                if (sdr.Read())
                {
                    Session["UserName"] = TextBox1.Text;
                    Response.Redirect("ManagerPanel.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid username or password')", true);
                }
            }
            catch(Exception)
            {
            }
           
        }
    }
}