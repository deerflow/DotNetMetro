using DotNetOpenData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DotNetOpenDataTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetStationsByPosition()
        {
            IWebClient client = new FakeWebClient("[{\"id\":\"SEM:0844\",\"name\":\"Grenoble, Champs-Elysées\",\"lon\":5.71025,\"lat\":45.17794,\"zone\":\"SEM_GENCHAMPSEL\",\"lines\":[\"SEM:12\"]}]");
            Station station = new Metro(client).GetStationsByPosition(0, 0).First();
            Assert.AreEqual(station.id, "SEM:0844");
            Assert.AreEqual(station.name, "Grenoble, Champs-Elysées");
        }

        [TestMethod]
        public void TestGetLineById()
        {
            IWebClient client = new FakeWebClient("[{\"id\":\"SEM: C4\",\"gtfsId\":\"SEM: 4\",\"shortName\":\"C4\",\"longName\":\"GRENOBLE Victor Hugo / EYBENS Le Verderet\",\"color\":\"F3D000\",\"textColor\":\"000000\",\"mode\":\"BUS\",\"type\":\"CHRONO\"}]");
            Line line = new Metro(client).GetLinesById("cool").First();
            Assert.AreEqual(line.id, "SEM: C4");
            Assert.AreEqual(line.longName, "GRENOBLE Victor Hugo / EYBENS Le Verderet");
        }
    }
}
