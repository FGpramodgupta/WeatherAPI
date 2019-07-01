using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web;
using System.IO;
using WeatherVO;
using WeatherBO;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace WeatherService.Controllers
{
    public class WeatherServiceController : ApiController
    {
        [HttpPost]
        [ActionName("GetAll")]
        public async Task<HttpResponseMessage> FetchAllWeather()
        {
            string folderName = "InputWeather";
            string outputFileName = "InputWeather";
            string inputFilename = String.Format("{0}__{1:dd-MM-yyyy}", folderName, DateTime.Now);
            string outputFilename = String.Format("{0}__{1:dd-MM-yyyy}", outputFileName, DateTime.Now);
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var fileUploadSavePath = HttpContext.Current.Server.MapPath("~/uploads/" + inputFilename);
            if (!Directory.Exists(fileUploadSavePath))
            {
                Directory.CreateDirectory(fileUploadSavePath);
            }
            string JSONResponse = String.Empty;

            List<WeatherJsonInput> responseWeather = new List<WeatherJsonInput>();
            if (httpRequest.Files.Count > 0)
            {
                var responseWeatherList = new List<ResponseWeather>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    var filePath = fileUploadSavePath + "/" + postedFile.FileName;
                    postedFile.SaveAs(filePath);
                    StreamReader reader = new StreamReader(postedFile.InputStream);
                    string strFileResponse = reader.ReadToEnd();
                    responseWeather = JsonConvert.DeserializeObject<List<WeatherJsonInput>>(strFileResponse);

                    FetchWeatherRequest fetchWeatherRequest = new FetchWeatherRequest();
                    FetchWeatherResponse fetchWeatherResponse = new FetchWeatherResponse();
                    foreach (WeatherJsonInput values in responseWeather)
                    {
                        fetchWeatherRequest.City = values.id;
                        fetchWeatherResponse = FetchWeather(fetchWeatherRequest);
                        if (fetchWeatherResponse.ErrorCode == "0")
                        {
                            responseWeatherList.Add(fetchWeatherResponse.ResponseWeather);
                        }
                    }
                    JSONResponse = JsonConvert.SerializeObject(responseWeatherList);
                    File.WriteAllText(fileUploadSavePath + "/" + outputFilename + ".json", JSONResponse);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, responseWeatherList);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        [HttpPost]
        [ActionName("ByID")]
        public FetchWeatherResponse FetchWeather(FetchWeatherRequest fetchWeatherRequest)
        {
            FetchWeatherResponse fetchWeatherResponse = new FetchWeatherResponse();
            WeatherBAL objWeatherBAL = new WeatherBAL();
            try
            {
                string cities = fetchWeatherRequest.City;
                if (cities != null)
                {
                    fetchWeatherResponse = objWeatherBAL.FetchWeatherByID(cities);
                }
                else
                {
                    fetchWeatherResponse.ErrorCode = "1";
                    fetchWeatherResponse.ErrorDescription = "Invalid Request";
                }
            }
            catch (Exception ex)
            {
                fetchWeatherResponse.ErrorCode = "1";
                fetchWeatherResponse.ErrorDescription = ex.Message;
            }
            return fetchWeatherResponse;
        }
    }
}