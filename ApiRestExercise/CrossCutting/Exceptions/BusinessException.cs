using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Exceptions
{
    /// <summary>
    /// Clase de tipo Exception que se utiliza para las excepciones manejadas.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
            : base()
        {

        }
        public BusinessException(string message)
            : base(message)
        {

        }
        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
