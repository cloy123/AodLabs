using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AOD2
{
    public abstract class Sort
    {
        public int ComparisonsCount = 0;
        public int SwapCount = 0;
        protected Stopwatch Timer = new Stopwatch();
        public List<int> Items;
        public TimeSpan Time;
        public string Name;

        protected void Swap(int positionA, int positionB)
        {
            if (positionA < Items.Count && positionB < Items.Count)
            {
                SwapCount++;
                var temp = Items[positionA];
                Items[positionA] = Items[positionB];
                Items[positionB] = temp;
            }
        }

        public Sort(List<int> array, string name)
        {
            Name = name;
            Items = array;
        }

        public abstract void SortItems();
    }
}
