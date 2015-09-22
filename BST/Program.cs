using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 二叉查找树、二叉搜索树、二叉排序树 说的都是这货！
/// </summary>
namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] datas = { 23, 45, 16, 37, 3, 99, 22 };

            var bst = new BST();
            foreach (var data in datas)
            {
                bst.BuildBST(data);
            }
            var bstRoot = bst.Root;

            Console.ReadLine();
            
        }
    }

    /// <summary>
    /// 二叉树的节点。一棵树有左孩子、右孩子、节点数据
    /// </summary>
    public class Node : IComparable
    {
        public int Data { get; set; }

        public Node LChild { get; set; }

        public Node RChild { get; set; }

        public int CompareTo(object obj)
        {
            int result = 0;
            Node n1 = obj as Node;

            if (n1.Data < this.Data)
            {
                result = 1;
            }
            else if (n1.Data > this.Data)
            {
                result = -1;
            }
            return result;
        }
    }

    public class BST
    {
        public Node Root
        {
            get;
            set;
        }            

        public void BuildBST(int data)
        {
            var node = new Node() { Data = data, LChild = null, RChild = null };
            if (null == Root)
            {
                Root = node;
                return;
            }

            var current = Root;
            Node parent = null;
            while (current != null)
            {
                parent = current;
                if (data < current.Data)
                {
                    current = current.LChild;
                    if (null == current)
                    {
                        parent.LChild = node;
                        break;
                    }
                }
                else
                {
                    current = current.RChild;
                    if (null == current)
                    {
                        parent.RChild = node;
                    }
                }

            }
        }
    }
}
