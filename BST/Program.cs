/*
    author : xuzz@2015-09-23
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 二叉查找树、二叉搜索树、二叉排序树 说的都是这货！
/// 
/// 相对较少的值保存在左节点上，较大的值保存在右节点中
/// 这使得查找比较方便。
/// </summary>
namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] datas = { 23, 45, 16, 37, 3, 99, 22 };

            var bst = new BST();
            //foreach (var data in datas)
            //{
            //    bst.BuildBST(data);
            //}

            //var bstRoot = bst.Root;
            var bstRoot = bst.BuildBST(datas);

            Console.WriteLine("中序遍历：");
            bst.InOrder(bstRoot);

            Console.WriteLine("\r\n先序遍历：");
            bst.PreOrder(bstRoot);

            Console.WriteLine("\r\n后序遍历：");
            bst.PostOrder(bstRoot);

            Console.WriteLine("\r\n最小值：");
            Console.Write(bst.FindMin());

            Console.WriteLine("\r\n最小值节点：");
            Console.Write(bst.FindMinNode());

            Console.WriteLine("\r\n最大值：");
            Console.Write(bst.FindMax());

            Console.WriteLine("\r\n最大值节点：");
            Console.Write(bst.FindMaxNode());

            Console.WriteLine("\r\n查找指定值：");
            Console.Write(bst.FindNode(45));

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

        public override string ToString()
        {
            return string.Format("节点的值是:{0}", this.Data);
        }
    }

    public class BST
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
                BuildBST(arrData);
            }

            return this.Root;
        }

        private void BuildBST(int data)
        {
            var node = new Node() { Data = data, LChild = null, RChild = null };
            if (null == Root)
            {
                Root = node;
                return;
            }

            //指向当前节点。从根节点开始查找可以插入的位置。
            //如果需要创建的值小于该节点，则往当前节点的左子树查找。否则往右子树查找。
            //如果在左子树查找，且左子树的LChlid为空，说明这就是需要插入的位置
            //右子树也是同样的道理
            var current = Root;
            while (current != null)
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

        /// <summary>
        /// 中序遍历(先输出根节点，再输出左子树，最后输出右子树）
        /// 中序遍历输出的顺序总是有序的。
        /// </summary>
        public void InOrder(Node node)
        {
            if (null != node)
            {

                InOrder(node.LChild);

                Console.Write(node.Data+",");

                InOrder(node.RChild);    
                            
            }
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PreOrder(Node node)
        {
            if (null != node)
            {
                Console.Write(node.Data+",");

                PreOrder(node.LChild);

                PreOrder(node.RChild);
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PostOrder(Node node)
        {
            if (null != node)
            {
                PostOrder(node.LChild);
                PostOrder(node.RChild);
                Console.Write(node.Data + ",");
            }
        }

        /// <summary>
        /// 查找最小值，最小值总是在左子树的最后一个节点
        /// </summary>
        /// <returns></returns>
        public int FindMin()
        {
            var current = Root;
            while (null != current.LChild)
            {
                current = current.LChild;
            }

            return current.Data;
        }

        /// <summary>
        /// 最小值节点
        /// </summary>
        /// <returns></returns>
        public Node FindMinNode()
        {
            var current = Root;
            while (null != current.LChild)
            {
                current = current.LChild;
            }
            return current;
        }

        /// <summary>
        /// 查找最大值。最大值总是在右子树的最后一个节点
        /// </summary>
        /// <returns></returns>
        public int FindMax()
        {
            var current = Root;
            while (null != current.RChild)
            {
                current = current.RChild;
            }
            return current.Data;
        }

        /// <summary>
        /// 寻找最大值所在的节点
        /// </summary>
        /// <returns></returns>
        public Node FindMaxNode()
        {
            var current = Root;
            while (null != current.RChild)
            {
                current = current.RChild;
            }
            return current;
        }
        
        /// <summary>
        /// 根据传入的值，查找节点。
        /// 
        /// 在二叉树上查找给定值，需要比较该值和当前节点上的值得大小。通过比较，就能确定如果给定值不在当前节点时，就要向左遍历和向右遍历了。
        /// </summary>
        /// <param name="iData"></param>
        /// <returns></returns>
        public Node FindNode(int iData)
        {
            var current = Root;
            while (null != current)
            {
                if (current.Data == iData)
                {
                    return current;
                }
                //如果当前节点的值比需要查找的小，说明需要查找的节点在当前节点的右边
                if (current.Data < iData)
                {
                    current = current.RChild;
                }
                //如果当前节点的值比需要查找的大，说明需要查找的节点在当前节点的左边
                else if (current.Data > iData)
                {
                    current = current.LChild;
                }
            }
            return null;
        }
    }
}
