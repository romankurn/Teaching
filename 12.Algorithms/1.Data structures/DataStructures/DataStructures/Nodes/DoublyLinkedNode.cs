namespace DataStructures
{
	public class DoublyLinkedNode<Type>
	{
		public DoublyLinkedNode(Type data)
		{
			Data = data;
		}

		public Type Data { get; set; }
		public DoublyLinkedNode<Type> Next { get; set; }
		public DoublyLinkedNode<Type> Previous { get; set; }
	}
}
