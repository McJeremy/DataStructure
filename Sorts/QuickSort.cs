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

            /*
            假设有数组：6, 1, 2, 7, 9, 3, 4, 5, 10, 8，需要做排序。
            step1：选择第一个元素 6作为基数，并将0,arr.Length分别作为开始
            step2:从右到左找小于基数的位置，找到的第一个是：5，位置是arr[7],那么，用它替换arr[i](也就是arr[0])数组是：  5,1, 2, 7, 9, 3, 4, 5, 10, 8,同时，将i++,此时，i=1,j=7
            step3: 从左到找大于基数的位置，找到的第一个是：7,位置是arr[3],那么，用它替换arr[j]（也就是arr[7])数组是： 5,1,2,7,9,3,4,7,10,8 ,同时，将j--,此时，i=3,j=6
            step4 :接着从右到左找小于基数的位置，找到的是：4，位置是arr[6],那么，用它替换arr[i](也就是arr[3])，数组是：  5,1,2,4,9,3,4,7,10,8,同时，将i++,此时，i=4,j=6
            step5: 接着从左到右找大于基数的位置，找到的是：9,位置是arr[4],那么，用它替换arr[j](也就是arr[6]），数组是： 5,1,2,4,9,3,9,7,10,8，同时，将j--,此时i=4,j=5
            step6: 接着从右到左找小于基数的位置，找到的是：3，位置是arr[5],那么，用它替换arr[i](也就是arr[4])，数组是：  5,1,2,4,3,3,9,7,10,8,同时，将i++,此时，i=5,j=5
            step7: 此时i==j，终止循环，并将基数6放入i的位置，结果数组是： 5,1,2,4,3,6,9,7,10,8
                可以看出，6左边的都是小于它的，右边都是大于它的。

               接下来，分别对6左右两边的，做同样的处理。最终完成排序。
            */

            while (i != j)
            {
                //从右到左选择小于基数的位置
                while (arr[j] >= tmp && i < j)
                {
                    j--;
                }
                //找到小于基数的，就将它与arr[i]交换，并将i加1
                arr[i++] = arr[j];                

                //从左到右选择大于基数的位置
                while (arr[i] <= tmp && i < j)
                {
                    i++;
                }
                arr[j--] = arr[i];

                //if (i < j)
                //{
                //    //把找到的两个数位置交换：小的换到左边，大的换到右边
                //    arr[i] = arr[i] + arr[j];
                //    arr[j] = arr[i] - arr[j];
                //    arr[i] = arr[i] - arr[j];
                //}
            }

            //当i与J重合，就说明完成一轮比较。则将基数放到它们重合的位置。
            //完成后，i左边的都是小于它的，右边都是大于它的。
            arr[i] = tmp;

            //接下来分别对左边右边的做同样的操作。
            Sort(arr, iLeft, i - 1);
            Sort(arr, i + 1, iRight);
        }
    }
}
