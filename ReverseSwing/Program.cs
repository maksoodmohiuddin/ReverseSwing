using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("Enter string to be reversed: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("You have entered: " + userInput);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            reverseStringLinearTime(userInput);
            stopWatch.Stop();
            Console.WriteLine("RunTime to reverse your input string in linear time is " + GetElapsedTime(stopWatch.Elapsed) + " ticks");
            stopWatch.Reset();
            
            stopWatch.Start();
            reverseStringLogTime(userInput);
            stopWatch.Stop();
            Console.WriteLine("RunTime to reverse your input string in log time is " + GetElapsedTime(stopWatch.Elapsed) + " ticks");
            stopWatch.Reset();

            // hack to pause the console
            Console.ReadKey();
        }

        #region Main Methods

        #region Reverse String in Linear Time
        static string reverseStringLinearTime(string input)
        {
            if (input == null || input.Length == 0)
                return null;

            StringBuilder reversredString = new StringBuilder();
            var words = input.Split(' ');
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversredString.Append(words[i]);
                reversredString.Append(' ');
            }
            return reversredString.ToString();
        }
        #endregion 

        #region Reverse String in Log Time
        static string reverseStringLogTime(string input)
        {
            if (input == null || input.Length == 0)
                return null;

            var words = input.Split(' ');
            string[] reversredString = new string[words.Length];
            int last = words.Length - 1;
            int first = 0;
            while (last > first)
            {
                reversredString[first] = words[last];
                reversredString[last] = words[first];
                last--;
                first++;
            }
            return string.Join(" ", reversredString);
        }
        #endregion 

        #endregion 
                
        #region Utility Methods

        #region Get Elapsed Time
        static string GetElapsedTime(TimeSpan ts)
        {
            // Add formatting if desired
            return ts.Ticks.ToString();            
        }
        #endregion

        #endregion 
    }
}
