using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// 插入排序（已知元素找位置）
    /// </summary>
    public class InsertSort
    {
        public static void Sort(int[] arr)
        {            
            for (int i = 1; i < arr.Length; i++)
            {
                int iTemp = arr[i];
                //在已有排序中，找元素可以插入的位置
                //从已有排序的右到左循环，如果碰到的元素比将要插入的大，则将它右移一位
                //如果碰到比它小的，就终止循环（因为已有排序是有序的，再往左，只能比它更小）
                int j;
                for (j = i - 1; j >= 0 && arr[j] > iTemp; j--)
                {
                    arr[j + 1] = arr[j];
                }
                //将元素插入到找到额位置
                arr[j + 1] = iTemp;      
            }
        }
    }
}
