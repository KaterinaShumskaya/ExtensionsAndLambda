using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Делегат условия поиска.
    /// </summary>
    /// <param name="number">Число.</param>
    /// <returns>Возвращает true, если число соответствует критерию заявленному в поиске.</returns>
    public delegate bool FindDelegate(int number);

    /// <summary>
    /// Расширения для массива.
    /// </summary>
    public static class ArrayExtensions
    {
        public static double GetSum(this double[] array)
        {
            return Enumerable.Sum(array);
        }

        public static int GetSum(this int[] array)
        {
            return Enumerable.Sum(array);
        }

        /// <summary>
        /// Поиск положительных элементов напрямую.
        /// </summary>
        /// <param name="arr">Исходный массив.</param>
        /// <returns>Массив положительных элементов.</returns>
        public static int[] FindPositive(this int[] arr)
        {
            return arr.Where(x => x > 0).ToArray();
        }

        /// <summary>
        /// Поиск положительных элементов через делегат.
        /// </summary>
        /// <param name="arr">Исходный массив.</param>
        /// <param name="findDelegate">Делегат для условия поиска.</param>
        /// <returns>Массив элементов, удовлетворяющих критерию поиска.</returns>
        public static int[] Find(this int[] arr, FindDelegate findDelegate)
        {
            return arr.Where(el => findDelegate(el)).ToArray();
        }

        /// <summary>
        /// Поиск положительных элементов через lambda-выражение.
        /// </summary>
        /// <param name="arr">Исходный массив.</param>
        /// <param name="condition">Lambda - выражение.</param>
        /// <returns>Массив элементов, удовлетворяющих критерию поиска.</returns>
        public static int[] FindPositive(this int[] arr, Func<int, bool> condition)
        {
            return arr.Where(condition).ToArray();
        }

        /// <summary>
        /// Поиск положительных элементов через LINQ-expression.
        /// </summary>
        /// <param name="arr">Исходный массив.</param>
        /// <param name="findDelegate"></param>
        /// <returns>Массив элементов, удовлетворяющих критерию поиска.</returns>
        public static int[] Find(this int[] arr)
        {
            return (from el in arr
                    where el > 0
                    select el).ToArray();
        }
    }
}
