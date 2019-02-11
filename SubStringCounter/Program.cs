using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubStringCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finnish = false;
            do
            {

                Console.WriteLine("please enter the text you are searching for!");
                var content = Console.ReadLine();
                Console.WriteLine("please enter the searching text!");
                var searching = Console.ReadLine();
                try
                {
                    InputAnalyzer ai = new InputAnalyzer();
                    var count = ai.CountInputInData(content, searching);
                    Console.WriteLine("Content: {0}\nSearching value: {1}\nResult: {2}", content, searching, count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Are you finnish it?[y\\n]");
                finnish = Console.ReadKey(false).Key == ConsoleKey.Y;
                Console.ReadLine();
            }
            while (!finnish);

        }
    }
    public class InputAnalyzer
    {
        public int CountInputInData(string data, string input, bool isCaseSensitive = false)
        {
            if (String.IsNullOrEmpty(input) || String.IsNullOrEmpty(data)) throw new Exception("Some parameter are null or empty! Please check it!");
            return isCaseSensitive ? Regex.Matches(data, input).Count : Regex.Matches(data.ToLower(), input.ToLower()).Count;
        }
    }
}
