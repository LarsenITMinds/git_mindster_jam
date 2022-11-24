namespace GitsterJam.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecast(int count);
    }

    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {


            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetForecast(int amount)
        {


            var summaries = Enumerable.Range(1, amount)
                .Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 45),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

            return await Task.FromResult(summaries);
        }
    }
}
