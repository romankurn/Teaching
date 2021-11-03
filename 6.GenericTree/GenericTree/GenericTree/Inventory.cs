using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTree
{
	/// <summary>
	/// Создать ограничение: "нельзя редактировать предшествующий уровень при работе с последующим"
	/// Понашвырять исключений
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	public class Inventory<TItem> where TItem : class
	{
		private static int _counter = 0;

		public List<Inventory<TItem>> Items { get; set; }
		public TItem Item { get; set; }

		public int Id { get; private set; }
		public InventoryType Type { get; set; }
		public string BoxName { get; private set; }

		public Inventory(InventoryType type, string boxName = null, TItem item = null)
		{
			Type = type;

			if (Type == InventoryType.Box)
			{
				if (string.IsNullOrEmpty(boxName))
					throw new BoxNameEmptyException();

				BoxName = boxName;
				Items = new List<Inventory<TItem>>();
			}
			else
			{
				if (item == null)
					throw new ItemNullException();
				Item = item;
			}

			Id = _counter;
			_counter++;
		}

		public void Push(Inventory<TItem> item)
		{
			if (item == null)
				throw new ItemNullException();

			if (Type == InventoryType.Box)
				Items.Add(item);
		}

		public void Pop(TItem item)
		{
			var index = 0;
			var exist = false;
			foreach (var inventiryItem in Items)
			{
				if (inventiryItem.Item.Equals(item))
				{
					exist = true;
					break;
				}
				index++;
			}

			if (exist)
				Items.RemoveAt(index);
		}

		public void Move(int targetId, int sourseId)
		{
			var targetItem = Items.FirstOrDefault(i => i.Id == targetId && i.Type == InventoryType.Box);
			var sourceItem = Items.FirstOrDefault(i => i.Id == sourseId);

			try
			{
				targetItem.Push(sourceItem);
			}
			catch (NullReferenceException)
			{
				throw new BoxNullException();
			}

			var index = 0;
			foreach (var inventiryItem in Items)
			{
				if (inventiryItem.Id == sourseId)
				{
					break;
				}
				index++;
			}
			Items.RemoveAt(index);
		}


		public TItem FindItem(TItem item)
		{
			TItem result = null;

			foreach (var itemInventory in Items.Where(i => i.Type == InventoryType.Item))
			{
				if (itemInventory.Item.Equals(item))
				{
					result = itemInventory.Item;
					Pop(itemInventory.Item);
					break;
				}
			}
			if (result != null)
				return result;

			foreach (var itemInventory in Items.Where(i => i.Type == InventoryType.Box))
			{
				result = itemInventory.FindItem(item);
			}
			return result;
		}

		public int? GetItemId(TItem item)
		{
			Inventory<TItem> result = null;

			foreach (var itemInventory in Items.Where(i => i.Type == InventoryType.Item))
			{
				if (itemInventory.Item.Equals(item))
				{
					result = itemInventory;
					break;
				}
			}
			if (result != null)
				return result.Id;

			return null;
		}

		public Inventory<TItem> FindBox(string boxName)
		{
			var box = Items.FirstOrDefault(box => box.BoxName == boxName);
			if (box == null)
				throw new BoxNullException();
			return box;
		}

		public void Scan(int level = 0)
		{
			var tabs = string.Concat(Enumerable.Repeat("   ", level));
			if (Type == InventoryType.Item)
			{
				Console.WriteLine($"{tabs}{Item}");
			}
			else
			{
				Console.WriteLine($"{tabs}{BoxName}");

				foreach (var inventoryItem in Items)
				{
					inventoryItem.Scan(level + 1);
				}
			}
		}
		
	}


}
