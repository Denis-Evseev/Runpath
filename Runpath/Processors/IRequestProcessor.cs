using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runpath.Processors
{
    public interface IRequestProcessor
    {
        T Process<T>(string requestUrl);
    }
}
