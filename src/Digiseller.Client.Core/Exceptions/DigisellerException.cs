using System;

namespace Digiseller.Client.Core.Exceptions
{
    public class DigisellerException : Exception
    {
        public DigisellerException(string message) : base(message)
        {
        }
    }
}