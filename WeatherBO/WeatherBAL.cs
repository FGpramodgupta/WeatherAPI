using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using WeatherVO;
using System.Web;
 

namespace WeatherBO
{
    public class WeatherBAL
    {

        public FetchWeatherResponse FetchWeatherByID(string cityID)
        {
            FetchWeatherResponse fetchWeatherResponse = new FetchWeatherResponse();

            ResponseWeather responseWeather;
            /*Calling API http://openweathermap.org/api */
            string apiKey = ConfigurationManager.AppSettings["AppID"].ToString();
            HttpWebRequest apiRequest =
            WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" +
            cityID + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            responseWeather = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
            fetchWeatherResponse.ErrorCode = "0";
            fetchWeatherResponse.ErrorDescription = "";
            fetchWeatherResponse.ResponseWeather = responseWeather;
            return fetchWeatherResponse;
        }

    }
}
