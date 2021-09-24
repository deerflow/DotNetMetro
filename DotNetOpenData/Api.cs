using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOpenData
{
    public class Station
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string zone { get; set; }
        public List<string> lines { get; set; }
    }

    public class Line
    {
        public string id { get; set; }
        public string gtfsId { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
    }
}
