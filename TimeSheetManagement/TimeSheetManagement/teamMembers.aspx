<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanelMaster.Master" AutoEventWireup="true" CodeBehind="teamMembers.aspx.cs" Inherits="TimeSheetManagement.teamMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="583px" Style="margin-left: 51px; margin-top: 0px" Width="1295px">
        <br />
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="Button3" runat="server" Text="Add Team Member" Width="201px" OnClick="Button3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;
        <asp:GridView ID="GridViewTeamMember" runat="server"
            OnRowDeleting="GridViewTeamMember_RowDeleting"
            OnRowUpdating="GridViewTeamMember_RowUpdating"
            OnRowEditing="GridViewTeamMember_RowEditing"
            OnRowCancelingEdit="GridViewTeamMember_RowCancelingEdit"
            DataKeyNames="Project_ID,Emp_ID" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="462px" Width="1134px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText ="Employee Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Project_Name" HeaderText="Project Name" />
                
                
                <asp:TemplateField HeaderText ="Involvement">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Involvement") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="Involvement" runat="server" Text='<%# Bind("Involvement") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText ="Bill Status">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Billable") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="Billable" runat="server" Text='<%# Bind("Billable") %>'></asp:Textbox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger" HeaderText="Remove Record" />

                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" HeaderText="Edit Record" />

            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
