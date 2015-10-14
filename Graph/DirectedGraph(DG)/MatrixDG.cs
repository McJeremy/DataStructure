using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DirectedGraph_DG_
{
    /// <summary>
    /// 用邻接矩阵标识的有向图
    /// 
    /// MatrixUDG是邻接矩阵对应的结构体。xs[i])"和"顶点j(即mVexs[j])"是邻接点；mMatrix[i][j]=0，则表示它们不是邻接点。
    /// </summary>
    public class MatrixDG
    {
        //通常由两个数组来标识，1个数组包含顶点的集合，另外一个数组标识边的集合
        //mVexs用于保存顶点，mMatrix则是用于保存矩阵信息的二维数组。例如，mMatrix[i][j]=1，则表示"顶点i(即mVe
        private int[] mVexs;   //顶点
        private int[,] mMatrix; //邻接矩阵

        private int GetVexPosition(char vex)
        {
            for (int i = 0; i < mVexs.Length; i++)
            {
                if (mVexs[i] == vex)
                {
                    return i;
                }
            }
            throw new Exception("not find vex");
        }

        public MatrixDG(char[] vexs, char[,] edges)
        {
            var vLen = vexs.Length;
            var eLen = edges.GetLength(0);

            mVexs = new int[vLen];
            for (var i = 0; i < vexs.Length; i++)
            {
                mVexs[i] = vexs[i];
            }

            mMatrix = new int[vLen,vLen];
            for (var j = 0; j < eLen; j++)
            {
                var matrixI = GetVexPosition(edges[j, 0]);
                var matrixJ = GetVexPosition(edges[j, 1]);

                //这里是与无向图的邻接矩阵唯一的区别。
                mMatrix[matrixI, matrixJ] = 1;
            }
        }

        public override string ToString()
        {
            Console.WriteLine("具有如下顶点:");
            for (var i = 0; i < mVexs.Length; i++)
            {
                Console.Write((char)mVexs[i] + ",");
            }

            Console.WriteLine("\r\n它们的连接关系如下：\r\n");

            Console.Write("      ");
            for (var i = 0; i < mVexs.Length; i++)
            {
                Console.Write((char)mVexs[i] + "   ");
            }

            for (var i = 0; i < mMatrix.GetLength(0); i++)
            {
                Console.Write("\r\n " + (char)mVexs[i]+"    ");
                for (var j = 0; j < mMatrix.GetLength(1); j++)
                {
                    Console.Write(mMatrix[i, j] + "   ");
                }
            }

            return string.Empty;
        }
    }
}
