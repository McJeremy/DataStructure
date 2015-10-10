using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "哈夫曼曼曼曼曼";

            NormalHuffmanTree nt = new NormalHuffmanTree();

            HuffmanTreeNode tree = nt.CreateHuffmanTree(source);

            foreach (KeyValuePair<char, string> code in nt.CreateHuffmanDict(tree))
            {
                Console.WriteLine(code.Key + "~~~" + code.Value);
            }
            //LINQHuffmanTree lt = new LINQHuffmanTree();
            //HuffmanTreeNode tree2 = lt.CreateHuffmanTree(source);

            string strLine = "";

            Console.Read();
        }        
    }


    /// <summary>
    /// 哈夫曼树节点
    /// </summary>
    public class HuffmanTreeNode:IComparable
    {
        public HuffmanTreeNode()
        { }

        public HuffmanTreeNode(char value,int weight)
        {
            this.Weight = weight;
            this.Value = value;
        }

        public int Weight { get; set; }
        public char Value { get; set; }
        public HuffmanTreeNode LChild { get; set; }
        public HuffmanTreeNode RChild { get; set; }

        public int CompareTo(object obj)
        {
            int result = 0;

            HuffmanTreeNode huff = obj as HuffmanTreeNode;

            if(huff.Weight<this.Weight)
            { result = 1; }
            else if(huff.Weight>this.Weight)
            { result = -1; }

            return result;
        }
    }

    public class NormalHuffmanTree
    {       

        public HuffmanTreeNode CreateHuffmanTree(string strValue)
        {
            char[] values = strValue.ToCharArray();
            return CreateHuffmanTree(values);
        }

        public HuffmanTreeNode CreateHuffmanTree(char[] arrValues)
        {
            HuffmanTreeNode[] weights = GetWeightArray(arrValues);
            return CreateHuffmanTree(weights);
        }

        public string StringToHuffmanCode(out Dictionary<char, string> key, string str)
        {
            string result = "";

            var tmps = GetWeightArray(str);

            var tree = CreateHuffmanTree(tmps);
            var dict = CreateHuffmanDict(tree);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            result = ToHuffmanCode(str, dict);

            key = dict;
            return result;
        }

        public Dictionary<char, string> CreateHuffmanDict(HuffmanTreeNode hTree)
        {
            return CreateHuffmanDict("", hTree);
        }

        private Dictionary<char, string> CreateHuffmanDict(string code,HuffmanTreeNode hTree)
        {
            Dictionary<char, string> result = new Dictionary<char, string>();

            //如果是叶子节点，那么传入的code就是它的哈夫曼编码
            if (hTree.LChild == null && hTree.RChild == null)
            {
                result.Add(hTree.Value, code);
            }
            else
            {
                //否则，约定左边的0，右边的1
                var dictL = CreateHuffmanDict(code + "0", hTree.LChild);
                var dictR = CreateHuffmanDict(code + "1", hTree.RChild);

                foreach (var item in dictL)
                {
                    result.Add(item.Key, item.Value);
                }

                foreach (var item in dictR)
                {
                    result.Add(item.Key, item.Value);
                }
            }

            return result;
        }

        public string ToHuffmanCode(string source, Dictionary<char, string> hfdict)
        {
            string result = "";

            for (int i = 0; i < source.Length; i++)
            {
                result += hfdict.First(m => m.Key == source[i]).Value;
            }

            return result;
        }

        public string HuffmanToText(string code, Dictionary<char, string> hfdict)
        {
            string result = "";

            for (int i = 0; i < code.Length;)
            {
                foreach (var item in hfdict)
                {
                    if (code[i] == item.Value[0]
                        && item.Value.Length + i <= code.Length)
                    {
                        char[] tmpArr = new char[item.Value.Length];

                        Array.Copy(code.ToCharArray(), i, tmpArr, 0, tmpArr.Length);

                        if (new String(tmpArr) == item.Value)
                        {
                            result += item.Key;
                            i += item.Value.Length;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private HuffmanTreeNode[] GetWeightArray(string strValue)
        {
            char[] arrValues = strValue.ToCharArray();
            return GetWeightArray(arrValues);
        }
        private HuffmanTreeNode[] GetWeightArray(char[] arrValues)
        {
            List<HuffmanTreeNode> Nodes = new List<HuffmanTreeNode>();

            while (arrValues.Length > 0)
            {
                char[] cntChars = null;

                //以该字符出现的次数，作为它的权重
                var tmp = arrValues.Where(m => m == arrValues[0]);
                cntChars = new char[tmp.Count()];
                tmp.ToArray().CopyTo(cntChars, 0);
                arrValues = arrValues.Where(m => m != tmp.First()).ToArray();
                
                Nodes.Add(new HuffmanTreeNode() { Value = cntChars[0], Weight = cntChars.Length });
            }

            return Nodes.ToArray();
        }

        private HuffmanTreeNode CreateHuffmanTree(HuffmanTreeNode[] sources)
        {
            HuffmanTreeNode topNode = null;
            HuffmanTreeNode[] nodes = sources;

            bool bIsNext = true;            

            while (bIsNext)
            {
                //先排序
                Array.Sort(nodes);

                //如果只有（或只剩下两个未处理节点），则分别作为左右节点。
                //因为已经排序，所以左节点的值小于右节点的值。
                if (nodes.Count() == 2)
                {
                    topNode = new HuffmanTreeNode();
                    topNode.LChild = nodes[0];
                    topNode.RChild = nodes[1];
                    bIsNext = false;
                }

                HuffmanTreeNode node1 = sources[sources.Length - 1];
                HuffmanTreeNode node2 = sources[sources.Length - 2];
                HuffmanTreeNode tmpNode = new HuffmanTreeNode();
                tmpNode.Weight = node1.Weight + node2.Weight;
                tmpNode.LChild = node1;
                tmpNode.RChild = node2;

                HuffmanTreeNode[] tmpNds = new HuffmanTreeNode[nodes.Length - 1];
                Array.Copy(nodes, 0, tmpNds, 0, nodes.Length - 1);
                tmpNds[tmpNds.Length - 1] = tmpNode;

                nodes = tmpNds;
            }

            return topNode;
        }
    }  

    public class LINQHuffmanTree
    {
        public HuffmanTreeNode CreateHuffmanTree(string strValue)
        {
            char[] iValues = strValue.ToCharArray();

            var treeList = new List<HuffmanTreeNode>();
            //根据输入的值组成树节点集合
            //节点的权值以节点的值出现次数计算
            treeList.AddRange(from n in iValues
                              group n by n into g
                              select new HuffmanTreeNode { Value = g.Key, Weight = g.Count() });

            while (treeList.Count > 1)
            {
                //对节点排序
                var sel = from i in treeList
                          orderby i.Weight ascending
                          select i;

                //取最小的两个
                var min = sel.Take(2).ToArray();

                treeList.Add(new HuffmanTreeNode { LChild = min[0], RChild = min[1], Weight = min[0].Weight + min[1].Weight });

                //将最小的两个删掉
                //注;实际上，它们已经与新建立的节点有了联系
                treeList.Remove(min[0]);
                treeList.Remove(min[1]);
            }

            return treeList[0];
        }
    }

}
