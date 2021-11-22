using System;
using System.Collections.Generic;

namespace Inherit
{
	class Program
	{
		static void Main(string[] args)
		{
			var book1 = new Book("warAndPeace", "Fat Lion", 55.67);
			book1.Print();

			var book2 = new BookGenre("War And Peace", "Fat Lion", 55.67, "novel");

			book2.Print();

			var book3 = new BookGenrePubl("War And Peace", "Fat Lion", 55.67, "novel", "Zvezdochka");

			book3.Print();
		}
	}
}

//	var advansedCustomCollection = new AdvansedCustomCollection<string>(new List<string> { "1", "2"});

//	var advansedCustomCollectionInt = new AdvansedCustomCollectionInt(new List<int> { 1, 2, 3 });
//		}

//public static string GetOrganisationFromPerson(Person person)
//{
//	//if (person is Employee)
//	//{
//	//	org = ((Employee)person).Organisation;
//	//}

//	var employee = (person as Employee);

//	var org = employee?.Organisation;

//	return org;
//}

//public static string GetOrganisationFromEmployee(Employee employee)
//{
//	var org = employee?.Organisation;

//	return org;

//var pers = new Person("pesr", Gender.Male, 1, "1");
//var empl = new Employee("empl", Gender.Female, 2, "2", "organisation");

//var org = GetOrganisationFromPerson(empl);
//var org2 = GetOrganisationFromEmployee(empl);

//org = GetOrganisationFromPerson(pers);
//org2 = GetOrganisationFromEmployee(pers as Employee);
