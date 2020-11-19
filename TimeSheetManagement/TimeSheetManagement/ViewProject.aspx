<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanelMaster.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="TimeSheetManagement.ViewProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>About Projects</h1>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Show Projects" Width="210px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Add  Project" Width="199px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="1573px" 
            OnRowUpdating="GridView1_RowUpdating" 
            OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowSelecting="GridView1_RowSelecting"
            OnRowCommand ="GridView1_RowCommand"

            DataKeyNames="Project_ID"  AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Project_ID" HeaderText="Project ID" />
                <asp:TemplateField HeaderText ="Project Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Project_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="TextPN" runat="server" Text='<%# Bind("Project_Name") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Start Date">
                    <ItemTemplate>
                        <asp:Label runat="server" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" Text='<%# Eval("StartDate", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="TextSD" runat="server" Text='<%# Bind("StartDate", "{0:dd-MMM-yyyy}") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="End Date">
                    <ItemTemplate>
                        <asp:Label runat="server" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="false" Text='<%# Eval("EndDate", "{0:dd-MMM-yyyy}")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="TextED" runat="server" Text='<%# Bind("EndDate", "{0:dd-MMM-yyyy}") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="Remove Record" >
<ControlStyle CssClass="btn btn-danger"></ControlStyle>
                </asp:CommandField>
                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" HeaderText="Edit Record" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>
                
               <asp:TemplateField HeaderText="View Team">
                <ItemTemplate>
                    <asp:Button ID="ViewTeam" runat="server" onclick="ViewTeam_Click" CommandName="ViewTeam" CommandArgument='<%# Eval("Project_ID") %>'   Text="ViewTeam" ControlStyle-CssClass="btn btn-info"/>
                </ItemTemplate>
            </asp:TemplateField>
                                
                <%--<asp:CommandField SelectText="View Team" ShowSelectButton="True" ControlStyle-CssClass="btn btn-info"/>--%>
                                
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
