using StrategyImplementation = Patterns.Strategy.Implementation;
using FactoryImplementation = Patterns.Factory.Implementation;
using System;

namespace Patterns
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StrategyImplementation.Move();

			FactoryImplementation.Move();
		}
	}
}
