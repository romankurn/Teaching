using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
	internal class GooglePay : IPay
	{
		private double _ourMoney;

		public GooglePay(double money)
		{
			_ourMoney = money;
		}

		public bool Pay(double money)
		{
			if (money > _ourMoney)
				return false;

			_ourMoney -= money;
			return true;
		}
	}
}
