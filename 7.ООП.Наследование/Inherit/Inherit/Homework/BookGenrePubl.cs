using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class BookGenrePubl : BookGenre
	{
		protected string _publ;

		public string Publ 
		{ 
			get 
			{ 
				return _publ;
			} 
			private set 
			{ 
				_publ = value; 
			} 
		}

		public BookGenrePubl (string title, string authorsSurnameAndFirstName, double price, string genre, string publ) : base(title,authorsSurnameAndFirstName, price, genre)
		{
			Publ = publ;
		}

		public void Print()
		{
			base.Print();
			Console.Write($", book publisher: {Publ}");
		}
	}
}
