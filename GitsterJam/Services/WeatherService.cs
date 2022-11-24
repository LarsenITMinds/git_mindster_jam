namespace GitsterJam.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecast();
        Task<string> GetMagic();
    }

    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetForecast()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray());
        }

        public async Task<string> GetMagic()
        {
            var jnadw = "Hey";
            return await Task.FromResult(jnadw);
        }
    }
}
