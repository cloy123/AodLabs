using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AOD2
{
    public class GnomeSort: Sort
    {
        public GnomeSort(List<int> items) : base(items, "Гномья сортировка") { }

        public override void SortItems()
        {
            ComparisonsCount = 0;
            SwapCount = 0;
            Timer = new Stopwatch();
            Timer.Start();
            var index = 1;
            var nextIndex = index + 1;
            while (index < Items.Count)
            {
                ComparisonsCount += 1;
                if (Items[index - 1] < Items[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(index - 1, index);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }
            Timer.Stop();
            Time = Timer.Elapsed;
        }
    }
}
