namespace homework
{
    public interface IWeatherService
    {
        public IEnumerable<WeatherForecast> Get(int index);
    }
}
