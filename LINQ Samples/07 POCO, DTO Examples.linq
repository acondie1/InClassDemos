<Query Kind="Program">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	//anonymous type														HOT KEYS CTRL+K, CTRL+C - Comment // CTRL+K, CTRL+U - Uncomments
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			Description = food.Description,
	//			Price = food.CurrentPrice,
	//			Cost = food.CurrentCost,
	//			Profit = food.CurrentPrice - food.CurrentCost
	//		}
	//	
	////works, but less user friendly and secure		
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			food.Description,
	//			food.CurrentPrice,
	//			food.CurrentCost,
	//			//food.CurrentPrice - food.CurrentCost
	//		}	
	//	
	////this will NOT work
	//from food in Items
	//where food.MenuCategory.Description.Equals("Entree") && 
	//		food.Active
	//orderby food.CurrentPrice descending
	//select new 
	//		{
	//			Description = food.Description,
	//			Price = food.CurrentPrice,
	//			Cost = food.CurrentCost,
	//			//CHANGE HERE
	//			Profit = Price - Cost
	//		}
	
	//type query set
	var results = from food in Items
		where food.MenuCategory.Description.Equals("Entree") && 
			food.Active
		orderby food.CurrentPrice descending
		select new FoodMargin()
			{
				Description = food.Description,
				Price = food.CurrentPrice,
				Cost = food.CurrentCost,
				Profit = food.CurrentPrice - food.CurrentCost
			};
		results.Dump();
		
		var results2 = from orders in Bills
			where orders.PaidStatus && 
				(orders.BillDate.Month == 9 && orders.BillDate.Year == 2014)
			orderby orders.Waiter.LastName, orders.Waiter.FirstName
			select new BillOrders()
			{
				BillId = orders.BillID,
				Waiter = orders.Waiter.LastName + ", " + orders.Waiter.FirstName,
				Orders = orders.BillItems
			};
		results2.Dump();
}	
	//Define other methods and classes here
	
	//Entity: calling the whole table	eg. Waiter.Dump();
	
	//Sample of a POCO type class: flat data set, no structures
	public class FoodMargin
	{
		public string Description{get;set;}
		public decimal Price{get;set;}
		public decimal Cost{get;set;}
		public decimal Profit{get;set;}
	}
	//Sample of a DTO type class: flat data set, with possible structures
	public class BillOrders
	{
		public int BillId{get;set;}
		public string Waiter{get;set;}
		public IEnumerable Orders{get;set;}		//This is a DTO		
	}