using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessData
{
    public class FitnessDataException : Exception
    {
        public FitnessDataException(string? message) : base(message)
        {
        }

        public FitnessDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
