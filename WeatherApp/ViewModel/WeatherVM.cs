using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVm
    {
        //to będzie cały obiekt naszej klasy, który przypiszemy jako kontekst dla naszego widoku
        public AccuWeather Weather { get; set; }

        public WeatherVm()
        {
            Weather= new AccuWeather();
        }
    }
}
