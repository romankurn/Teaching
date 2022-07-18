using System;

namespace Payment
{
	internal class Program
	{
		static CashPay _cash;
		static CardPay _card;
		static GooglePay _gPay;

		static double _cashMoney = 100;
		static double _cardMoney = 500;
		static double _gPayMoney = 300;

		static PaymentFactory _paymentFactory = new PaymentFactory();

		static CashRegister _cashRegister;

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			_cashRegister = new CashRegister(100000);

			_cash = new CashPay(_cashMoney);
			_card = new CardPay(_cardMoney);
			_gPay = new GooglePay(_gPayMoney);

			PayViaPaymentWay(PaymentWay.Cash, 245);
			PayViaPaymentWay(PaymentWay.Card, 245);

			PayViaPaymentWay2(PaymentWay.Cash, 245);
			PayViaPaymentWay2(PaymentWay.Card, 245);
		}

		static void PayViaPaymentWay(PaymentWay way, double requiredMoney)
		{
			switch (way)
			{
				case PaymentWay.Card:
					_cashRegister.GetMoney(_card, requiredMoney);
					break;

				case PaymentWay.Cash:
					_cashRegister.GetMoney(_cash, requiredMoney);
					break;

				case PaymentWay.GooglePay:
					_cashRegister.GetMoney(_gPay, requiredMoney);
					break;
			}
				
		}

		static void PayViaPaymentWay2(PaymentWay way, double requiredMoney)
		{
			var paymentWay = _paymentFactory.GetPaymentWay(way, requiredMoney);
			_cashRegister.GetMoney(paymentWay, requiredMoney);
		}
	}
}
