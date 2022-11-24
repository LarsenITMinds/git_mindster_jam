namespace GitsterJam.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecast(int count);
        Task<string> GetMagic();
    }

    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Solid Ice",
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Sweltering",
            "Scorching",
            "Liquid Lava"
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

        public async Task<string> GetMagic()
        {
            var jnadw = "Hey";
            return await Task.FromResult(jnadw);
        }
    }
}
