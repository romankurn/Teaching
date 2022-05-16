using StrategyImplementation = Patterns.Strategy.Implementation;
using FactoryImplementation = Patterns.Factory.Implementation;
using AdapterImplementation = Patterns.Adapter.Implementation;
using SingletoneImplementation = Patterns.Singleton.Implementatoin;
using DecoratorImplementation = Patterns.Decorator.Implementation;
using PrototypeImplementation = Patterns.Prototype.Implementation;
using ProxyImplementation = Patterns.Proxy.Implementation;
using System;
using Patterns.Observer;
using System.Threading.Tasks;

namespace Patterns
{
	internal class Program
	{
		static void  Main(string[] args)
		{
			ProxyImplementation.Execute();
		}
	}
}
