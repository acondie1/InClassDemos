<Query Kind="Statements">
  <Connection>
    <ID>1e192cc9-d382-4d2c-8ac7-32087e311da8</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var EmployeeYOECollection = from eachemployee in Employees
							select new 
							{
								Name = eachemployee.LastName + " " + eachemployee.FirstName,
								YOE = eachemployee.EmployeeSkills.Sum
														(eachEmployeeSkillRow => eachEmployeeSkillRow.YearsOfExperience)
							};
EmployeeYOECollection.Dump();

var MaxYOE = EmployeeYOECollection.Max(eachEYOECRow => eachEYOECRow.YOE);

MaxYOE.Dump();

var finalList = from emp in EmployeeYOECollection
				where emp.YOE == MaxYOE
				select emp.Name;
				
finalList.Dump();				