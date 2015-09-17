<Query Kind="Expression">
  <Connection>
    <ID>4a54137a-18c1-4398-aaaf-4810d1a85f01</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//step 1 connect to the desired database

	//click on Add connection
	//take defaults press Next
	//change server to . (dot), select existing database from dropdown list
	//optionally press Test
	//press OK
	//REMEMBER to check the connection dropdownlist to see which database is the active connection, and language is set as C# Expression
	
	//result should show database tables in connection object area
	//expanding a table will reveal the table attributes and any relationships
	
//step 2 view table (Waiter) data
	Waiters
	
	//query syntax to also view Waiter data
	from item in Waiters 
	select item

	//method syntax to view Waiter data
	Waiters.Select (item /*input parameter*/ => /*lambda*/ item /*expression*/)
	
	//alter the query syntax into a C# statement
	var results = from item in Waiters 
					select item;
	results.Dump();
	
	//once the query is created, tested, you will be able to transfer the query with minor modificatons into your BLL methods
	//public List<pocoObject> SomeBLLMethodName()
	//{
		//connect to your DAL object : var contextvariable
		//do your query
	//	var results = from item in contextvariable.Waiters 
	//					select item;
	//	return results.ToList();
	}