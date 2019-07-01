# OpenWeatherMap-API - C# Library
### Overview
This library takes what openweathermap api returns in JSON, and converts it to C# objects for easy interaction with in C# projects.  It supports (most/all) of the returned data the API returns in JSON. The JSON api returned properties are sometimes present, and sometimes not.  I have done my best to detect properties that are prone to not being presented, and assigning those values null.  You should check certain properties for null vals before assigning under the assumption they are good values.  It is also possible I missed values, and the C# library may nullref.  This project was originally created to be used in a Twitch chat bot, but has been released for others to use.

### Returned Data
- Clouds
  * All - Level of cloudiness (percentage of cloud cover?)
- Coords
  * Longitude - Query location longitude
  * Latitude - Query location latitude
- Main
  * CelsiusCurrent - Returns converted Kelvin values of current temperature in Centigrade
  * FahrenheitCurrent - Returns converted Kelvin values of current temperature in Fahrenheight
  * KelvinCurrent - Returns raw openweather API values for temperature in Kelvin
  * CelsiusMinimum - Returns converted Kelvin values of minimum temperature in Centigrade
  * CelsiusMaximum - Returns converted Kelvin values of maximum temperature in Centigrade
  * FahrenheitMinimum - Returns converted Kelvin values of minimum temperature in Fahrenheight
  * FahrenheitMaximum - Returns converted Kelvin values of maximum temperature in Fahrenheight
  * KelvinMinimum - Returns raw openweather API values for minimum temperature in Kelvin
  * KelvinMaximum - Returns raw openweather API values for maximum temperatures in Kelvin
  * SeaLevel - Returns atmospheric pressure on sea level, hPa, raw from openweather API
  * GroundLevel - Returns atmospheric pressure on ground level, hPa, raw from openweather API
- Rain
  * 3h - Returns rain related data for the last 3 hours at query location (if available).
- Snow
  * 3h - Returns snow related data for the last 3 hours at query location (if available).
- Sys
  * Type - System related parameter, avoid usage
  * ID - Openweather API city identification int
  * Message - System related parameter, avoid usage
  * Country - Country code of given query location
  * Sunrise - Returns DateTime for sunrise converted from openweather API returned unix time.
  * Sunset - Returns DateTime for sunset converted from openweather API returned unix time.
- Weather
  * ID - System related parameter, avoid usage
  * Main - Main description of the weather (IE rain, snow, etc.)
  * Description - Description of main parameter (heavy intensity rain, etc)
  * Icon - Weather icon ID
- Wind
  * SpeedMetersPerSecond -  Gives wind speed in raw values returned by openweathermap api, in meters per second
  * SpeedFeetPerSecond - Gives wind speed in converted values in feet per second
  * Direction - Returns DirectionEnum with details of direction of wind on basis of degree
  * Degree - Returns raw 360-oriented degree returned by openweathermap api
  * Gust - Returns speed of wind gusts in meters per second
### Added Functionality
- FetchWeatherByID :  In this method you can get the weathere details by passing city id.
- FetchAllWeatherByJson - In this method you can get the weathere details by passing list of city as per the format given at     http://bulk.openweathermap.org/sample/city.list.json.gz and in the response you will get weather details of all the inputed citie.




