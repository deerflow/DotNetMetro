using OpenDataClassLibrary;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuiWPF
{
    class MainViewModel
    {
        public ObservableCollection<LocationToString> Stations { get; set; } = new ObservableCollection<LocationToString>();

        public MainViewModel()
        {
            List<Station> stations = new Metro().GetStationsByPosition(5.731524158690335, 45.18502649145396, 8000);
            Stations.Clear();
            stations.ForEach(station => Stations.Add(new LocationToString(station.lat, station.lon)));
        }
    }

    class LocationToString
    {
        public string Location { get; set; }

        public LocationToString(double x, double y)
        {
            Location = $"{x.ToString(CultureInfo.InvariantCulture)}, {y.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
