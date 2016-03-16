using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            var datas = new int[] { 1, 2, 3, 4, 5 };
            var startnode = new Node<int> { Data = datas[0] };
            var node = startnode;
            for (var i = 1; i < datas.Length; i++)
            {
                node.Next = new Node<int> { Data = datas[i] };
                node = node.Next;
            }

            //while (startnode != null)
            //{
            //    Console.Write(startnode.Data + " ");
            //    startnode = startnode.Next;
            //}

            #region 就地反转

            
            var head = new Node<int> { Next = null };
            var prev = head;
            var cur = startnode;

            while (cur != null)
            {
                prev.Next = cur.Next;
                cur.Next = head.Next;
                head.Next = cur;
                cur = prev.Next;
            }

            startnode = head.Next;
            while (startnode != null)
            {
                Console.Write(startnode.Data + " ");
                startnode = startnode.Next;
            }

            #endregion

            Console.Read();
        }
    }

    public class Node<T>
    {
        public T Data;
        public Node<T> Next
        {
            get; set;
        }
    }
}
