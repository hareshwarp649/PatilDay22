using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectMoodAnaly7
{
    public class MoodAnalyser
    {
        public string message;

        public MoodAnalyser()
        {
            Console.WriteLine("Default Constructor");
        }

        //Constructor for initializing the message
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        //Method to analyse mood form a given message
        public string AnalyseMood()
        {
            //Custom Exception Handling
            try
            {
                if (this.message.Equals(null))
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NULL_MOOD_EXCEPTION, "Message should not be null");
                }
                else if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.EMPTY_MOOD_EXCEPTION, "Message should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (ExceptionMoodAnaly)
            {
                return "HAPPY";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "HAPPY";
            }
        }
    }
}
