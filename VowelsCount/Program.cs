using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            StreamReader sr = new StreamReader(@"C:\Personal\Sample.txt");
            StreamWriter sw = new StreamWriter(@"C:\Personal\output.txt");

            try
            {
                line = sr.ReadLine();

                Dictionary<char, int> dictionary = (line.GroupBy(item => item).ToDictionary(item => item.Key, item => item.Count()));

                var vowels = new List<string>() { "a", "e","i","o" ,"u" };

                foreach (var item in dictionary.OrderByDescending(key => key.Value))
                {
                    if (vowels.Contains(item.Key.ToString()))
                    {
                        sw.WriteLine(item);
                    }
                }
                dictionary.Select(i => $"{i.Key}: {i.Value}").ToList();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
                sw.Close();
            }
        }
    }
}
