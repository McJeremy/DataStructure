using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Node : IComparable
    {
        public int Data
        {
            get; set;
        }

        public Node LChild
        {
            get; set;
        }

        public Node RChild
        {
            get; set;
        }

        public int Height
        {
            get              ; set;
        }

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

        public override string ToString()
        {
            return string.Format("节点的值是:{0}", this.Data);
        }
    }

    public class AVLTree
    {
        public Node Root
        {
            get;
            set;
        }

        public Node BuildBST(int[] arrDatas)
        {
            foreach (var arrData in arrDatas)
            {
                BuildAVL(arrData);
            }

            return this.Root;
        }

        private void BuildAVL(int data)
        {
            var node = new Node() { Data = data, LChild = null, RChild = null, Height = 0 };
            if (null == Root)
            {
                Root = node;
                return;
            }

            var current = Root;
            while (null != current)
            {
                if (data < current.Data)
                {
                    if (null == current.LChild)
                    {
                        current.LChild = node;
                        break;
                    }
                    else
                    {
                        current = current.LChild;
                    }
                }
                else
                {
                    if (null == current.RChild)
                    {
                        current.RChild = node;
                        break;
                    }
                    else
                    {
                        current = current.RChild;
                    }
                }
            }
        }
    }
}
