using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
	internal interface ICat : IMamal
	{
		void Move()
		{
			Console.WriteLine("Cat moves");
		}
	}
}
