using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReflectMoodAnaly7
{
    public class FactoryReflection
    {
        public object CreateMoodMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyzerType);
                }
                catch (ArgumentNullException)
                {

                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        //UC5 - Using Reflection Create MoodAnalyser with parameter constructor
        public object CreateMoodMoodAnalyserParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_METHOD, "Could not find constructor");
                }
            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_CLASS, "Could not find class");
            }
        }

        //UC6 - Use Reflector to invoke MoodAnalyzer method 
        public string InvokeMoodAnalyzer(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo methodInfo = type.GetMethod(methodName);
                FactoryReflection reflector = new FactoryReflection();
                object moodAnalyserObject = reflector.CreateMoodMoodAnalyserParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {

                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_METHOD, "Method not found");
            }
        }

        //UC7 - Method to change mood dynamically (Set field value)
        public string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyzer = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyzer, message);
                return moodAnalyzer.message;
            }
            catch (NullReferenceException)
            {

                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionTypes.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
