using System;
using System.Collections.Generic;
using System.Linq;

namespace GenealogicalTree
{
	public class FamilyMembers
	{
		//private bool _isLast;
		private static int _counter = 0;

		public List<FamilyMembers> Descendants { get; private set; }
		public People Person;
	

		public FamilyMembers()
		{
			Descendants = new List<FamilyMembers>();
		}

		public FamilyMembers(People person)
		{
			Descendants = new List<FamilyMembers>();
			Person = person;
			_counter++;
		}

		public void Push(FamilyMembers familyMember)
		{
			Descendants.Add(familyMember);
		}

		public void Scan(int level = 0)
		{
			var tabs = string.Concat(Enumerable.Repeat("   ", level));

			foreach (var persone in Descendants)
			{
				Console.WriteLine($"{tabs}{persone.Person.Name}");
				persone.Scan(level + 1);
			}
		}

		public void Move(FamilyMembers ancestor, FamilyMembers descendant)
		{
			Descendants.Remove(descendant);

			ancestor.Push(descendant);
		}

		public void Remove(FamilyMembers removedPerson)
		{
			bool personIsFound = false;
			var index = 0;

			foreach (var familyMember in Descendants)
			{
				if (familyMember == removedPerson)
				{
					personIsFound = true;
					break;
				}
				index++;
			}
			if (personIsFound)
			{
				Descendants.RemoveAt(index);
				return;
			}
			else
			{
				foreach (var familyMember in Descendants)
				{
					familyMember.Remove(removedPerson);
				}
			}
		}

		public FamilyMembers FindPerson(string personsName)
		{
			var foundPerson = Descendants.FirstOrDefault(FamilyMember => FamilyMember.Person.Name == personsName);
			if (foundPerson != null)
			{
				return foundPerson;
			}
			else
			{
				foreach (var familyMember in Descendants)
				{
					foundPerson = familyMember.FindPerson(personsName);
					if (foundPerson != null)
						return foundPerson;
				}
			}
			return null;
		}
	}
}
