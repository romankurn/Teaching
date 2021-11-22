using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class Book
	{
		protected string _title;
		protected string _authorsSurnameAndFirstName;
		protected double _price;

		public string Title
		{
			get 
			{ 
				return _title; 
			}
			protected set 
			{ 
				_title = value; 
			}
		}
		public string AuthoritsSurnameAndFirstName
		{
			get 
			{ 
				return _authorsSurnameAndFirstName;
			}
			protected set
			{ 
				_authorsSurnameAndFirstName = value;
			}
		}

		public double Price
		{
			get 
			{ 
				return _price; 
			}
			protected set
			{ 
				_price = value; 
			}
		}

		public Book(string title, string authorsSurnameAndFirstName, double price)
		{
			Title = title;
			AuthoritsSurnameAndFirstName = authorsSurnameAndFirstName;
			Price = price;
		}

		public void Print()
		{
			Console.Write($"Book title: {Title}, author's surname and first name: {AuthoritsSurnameAndFirstName}, book price: {Price}");
		}
	}
}
