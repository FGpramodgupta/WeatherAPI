using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Models
{
    public class FetchWeatherRequest
    {
        string objCity;
        public string City
        {
            get { return objCity; }
            set { objCity = value; }
        }
    }
}