using HWMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class SpecifyStudentsTeacher : IAction
	{
		public void Execute()
		{
			Console.Write("Enter the student's name");
			var studentName = Console.ReadLine();
			Console.Write("Enter the teacher's name");
			var teacherName = Console.ReadLine();


		}
	}
}
