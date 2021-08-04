using System;

namespace Scooters
{
    public class DateTimeException : Exception
    {
        public DateTimeException()
        {
        }

        public DateTimeException(string message)
            : base(message)
        {
        }

        public DateTimeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ScooterIdException : Exception
    {
        public ScooterIdException()
        {
        }

        public ScooterIdException(string message)
            : base(message)
        {
        }

        public ScooterIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ScooterIsRentedException : Exception
    {
        public ScooterIsRentedException()
        {
        }

        public ScooterIsRentedException(string message)
            : base(message)
        {
        }

        public ScooterIsRentedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
