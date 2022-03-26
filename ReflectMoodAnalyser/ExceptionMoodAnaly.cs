using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectMoodAnalyser
{
    public class ExceptionMoodAnaly:Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE, NO_SUCH_FIELD,
            NO_SUCH_METHOD, NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }

        /// <summary>
        /// The type of exception
        /// </summary>
        private readonly ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMoodAnaly"/> class.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="message">The message.</param>
        public ExceptionMoodAnaly(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}
