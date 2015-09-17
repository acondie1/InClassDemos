<Query Kind="Expression">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//anonymous type
from food in Items
where food.MenuCategory.Description.Equals("Entree") && 
		food.Active
orderby food.CurrentPrice descending
select new 
		{
			Description = food.Description,
			Price = food.CurrentPrice,
			Cost = food.CurrentCost,
			Profit = food.CurrentPrice - food.CurrentCost
		}
	
//works, but less user friendly and secure		
from food in Items
where food.MenuCategory.Description.Equals("Entree") && 
		food.Active
orderby food.CurrentPrice descending
select new 
		{
			food.Description,
			food.CurrentPrice,
			food.CurrentCost,
			//food.CurrentPrice - food.CurrentCost
		}	
	
//this will NOT work
from food in Items
where food.MenuCategory.Description.Equals("Entree") && 
		food.Active
orderby food.CurrentPrice descending
select new 
		{
			Description = food.Description,
			Price = food.CurrentPrice,
			Cost = food.CurrentCost,
			//CHANGE HERE
			Profit = Price - Cost
		}