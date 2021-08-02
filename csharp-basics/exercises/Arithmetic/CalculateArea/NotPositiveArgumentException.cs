using System;


namespace CalculateArea
{
    public class NotPositiveArgumentException : Exception
    {
        public NotPositiveArgumentException()
        {
        }

        public NotPositiveArgumentException(string message)
            : base(message)
        {
        }

        public NotPositiveArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
