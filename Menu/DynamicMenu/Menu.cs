using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicMenu
{
	public class Menu
	{
		private string _optionName;
		private int _optionId;
		private List<Menu> _subMenuOptions;
		private IAction _action;

		public Menu()
		{
			_subMenuOptions = new List<Menu>();
		}

		public Menu(string optionName, IAction action)
		{
			_optionName = optionName; 
			_action = action;
			_subMenuOptions = new List<Menu>();
		}

		public void AddSubMenu(params Menu[] subMenus)
		{
			foreach (Menu subMenu in subMenus)
			{
				subMenu._optionId = _subMenuOptions.Count + 1;
				_subMenuOptions.Add(subMenu);
			}
		}

		public void Print()
		{
			foreach (var subMenu in _subMenuOptions)
			{
				Console.WriteLine($"{subMenu._optionId}: {subMenu._optionName}");
			}
		}

		public void ChooseAction()
		{
			Print();

			try
			{
				var chosenOptionId = int.Parse(Console.ReadLine());
				var option = _subMenuOptions.FirstOrDefault(e => e._optionId == chosenOptionId);

				if (option == null)
				{
					Console.WriteLine("Enter correct menu option");
				}

				if (option._subMenuOptions.Any())
				{
					option.ChooseAction();
				}
				else
				{
					option.Execute();
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("Enter correct menu option");
			}

		}

		private void Execute()
		{
			_action.Execute();
		}
	}
}
