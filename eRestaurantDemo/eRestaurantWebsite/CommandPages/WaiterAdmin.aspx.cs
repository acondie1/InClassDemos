using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
using eRestaurantSystem.BLL;    //controller
using eRestaurantSystem.DAL.Entities;   //entity
using EatIn.UI;     //mesageusercontrol
#endregion

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //initialize the date hired to today
        DateHired.Text = DateTime.Today.ToShortDateString();
    }
    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0)
        {
            MessageUserControl1.ShowInfo("Please select a waiter before clicking 'Fetch Waiter'.");
        }
        else
        {
            //we will use a TryRun() from the MessageUserControl
            //this will capture error messages when/if they happen and properly display in the user control
            //GetWaiterInfo is your mehtod for accessing BLL and query
            MessageUserControl1.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }
    public void GetWaiterInfo()
    {
        //a standard lookup sequence
        AdminController sysmgr = new AdminController();

        var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));

        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        DateHired.Text = waiter.HireDate.ToShortDateString();
        if(waiter.ReleaseDate.HasValue)
        {
            DateReleased.Text = waiter.ReleaseDate.ToString();
        }

    }
    protected void InsertWaiter_Click(object sender, EventArgs e)
    {
        //this example is using the TryRun inline
        MessageUserControl1.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);
                item.ReleaseDate = null;
                AdminController sysmgr = new AdminController();
                WaiterID.Text = sysmgr.Waiter_Add(item).ToString();
                MessageUserControl1.ShowInfo("Waiter Added.");
            });
    }
    protected void UpdateWaiter_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(WaiterID.Text))
        {
            MessageUserControl1.ShowInfo("Please select a waiter to update");
        }
        else
        {
            MessageUserControl1.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.WaiterID = int.Parse(WaiterID.Text);
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);
                if(string.IsNullOrEmpty(DateReleased.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(DateReleased.Text);
                }                
                AdminController sysmgr = new AdminController();
                sysmgr.Waiter_Update(item);
                MessageUserControl1.ShowInfo("Waiter Updated.");
            });
        }
    }
}