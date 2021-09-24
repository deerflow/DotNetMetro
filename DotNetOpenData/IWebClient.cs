using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOpenData
{
    public interface IWebClient
    {
        string Get(string url);
    }
}
