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
    public partial class ManagerPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("ManagerLogin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            
                string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                try
                {
                    SqlCommand sqlComm = new SqlCommand("empRegister", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@empid", TextBox1.Text);
                    sqlComm.Parameters.AddWithValue("@fName", TextBox2.Text);
                    sqlComm.Parameters.AddWithValue("@lName", TextBox3.Text);
                    sqlComm.Parameters.AddWithValue("@password", TextBox4.Text);
                    sqlComm.Parameters.AddWithValue("@phone", TextBox5.Text);
                    sqlComm.Parameters.AddWithValue("@gender", gender.SelectedItem.Text);
                    sqlComm.Parameters.AddWithValue("@address", TextBox6.Text);
                    sqlComm.Parameters.AddWithValue("@designation", DropDownList1.Text);
                    sqlComm.Parameters.AddWithValue("@mail", TextBox7.Text);
                    sqlComm.Parameters.AddWithValue("@dob", DateTime.Parse(TextBox8.Text));

                    sqlComm.ExecuteNonQuery();
                    conn.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Done!!!')", true);
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                gender.ClearSelection();
                DropDownList1.ClearSelection();

            }
                catch (Exception)
                {
                }
            
        }
        
    }
}