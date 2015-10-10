using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 1, 5, 9, 0, 6, 8, 7, 3 };

            BinaryHeap heap = new BinaryHeap(arr);
            Console.Write("上浮方式（与父节点比较）：");
            heap.BuildWithSwim();
            heap.Heap.ToList().ForEach(x =>
            {
                Console.Write(x + ",");
            });
            Console.Write("\r\n下沉方式（父节点与两个子节点中的大者比较）：");
            heap = new BinaryHeap(arr);
            heap.BuildWithSink();
            heap.Heap.ToList().ForEach(x =>
            {
                Console.Write(x + ",");
            });
            /*
                最终的二叉(大顶)堆大约是这样的：
                          9
                      7       8
                    5   0   2   6
                  1  3
            */
            Console.Read();
        }
    }

    /// <summary>
    /// 二叉堆（使用数组实现）
    /// </summary>
    public class BinaryHeap
    {
        //位置0使用
        private int[] _heap;

        public BinaryHeap(int[] arr)
        {
            _heap = arr;
        }

        public int[] Heap
        {
            get
            {
                return _heap;
            }
        }

        /// <summary>
        /// 将堆中i1位置的值和i2位置的值交换
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        private void Swap(int i1, int i2)
        {
            _heap[i1] = _heap[i1] + _heap[i2];
            _heap[i2] = _heap[i1] - _heap[i2];
            _heap[i1] = _heap[i1] - _heap[i2];
        }

        /// <summary>
        /// 上浮方式创建堆（也就是依次与父节点比较，如果大于父节点，则与父节点交换位置）
        /// </summary>
        public void BuildWithSwim()
        {
            //从左边到右边依次与父节点比较
            for (var i = 0; i < _heap.Length; i++)
            {
                //思维上，如果当前i值是3，那么可以想象成该数组后面的值都还没有
                //现在3就是数组末尾，那么它一定是叶子节点，它需要与父级不停的比较
                var k = i;
                //一直比较到父节点的值比较大为止（有序）
                while (k >= 0 && _heap[k] > _heap[(k-1) / 2])
                {
                    Swap(k, (k-1) / 2);
                    k = (k - 1) / 2;
                }
            }
        }

        /// <summary>
        /// 下沉方式创建堆
        /// </summary>
        public void BuildWithSink()
        {
            //下沉方式比较特殊的是，一个父节点有两个子节点，这个时候就需要先查找到子节点中哪个的值大一些
            //再将父节点与值大的那一个交换位置
            for (var i = _heap.Length / 2; i >= 0; i--)
            {
                var maxIndex = -1;

                //注意，由于数组使用了0,位置，所以子节点的位置分别是2*i+1和2*i+2
                //如果不使用，则是2*i,2*i+1
                while ((i * 2 + 1) < _heap.Length - 1)
                {
                    if (_heap[i * 2 + 1] < _heap[i * 2 + 2])
                    {
                        maxIndex = i * 2 + 2;
                    }
                    else
                    {
                        maxIndex = i * 2 + 1;
                    }

                    if (_heap[i] > _heap[maxIndex])
                    {
                        break;
                    }

                    Swap(i, maxIndex);

                    i = maxIndex;
                }
            }
        }
    }
}
