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

            int tot = 0;
            for (var i = 0; i < cs.Length; i++)
            {
                tot += (37*tot + (int)(cs[i]));
            }

            tot = tot % arrLen;

            if (tot < 0)
            {
                tot = s.GetUpperBound(0);
            }

            return (int)tot;
        }
    }
}
