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
			foreach (var subMenu in subMenus)
			{
				var lastOptionId = _subMenuOptions.LastOrDefault()?._optionId ?? 0;
				subMenu._optionId = lastOptionId + 1;

				_subMenuOptions.Add(subMenu);
			}
		}

		public void Print()
		{
			foreach (var menuOption in _subMenuOptions)
			{
				Console.WriteLine($"{menuOption._optionId}. {menuOption._optionName}");
			}
		}

		public Menu ChooseAction()
		{
			Menu option = null;
			while (true)
			{
				Print();

				try
				{
					var optionId = int.Parse(Console.ReadLine());
					option = _subMenuOptions.FirstOrDefault(o => o._optionId == optionId);

					if (option == null)
					{
						Console.WriteLine("Please choose correct option");
						continue;
					}
					break;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Please choose correct option");
				}
			}

			if (option._subMenuOptions.Any())
			{
				option = option.ChooseAction();
			}

			return option;
		}

		public IOutputParams Execute(IInputParams inputParams = null)
		{
			return _action.Execute(inputParams);
		}
	}
}
