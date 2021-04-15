using AOD2.Tree;
using System.Collections.Generic;
using System.Diagnostics;

namespace AOD2
{
    class TreeSort : Sort
    {
        public TreeSort(List<int> items) : base(items, "Сортировка деревом") { }

        public override void SortItems()
        {
            SwapCount = 0;
            ComparisonsCount = 0;
            Timer = new Stopwatch();
            Timer.Start();
            BinaryTree tree = new BinaryTree(Items);
            Items = new List<int>(tree.Inorder());
            Timer.Stop();
            Time = Timer.Elapsed;
            ComparisonsCount = tree.ComparisonsCount;
        }
    }
}
