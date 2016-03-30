using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointCloud.Exceptions
{
    public class PCDReaderException : Exception
    {
        public PCDReaderException() {}

        public PCDReaderException(String message) : base(message) { }
    }
}
