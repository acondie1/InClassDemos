<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register src="../UserControls/MessageUserControl.ascx" tagname="MessageUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Waiter Admin</h1>
    
    <br />
    <uc1:MessageUserControl ID="MessageUserControl1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="Select Waiter for Update"></asp:Label>
    <asp:DropDownList ID="WaiterList" runat="server" DataSourceID="ODSWaiters" DataTextField="FullName" DataValueField="WaiterID" Height="16px" Width="249px">        
    </asp:DropDownList>
    <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">Fetch Waiter</asp:LinkButton>
    <asp:ObjectDataSource ID="ODSWaiters" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiters_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <br />
    <table align="center" style="width: 70%">
        <tr>
            <td>Waiter ID</td>
            <td>
                <asp:Label ID="WaiterID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Hired (mm/dd/yyyy)</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Released (mm/dd/yyyy)</td>
            <td>
                <asp:TextBox ID="DateReleased" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="InsertWaiter" runat="server" OnClick="InsertWaiter_Click">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="UpdateWaiter" runat="server" OnClick="UpdateWaiter_Click">Update</asp:LinkButton>
            </td>
        </tr>
    </table>    
    <br />
</asp:Content>

