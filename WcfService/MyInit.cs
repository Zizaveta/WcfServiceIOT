using System;
using System.Data.Entity;

namespace WcfService
{
    internal class MyInit<T> : DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            context.AllData.Add(new TempData() { DateAndTime = DateTime.Now, Altitude = 10, Pressure = 10, Temperature = 10 });
            context.SaveChanges();
        }
    }
}