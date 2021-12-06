using DynamicMenu;
using GenericTree.Actions;
using ObjectSaver;
using OOP1;
using System;

namespace GenericTree
{
	class Program
	{
		private const string fileName = "boxes.txt";

		static void Main(string[] args)
		{
			var mainMenu = new Menu();

			var createBoxOption = new Menu("Create box", new CreateBoxAction());
			var createPointOption = new Menu("Create point", new CreatePointAction());

			var moveOption = new Menu("Move ...", null);
			var movePointOption = new Menu("Move point", new MovePointAction());
			var moveBoxOption = new Menu("Move box", new MoveBoxAction());
			moveOption.AddSubMenu(movePointOption, moveBoxOption);

			var pullOption = new Menu("Pull", new PullAction());
			var scanOption = new Menu("Scan", new ScanAction());
			var exitOption = new Menu("Exit", new ExitAction());
			var saveOption = new Menu("Save", new SaveAction(fileName));
			var loadOption = new Menu("Load", new LoadAction(fileName));


			mainMenu.AddSubMenu(createBoxOption, createPointOption, moveOption, pullOption, scanOption, exitOption, saveOption, loadOption);

			while (true)
			{
				try
				{
					mainMenu.ChooseAction();

					if (ExitAction.exit)
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
