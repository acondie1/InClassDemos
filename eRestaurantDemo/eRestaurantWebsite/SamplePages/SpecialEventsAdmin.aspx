<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration</h1>
    <table align="center" cellpadding="2" style="width: 80%; border-style: solid; border-width: 1px">
        <tr>
            <td align="right" style="width:50%">Select an Event:</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server"
                    width="200px" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservationsButton" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="ReservationList" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 339px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 339px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>

