<Query Kind="Statements">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from abillrow in Bills
where abillrow.BillDate.Month == 5
orderby abillrow.BillDate, abillrow.Waiter.LastName, abillrow.Waiter.FirstName
select new
{
	BillDate = new DateTime(abillrow.BillDate.Year, 
							abillrow.BillDate.Month,
							abillrow.BillDate.Day),
	Name = abillrow.Waiter.LastName + ", " + abillrow.Waiter.FirstName,
	BillID = abillrow.BillID,
	BillTotal = abillrow.BillItems.Sum(bitem => bitem.Quantity * bitem.SalePrice),
	PartySize = abillrow.NumberInParty,
	Customer = abillrow.Reservation.CustomerName
}