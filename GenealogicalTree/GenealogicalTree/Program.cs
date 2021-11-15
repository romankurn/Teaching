using ObjectSaver;
using System;

namespace GenealogicalTree
{
	class Program
	{
		private const string fileName = "family.txt";
		private static FamilyMembers adam;

		static void Main(string[] args)
		{
			adam = new FamilyMembers();

			var exit = false;

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Choose action:");
				Console.WriteLine("1: Add new family member");
				Console.WriteLine("2: Remove an existing family member");
				Console.WriteLine("3: Specify an ancestor");
				Console.WriteLine("4: Show descendants");
				Console.WriteLine("5: Scan");
				Console.WriteLine("6: Save");
				Console.WriteLine("7: Load");
				Console.WriteLine("0: Close");
				var option = Convert.ToByte(Console.ReadLine());

				switch (option)
				{
					case 1:
						AddFamilyMember();
						Console.WriteLine("Family member added");
						break;

					case 2:
						RemoveFamilyMember();
						Console.WriteLine("Family member removed");
						break;

					case 3:
						SpecifyAnAncestor();
						Console.WriteLine("Relationship added");
						break;

					case 4:
						IdentifyPerson();
						break;

					case 5:
						adam.Scan();
						break;

					case 6:
						File<FamilyMembers>.Save(fileName, adam);
						Console.WriteLine("File saved");
						break;

					case 7:
						adam = File<FamilyMembers>.GetItemFromFile(fileName);
						Console.WriteLine("Saved file loaded");
						break;

					case 0:
						exit = true;
						break;
				}
				if (exit)
					break;
			}
		}

		static void AddFamilyMember()
		{
			var newFamilyMember = new FamilyMembers(GetPerson());
			adam.Push(newFamilyMember);
		}

		static void RemoveFamilyMember()
		{
			Console.Write("Enter the person's name ");
			var name = Console.ReadLine();

			var removedPerson =  adam.FindPerson(name);

			adam.Remove(removedPerson);
		}

		static People GetPerson()
		{
			Console.Write("Enter the person's name ");
			var name = Console.ReadLine();
			Console.Write("Enter the person's age ");
			var age = Convert.ToInt32(Console.ReadLine());

			var newPerson = new People(name, age);
			return newPerson;
		}

		static void SpecifyAnAncestor()
		{
			Console.Write("Enter the name of the ancestor: ");
			var ancestorName = Console.ReadLine();
			Console.Write("Enter the name of the descendant: ");
			var descendantName = Console.ReadLine();

			var ancestor = adam.FindPerson(ancestorName);
			var descendant = adam.FindPerson(descendantName);

			adam.Move(ancestor, descendant);
		}

		static void IdentifyPerson()
		{
			Console.Write("Enter the person's name ");
			var ancestorName = Console.ReadLine();

			var ancestor = adam.FindPerson(ancestorName);

			ancestor.Scan();
		}
	}
}
