using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _3.无重复字符的最长子串
{
    class Program
    {
        static void Main(string[] args)
        {
            //string source = "abcabcbb";
            string source = File.ReadAllText("Test.txt");
            Stopwatch stopWath = new Stopwatch();
            stopWath.Start();
            //string source = "bbbbb";
            //string source= "dvdf";
            //var list= FindAllDistinctStr(source);
            //Console.WriteLine("找到的字符串：");
            //list.ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("最大长度为："+list.Select(x=>x.Length).Max());
            double[] ratios = new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 };

            int testCount = 10;
            foreach (double d in ratios)
            {
                Console.WriteLine($"ratio:{d}");
                TestFunciton(GetMaxSequenceLenth, source, d, testCount);
                Console.WriteLine("=================");
            }

            Console.WriteLine("总耗时：{0}ms", stopWath.ElapsedMilliseconds);
            Console.ReadLine();
        }

        private static void TestFunciton(Func<string, double, int> func,string source,double ratio, int count)
        {
            Stopwatch stopwatch_Total = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var result = func(source,ratio);
                Console.WriteLine($"第{i+1}次执行耗时：{stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Stop();
            }
            Console.WriteLine($"平均执行耗时：{stopwatch_Total.ElapsedMilliseconds/count}ms");
        }

        #region 预测法，每次预测一次，去验证一次
        static int GetMaxSequenceLenth(string source,double ratio)
        {
            if (string.IsNullOrEmpty(source)) return 0;
           
            //从中间值去寻找
            int startLenth = 0;
            int endLenth = source.Length;
            while (true)
            {
                if (endLenth - startLenth <= (1/ratio)) break;
                if (IsExistSequence(source, startLenth, endLenth,ratio))
                {
                    startLenth =(int)(startLenth+(endLenth-startLenth)*ratio);
                }
                else
                {
                    endLenth = (int)(startLenth + (endLenth - startLenth) * ratio);
                }
            }
            if (startLenth == endLenth)
            {
                return startLenth;
            }
            else
            {
                for (int i = endLenth; i >= startLenth; i--)
                {
                    if (IsExistSequence(source, i)) return i;
                }
                return startLenth;
            } 
        }

        /// <summary>
        /// 判断source中是否存在（startLength+endLenth）* ratio 的连续不重复字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startLenth"></param>
        /// <param name="endLength"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        static bool IsExistSequence(string source, int startLenth, int endLength, double ratio)
        {
            return IsExistSequence(source, (int)(startLenth + (endLength - startLenth) * ratio));
        }
        /// <summary>
        /// 判断source里是否存在lenth的连续不重复的字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="lenth"></param>
        /// <returns></returns>
        static bool IsExistSequence(string source, int lenth)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            int startPosition = 0;
           
            while (startPosition+lenth <= source.Length)
            {
                StringBuilder source_copy = new StringBuilder(source);
                //source_copy.Remove(0, startPosition);
                //source_copy.Remove(lenth, source_copy.Length - lenth);

                if (!ContainsSameChar(source_copy.ToString(startPosition,lenth)))
                {
                    return true;
                }
                startPosition++;
            }
            //Console.WriteLine($"源字符串长度：{source.Length},要寻找的长度：{lenth},耗时：{stopwatch.ElapsedMilliseconds}ms");
            return false;
        }
        static bool ContainsSameChar(StringBuilder sb)
        {           
            
            Dictionary<char, object> dic = new Dictionary<char, object>();
            for (int i = 0; i < sb.Length; i++)
            {
                if (dic.ContainsKey(sb[i]))
                {
                    //说明有重复字符
                    return true;
                }
                dic.Add(sb[i], null);
            }
            return false;
        }
        static bool ContainsSameChar(string str)
        {

            Dictionary<char, object> dic = new Dictionary<char, object>();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (dic.ContainsKey(str[i]))
            //    {
            //        //说明有重复字符
            //        return true;
            //    }
            //    dic.Add(str[i], null);
            //}
            foreach (var c in str)
            {
                if (dic.ContainsKey(c))
                {
                    return true;
                }
                dic.Add(c, null);
            }
            return false;
        }
        #endregion

        #region 之前的解题思路，是错的，对于"dvdf"字符串求出来的最大值是错误的
        //private static List<string> FindAllDistinctStr(string source)
        //{

        //    List<string> result = new List<string>();
        //    int startIndex = 0;
        //    while (startIndex < source.Length)
        //    {
        //        string str = FindDistinctStr(source, startIndex);
        //        if (result.Count > 0 && result.Select(x => x.Length).Max() > source.Length / 2)
        //        {
        //            break;//当最大长度大于原字符串的二分之一，跳出
        //        }
        //        if (string.IsNullOrEmpty(str)) break;
        //        result.Add(str);
        //        startIndex += str.Length;
        //    }
        //    return result;
        //}
        //private static string FindDistinctStr(string source, int startIndex)
        //{
        //    if (startIndex == source.Length) return null;
        //    List<char> result = new List<char>();
        //    for (int i = startIndex; i < source.Length; i++)
        //    {
        //        if (result.Contains(source[i]))
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            result.Add(source[i]);
        //        }
        //    }
        //    return string.Join("", result);
        //}
        #endregion
    }
}
