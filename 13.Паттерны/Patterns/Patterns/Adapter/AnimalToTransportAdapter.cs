using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
	public class AnimalToTransportAdapter : ITransport
	{
		private IAnimal _animal;
		
		public AnimalToTransportAdapter(IAnimal animal)
		{
			_animal = animal;
		}

		public void Drive()
		{
			_animal.Move();
		}
	}
}
