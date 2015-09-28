<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration</h1>
    <table align="center" cellpadding="2" style="width: 1016px; border-style: solid; border-width: 1px" border="0">
        <tr>
            <td align="right" style="width:671px">Select an Event:</td>
            <td style="width: 335px">
                <asp:DropDownList ID="SpecialEventList" runat="server"
                    width="200px" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="True">
                    <asp:ListItem Value="z">Select Event</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservationsButton" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="ReservationListGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservations">
                    <AlternatingRowStyle BackColor="#CCFFCC" />
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                        <asp:BoundField DataField="ReservationDate" DataFormatString="{0:MMM dd,yyyy}" HeaderText="Date" SortExpression="ReservationDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="NumberInParty" SortExpression="NumberInParty">
                        <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Contact Phone" SortExpression="ContactPhone">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Reservation Status" SortExpression="ReservationStatus">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        No data to display at this time.
                    </EmptyDataTemplate>
                    <HeaderStyle BackColor="#006699" Font-Size="Large" ForeColor="#FFFFCC" />
                    <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NextPreviousFirstLast" PageButtonCount="5" Position="TopAndBottom" />
                    <RowStyle BackColor="#00CCFF" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 671px" align="center">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" DataSourceID="ODSReservations">
                    <EmptyDataTemplate>
                        No data to display at this time.
                    </EmptyDataTemplate>
                </asp:DetailsView>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 671px">&nbsp;</td>
            <td style="width: 335px">&nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

