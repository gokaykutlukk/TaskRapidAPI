using Microsoft.AspNetCore.Mvc;
using TaskRapidAPI.Models;

namespace TaskRapidAPI.ViewComponents
{
    public class _SoccerComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free-api-live-football-data.p.rapidapi.com/football-current-live"),
                Headers =
    {
        { "x-rapidapi-key", "d003d77d28msh4fdf3b32490918bp1e0950jsn153e44080b0b" },
        { "x-rapidapi-host", "free-api-live-football-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<SoccerViewModel>(body);
                return View(model);
            }
        }
    }
}
