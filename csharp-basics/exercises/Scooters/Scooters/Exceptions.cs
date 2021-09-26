using System;

namespace Scooters
{
    public class ScooterActivityException : Exception
    {
        public ScooterActivityException()
        {
        }

        public ScooterActivityException(string message)
            : base(message)
        {
        }

        public ScooterActivityException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class InvalidDateTimeException : Exception
    {
        public InvalidDateTimeException()
        {
        }

        public InvalidDateTimeException(string message)
            : base(message)
        {
        }

        public InvalidDateTimeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class DuplicateScooterIdException : Exception
    {
        public DuplicateScooterIdException()
        {
        }

        public DuplicateScooterIdException(string message)
            : base(message)
        {
        }

        public DuplicateScooterIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ScooterIdNotFoundException : Exception
    {
        public ScooterIdNotFoundException()
        {
        }

        public ScooterIdNotFoundException(string message)
            : base(message)
        {
        }

        public ScooterIdNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ScooterRentedException : Exception
    {
        public ScooterRentedException()
        {
        }

        public ScooterRentedException(string message)
            : base(message)
        {
        }

        public ScooterRentedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
