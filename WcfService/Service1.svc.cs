using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    public class Service1 : IService1
    {
        public void ReceiveData(string Name, string Temperature, string Humidity, string Pressure)
        {
            using (WeatherContext db = new WeatherContext())
            {
                TempData data = new TempData();
                data.DateAndTime = DateTime.Now.ToString();
                try
                {
                    data.Temperature = Double.Parse(Temperature);
                    data.Humidity = Double.Parse(Humidity);
                    data.Pressure = Double.Parse(Pressure);
                    data.NamePerson = Name;
                    Debug.WriteLine($"{data.Temperature} {data.Pressure} {data.Humidity}");
                    db.AllData.Add(data);
                    db.SaveChanges();
                }
                catch {}
            }
        }

        public TempData[] ReturnAllData()
        {
            try
            {   
                using (WeatherContext db = new WeatherContext())
                {
                    return db.AllData.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        public string ReturnCountOfData()
        {
            try
            {
                using (WeatherContext db = new WeatherContext())
                {
                    return db.AllData.Count().ToString();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public TempData ReturnLastData()
        {
            try
            {
                using (WeatherContext db = new WeatherContext())
                {
                    TempData tmp = db.AllData.First();
                    return tmp;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
