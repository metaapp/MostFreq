using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeAI
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static List<int> ReturnMostFreq(int[] array, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int n in array)
            {
                if (dic.ContainsKey(n))
                    dic[n]++;
                else
                    dic[n] = 0;
            }

            Dictionary<int, int> dicSorted = dic.ToDictionary(kp => kp.Value, kp => kp.Key);
            dicSorted.OrderByDescending(key => key.Key);

            List<int> mostF = new List<int>();
            for (int i = 0; i < k; k++)
                mostF.Add(dicSorted.Keys.ElementAt(i));

            return mostF;
        }
    }
}
