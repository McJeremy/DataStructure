﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.UnDirectedGraph_UDG_
{
    /// <summary>
    /// 用邻接表实现的无向图
    /// </summary>
    public class ListUDG
    {
        public List<VNode> VertexNodes
        {
            get;
            set;
        }

        public ListUDG(char[] vexs, char[,] edges)
        {
            InitVertextNodes(vexs);
            BuildEdges(edges);
        }

        private void InitVertextNodes(char[] vexs)
        {
            VertexNodes = new List<VNode>();
            foreach (var vex in vexs)
            {
                VertexNodes.Add(new VNode { Data = vex, FirstEdge = null, Visited = false
          });
            }
        }

        private dynamic GetVNodePosition(char vex)
        {
            for (var i = 0; i < VertexNodes.Count; i++)
            {
                if (VertexNodes[i].Data == vex)
                {
                    return new
                    {
                        Index = i,
                        Node = VertexNodes[i]
                    };
                }
            }
            return null;
        }

        private void BuildEdges(char[,] edges)
        {
            for (var i = 0; i < edges.GetLength(0); i++)
            {
                AddListWithFromAndTo(edges[i, 0], edges[i, 1]);
                AddListWithFromAndTo(edges[i, 1], edges[i, 0]);
            }
        }

        private void AddListWithFromAndTo(char fromVex, char toVex)
        {
            var from = GetVNodePosition(fromVex);
            var to = GetVNodePosition(toVex);

            if (null == from)
            {
                return;
            }
            var fromNode = from.Node as VNode;
            var toNode = new ENode { Adj = to.Node, Next = null };
            if (null == fromNode.FirstEdge)
            {
                fromNode.FirstEdge = toNode;
            }
            else
            {
                var node = fromNode.FirstEdge;
                while (null != node.Next)
                {
                    node = node.Next;
                }
                node.Next = toNode;
            }
        }

        public void InitVisited()
        {
            VertexNodes.ForEach(v => v.Visited = false);
        }

        public void DFS(VNode vertex)
        {
            vertex.Visited = true;
            Console.WriteLine("Visit:{0}", vertex.Data);

            var eNode = vertex.FirstEdge;
            while (null != eNode)
            {
                if (!eNode.Adj.Visited)
                {
                    DFS(eNode.Adj);                    
                }
                eNode = eNode.Next;
            }
        }

        public void BFS(VNode v)
        {
            /*使用队列来实现广度优先搜索
            
            */
            Queue<VNode> q = new Queue<VNode>();
            v.Visited = true;
            q.Enqueue(v);
            Console.WriteLine("Visit:{0}", v.Data);
            while (q.Count > 0)
            {
                var vnode = q.Dequeue();
                var enode = vnode.FirstEdge;
                while (null != enode)
                {
                    if (!enode.Adj.Visited)
                    {
                        enode.Adj.Visited = true;
                        Console.WriteLine("Visit:{0}", enode.Adj.Data);
                        q.Enqueue(enode.Adj);
                    }
                    enode = enode.Next;
                }
            }
        }

        public override string ToString()
        {
            VertexNodes.ForEach(v =>
            {
                Console.Write("顶点{0},连接：", v.Data);
                var node = v.FirstEdge;
                while (null != node)
                {
                    Console.Write(node.Adj.Data+",");
                    node = node.Next;
                }
                Console.Write(("\r\n"));
            });
            return string.Empty;
        }
    }

    /// <summary>
    /// 标识顶点
    /// </summary>
    public class VNode
    {
        public bool Visited
        {
            get; set;
        }
        public char Data
        {
            get;
            set;
        }

        public ENode FirstEdge
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 标识边
    /// </summary>
    public class ENode
    {
        public VNode Adj
        {
            get;
            set;
        }
        public ENode Next
        {
            get;
            set;
        }
    }
}
