using DotNetOpenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetOpenDataTests
{
    class FakeWebClient : IWebClient
    {
        private string _response;
        public FakeWebClient(string reponse)
        {
            _response = reponse;
        }

        public string Get(string url)
        {
            return _response;
        }
    }
}
