using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DotNetOpenData
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            List <Station> stations = new Metro().GetStationsByPosition(5.709360123, 45.176494599999984, 600);
            Console.WriteLine(JsonConvert.SerializeObject(stations, Formatting.Indented));

            Console.Read();
        }
    }
}