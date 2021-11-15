using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTree
{
	public class Content<TItem> where TItem : class
	{
		private int _level;

		public List<Content<TItem>> Children { get; set; }
		public TItem Element { get; set; }

		public string Id { get; set; } = "0";

		public Content()
		{
			_level = 0;
			Children = new List<Content<TItem>>();
		}

		public Content(TItem item)
		{
			_level = 0;
			Children = new List<Content<TItem>>();
			Element = item;
		}

		public TItem this[string id]
		{
			get
			{
				return Find(id);
			}
			set
			{
				Replase(id, value);
			}
		}

		private bool Replase(string replasedId, TItem newElement)
		{
			if (Id == replasedId)
			{
				Element = newElement;
				return true;
			}

			foreach(var child in Children)
			{
				if (child.Replase(replasedId, newElement))
					return true;
			}
			return false;
		}

		private TItem Find(string id)
		{
			var foundElement = Children.FirstOrDefault(item => item.Id == id)?.Element;
			if (foundElement != null)
			{
				return foundElement;
			}
			else
			{
				foreach (var child in Children)
				{
					foundElement = child.Find(id);
					if (foundElement != null)
						return foundElement;
				}
			}
			return null;
		}

		public void Add(Content<TItem> item)
		{
			item._level = this._level + 1;
			item.Id = this._level > 0 ? $"{this.Id}.{Children.Count + 1}" : $"{Children.Count + 1}";

			Children.Add(item);
		}

		public void Scan(int level = 0)
		{
			var tabs = string.Concat(Enumerable.Repeat("   ", level));

			foreach (var child in Children)
			{
				Console.WriteLine($"{tabs}{child.Id} {child.Element}");
				child.Scan(level + 1);
			}
		}
	}
}
