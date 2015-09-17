<Query Kind="Expression">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//simple where clauses

	//list all tables that hold more than 3 people
	from row in Tables 
	where row.Capacity > 3
	select row
	
	//list all items with more than 500 calories and selling for more than 10.00
	from row in Items
	where row.Calories > 500 && 
		  row.CurrentPrice > 10.00m
	select row
	
		//method syntax
		Items.Where (row => ((row.Calories > (Int32?)500) && (row.CurrentPrice > 10.00)))

	//list all items with more than 500 calories and are Entrees on the menu
	//HINT: navigational properties of the database and LINQPad's knowledge 
	from row in Items
	where row.Calories > 500 && 
		  row.MenuCategory.Description.Equals("Entree")
	select row
	
		//method syntax
		Items.Where (row => ((row.Calories > (Int32?)500) && row.MenuCategory.Description.Equals ("Entree")))
		
		//SQL syntax
		-- Region Parameters
		DECLARE @p0 Int = 500
		DECLARE @p1 NVarChar(1000) = 'Entree'
		-- EndRegion
		SELECT [t0].[ItemID], [t0].[Description], [t0].[CurrentPrice], [t0].[CurrentCost], [t0].[Active], [t0].[Calories], [t0].[Comment], [t0].[MenuCategoryID]
		FROM [Items] AS [t0]
		INNER JOIN [MenuCategories] AS [t1] ON [t1].[MenuCategoryID] = [t0].[MenuCategoryID]
		WHERE ([t0].[Calories] > @p0) AND ([t1].[Description] = @p1)
	