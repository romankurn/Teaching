using Lesson2;
using System;
using System.Text;

namespace Functions
{
	//See Homework.docx

	public class Homework
	{

		// tack 1 from Homework.docx
		//В строке найти первую последовательность цифр, прибавить к этому числу единицу
		//и заменить начальное число в строке полученным результатом. 
		public static string Task1(string str)
		{
			var digitsCounter = 1;
			var charsArray = new char[str.Length];
			charsArray = str.ToCharArray();

			for (var charIndex = 0; charIndex < charsArray.Length; charIndex++)
			{
				if (char.IsDigit(charsArray[charIndex]))
				{
					while (char.IsDigit(charsArray[charIndex + 1]))
					{
						charIndex++;
						digitsCounter++;
						if (charIndex >= charsArray.Length - 1)
							break;
					}
					while (true)
					{
						if (charsArray[charIndex] != '9')
						{
							charsArray[charIndex] = (char)(charsArray[charIndex] + 1);

							StringBuilder sb = new StringBuilder();
							foreach (char ch in charsArray)
								sb.Append(ch);
							str = sb.ToString();

							return str;
						}
						else if (digitsCounter == 1)
						{
							charsArray[charIndex] = '0';

							StringBuilder sb = new StringBuilder();
							foreach (char ch in charsArray)
								sb.Append(ch);
							str = sb.ToString();
							str = str.Insert(charIndex, "1").ToString();

							return str;
						}
						else
						{
							charsArray[charIndex--] = '0';
							digitsCounter--;
						}
					}
				}
			}
			return "There are no digits in the string";
		}

		/// <summary>
		/// Humanize string
		/// _User_Id
		/// user_Id
		/// User_id
		/// User_Id
		/// </summary>
		/// <param name="str">input parameter</param>
		/// <returns></returns>
		public static string Task2(string str) // repaired
		{
			var charsArray = str.ToCharArray();
			var newCharsArray = new char[charsArray.Length * 2];
			var newCharsCounter = 0;
			var charIndex = 0;

			if (char.IsLetter(charsArray[0]) && charsArray[0] != '_')
				newCharsArray[newCharsCounter++] = char.ToUpper(charsArray[charIndex++]);
			while (charIndex < charsArray.Length)
			{
				if (charsArray[charIndex] == '_')
				{
					newCharsArray[newCharsCounter++] = ' ';
					charIndex++;
					newCharsArray[newCharsCounter++] = char.ToUpper(charsArray[charIndex++]);
				}
				else if (char.IsUpper(charsArray[charIndex]))
				{
					newCharsArray[newCharsCounter++] = ' ';
					newCharsArray[newCharsCounter++] = charsArray[charIndex++];
				}
				else
				{
					newCharsArray[newCharsCounter++] = charsArray[charIndex++];
				}
			}
			StringBuilder sb = new StringBuilder();
			foreach (char ch in newCharsArray)
				sb.Append(ch);
			str = sb.ToString();
			str = str.Trim();

			return str;
		}

