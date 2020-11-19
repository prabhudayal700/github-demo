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
    public partial class EmployeeTimesheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("ManagerLogin.aspx");
            }
            if (!IsPostBack)
            {
                string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn;
                conn = new SqlConnection(connectString);
                conn.Open();
                SqlCommand sqlComm = new SqlCommand("empShow", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sAdp = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                sAdp.Fill(ds, "Employee");
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataTextField = "FirstName";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Select--");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            try
            {
                SqlCommand sqlComm = new SqlCommand("ShowTimesheet", conn);
                sqlComm.Parameters.AddWithValue("@firstName", DropDownList1.Text);
                sqlComm.Parameters.AddWithValue("@lastName", DropDownList2.Text);
                sqlComm.Parameters.AddWithValue("@date", DateTime.Parse(TextBox1.Text));
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                dataAdp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                conn.Close();

            }
            catch (Exception)
            {
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn;
            conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand sqlComm = new SqlCommand("lastname", conn);
            sqlComm.Parameters.AddWithValue("@fname", DropDownList1.Text);
            sqlComm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sAdp = new SqlDataAdapter(sqlComm);
            DataSet ds = new DataSet();
            sAdp.Fill(ds, "Employee");
            DropDownList2.DataSource = ds.Tables[0];
            DropDownList2.DataTextField = "LastName";
            DropDownList2.DataBind();
        }
    }
}