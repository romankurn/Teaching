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

		private List<Inventory<TItem>> _items;
		private TItem _item;

		public int Id { get; private set; }
		public InventoryType Type { get; set; }
		public string BoxName { get; private set; }

		public Inventory(InventoryType type, string boxName = null, TItem item = null)
		{
			Type = type;

			if (Type == InventoryType.Box)
			{
				//TODO: exception if boxName is empty
				BoxName = boxName;
				_items = new List<Inventory<TItem>>();
			}
			else
			{
				if (item == null)
					throw new ItemNullException("Item cannot be null");
				_item = item;
			}

			Id = _counter;
			_counter++;
		}

		public void Push(Inventory<TItem> item)
		{
			if (Type == InventoryType.Box)
				_items.Add(item);
		}

		public void Pop(TItem item)
		{
			var index = 0;
			var exist = false;
			foreach (var inventiryItem in _items)
			{
				if (inventiryItem._item.Equals(item))
				{
					exist = true;
					break;
				}
				index++;
			}

			if (exist)
				_items.RemoveAt(index);
		}

		public void Move(int targetId, int sourseId)
		{
			var targetItem = _items.FirstOrDefault(i => i.Id == targetId && i.Type == InventoryType.Box);
			var sourceItem = _items.FirstOrDefault(i => i.Id == sourseId);

			targetItem.Push(sourceItem);

			var index = 0;
			foreach (var inventiryItem in _items)
			{
				if (inventiryItem.Id == sourseId)
				{
					break;
				}
				index++;
			}
			_items.RemoveAt(index);
		}


		//public TItem Find(TItem item)
		//{
		//	TItem result = null;

		//	foreach (var itemInventory in _items.Where(i => i.Type == InventoryType.Item))
		//	{
		//		if (itemInventory._item.Equals(item))
		//		{
		//			result = itemInventory._item;
		//			Pop(itemInventory._item);
		//			break;
		//		}
		//	}
		//	if (result != null)
		//		return result;

		//	foreach (var itemInventory in _items.Where(i => i.Type == InventoryType.Box))
		//	{
		//		result = itemInventory.Find(item);
		//	}
		//	return result;
		//}

		public int? Find(TItem item)
		{
			Inventory<TItem> result = null;

			foreach (var itemInventory in _items.Where(i => i.Type == InventoryType.Item))
			{
				if (itemInventory._item.Equals(item))
				{
					result = itemInventory;
					break;
				}
			}
			if (result != null)
				return result.Id;

			return null;
		}

		public Inventory<TItem> Find(string boxName)
		{
			return _items.FirstOrDefault(box => box.BoxName == boxName);
		}
		
	}


}
