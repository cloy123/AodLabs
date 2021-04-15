using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AOD2
{
    class QuickSort : Sort
    {
        public QuickSort(List<int> items) : base(items, "Быстрая сортировка") { }

        public override void SortItems()
        {
            ComparisonsCount = 0;
            SwapCount = 0;
            Timer = new Stopwatch();
            Timer.Start();
            Items = quickSort(Items, 0, Items.Count - 1);
            Time = Timer.Elapsed;
        }

        private List<int> quickSort(List<int> items, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return items;
            }

            var pivotIndex = Partition(items, minIndex, maxIndex);
            items = quickSort(items, minIndex, pivotIndex - 1);
            items = quickSort(items, pivotIndex + 1, maxIndex);
            return items;
        }

        private int Partition(List<int> items, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                ComparisonsCount += 1;
                if (items[i] < items[maxIndex])
                {
                    pivot++;
                    Swap(pivot, i);
                }
            }

            pivot++;
            Swap(pivot, maxIndex);
            return pivot;
        }
    }
}
