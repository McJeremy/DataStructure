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

    public class JosephusNode
    {
        public bool IsKickout
        {
            get; set;
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
            var pre = head;
            var curr = head;
            int count = 1;
            while (null!= curr)
            {
                if (count == 3)
                {
                    Console.WriteLine("出圈{0}:", curr.Index);                    
                    pre.Next = curr.Next;
                    count = 0;
                }
                pre = curr;
                curr = curr.Next;
                count++;

                if (pre==curr)
                {
                    Console.WriteLine("留下{0}:", curr.Index);
                    break;
                }
            }
        }

        public static JosephusNode BuildLinkedList(List<int> kids)
        {
            var head = new JosephusNode()
            {
                Next = null,
                Index = 0
            };
            var tmp = head;
            head.Next = tmp;
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
                        Next = null,
                        Index = kids[i]
                    };
                    tmp = tmp.Next;
                }
            }
            tmp.Next = head;
            //var tmp = head;
            //head.Next = tmp;
            //kids.ForEach(k =>
            //{
            //    tmp.Next= new JosephusNode()
            //    {
            //        Next = null,
            //        Index = k
            //    };
            //    tmp = tmp.Next;
            //});
            //tmp.Next = head;
            return head;

            //var list = new JosephusNode()
            //{
            //    ID = Guid.NewGuid().ToString(),
            //    Next = null,
            //    Index = 0
            //};
            //var current = new JosephusNode()
            //{
            //    ID = Guid.NewGuid().ToString(),
            //    Next = null,
            //    Index = 0
            //};
            //list.Next = current;
            ////for (int i = 0; i < kids.Count(); i++)
            ////{
            ////    if (i == 0)
            ////    {
            ////        current.Index = kids[i];
            ////    }
            ////    else
            ////    {
            ////        current.Next = new JosephusNode()
            ////        {
            ////            ID = Guid.NewGuid().ToString(),
            ////            Next = null,
            ////            Index = kids[i]
            ////        };

            ////        current = current.Next;
            ////    }
            ////}
            //kids.ForEach(kid =>
            //{
            //    current.Next = new JosephusNode()
            //    {
            //        ID = Guid.NewGuid().ToString(),
            //        Next = null,
            //        Index = kid
            //    };

            //    current = current.Next;
            //});

            //current.Next = list;

            //return list;
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
