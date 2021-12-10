using HWMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Start
	{
		private const string fileName = "univer.txt";

		public static void Beginning()
		{
			var mainMenu = new Menu();

			var createPersonOption = new Menu("Create person", new CreatePerson());
			var CreateRandomPersonOption = new Menu("Create random person", new CreateRandomPerson());
			var CreateStudentOption = new Menu("Create student", new CreateStudent());
			var CreateRandomStudentOption = new Menu("Create random student", new CreateRandomStudent());
			var CreateTeacherOption = new Menu("Create teacher", new CreateTeacher());
			var CreateRandomTeacherOption = new Menu("Create random student", new CreateRandomTeacher());

		}
	}
}
