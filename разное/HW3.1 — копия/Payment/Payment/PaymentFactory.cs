using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
	internal class PaymentFactory
	{
		public IPay GetPaymentWay(PaymentWay way, double myMoney)
		{
			switch (way)
			{
				case PaymentWay.Cash:
					return new CashPay(myMoney);
				case PaymentWay.Card:
					return new CardPay(myMoney);
				case PaymentWay.GooglePay:
					return new GooglePay(myMoney);
				default:
					throw new ArgumentException("Nema");
			}
		}
	}
}
