using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    using System.Diagnostics;

    class Program
    {
        private static bool IsPositive(int number)
        {
            return number > 0;
        }

        static void Main(string[] args)
        {
            FindDelegate findDelegate = IsPositive;
            var arr = new int[10];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            Console.WriteLine("Сумма элементов массива = {0}", arr.GetSum());

            var stopwatch = new Stopwatch();
            var arrForFind = new int[1000000];
            var k = -100;
            for (var i = 0; i < arr.Length; i++){
                arrForFind[i] = k;
                k++;
            }

            var tArr = new long[50];
            for (var i = 0; i < tArr.Length; i++)
            {
                stopwatch.Restart();
                arrForFind.FindPositive();
                stopwatch.Stop();
                tArr[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(tArr);
            Console.WriteLine("Время поиска напрямую = {0} ms", tArr[(tArr.Length / 2)]);

            stopwatch.Reset();
            for (var i = 0; i < tArr.Length; i++)
            {
                stopwatch.Restart();
                arrForFind.Find(findDelegate);
                stopwatch.Stop();
                tArr[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(tArr);
            Console.WriteLine("Время поиска с помощью метода, в который передаётся делегат = {0} ms", tArr[(tArr.Length / 2)]);

            FindDelegate findDelegate2 = delegate(int number) { return number > 0; };
            stopwatch.Reset();
            for (var i = 0; i < tArr.Length; i++)
            {
                stopwatch.Restart();
                arrForFind.Find(findDelegate2);
                stopwatch.Stop();
                tArr[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(tArr);
            Console.WriteLine("Время поиска с помощью метода, в который передаётся делегат в виде анонимного метода = {0} ms", tArr[(tArr.Length / 2)]);

            stopwatch.Reset();
            for (var i = 0; i < tArr.Length; i++)
            {
                stopwatch.Restart();
                arrForFind.FindPositive(x => x > 0);
                stopwatch.Stop();
                tArr[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(tArr);
            Console.WriteLine("Время поиска с помощью метода, в который передаётся lambda = {0} ms", tArr[(tArr.Length / 2)]);

            stopwatch.Reset();
            for (var i = 0; i < tArr.Length; i++)
            {
                stopwatch.Restart();
                arrForFind.Find();
                stopwatch.Stop();
                tArr[i] = stopwatch.ElapsedMilliseconds;
            }
            Array.Sort(tArr);
            Console.WriteLine("Время поиска с помощью LINQ выражения = {0}", tArr[(tArr.Length / 2)]);

            Console.WriteLine("Введите строку");
            var str = Console.ReadLine();
            Console.WriteLine(
                str.IsPositiveNumber()
                    ? "Строка является положительным целым числом."
                    : "Строка не является положительным целым числом.");
            Console.ReadKey();
        }
    }
}
