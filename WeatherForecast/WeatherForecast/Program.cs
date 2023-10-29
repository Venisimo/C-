using System;
using System.Collections.Generic;

namespace WeatherForecast
{
    public interface IObserver
    {
        void vivod(Weather weatherData);
    }
    public interface IObservable
    {
        void addObserver(IObserver o);
        void removeObserver(IObserver o);
        void NotifyObservers();
    }
    public interface IRemove
    {
        void RemoveInfo();
    }
    public class objectObservable : IObservable
    {
        List<IObserver> listObservers;
        Weather weatherData;

        public objectObservable()
        {
            listObservers = new List<IObserver>();
            weatherData = new Weather(0, 0, 0);
        }
        public void addObserver(IObserver o)
        {
            listObservers.Add(o);
        }
        public void removeObserver(IObserver o)
        {
            listObservers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver ob in listObservers)
            {
                ob.vivod(weatherData);
            }
        }
        public void ChangeInfo(int T, int H, int P)
        {
            weatherData.Temp = T;
            weatherData.Humidity = H;
            weatherData.Pressure = P;
            NotifyObservers();
        }
    }

    public class WeatherCurrently : IObserver
    {
        public IObservable observable;

        public WeatherCurrently(IObservable ob)
        {
            observable = ob;
            observable.addObserver(this);
        }
        public void vivod(Weather weatherData)
        {
            Console.WriteLine("Текущая погода: " + "Темература = " + weatherData.Temp
            + " | " + "Влажность = " + weatherData.Humidity + " % |" + "Давление = " + weatherData.Pressure + " миллиметров ртутного столба");
        }
    }
    public class WeatherForecast : IObserver, IRemove
    {
        public IObservable observable;
        public IRemove rem;
        public WeatherForecast(IObservable ob)
        {
            observable = ob;
            observable.addObserver(this);
        }
        public void vivod(Weather weatherData)
        {
            weatherData.Temp += 10;
            weatherData.Humidity += 10;
            weatherData.Pressure -= 10;
            Console.WriteLine("Прогноз: " + "Темература = " + weatherData.Temp
            + " | " + "Влажность = " + weatherData.Humidity + " % |" + "Давление = " + weatherData.Pressure + " миллиметров ртутного столба");
        }
        public void RemoveInfo()
        {
            observable.removeObserver(this);
        }
    }
    public class Weather
    {
        public int Temp { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public Weather(int T, int H, int P)
        {
            Temp = T;
            Humidity = H;
            Pressure = P;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            objectObservable ObjectObservable = new objectObservable();

            WeatherCurrently obj1 = new WeatherCurrently(ObjectObservable);
            WeatherForecast obj2 = new WeatherForecast(ObjectObservable);

            ObjectObservable.ChangeInfo(15, 60, 1015);
            obj2.RemoveInfo();
            ObjectObservable.ChangeInfo(15, 60, 1015);

        }
    }
}
