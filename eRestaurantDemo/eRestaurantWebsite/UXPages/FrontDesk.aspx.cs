using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL.Entities;
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.POCOs;
#endregion

public partial class UXPages_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SeatingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //extract tablenumber, waiterid, numberinparty from the gridview
        // we will also create a datetime variable using the mock clock at the top of
        //the page. (Typically in real-time you use use DateTime.Today)

        //once the data is collected it will be passed to the BLL from processing

        //the command will be done under the control of the MessageUserControl
        //we will use the MUC inline technique

        MessageUserControl.TryRun(() =>
        {
            //obtain our data from the GridView row
            GridViewRow agvrow = SeatingGridView.Rows[e.NewSelectedIndex];

            //accessing a web control on thee gridview row
            //the command to do this is .FindControl("xxxx") as datatype
            //all data from the gridview is a string
            string tablenumber = (agvrow.FindControl("TableNumber") as Label).Text;
            string numberinparty = (agvrow.FindControl("NumberInParty") as TextBox).Text;
            string waiterid = (agvrow.FindControl("WaiterList") as DropDownList).SelectedValue;
            DateTime when = Mocker.MockDate.Add(Mocker.MockTime);

            //standard typical call to your controller in the BLL
            AdminController sysmgr = new AdminController();
            sysmgr.SeatCustomer(when, byte.Parse(tablenumber),
                                      int.Parse(numberinparty),
                                      int.Parse(waiterid));

            //refresh the gridview
            SeatingGridView.DataBind();
        }, "Customer Seated", "New walk-in customer has been saved");
    }
}