using System;

namespace Defroster.Exceptions
{
    public class DefrostException : Exception
    {
        public DefrostException(string message) : base(message) {}
    }
}