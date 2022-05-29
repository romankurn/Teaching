using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
	internal class Program
	{
		static int _port = 8005; // Порт для приема входящих запросов
		static string _host = "127.0.0.1"; //localhost

		static void Main(string[] args)
		{
			var ipPoint = new IPEndPoint(IPAddress.Parse(_host), _port); 

			//create socket
			var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				//Связываем сокет с локальной точкой, по которой будем слушать данные (задаем концу сокета наш адрес)
				listenSocket.Bind(ipPoint);

				listenSocket.Listen(10);

				Console.WriteLine("Ждемс..");

				while (true)
				{
					var handler = listenSocket.Accept();

					var builder = new StringBuilder();
					var bytes = 0;
					var data = new byte[256];

					do
					{
						bytes = handler.Receive(data);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					}
					while (handler.Available > 0);

					Console.WriteLine("От клиента получено сообщение:");
					var expression = JsonConvert.DeserializeObject<Expression>(builder.ToString());
					Console.WriteLine(builder.ToString()); //сделать красивые стринги

					var answer = "";

					if (Enum.TryParse<Operation>(expression.Operation, out var operation))
					{
						double result = 0;
						
						switch (operation)
						{
							case Operation.Addition:
								result = expression.Value1 + expression.Value2;
								break;

							case Operation.Subtraction:
								result = expression.Value1 - expression.Value2;
								break;

							case Operation.Multiplication:
								result = expression.Value1 * expression.Value2;
								break;

							case Operation.Division:
								result = expression.Value1 / expression.Value2;
								break;

							case Operation.Pow:
								result = Math.Pow(expression.Value1, expression.Value2);
								break;
						}

						answer = result.ToString();
					}					
					else
					{
						answer = "Неверная операция";
					}
					
					data = Encoding.Unicode.GetBytes(answer);
					handler.Send(data);

					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
