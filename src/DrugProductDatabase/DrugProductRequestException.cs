using System;
using System.Collections.Generic;
using System.Text;

namespace DrugProductDatabase
{
    public class DrugProductRequestException : Exception
    {
        public DrugProductRequestException(string Message, Exception innerException = null) 
            : base(Message, innerException)
        {
        }
    }
}
