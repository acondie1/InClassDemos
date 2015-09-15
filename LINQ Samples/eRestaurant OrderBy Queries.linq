<Query Kind="Expression">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//orderby

	//default ascending
	from food in Items
	orderby food.Description
	select food
	
	//default descending
	from food in Items
	orderby food.CurrentPrice descending
	select food
	
	//default descending and ascending
	from food in Items
	orderby food.CurrentPrice descending, food.Calories ascending
	select food
	
	//default descending and ascending with where clause				***ORDER Doesn't matter in select statements
	from food in Items
	orderby food.CurrentPrice descending, food.Calories ascending
	where food.MenuCategory.Description.Equals("Appetizer")
	select food
