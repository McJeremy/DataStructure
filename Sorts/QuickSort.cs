using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// 快速排序
    /// </summary>
    public class QuickSort
    {
        public static void Sort(int[] arr,int iLeft, int iRight)
        {
            int i, j, tmp;
            if (iLeft > iRight)
            {
                return;
            }

            i = iLeft;
            j = iRight;
            tmp = arr[iLeft];   //选取第一个作为比较基数

            while (i != j)
            {
                //从右到左选择小于基数的位置
                while (arr[j] >= tmp && i < j)
                {
                    j--;
                }

                //从左到右选择大于基数的位置
                while (arr[i] <= tmp && i < j)
                {
                    i++;
                }

                if (i < j)
                {
                    //把找到的两个数位置交换：小的换到左边，大的换到右边
                    arr[i] = arr[i] + arr[j];
                    arr[j] = arr[i] - arr[j];
                    arr[i] = arr[i] - arr[j];
                }
            }

            //这一轮循环完成后，把基数移动到最后的i位置
            arr[iLeft] = arr[i];
            arr[i] = tmp;

            Sort(arr, iLeft, i - 1);
            Sort(arr, i + 1, iRight);
        }
    }
}
