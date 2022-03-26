using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReflectMoodAnalyser
{
    public class FactoryException
    {
        public static object MoodAnalyseObjectCreation(string className, string constructorName)
        {
            string name = @".*" + constructorName + "$";
            bool result = Regex.IsMatch(className, name);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
    }
}
