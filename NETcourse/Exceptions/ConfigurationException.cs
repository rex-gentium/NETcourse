using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Exceptions
{
    class ConfigurationException : Exception
    {
        public ConfigurationException(): base() { }
        public ConfigurationException(string message): base(message) { }
        public ConfigurationException(string message, Exception cause): base(message, cause) { }
    }
}
