<Query Kind="Program" />


//5+7;
/*string name;
name = "Ashley";
string message = "hello " + name + " world";
message.Dump();*/

void Main()
{
	/*string name;
	name = "Ashley";
	string message = "hello " + name + "world";
	message.Dump();*/
	SayHello("Ashley");
}

//Define other methods and classes here
public void SayHello(string name)
{
	string message = "hello " + name + " world";
	message.Dump();
}