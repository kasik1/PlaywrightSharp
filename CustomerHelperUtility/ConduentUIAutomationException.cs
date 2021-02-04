using System;
using System.Runtime.Serialization;

namespace CustomerHelperUtility
{
    [Serializable]
    public class ConduentUIAutomationException : Exception
    {
        public ConduentUIAutomationException()
        {
        }

        public ConduentUIAutomationException(string message)
            : base(message)
        {
        }

        public ConduentUIAutomationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ConduentUIAutomationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}