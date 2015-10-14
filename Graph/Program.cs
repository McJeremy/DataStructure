using Graph.DirectedGraph_DG_;
using Graph.UnDirectedGraph_UDG_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vexs = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            Console.WriteLine("无向图的邻接矩阵:\r\n");
            char[,] udgedges = new char[,]{
            {'A', 'C'},
            {'A', 'D'},
            {'A', 'F'},
            {'B', 'C'},
            {'C', 'D'},
            {'E', 'G'},
            {'F', 'G'}};
            MatrixUDG udg = new MatrixUDG(vexs, udgedges);
            udg.ToString();

            Console.WriteLine("\r\n有向图的邻接矩阵:\r\n");
            char[,] dgedges = new char[,]{
            {'A', 'B'},
            {'B', 'C'},
            {'B', 'E'},
            {'B', 'F'},
            {'C', 'E'},
            {'D', 'C'},
            {'E', 'B'},
            {'E', 'D'},
            {'F', 'G'}};
            MatrixDG dg = new MatrixDG(vexs, dgedges);
            dg.ToString();

            Console.Read();
        }
    }
}
