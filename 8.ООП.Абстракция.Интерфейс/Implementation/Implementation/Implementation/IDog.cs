﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
	internal interface IDog : IMamal
	{
		void Move()
		{
			Console.WriteLine("Dog moves");
		}
	}
}
