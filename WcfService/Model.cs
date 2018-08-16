namespace WcfService
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Serialization;

    public class WeatherContext : DbContext
    {
        public WeatherContext()
            : base("name=Model")
        {
            Database.SetInitializer<WeatherContext>(new MyInit<WeatherContext>());
        }
        public virtual DbSet<TempData> AllData { get; set; }
    }

    [DataContract]
    public class TempData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DateAndTime { get; set; }
        [DataMember]
        public double Temperature { get; set; }
        [DataMember]
        public double Altitude { get; set; }
        [DataMember]
        public double Pressure { get; set; }
    }


}