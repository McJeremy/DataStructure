using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class Floyd
    {
        //定义图的定点
        int[,] vertexs = new int
            [6, 6] {
               {int.MaxValue,1,1,int.MaxValue,int.MaxValue,int.MaxValue},
                {int.MaxValue,int.MaxValue,1,int.MaxValue,int.MaxValue,int.MaxValue},
                {int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,1},
                {int.MaxValue,int.MaxValue,1,int.MaxValue,int.MaxValue,int.MaxValue},
                {int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue},
                {int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue}
            };

        public int[,] CalShortestPath()
        {
            int[,] g = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    g[i, j] = vertexs[i, j];
                }
            }

            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (g[i, k] == int.MaxValue || g[k, j] == int.MaxValue)
                        {
                            continue;
                        }

                        if (g[i, j] > (g[i, k] + g[k, j]))
                        {
                            g[i, j] = g[i, k] + g[k, j];
                        }
                        

                        //g[i, j] = Math.Min(
                        //    g[i, j], 
                        //        (g[i, k] == int.MaxValue || g[k, j] == int.MaxValue) 
                        //        ? 
                        //        int.MaxValue : 
                        //        g[i, k] + g[k, j]
                        //    );
                    }
                }
            }

            return g;
        }

        public void PrintPath()
        {
            var g = CalShortestPath();
            for(int i=0;i<6;i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (g[i, j] == int.MaxValue)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(g[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
