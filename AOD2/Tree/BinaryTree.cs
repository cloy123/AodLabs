using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOD2.Tree
{
    public class BinaryTree
    {
        protected Node root;
        public int ComparisonsCount = 0;
        public int Count { get; protected set; }

        public BinaryTree(List<int> items)
        {
            AddRange(items);
        }

        public void AddRange(List<int> items)
        {
            foreach (int value in items)
                Add(value);
        }

        public List<int> Inorder()
        {
            List<int> items = new List<int>();

            var stack = new Stack<Node>();
            var node = root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    items.Add(node.Value);
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
            return items;
        }

        public void Add(int item)
        {
            var node = new Node(item);

            if (root == null)
                root = node;
            else
            {
                Node current = root, parent = null;

                while (current != null)
                {
                    parent = current;
                    ComparisonsCount++;
                    if (item < current.Value)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                ComparisonsCount++;
                if (item < parent.Value)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }
    }
}