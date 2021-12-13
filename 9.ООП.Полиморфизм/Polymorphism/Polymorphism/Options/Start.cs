using DynamicMenu;
using System;

namespace Polymorphism
{
	public class Start
	{
		public static void Beginning()
		{
			var mainMenu = new Menu();

			var createOption = new Menu("Create ...", null);
			var createPersonOption = new Menu("Create person", new CreatePerson());
			var createStudentOption = new Menu("Create student", new CreateStudent());
			var createTeacherOption = new Menu("Create teacher", new CreateTeacher());
			createOption.AddSubMenu(createPersonOption, createStudentOption, createTeacherOption);

			var scanOption = new Menu("Scan", new Scan());
			var exitOption = new Menu("Exit", new Exit());

			mainMenu.AddSubMenu(createOption, scanOption, exitOption);

			while (true)
			{
				try
				{
					mainMenu.ChooseAction();

					if (Exit.exit)
						break;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}
	}
}
