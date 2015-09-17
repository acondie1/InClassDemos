<Query Kind="Expression">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//AGGREGATES

//Count
//method syntax
from category in MenuCategories
select new
{
	Category = category.Description,
	Items = category.Items.Count()
}

//Brackets are query syntax, rest is method syntax	- gets ugly
from category in MenuCategories
select new
{
	Category = category.Description,
	Items = (from x in category.Items select x).Count()
}

//Sum
(from theBill in BillItems
where theBill.BillID == 104
select theBill.SalePrice * theBill.Quantity).Sum()

//alternatively
BillItems
	.Where (theBill => theBill.BillID == 104)
	.Select(theBill => theBill.SalePrice * theBill.Quantity)
	.Sum()

//or
from customer in Bills
where customer.BillID == 104
select customer.BillItems.Sum (theBill => theBill.SalePrice * theBill.Quantity)

//Max and Sum
(from customer in Bills
where customer.PaidStatus == true
select customer.BillItems.Sum (theBill => theBill.SalePrice * theBill.Quantity)).Max()

//OYO find the average number of items per bill
(from bill in Bills
select bill.BillItems.Count()).Average()

//Conversions - ToList(), AsEnumerable(), AsQueryable()

//Selection Filters - FirstOrDefault(), SingleOrDefault(), Distinct(), Take(), TakeWhile(), Skip(), SkipWhile()

//Other Stuff - Any(), All(), Union()
