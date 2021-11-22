using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class BookGenre : Book
	{
		private string _genre;

		public string Genre
		{
			get 
			{
				return _genre; 
			}
			private set 
			{
				_genre = value;
			}
		}

		public BookGenre (string title, string authorsSurnameAndFirstName, double price, string genre) : base(title, authorsSurnameAndFirstName, price)
		{
			Genre = genre;
		}

		public void Print()
		{
			base.Print();
			Console.Write($", book genre: {Genre}");
		}

	}
}
