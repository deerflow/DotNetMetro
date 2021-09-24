using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DotNetOpenData;

namespace GUI.Schemas
{
    public class CoordinateFormViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Metro metro = new Metro();

        public CoordinateFormViewModel()
        {
            Stations = new ObservableCollection<Station>();
        }

        public double Longitude { get; set; } = 5.709360123;
        public double Latitude { get; set; } = 45.176494599999984;
        public int Radius { get; set; } = 400;

        public ObservableCollection<Station> Stations { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnSubmitClick()
        {
            Stations.Clear();
            metro.GetStationsByPosition(Longitude, Latitude, Radius).ForEach(station => Stations.Add(station));
        }
    }
}
