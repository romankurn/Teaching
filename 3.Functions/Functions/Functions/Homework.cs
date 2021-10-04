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
		public static string Task2(string str)
		{
			var charsArray = new char[str.Length];
			charsArray = str.ToCharArray();
			var charIndex = 0;

			if (charsArray[charIndex] == '_')
			{
				var newCharsArray = new char[charsArray.Length - 1];
				var newCharsCounter = 0;

				while (charIndex < charsArray.Length - 1)
				{
					if (charsArray[charIndex] == '_')
					{
						newCharsArray[newCharsCounter++] = char.ToUpper(charsArray[++charIndex]);
					}
					else if (charsArray[charIndex + 1] != '_')
					{
						newCharsArray[newCharsCounter++] = charsArray[++charIndex];
					}
					else
					{
						newCharsArray[newCharsCounter++] = ' ';
						charIndex++;
					}
				}
				StringBuilder sb = new StringBuilder();
				foreach (char ch in newCharsArray)
					sb.Append(ch);
				str = sb.ToString();

				return str;
			}
			else
			{
				var newCharsArray = new char[charsArray.Length * 2];
				var newCharsCounter = 1;

				newCharsArray[0] = char.ToUpper(charsArray[0]);

				while (charIndex < charsArray.Length - 1)
				{
					if (char.IsUpper(charsArray[charIndex + 1]))
					{
						newCharsArray[newCharsCounter++] = ' ';
						newCharsArray[newCharsCounter++] = charsArray[++charIndex];

					}
					else
					{
						newCharsArray[newCharsCounter++] = charsArray[++charIndex];
					}
				}

				StringBuilder sb = new StringBuilder();
				foreach (char ch in newCharsArray)
					sb.Append(ch);
				str = sb.ToString();

				return str;
			}
		}

		public static void Task3(string theFirstNomber, string theSecondNomber) // реализация на 5 экранов вниз будет
		{
			bool theFirstNomberIsLonger = theFirstNomber.Length >= theSecondNomber.Length;

			var theFirstNomberDigitsCounter = 0;
			var theSecondNomberDigitsCounter = 0;
			var numbersSumCounter = 0;
			var numbersSum = new char[(theFirstNomberIsLonger == true ? theFirstNomber.Length + 1 : theSecondNomber.Length + 1)];

			if (theFirstNomber[0] != '-' && theSecondNomber[0] != '-')
			{
				if (theFirstNomberIsLonger)
				{
					while(theSecondNomberDigitsCounter < theSecondNomber.Length -1)
					{
						//int.Parse('7'.ToString())
						numbersSum[numbersSumCounter++] = (char)(int.Parse(theFirstNomber[theFirstNomberDigitsCounter++].ToString()) + Convert.ToInt32(Convert.ToString(theSecondNomber[theSecondNomberDigitsCounter++])));
					}
				}
			}
		}

		public static void Task4(string str)
		{
			
		}

		public static int GetMinWeight(int[][] field, int[][] weights, char[][] directions, int row, int column)
		{
			return 0;
		}

		public static void ConvertDirectionToPath(char[][] directions, byte[][] path, int row, int column)
		{ 
		}

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
