using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
	internal class Program
	{
		static int _port = 8005; // Порт для приема входящих запросов
		static string _host = "127.0.0.1"; //localhost

		static void Main(string[] args)
		{
			var ipPoint = new IPEndPoint(IPAddress.Parse(_host), _port);

			try
			{
				while (true)
				{
					//create socket
					var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

					socket.Connect(ipPoint);

					Console.WriteLine("Введите пример");
					var expressionString = Console.ReadLine();
					var expression = new Expression(expressionString);
					var expressionJson = JsonConvert.SerializeObject(expression);

					var data = Encoding.Unicode.GetBytes(expressionJson);

					socket.Send(data);

					var builder = new StringBuilder();
					var bytes = 0;
					var buffer = new byte[256];

					do
					{
						bytes = socket.Receive(buffer);
						builder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
					}
					while (socket.Available > 0);

					Console.WriteLine(builder.ToString());

					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
