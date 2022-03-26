using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectMoodAnalyser
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser()
        {

        }
       
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

      
        public string AnalyseMood()
        {
            string mood;
            try
            {
                mood = this.message.Contains("Sad") || this.message.Contains("sad") ? "Sad" : "Happy";
                if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
            }
            catch (NullReferenceException)
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }
            return mood;
        }
    }
}
