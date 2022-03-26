using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectMoodAnaly7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Anayzer Program");

            //UC1 - Creating MoodAnalyzer object
            MoodAnalyser moodAnalyzer = new MoodAnalyser("");
            Console.WriteLine(moodAnalyzer.AnalyseMood());
            Console.ReadLine();
        }
    }
}
