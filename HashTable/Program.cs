using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strNames =new string[99];
            string[] strSomeNames = { "xuzz","Bob","Jack","Stephen","Mayno","Danina","Michael","Mike"};

            //两种求  散列键值的相同点都是处理完字符的ascii码后，与存储数据的数组长度相除求余
            //不同的是，仅仅是ascii码相加，键值分布不均匀，而且容易冲突
            //而采用一个素数的方式，键值分布相对集中。
            foreach (var strName in strSomeNames)
            {
                strNames[BetterHash(strName, strNames)] = strName;
            }


            for (var i = 0; i < strNames.GetUpperBound(0); i++)
            {
                if(null!=strNames[i])
                Console.WriteLine(i + ":" + strNames[i]);
            }

            Console.Read();
        }

        static int SimpleHash(string str, string[] s)
        {
            //将所有字符的ascii码想加，再除以存储数据的数组长度，然后取余作为存储位置（下标）
            var arrLen = s.GetUpperBound(0);

            char[] cs = str.ToCharArray();

            int tot = 0;
            for (var i = 0; i < cs.Length; i++)
            {
                tot += (int)(cs[i]) ;
            }

            return tot % arrLen;
        }

        static int BetterHash(string str, string[] s)
        {
            var arrLen = s.GetUpperBound(0);

            char[] cs = str.ToCharArray();

            //采用一个素数来与想加的acsii码相乘，然后再加上当前字符ascii码
            int tot = 0;
            for (var i = 0; i < cs.Length; i++)
            {
                tot += (37*tot + (int)(cs[i]));
            }

            //再除以存储数据的数组长度，然后取余作为存储位置（下标）
            tot = tot % arrLen;

            if (tot < 0)
            {
                tot = s.GetUpperBound(0);
            }

            return (int)tot;
        }
    }
}
