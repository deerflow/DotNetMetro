using DotNetOpenData;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace OpenDataClassLibrary
{
    public class Metro
    {
        private readonly IWebClient _client;

        public Metro()
        {
            _client = new WebClient();
        }

        public Metro(IWebClient webClient)
        {
            _client = webClient;
        }

        public List<Station> GetStationsByPosition(double x, double y, int distance = 300)
        {
            string json = _client.Get($"https://data.mobilites-m.fr/api/linesNear/json?x={x.ToString(CultureInfo.InvariantCulture)}&y={y.ToString(CultureInfo.InvariantCulture)}&dist={distance}&details=true");
            return JsonConvert.DeserializeObject<List<Station>>(json);
        }

        public List<Line> GetLinesById(string id)
        {
            string json = _client.Get($"https://data.mobilites-m.fr/api/routers/default/index/routes?codes={id}");
            return JsonConvert.DeserializeObject<List<Line>>(json);
        }

        public List<Line> GetLinesById(List<string> ids)
        {
            string json = _client.Get($"https://data.mobilites-m.fr/api/routers/default/index/routes?codes={ids}");
            return JsonConvert.DeserializeObject<List<Line>>(json);
        }
    }

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
