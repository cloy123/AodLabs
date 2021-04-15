using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using AOD2.Tree;

namespace AOD2
{
    class Program
    {
        static double K = 50;
        static int L = 10;
        static double M = 4;

        static void Main(string[] args)
        {
            SortTest(100);
            SortTest(1000);
            SortTest(10000);
        }

        static void SortTest(int n)
        {
            Console.WriteLine($"n = {n}\n");
            List<int> randNumsArray = GetRandNums(n);
            List<int> randNumsWithRepetitions = GetRandNumsWithRepetitions(n, K, 1);
            List<int> numsWithSortArrays = GetNumsWithSortArrays(n, L);
            List<int> sortArrayWithRandNums = GetSortArrayWithRandNums(n, M);

            SortArray(randNumsArray, "Массив случайных чисел");
            SortArray(randNumsWithRepetitions, "Массив случайных чисел с большим количеством повторений одного элемента K = " + K + "%");
            SortArray(numsWithSortArrays, "Массив из L отсортированных подмассивов L = " + L);
            SortArray(sortArrayWithRandNums, "Отсортированный массив, в котором M% чисел заменены на случайные M = " + M + "%");
        }

        static void SortArray(List<int> items, string arrayName)
        {
            GnomeSort gnomeSort = new GnomeSort(new List<int>(items));
            gnomeSort.SortItems();
            TreeSort treeSort = new TreeSort(new List<int>(items));
            treeSort.SortItems();
            QuickSort quickSort = new QuickSort(new List<int>(items));
            quickSort.SortItems();
            PrintInfo(gnomeSort, arrayName);
            PrintInfo(treeSort, arrayName);
            PrintInfo(quickSort, arrayName);
        }

        static void PrintInfo(Sort sort, string arrayName)
        {
            Console.WriteLine($"{sort.Name}(n = {sort.Items.Count}):") ;
            Console.WriteLine($"{arrayName}(n = {sort.Items.Count}):");
            Console.WriteLine($"Операций сравнений: {sort.ComparisonsCount}");
            Console.WriteLine($"Операций обмена: {sort.SwapCount}");
            Console.WriteLine($"Время: {sort.Time.TotalMilliseconds}");
            Console.WriteLine();
        }

        static List<int> GetRandNums(int n)
        {
            List<int> items = new List<int>();
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                items.Add(random.Next(1, 10000));
            }
            return items;
        }

        static List<int> GetRandNumsWithRepetitions(int n, double percent, int number)
        {
            List<int> items = GetRandNums(n);
            int sumNumbers = Convert.ToInt32((Convert.ToDouble(n) * (percent / 100)));
            int step = n / sumNumbers;
            int i = 0;
            while (sumNumbers > 0 && i < n)
            {
                if (i % step == 0 && items[i] == number)
                {
                    sumNumbers -= 1;
                }
                else if (i % step == 0)
                {
                    items[i] = number;
                    sumNumbers -= 1;
                }
                else if (items[i] == number)
                {
                    sumNumbers -= 1;
                }
                i += 1;
            }
            return items;
        }

        static List<int> GetNumsWithSortArrays(int n, int numArrays)
        {
            List<int> items = new List<int>();
            int lengthSortArray = n / numArrays;
            List<int> L = GetSortArray(lengthSortArray);
            for(int i = 0; i < n; i++)
            {
                items.Add(L[i % (lengthSortArray)]);
            }
            return items;
        }

        static List<int> GetSortArray(int n)
        {
            List<int> items = new List<int>();
            for (int i = 0; i < n; i++)
            {
                items.Add(i + 1);
            }
            return items;
        }

        static List<int> GetSortArrayWithRandNums(int n, double percent)
        {
            List<int> items = GetSortArray(n);
            int sumRarndNums = Convert.ToInt32(Convert.ToDouble(n) * (percent / 100));
            int step = n / sumRarndNums;
            Random random = new Random();
            int i = 0;
            while(sumRarndNums > 0 && i < n)
            {
                if (i % step == 0)
                {
                    items[i] = random.Next(n, n + 1000);
                    sumRarndNums -= 1;
                }
                i += 1;
            }
            return items;
        }
    }
}