using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 约瑟夫环
/// </summary>
namespace JosephusRing
{
    class Program
    {
        static void Main(string[] args)
        {
            var kids = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //Josephus.KickoutByMath(kids, 3);

            var linkNode = Josephus.BuildLinkedList(kids);
            Josephus.KickoutByLink(linkNode);
            Console.Read();
        }
    }

    //使用双向链表
    public class JosephusNode
    {
        //public bool IsKickout
        //{
        //    get; set;
        //}

        public JosephusNode Prev
        {
            get;
            set;
        }

        public JosephusNode Next
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }
 
    }

    public class Josephus
    {
        public static void KickoutByLink(JosephusNode head)
        {
            #region 单循环链表的实现

            //var pre = head;
            //var curr = head;
            //int count = 1;
            //while (null != curr)
            //{
            //    if (count == 3)
            //    {
            //        Console.WriteLine("出圈{0}:", curr.Index);
            //        pre.Next = curr.Next;
            //        count = 0;
            //    }
            //    pre = curr;
            //    curr = curr.Next;
            //    count++;

            //    if (pre == curr)
            //    {
            //        Console.WriteLine("留下{0}:", curr.Index);
            //        break;
            //    }
            //}

            #endregion

            #region 双向循环链表的实现

            var curr = head;
            int count = 1;
            while (curr.Next != curr)
            {
                if (count == 3)
                {
                    Console.WriteLine("出圈{0}:", curr.Index);
                    curr.Prev.Next = curr.Next;
                    curr.Next.Prev = curr.Prev;
                    count = 0;
                }

                curr = curr.Next;
                count++;
            }

            Console.WriteLine("留下{0}:", curr.Index);

            #endregion
        }

        public static JosephusNode BuildLinkedList(List<int> kids)
        {
            var head = new JosephusNode()
            {
                Prev = null,
                Next = null,
                Index = 0
            };

            //声明临时节点，用于循环构建链表
            var tmp = head;

            //该临时节点与head相连
            head.Next = tmp;
            tmp.Prev = head;

            for (var i = 0; i < kids.Count(); i++)
            {
                if (i == 0)
                {
                    head.Index = kids[i];
                }
                else
                {
                    tmp.Next = new JosephusNode()
                    {
                        Prev = tmp,
                        Next = null,
                        Index = kids[i]
                    };
                    tmp = tmp.Next;
                }
            }

            //最后一个节点与head相连
            tmp.Next = head;
            head.Prev = tmp;

            return head;
        }

        /// <summary>
        /// 使用数学方法
        /// </summary>
        /// <param name="kids">人员集合</param>
        /// <param name="M">数到第几出列？</param>
        public static void KickoutByMath(List<int> kids, int M)
        {
            var i = M-1 % kids.Count;   
            //M%len 一定是第一个出列的人.比如总共有17个人，数到3出列，那第一个出列的一定是3（3%17=3）
            while (kids.Count > 1)
            {
                Console.WriteLine("{0} 出列", kids[i]);
                kids.RemoveAt(i);
                i = (i+M-1) % kids.Count;
            }
            Console.WriteLine("留下{0}", kids[i]);
        }
    }

}
