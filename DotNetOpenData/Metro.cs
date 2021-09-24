using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Newtonsoft.Json;

namespace DotNetOpenData
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
}