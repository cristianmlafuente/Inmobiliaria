using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InmDAL
{
    public class DALException : Exception
    {
        public DALException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
