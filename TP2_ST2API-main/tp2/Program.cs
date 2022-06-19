using System;

namespace tp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var p = new APIcontrol();
            WeatherMoroco(p);
            SunOslo(p);
            TempJakarta(p);
            MoreWindy();
            Humidity();
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();


        }
        static void WeatherMoroco(APIcontrol p)
        {
            
            p.GetInfo("31.791702","-7.09262");
            
            Console.WriteLine("The Weather in Morocco is :" +  p.objectRes.weather[0].description);
        }
        static void SunOslo(APIcontrol p)
        {
            
            p.GetInfo("59.9138688","10.7522454");
            
            Console.WriteLine("The Sun rise at "+  UnixTimeStampToDateTime(p.objectRes.sys.sunrise).ToString("HH:mm:ss")+" UTC and set at "+UnixTimeStampToDateTime(p.objectRes.sys.sunset).ToString("HH:mm:ss")+" UTC in Oslo " );
        }
        
        static void TempJakarta(APIcontrol p)
        {
            
            p.GetInfo("-6.2087634","106.845599");
            
            Console.WriteLine("The Temperature in Jakarta in Celsius is " +  p.objectRes.main.temp);
        }
        static void MoreWindy()
        {
            var NY = new APIcontrol();
            var T = new APIcontrol();
            var P = new APIcontrol();

            
            NY.GetInfo("40.712784","-74.005941");
            T.GetInfo("35.652832","139.839478");
            P.GetInfo("48.856614","2.3522219");
       

            if (P.objectRes.wind.speed > NY.objectRes.wind.speed && P.objectRes.wind.speed > T.objectRes.wind.speed)
            {
                Console.WriteLine("The more Windy out of New-York, Tokyo and Paris is Paris with a wind speed of " +  P.objectRes.wind.speed +"meter/sec");
            }
            else if (NY.objectRes.wind.speed > P.objectRes.wind.speed && NY.objectRes.wind.speed > T.objectRes.wind.speed)
            {
                Console.WriteLine("The more Windy out of New-York, Tokyo and Paris is NewYork with a wind speed of " +  NY.objectRes.wind.speed +"meter/sec");
            }
            else
            {
                Console.WriteLine("The more Windy out of New-York, Tokyo and Paris is Tokyo with a wind speed of " +  T.objectRes.wind.speed +"meter/sec");
            }
        }
        static void Humidity()
        {
            
            var K = new APIcontrol();
            var M = new APIcontrol();
            var B = new APIcontrol();
            
            K.GetInfo("50.450001","30.523333");
            M.GetInfo("55.751244","37.618423");
            B.GetInfo("52.520008","13.404954");
            Console.WriteLine("The Humidity is "+K.objectRes.main.humidity +" and the preasure is "+K.objectRes.main.pressure +" at Kiev" );
            Console.WriteLine("The Humidity is "+M.objectRes.main.humidity +" and the preasure is "+M.objectRes.main.pressure +" at Moscow" );
            Console.WriteLine("The Humidity is "+B.objectRes.main.humidity +" and the preasure is "+B.objectRes.main.pressure +" at Berlin" );
        }
        
        public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            
            return dateTime;
        }
    }
}