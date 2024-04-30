using Microsoft.Extensions.Options;

namespace homework
{
    public class WeatherClientResolver
    {
        private readonly WeatherServiceOptions _weatherServiceOptions;
        private readonly WeatherServiceFactory _factory;

        public WeatherClientResolver(
            IOptions<WeatherServiceOptions> weatherServiceOptions,
            WeatherServiceFactory factory
            )
        {
            _weatherServiceOptions = weatherServiceOptions.Value;
            _factory = factory;
        }

        public IWeatherService Resolve()
        {
            return _factory.Create(_weatherServiceOptions.ActiveWeatherService);
        }
    }
}
