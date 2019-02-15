using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.Annotations;

namespace WeatherApp.Model
{
    //public class Metric : INotifyPropertyChanged
    //{
    //    private double _value;

    //    public double Value
    //    {
    //        get { return _value; }
    //        set
    //        {
    //            this._value = value;
    //            OnPropertyChanged(nameof(Value));
    //        }
    //    }

    //    private string _unit;

    //    public string Unit
    //    {
    //        get { return _unit; }
    //        set
    //        {
    //            this._unit = value;
    //            OnPropertyChanged(nameof(Unit));
    //        }
    //    }

    //    private int _unitType;

    //    public int UnitType
    //    {
    //        get { return _unitType; }
    //        set
    //        {
    //            this._unitType = value;
    //            OnPropertyChanged(nameof(UnitType));
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}


    //public class Temperature : INotifyPropertyChanged
    //{
    //    private Metric _metric;

    //    public Metric Metric
    //    {
    //        get { return _metric; }
    //        set
    //        {
    //            this._metric = value;
    //            OnPropertyChanged(nameof(Metric));
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //}

    //public class AccuWeather : INotifyPropertyChanged
    //{
    //    private DateTime _localObservationDateTime;

    //    public DateTime LocalObservationDateTime
    //    {
    //        get { return _localObservationDateTime; }
    //        set
    //        {
    //            this._localObservationDateTime = value;
    //            OnPropertyChanged(nameof(LocalObservationDateTime));
    //        }
    //    }

    //    private string _weatherText;

    //    public string WeatherText
    //    {
    //        get { return _weatherText; }
    //        set
    //        {
    //            _weatherText = value;
    //            OnPropertyChanged(nameof(WeatherText));
    //        }
    //    }

    //    private int _weatherIcon;

    //    public int WeatherIcon
    //    {
    //        get { return _weatherIcon; }
    //        set
    //        {
    //            _weatherIcon = value;
    //            OnPropertyChanged(nameof(WeatherIcon));
    //        }
    //    }

    //    private bool _isDayTime;

    //    public bool IsDayTime
    //    {
    //        get { return _isDayTime; }
    //        set
    //        {
    //            _isDayTime = value; 
    //            OnPropertyChanged(nameof(IsDayTime));
    //        }
    //    }

    //    private Temperature _temperature;

    //    public Temperature Temperature
    //    {
    //        get { return _temperature; }
    //        set
    //        {
    //            _temperature = value;
    //            OnPropertyChanged(nameof(Temperature));
    //        }
    //    }

    //    private string _link;

    //    public string Link
    //    {
    //        get { return _link; }
    //        set
    //        {
    //            _link = value;
    //            OnPropertyChanged(nameof(Link));
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public AccuWeather()
    //    {
    //        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
    //        {
    //            WeatherIcon = 1111;
    //            LocalObservationDateTime = DateTime.Now;
    //            Temperature = new Temperature()
    //            {
    //                Metric = new Metric()
    //                {
    //                    Value = 12,
    //                    Unit = "C",
    //                    UnitType = 22222
    //                }

    //            };
    //            WeatherText = "Sunny/Windy";
    //            IsDayTime = true;
    //            Link = "linklinklinklink";

    //        }
           

    //    }

    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}



    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Maximum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class Day
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    public class Night
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
    }

    public class DailyForecast : INotifyPropertyChanged
    {

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private Temperature temperature;

        public Temperature Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private Day day;

        public Day Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        private Night night;

        public Night Night
        {
            get { return night; }
            set
            {
                night = value;
                OnPropertyChanged("Night");
            }
        }


        public IList<string> Sources { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class AccuWeather
    {
        public IList<DailyForecast> DailyForecasts { get; set; }


        public AccuWeather()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                DailyForecasts  = new List<DailyForecast>();
                for (int i = 0; i < 3; i++)
                {
                    DailyForecast dailyForecast = new DailyForecast
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Temperature = new Temperature
                        {
                            Maximum = new Maximum
                            {
                                Value = 21 + i
                            },
                            Minimum = new Minimum
                            {
                                Value = 5-i
                            }

                        }
                    };
                    DailyForecasts.Add(dailyForecast);
                }
               
               
            }


        }
    }


}
