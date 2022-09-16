using System.ComponentModel.DataAnnotations;

public class HomeModule : ICarterModule
{
    public IDataService _dataService { get; set; }
    public HomeModule(IDataService dataService)
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
        {
            var score = await _dataService.GetAnimeScoreAsync(animeName);
            return score;
        });
    }
}
