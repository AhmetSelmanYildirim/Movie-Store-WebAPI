using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Services
{
    public interface ILoggerService
    {
        public void Write(string message);
    }
}
