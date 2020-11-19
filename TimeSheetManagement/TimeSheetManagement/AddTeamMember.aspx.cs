using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TimeSheetManagement
{
    public partial class AddTeamMember : System.Web.UI.Page
    {
        string connstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string myquery = "";
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlDataReader sdr;
        DataSet ds1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                myquery = "select * from dbo.Employee";
                using (conn = new SqlConnection(connstring))
                {
                    try
                    {
                        conn.Open();
                        command = new SqlCommand(myquery, conn);
                        adapter = new SqlDataAdapter(command);
                        ds1 = new DataSet();
                        adapter.Fill(ds1, "Employee");
                        //DropDownList1.DataValueField = "Code";
                        DrpDwnEmpName.DataTextField = "FirstName";
                        DrpDwnEmpName.DataSource = ds1;
                        DrpDwnEmpName.DataBind();
                        DrpDwnEmpName.Items.Insert(0, "Select");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            bool billable;
            if (radioButtonList.SelectedItem.Text=="Billable")
            {
                billable = true;
            }
            else
            {
                billable =false;
            }
            try
            {
                
                
                    conn = new SqlConnection(connstring);
                    conn.Open();
                    
                    command = new SqlCommand("AddTeamMember", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Emp_Name", DrpDwnEmpName.Text);
                    command.Parameters.AddWithValue("@Involvement", int.Parse(TbInvolve.Text));
                    command.Parameters.AddWithValue("@Billable", billable);
                    sdr = command.ExecuteReader();
                    String cstext = "alert('Data Registered');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    DrpDwnEmpName.SelectedValue = null;
                    TbInvolve.Text = "";
                    radioButtonList.ClearSelection();
              
            }
            catch (Exception)
            {

            }
        }      
    }
}