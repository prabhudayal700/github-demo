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
    public partial class ViewProject : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        private void GetData()
        {
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewProject", con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProject.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ViewProject", con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
            con.Close();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);

            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteProject", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Project_ID", id);
            //GridView1.DataSource = cmd.ExecuteReader();
            //GridView1.DataBind();
            cmd.ExecuteNonQuery();
            con.Close();

            GetData();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }



        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            GetData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            GetData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            con.Open();

            string pid = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
            string pname = (GridView1.Rows[e.RowIndex].FindControl("TextPN") as TextBox).Text;


            TextBox StartDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextSD");
            DateTime sd = Convert.ToDateTime(StartDate.Text);
            StartDate.Text = sd.ToString("0:dd - MMM - yyyy");

            TextBox EndDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextED");
            DateTime ed = Convert.ToDateTime(EndDate.Text);
            EndDate.Text = ed.ToString("0:dd - MMM - yyyy");

            //string ed = (GridView1.Rows[e.RowIndex].FindControl("TextED") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("EditProject", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Project_ID", pid);
            cmd.Parameters.AddWithValue("@Project_Name", pname);
            cmd.Parameters.AddWithValue("@StartDate", sd);
            cmd.Parameters.AddWithValue("@EndDate", ed);

            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            GetData();

        }
        protected void ViewTeam_Click(object sender, EventArgs e)
        {
            var obj = (Control)sender;
            GridViewRow gvr = (GridViewRow)obj.NamingContainer;
            string id = gvr.Cells[0].Text;
           // string prid = GridView1.Rows[0].ToString();
           //Label1.Text = prid;
           Response.Redirect("teamMembers.aspx?pid=" + id);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTeam")
            {
                string s = e.CommandArgument.ToString();
            }
        }
        //protected void GridView1_RowSelecting(object sender, GridViewCancelEditEventArgs e)
        //{
        //    Response.Redirect("teamMembers.aspx");
        //    string id =Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
        //}
    }
}