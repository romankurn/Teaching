namespace DataStructures
{
	public class Node<Type>
	{
		public Node(Type data)
		{
			Data = data;
		}

		public Type Data { get; set; }
		public Node<Type> Next { get; set; }
	}
}