		public static void Task3(string theFirstNomber, string theSecondNomber)
		{
			bool theFirstNomberIsLonger = theFirstNomber.Length >= theSecondNomber.Length; // определил какое число длиннее и какие у них знаки
			bool theFirstNumberIsPositive = theFirstNomber[0] != '-';
			bool theSecondNumberIsPositive = theSecondNomber[0] != '-';

			var theFirstNomberdigits = new int[theFirstNumberIsPositive == true ? theFirstNomber.Length : theFirstNomber.Length - 1]; // определил длинну массивов
			var theSecondNumberDigits = new int[theSecondNumberIsPositive == true ? theSecondNomber.Length : theSecondNomber.Length - 1];
			var sum = new int[theFirstNomberdigits.Length > theSecondNumberDigits.Length ? theFirstNomberdigits.Length : theSecondNumberDigits.Length];

			if (theFirstNumberIsPositive)
			{
				for (var digitIndex = 0; digitIndex < theFirstNomber.Length; digitIndex++)
				{
					theFirstNomberdigits[digitIndex] = int.Parse((theFirstNomber[digitIndex]).ToString());
				}
			} // перекладываю цифры из строк в массивы интов
			else
			{
				for (var digitIndex = 1; digitIndex < theFirstNomber.Length; digitIndex++)
				{
					theFirstNomberdigits[digitIndex - 1] = int.Parse((theFirstNomber[digitIndex]).ToString());
				}
			}
			if (theSecondNumberIsPositive)
			{
				for (var digitIndex = 0; digitIndex < theSecondNomber.Length; digitIndex++)
				{
					theSecondNumberDigits[digitIndex] = int.Parse((theSecondNomber[digitIndex]).ToString());
				}
			}
			else
			{
				for (var digitIndex = 1; digitIndex < theSecondNomber.Length; digitIndex++)
				{
					theSecondNumberDigits[digitIndex - 1] = int.Parse((theSecondNomber[digitIndex]).ToString());
				}
			}

			var carryover = 0;

			if (theFirstNumberIsPositive && theSecondNumberIsPositive) // складываю два положительных числа
			{
				if (theFirstNomberIsLonger)
				{
					for (var firstDigitIndex = theFirstNomberdigits.Length - 1; firstDigitIndex >= 0; firstDigitIndex--)
					{
						if (true)
						{
							for (var secondDigitIndex = theSecondNumberDigits.Length - 1; secondDigitIndex >= 0; secondDigitIndex--)
							{
								if ((theFirstNomberdigits[firstDigitIndex] + theSecondNumberDigits[secondDigitIndex] + carryover) > 9)
								{
									sum[firstDigitIndex--] = theFirstNomberdigits[firstDigitIndex] + theSecondNumberDigits[secondDigitIndex] + carryover - 10;
									carryover = 1;
								}
								else
								{
									sum[firstDigitIndex--] = theFirstNomberdigits[firstDigitIndex] + theSecondNumberDigits[secondDigitIndex] + carryover;
									carryover = 0;
								}
							}
						}
						else
						{
							if (theFirstNomberdigits[firstDigitIndex] + carryover > 9)
							{
								sum[firstDigitIndex] = 0;
								carryover = 1;
							}
						}
					}

				}
			}








			var theFirstNomberDigitsCounter = 0;
			var theSecondNomberDigitsCounter = 0;
			var numbersSumCounter = 0;
			var numbersSum = new char[(theFirstNomberIsLonger == true ? theFirstNomber.Length + 1 : theSecondNomber.Length + 1)];

			if (theFirstNomber[0] != '-' && theSecondNomber[0] != '-')
			{
				if (theFirstNomberIsLonger)
				{
					while (theSecondNomberDigitsCounter < theSecondNomber.Length - 1)
					{
						//int.Parse('7'.ToString())
						numbersSum[numbersSumCounter++] = (char)(int.Parse(theFirstNomber[theFirstNomberDigitsCounter++].ToString()) + Convert.ToInt32(Convert.ToString(theSecondNomber[theSecondNomberDigitsCounter++])));
					}
				}
			}
		}

		public static void Task4()
		{
			Console.WriteLine("Enter the number of elements of the array");
			var n = Convert.ToInt32(Console.ReadLine());

			var array = new int[n];
			for (var elementIndex = 0; elementIndex < n; elementIndex++)
			{
				array[elementIndex] = elementIndex + 1;
			}

			array = Functions.Mix(array);
			Arrays.PrintArray(array);
		}


