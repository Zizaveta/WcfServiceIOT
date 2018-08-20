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
        public TempData AvgDataByDay(string Date) // rewrite
        {
            try
            {
                var tmp_data = Date.Replace('.', '/');
                TempData[] arrayOfData = ReturnAllDataByDay(tmp_data);
                return new TempData() { DateAndTime = Date, Humidity = arrayOfData.Average(elem => elem.Humidity), Pressure = arrayOfData.Average(elem => elem.Pressure), Temperature = arrayOfData.Average(elem => elem.Temperature) };
            }
            catch { return null; }
        }

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

        public TempData[] Return10LastDataByName(string Name)
        {
            try
            {
                TempData[] arrayOfData = ReturnDataByName(Name);
                if (arrayOfData.Count() > 10)
                    arrayOfData = arrayOfData.Skip(arrayOfData.Count() - 10).Take(10).ToArray();
                return arrayOfData;
            }
            catch
            { return null; }
        }

        public TempData[] Return20LastData()
        {
            try
            {
                TempData[] arrayOfData = ReturnAllData();
                if (arrayOfData.Count() > 20)
                    arrayOfData = arrayOfData.Skip(arrayOfData.Count() - 20).Take(20).ToArray();
                return arrayOfData;
            }
            catch
            { return null; }
        }

        public TempData[] Return20LastDataByName(string Name)
        {
            try
            {
                TempData[] arrayOfData = ReturnDataByName(Name);
                if (arrayOfData.Count() > 20)
                    arrayOfData = arrayOfData.Skip(arrayOfData.Count() - 20).Take(20).ToArray();
                return arrayOfData;
            }
            catch
            { return null; }
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

        public TempData[] ReturnAllDataByDay(string Date)
        {
           try
            {
                return ReturnAllData().Where(elem => elem.DateAndTime.StartsWith(Date)).ToArray();
            }
            catch { return null; }
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

        public TempData[] ReturnDataByName(string Name)
        {
            try
            {
                using (WeatherContext db = new WeatherContext())
                {
                    return db.AllData.Where(elem => elem.NamePerson == Name).ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        public TempData ReturnLastData()
        {
            try
            {
                using (WeatherContext db = new WeatherContext())
                {
                    TempData tmp = db.AllData.ToArray()[db.AllData.Count()-1];
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
