namespace homework
{
    public class WeatherServiceFactory
    {
        public IWeatherService Create(string type)
        {
            return type switch
            {
                "Paid" => new PaidWeatherService(),
                "Free" => new RandomWeatherService(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
