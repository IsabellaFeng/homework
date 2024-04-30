namespace homework
{
    public static class DependencyInversions
    {
        public static IServiceCollection AddWeatherServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<WeatherServiceFactory>();
            services.AddSingleton<WeatherClientResolver>();
            services.Configure<WeatherServiceOptions>(configuration.GetRequiredSection("WeatherServiceOptions"));

            services.AddTransient<IWeatherService>(sp =>
            {
                var resolver = sp.GetRequiredService<WeatherClientResolver>();
                return resolver.Resolve();
            });

            return services;
        }

    }
}
