using System;
using System.Collections.Generic;

namespace Inherit
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var advansedCustomCollection = new AdvansedCustomCollection<string>(new List<string> { "1", "2"});

			var advansedCustomCollectionInt = new AdvansedCustomCollectionInt(new List<int> { 1, 2, 3 });
				}

		public static string GetOrganisationFromPerson(Person person)
		{
			//if (person is Employee)
			//{
			//	org = ((Employee)person).Organisation;
			//}

			var employee = (person as Employee);

			var org = employee?.Organisation;

			return org;
		}

		public static string GetOrganisationFromEmployee(Employee employee)
		{
			var org = employee?.Organisation;

			return org;
		}
	}
}

//var pers = new Person("pesr", Gender.Male, 1, "1");
//var empl = new Employee("empl", Gender.Female, 2, "2", "organisation");

//var org = GetOrganisationFromPerson(empl);
//var org2 = GetOrganisationFromEmployee(empl);

//org = GetOrganisationFromPerson(pers);
//org2 = GetOrganisationFromEmployee(pers as Employee);
