using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
	/// <summary>
	/// Касса
	/// </summary>
	internal class CashRegister
	{
		private double _money;

		public CashRegister(double money)
		{
			_money = money;
		}
		public bool GetMoney(IPay pay, double requiredMoney)
		{
			//actions
			if (!pay.Pay(requiredMoney))
			{
				
				return false;
			}
			_money += requiredMoney;
			return true;
		}
	}
}
