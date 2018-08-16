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
        public void ReceiveData(string Temperature, string Altitude, string Pressure)
        {
            using (WeatherContext db = new WeatherContext())
            {
                TempData data = new TempData();
                data.DateAndTime = DateTime.Now;
                try
                {
                    data.Temperature = Double.Parse(Temperature);
                    data.Altitude = Double.Parse(Altitude);
                    data.Pressure = Double.Parse(Pressure);
                    Debug.WriteLine($"{data.Temperature} {data.Pressure} {data.Altitude}");
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
