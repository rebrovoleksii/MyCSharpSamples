using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    public class TreeNode<T>
    {
        private T nodeValue;

        public T NodeValue
        {
            get { return nodeValue; }
            set { nodeValue = value; }
        }

        public List<TreeNode<T>> Nodes;

        public void DrawTree( TreeNode<T> tree)
        {
            Console.WriteLine(tree.NodeValue);
            if (tree.HasChildren())
            {

            }
            Console.WriteLine();
        }

        public bool HasChildren()
        {
            return true;
        }

        public int TreeDepth(TreeNode<T> tree)
        {
            var treeDepth = 1;

            if (tree.HasChildren())
            {
                treeDepth++;
                TreeDepth(tree.Nodes[0]);
            }

            return treeDepth;
               
        }


    }
}
