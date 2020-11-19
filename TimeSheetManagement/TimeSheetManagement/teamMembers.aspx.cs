using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TimeSheetManagement
{
    public partial class teamMembers : System.Web.UI.Page
    {
        string Pid = "";
        SqlConnection conn;
        string connstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TimesheetMgmt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void syncemp()
        {
            string pid = Request.QueryString["pid"];
            //try
            //{
            //     Pid = Session["Project_ID"].ToString();
            //    Label1.Text = Pid;

            //}
            //catch (Exception ex)
            //{ 
            //}
            using ( conn = new SqlConnection(connstring))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("DisplayTeam", conn);
                    command.Parameters.AddWithValue("Project_ID", pid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    dataAdp.Fill(ds);

                    GridViewTeamMember.DataSource = ds;
                    GridViewTeamMember.DataBind();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewTeamMember.Visible = true;
            if (!Page.IsPostBack)
            {
                
                syncemp();
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTeamMember.aspx");
        }

        protected void GridViewTeamMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Pid = Convert.ToString(GridViewTeamMember.DataKeys[e.RowIndex].Values["Project_ID"]);
            string Empid= Convert.ToString(GridViewTeamMember.DataKeys[e.RowIndex].Values["Emp_ID"]);
            
            using (conn = new SqlConnection(connstring))
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTeamMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Project_ID", Pid);
                    cmd.Parameters.AddWithValue("@Emp_ID", Empid);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    syncemp();
                }
                catch (Exception ex)
                { 
                }
        }

        protected void GridViewTeamMember_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            GridViewTeamMember.EditIndex = e.NewEditIndex;
            syncemp();
        }

        protected void GridViewTeamMember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTeamMember.EditIndex = -1;
            syncemp();
        }

        protected void GridViewTeamMember_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Pid = Convert.ToString(GridViewTeamMember.DataKeys[e.RowIndex].Values["Project_ID"]);
            string Empid =Convert.ToString(GridViewTeamMember.DataKeys[e.RowIndex].Values["Emp_ID"]);
            using (conn = new SqlConnection(connstring))
                try
                {
                    conn.Open();

                    string involvement = (GridViewTeamMember.Rows[e.RowIndex].FindControl("Involvement") as TextBox).Text;
                    bool billable = bool.Parse((GridViewTeamMember.Rows[e.RowIndex].FindControl("Billable") as TextBox).Text);
                    string s = involvement;
                    Label1.Text = s;


                    SqlCommand cmd = new SqlCommand("EditTeamMember", conn);
                    cmd.CommandType =CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Project_ID", Pid);
                    cmd.Parameters.AddWithValue("@Emp_ID", Empid);
                    cmd.Parameters.AddWithValue("@Involvement", int.Parse(involvement));
                    cmd.Parameters.AddWithValue("@Billable", billable);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    GridViewTeamMember.EditIndex = -1;
                    syncemp();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
        }
    }
}