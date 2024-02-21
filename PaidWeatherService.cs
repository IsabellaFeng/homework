namespace homework
{
    public class PaidWeatherService: IWeatherService
    {
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private string calculateSummary(int temperature){
            if (temperature == 55) return Summaries[Summaries.Length - 1];
            var summaryLength = Summaries.Length;
            var index = (int)((temperature + 20) / (double)(75 / summaryLength));

            return Summaries[index];
         }


        public IEnumerable<WeatherForecast> Get(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException();
            }
            var randomTemp = Random.Shared.Next(-20, 55);
            return Enumerable.Range(1, index).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = randomTemp,
                Summary = calculateSummary(randomTemp)
            })
            .ToArray();
        }
    }
}
