using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// 选择排序（已知位置找元素）
    /// </summary>
    public class SelectionSort
    {
        public static void Sort(int[] arr)
        {            
            for (int i = 0; i < arr.Length; i++)
            {
                int iSwapIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[iSwapIndex])
                    {
                        iSwapIndex = j;
                    }
                }

                if (iSwapIndex != i)
                {
                    arr[i] = arr[i] + arr[iSwapIndex];
                    arr[iSwapIndex] = arr[i] - arr[iSwapIndex];
                    arr[i] = arr[i] - arr[iSwapIndex];
                }                
            }
        }
    }
}
