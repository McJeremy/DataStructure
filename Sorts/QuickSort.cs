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
        /*概念及实现

思想：分治策略。

快速排序的原理：通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，然后再按此方法对这两部分数据分别进行快速排序。

"保证列表的前半部分都小于后半部分"就使得前半部分的任何一个数从此以后都不再跟后半部分的数进行比较了，大大减少了数字间的比较次数。
 

具体如下（实现为升序）：

设数组为a[0…n]。

1.        数组中找一个元素做为基准(pivot)，通常选数组的第一个数。

2.        对数组进行分区操作。使基准元素左边的值都小于pivot，基准元素右边的值都大于等于pivot。

3.        将pivot值调整到分区后的正确位置。

4.        将基准两边的分区序列，分别进行步骤1~3。（递归）

5.        重复步骤1~4，直到排序完成。

            快速排序的基本思想如下：
1.对数组进行随机化。
2.从数列中取出一个数作为中轴数(pivot)。
3.将比这个数大的数放到它的右边，小于或等于它的数放到它的左边。
4.再对左右区间重复第三步，直到各区间只有一个数。

            划分操作可以分为以下5个步骤：
1.获取中轴元素
2.i从左至右扫描，如果小于基准元素，则i自增，否则记下a[i]
3.j从右至左扫描，如果大于基准元素，则i自减，否则记下a[j]
4.交换a[i]和a[j]
5.重复这一步骤直至i和j交错，然后和基准元素比较，然后交换。

*/
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

                //找到小于基数的位置后，将这个数移动到i的位置，并将i的位置++.
                if (i < j)
                {
                    arr[i] = arr[j];
                    i++;
                }

                //从左到右选择大于基数的位置
                while (arr[i] <= tmp && i < j)
                {
                    i++;
                }
                if (i < j)
                {
                    arr[j] = arr[i];
                    j--;
                }

                //if (i < j)
                //{
                //    //把找到的两个数位置交换：小的换到左边，大的换到右边
                //    arr[i] = arr[i] + arr[j];
                //    arr[j] = arr[i] - arr[j];
                //    arr[i] = arr[i] - arr[j];
                //}
            }

            //这一轮循环完成后，i==j,此时把基数移动到最后的i位置
            //arr[iLeft] = arr[i];
            arr[i] = tmp;

            Sort(arr, iLeft, i - 1);
            Sort(arr, i + 1, iRight);
        }
    }
}
