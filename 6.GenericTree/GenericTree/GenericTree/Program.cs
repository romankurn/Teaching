using ObjectSaver;
using OOP1;
using System;
using DynamicMenu;
using GenericTree.Actions;

namespace GenericTree
{
	class Program
	{
		private const string fileName = "boxes.txt";

		static void Main(string[] args)
		{
			var mainMenu = new Menu();
			
			var createBoxOption = new Menu("Create box", new CreateBoxAction());
			var createItemOption = new Menu("Create item", new CreateItemAction());
			
			var moveOption = new Menu("Move ...", null);
			var moveItemOption = new Menu("Move item", new MoveItemAction());
			var moveBoxOption = new Menu("Move box", new MoveBoxAction());
			moveOption.AddSubMenu(moveItemOption, moveBoxOption);

			var pullOption = new Menu("Pull", new PullAction());
			var scanOption = new Menu("Scan", new ScanAction());
			var saveOption = new Menu("Save", new SaveAction(fileName));
			var loadOption = new Menu("Load", new LoadAction(fileName));
			var exitOption = new Menu("Close", new ExitAction());

			mainMenu.AddSubMenu(createBoxOption, createItemOption, moveOption, pullOption, scanOption, saveOption, loadOption, exitOption);

			while (true)
			{
				try
				{
					var chosenOption = mainMenu.ChooseAction();
					var param = chosenOption.Execute();

					if (param is ExitParam exitParam && exitParam.Exit)
						break;
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}

		}
	}
}
