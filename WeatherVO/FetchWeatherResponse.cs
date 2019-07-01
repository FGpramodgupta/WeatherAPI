using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherVO
{
    public class FetchWeatherResponse
    {

        //string objErrorCode;
        //public string ErrorCode
        //{
        //    get { return objErrorCode; }
        //    set { objErrorCode = value; }
        //}

        //string objErrorDescription;
        //public string ErrorDescription
        //{
        //    get { return objErrorDescription; }
        //    set { objErrorDescription = value; }
        //}
        //ResponseWeather objResponseWeather;
        //public ResponseWeather ResponseWeather
        //{
        //    get { return objResponseWeather; }
        //    set { objResponseWeather = value; }
        //}

        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public ResponseWeather ResponseWeather { get; set; }

    }
}