		#region Task5
		//Дано прямоугольное поле размером n*m клеток. Можно совершать шаги длиной в одну клетку вправо
		//или вниз. В каждой клетке записано некоторое натуральное число. Необходимо попасть из
		//верхней левой клетки в правую нижнюю. Вес маршрута вычисляется как сумма чисел со всех
		//посещенных клеток. Необходимо найти минимальный вес маршрута и отобразить сам маршрут в виде
		//матрицы из нулей и единиц.
		public static int[][] Task5()
		{
			Console.Write("Enter: row number: ");
			var row = Convert.ToInt32(Console.ReadLine());
			Console.Write("column number: ");
			var column = Convert.ToInt32(Console.ReadLine());
			Console.Write("min value: ");
			var min = Convert.ToInt32(Console.ReadLine());
			Console.Write("max value: ");
			var max = Convert.ToInt32(Console.ReadLine());

			var field = Arrays.CreateMatrix(row, column, min, max);
			var weights = Arrays.CreateMatrix(row, column, 0, 0);
			var directions = Arrays.CreateMatrix(row, column);
			Arrays.PrintMatrix(field);
			Console.WriteLine();

			GetMinWeight(field, weights, directions, row - 1, column - 1);

			Arrays.PrintMatrix(weights);
			Console.WriteLine();

			Arrays.PrintMatrix(directions);
			Console.WriteLine();

			Console.WriteLine();


			return field;
		}

		public static int GetWeightsMatrix(int[][] field, int row, int column)
		{
			int result = 0;

			if (row == 0 && column == 0)
				result = field[0][0];

			if (row == 0 && column != 0)
			{
				result = GetWeightsMatrix(field, row, column - 1);
			}
			else if (column == 0 && row != 0)
			{
				result = GetWeightsMatrix(field, row - 1, column);
			}
			else if (row != 0 && column != 0)
			{
				result = Math.Min(GetWeightsMatrix(field, row, column - 1), GetWeightsMatrix(field, row - 1, column));
			}

			field[row][column] = result;
			return result;
		}

		//public static int GetWeightsMatrix (int[][] field, int[][] WeightsMatrix, int row, int column)
		//{
		//	int result = 0;

		//	if (row == 0 && column == 0)
		//		result = field[0][0];

		//	if (row == 0 && column != 0)
		//	{
		//		result += GetWeightsMatrix(field, WeightsMatrix, row, column - 1);
		//	}
		//	else if (column == 0 && row != 0)
		//	{
		//		result += GetWeightsMatrix(field, WeightsMatrix, row - 1, column);
		//	}
		//	else if (row != 0 && column != 0)
		//	{
		//		result += Math.Min(GetWeightsMatrix(field, WeightsMatrix, row, column - 1), GetWeightsMatrix(field, WeightsMatrix, row - 1, column));
		//	}

		//	WeightsMatrix[row][column] = result;
		//	return result;
		//}

		public static int GetMinWeight(int[][] field, int[][] weights, char[][] directions, int row, int column)
		{
			int result = 0;

			if (row == 0 && column == 0)
			{
				result = field[0][0];
				directions[row][column] = '*';
			}

			if (row == 0 && column != 0)
			{
				result = GetMinWeight(field, weights, directions, row, column - 1) + field[row][column];
				directions[row][column] = 'l';
			}
			else if (column == 0 && row != 0)
			{
				result = GetMinWeight(field, weights, directions, row - 1, column) + field[row][column];
				directions[row][column] = 'u';
			}
			else if (row != 0 && column != 0)
			{
				result = Min(GetMinWeight(field, weights, directions, row, column - 1), GetMinWeight(field, weights, directions, row - 1, column), out int index) + field[row][column];
				directions[row][column] = index == 1 ? 'l' : 'u';
			}
			weights[row][column] = result;
			return result;
		}

		public static int Min(int a, int b, out int index)
		{
			if (a < b)
			{
				index = 1;
				return a;
			}

			index = 2;
			return b;
		}

		public static void ConvertDirectionToPath(char[][] directions, byte[][] path, int row, int column)
		{
		}
		#endregion

	}
	public class Recursion
	{
		#region task 1
		public static double cFunction1(int z)
		{
			return Math.Sqrt(Math.Abs(pFunction1(4, z) + hFunction1(6, z)));
		}

		public static double pFunction1(int indexP, int z)
		{
			if (indexP == 1)
				return Math.Sin(0.5);

			return (z * pFunction1(indexP - 1, z) * pFunction1(indexP - 1, z) + pFunction1(indexP - 1, z) + 2);
		}

		public static double hFunction1(int indexH, int z)
		{
			if (indexH == 1)
				return Math.Cos(0.5);

			return (3 * hFunction1(indexH - 1, z) / (2 * z));
		}
		#endregion
	}
}
