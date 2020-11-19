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
    public partial class AddProject : System.Web.UI.Page
    {

        string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("ManagerLogin.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("spAddProject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Project_ID", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Project_name", TextBox2.Text);
                cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(TextBox3.Text));
                cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(TextBox4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Information submitted successfully!!')", true);
            }
            catch (Exception)
            {
            }
        }
    }
}