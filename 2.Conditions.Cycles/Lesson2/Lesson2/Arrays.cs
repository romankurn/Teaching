using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Lesson2
{
	public class Arrays
	{
		#region Одномерные массивы

		/// <summary>
		/// Преобразовывает элементы в строке, разделенные пробелами к указанному типу данных
		/// </summary>
		/// <typeparam name="TArray"></typeparam>
		/// <param name="line"></param>
		/// <returns></returns>
		public static TArray[] ConvertStringToArray<TArray>(string line)
		{
			var jarray = $"[{line.Replace(" ", ",")}]";

			return JsonConvert.DeserializeObject<TArray[]>(jarray);
		}

		#region Вывод

		/// <summary>
		/// Выводит все элементы массива.
		/// </summary>
		public static void Func1()
		{

		}

		/// <summary>
		/// Выводит все элементы массива в обратном порядке
		/// </summary>
		public static void Func2()
		{

		}

		/// <summary>
		/// Выводит чётные элементы массива
		/// </summary>
		public static void Func3()
		{

		}

		/// <summary>
		/// Выводит все элементы массива пока не встретится элемент -1
		/// </summary>
		public static void Func4()
		{

		}

		#endregion

		#region Добавление

		/// <summary>
		/// В массив добавляется элемент в конец
		/// </summary>
		public static void Func5()
		{ }

		/// <summary>
		/// В массив добавляется элемент в начало
		/// </summary>
		public static void Func6()
		{ }

		/// <summary>
		/// В массив добавляется элемент в позицию k
		/// </summary>
		public static void Func7()
		{ }

		#endregion

		#region Удаление

		/// <summary>
		/// Из массива удаляется элемент с конца
		/// </summary>
		public static void Func8()
		{ }

		/// <summary>
		/// Из массива удаляется элемент с начала
		/// </summary>
		public static void Func9()
		{ }

		/// <summary>
		/// Из массива удаляется элемент с позиции k
		/// </summary>
		public static void Func10()
		{ }

		#endregion

		#region Изменение, обработка, наполнение

		/// <summary>
		/// Дано число любой степени. Выяснить, является ли оно палиндромом, т. е. таким числом,
		/// десятичная запись которого читается одинаково слева направо и справа налево.
		/// </summary>
		public static void Func14FromCycles()
		{
			//сделать без составления нового числа
		}

		/// <summary>
		/// Заменить все элементы на четной позиции числом 2, на нечетной: 1
		/// </summary>
		public static void Func11()
		{ }

		/// <summary>
		/// Заменить все положительные числа цифрой 1, отрицательные: -1
		/// </summary>
		public static void Func13()
		{ }

		/// <summary>
		/// Заменить все элементы массива суммой соседних элементов.
		/// Например [1,5,3,8,5,2,-9,100,0] -> [5,4,13,8,10,-4,102,-9,100]
		/// </summary>
		public static void Func14()
		{ }

		/// <summary>
		/// Найти минимальный и максимальный элемент массива
		/// </summary>
		public static void Func15()
		{ }

		/// <summary>
		/// Сортировка массива по возрастанию/убыванию
		/// </summary>
		public static void Func16()
		{ }

		/// <summary>
		/// Посчитать количество повторяющихся элементов в массиве
		/// [1,2,3,5,1,2,6,7,5,1] -> 3: 1,2,5
		/// </summary>
		public static void Func17()
		{ }

		/// <summary>
		/// Посчитать количество уникальных элементов в массиве
		/// </summary>
		public static void Func22()
		{ }

		/// <summary>
		/// Создание массива из двух массивов. В итоговом массиве должны быть элементы первого и второго массива
		/// </summary>
		public static void Func18()
		{

		}

		/// <summary>
		/// Даны 2 массива. Найти в первом массиве первое число, которое встречается во втором массиве.
		/// Если такого числа нет, выдать сообщение
		/// </summary>
		public static void Func19()
		{

		}

		/// <summary>
		/// Даны 2 массива. Создать массив из элементов, которые содержатся как в первом так и во втором массивах.
		/// [1,2,3,1,2,3,4,5], [11,12,13,1,1,2,4,20] -> [1,2,4]
		/// </summary>
		public static void Func20()
		{

		}

		/// <summary>
		/// Даны 2 массива. Создать третий, в котором будут не повторяющиеся элементы первого и второго массива.
		/// [1,2,3,1,2,3], [2,3,4,2,3,4] -> [1,4]
		/// </summary>
		public static void Func21()
		{

		}

		/// <summary>
		/// Даны 2 массива: массив слов и массив индексов.
		/// Остортировать первый массив, согласно индексам во втором массиве.
		/// Проверить массив индексов на корректность
		/// ["word1","word2","word3"], [3,1,2] -> ["word3","word1","word2"]
		/// </summary>
		public static void Func23()
		{

		}

		/// <summary>
		/// В первом массиве даны имена людей, во втором их возраста соотвественно.
		/// Отсортировать данные
		/// 1) По именам по алфавиту
		/// 2) По возрасту по возрастанию
		/// </summary>
		public static void Func24()
		{

		}

		#endregion

		#endregion


		#region Обработка строки как массива символов

		/// <summary>
		/// Посчитать количество цифр в строке.
		/// 1) вручную
		/// 2) с помощью char.IsDigit()
		/// 3) с помощью методов LINQ
		/// </summary>
		public static void Func25()
		{
		}

		/// <summary>
		/// Посчитать количество букв в строке.
		/// 1) вручную
		/// 2) с помощью char.IsLetter()
		/// 3) с помощью методов LINQ
		/// </summary>
		public static void Func26()
		{
		}

		/// <summary>
		/// Посчитать количество чисел в строке
		/// (если в строке "dsfg12 gdfg3 sd4567" - 7 цифр, то чисел здесь всего 3)
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func27()
		{
		}

		/// <summary>
		/// Посчитать количество слов в строке, считая, что слова разделены пробелами
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func29()
		{
		}

		/// <summary>
		/// Посчитать количество слова word, вводимого с клавиатуры, в строке
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func30()
		{
		}

		/// <summary>
		/// Заменить все слова в строке, начинающиеся с буква 'а' их перевертышами
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func31()
		{
		}

		/// <summary>
		/// Найти порядковый номер первого слова в строке, в котором встречается буква 'r'
		/// *Показать, как это делается через LINQ
		/// </summary>
		public static void Func32()
		{
		}

		/// <summary>
		/// Заменить в строке все последовательности пробелов больше 1 на 1 пробел, а пробелы в начале и конце удалить
		/// *Показать как это делается через регулярки
		/// </summary>
		public static void Func33()
		{
		}

		/// <summary>
		/// Проверить правильность открывающихся и закрывающихся круглых скобок в строке
		/// "df( sdf ( sdf ) ff ) dfg (fsdf)" - валидно.
		/// "fff)sdfsdf( sdfsd (sdf)sadf" - невалидно
		/// </summary>
		public static void Func34()
		{
		}

		/// <summary>
		/// Дана последовательность литер, имеющая следующий вид: d1+-d2+-d3+-...+-dn (где di цифра от 0 до 9).
		/// Последовательность заканчивается знаком «=».
		/// Вычислить значение алгебраической суммы.
		/// </summary>
		public static void Func35()
		{

		}

		#endregion


		#region Двумерные массивы - Comming soon...

		/// <summary>
		/// Заполнить матрицу размера rows*columns рандомными числами от min до max 
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int[][] CreateMatrix(int rows, int columns, int min, int max)
		{

		}

		/// <summary>
		/// Напечатать двумерный массив
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="matrix"></param>
		public static void PrintMatrix<T>(T[][] matrix)
		{

		}

		/// <summary>
		/// Создать двумерный массив вида:
		/// а)
		/// 1
		/// 2 2
		/// 3 3 3
		/// 4 4 4 4
		/// 5 5 5 5 5
		///
		/// б)
		/// 20 21 22 23 24
		///	19 20 21 22
		/// 18 19 20
		/// 17 18
		/// 16
		///
		/// в)
		/// 1
		/// 4
		/// 1 2 3
		/// 16
		/// 1 2 3 4 5
		/// 36
		/// 1 2 3 4 5 6 7
		/// 64
		/// 1 2 3 4 5 6 7 8 9
		/// 100
		/// 
		/// 
		/// </summary>
		public static void Func21FromCycles()
		{

		}

		/// <summary>
		/// Отсортировать четные столбцы по возрастанию
		/// нечетные - по убыванию
		/// </summary>
		public static void MatrixFunc1()
		{

		}

		/// <summary>
		/// Отсортировать все элементы матрицы по возрастанию
		/// </summary>
		public static void MatrixFunc2()
		{

		}

		/// <summary>
		/// Поменять местами макимальный элемент первой матрицы
		/// с минимальным элементом второй матрицы
		/// </summary>
		public static void MatrixFunc8()
		{

		}

		/// <summary>
		/// Поменять местами столбцы с макимальным и минимальным элемантами
		/// </summary>
		public static void MatrixFunc7()
		{

		}

		/// <summary>
		/// Транспонировать матрицу
		/// </summary>
		public static void MatrixFunc3()
		{

		}

		/// <summary>
		/// Составить массив из максимальных элементов каждого столбца матрицы
		/// Получинным массивом заменить строку с минимальным элементом
		/// </summary>
		public static void MatrixFunc4()
		{

		}

		/// <summary>
		/// Составить массив произведений диагоналей квадратной матрицы нечетной размерности
		/// Полученным массивом заменить среднюю строку и средний столбец
		/// </summary>
		public static void MatrixFunc5()
		{

		}

		/// <summary>
		/// Выполнить преобразование над матрицей (см файл)
		/// в которой размерности кратны 3
		/// </summary>
		public static void MatrixFunc6()
		{

		}

		#endregion
	}
}
