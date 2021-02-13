using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }
        public BusinessException(string mensaje) : base(mensaje)
        {

        }
    }
}
