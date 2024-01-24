using System.ComponentModel.DataAnnotations;

namespace RateMyAnime.Controllers;

public class HomeController : ICarterModule
{
    private IDataService _dataService { get; }

    public HomeController(IDataService dataService)
    {
        _dataService = dataService;
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/randomScore", async () =>
        {
            //Reviews reviews = await _dataService.GetReviewsAsync(23);
            var score = await _dataService.GetRandomScoreAsync();
            return score;
        });
        app.MapGet("/api/animeScore", async ([Required] string animeName) =>
            await _dataService.GetAnimeScoreAsync(animeName)
        );
    }
}