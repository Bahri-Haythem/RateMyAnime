using System;
using Random = RateMyAnime.Models.Random;

public class DataService : IDataService
{
    private IConfiguration _configuration { get; set; }
    private Settings _settings { get; set; }
    public DataService(IConfiguration configuration, Settings settings)
    {
        _configuration = configuration;
        _settings = settings;
    }
    #region deprecatedJikanVersion
    public async Task<Reviews> GetReviewsAsync(int id)
    {
        var baseUrl = _configuration["BaseUrl"];

        var client = new RestClient(baseUrl);
        var request = new RestRequest("anime/" + id + "/reviews");
        request.AddHeader("X-RapidAPI-Host", _settings.ApiHost);
        request.AddHeader("X-RapidAPI-Key", _settings.ApiKey);
        var reviews = await client.GetAsync<Reviews>(request);
        return reviews;
    }
    public async Task<string> GetAnimeAsync()
    {
        var baseUrl = _configuration["BaseUrl"];

        var client = new RestClient(baseUrl);
        var request = new RestRequest("anime");
        request.AddHeader("X-RapidAPI-Host", _settings.ApiHost);
        request.AddHeader("X-RapidAPI-Key", _settings.ApiKey);
        var reviews = await client.GetAsync(request);
        return reviews.Content;
    }
    #endregion
    public async Task<Result> GetRandomScoreAsync()
    {
        var baseUrl = _configuration["BaseUrlV4"];

        var client = new RestClient(baseUrl);
        var request = new RestRequest("random/anime");
        double score;
        Random random;
        do
        {
            random = await client.GetAsync<Random>(request);
            await Task.Delay(500);
            score = await GetScoreFromEpisodesAsync(random.data.Id);
        } while (score == 0);
        return new Result { Name = random.data.title, Score = score };
    }

    public async Task<Result> GetAnimeScoreAsync(string animeName)
    {
        if (string.IsNullOrEmpty(animeName))
            return new Result();
        var baseUrl = _configuration["BaseUrlV4"];

        var client = new RestClient(baseUrl);
        var request = new RestRequest("anime");
        request.AddParameter("q", animeName);
        request.AddParameter("type", "tv");
        var episodes = await client.GetAsync<Episodes>(request);
        if (episodes.data.Count == 0)
            return new Result { Name = "No result", Score = 0 };
        else
        {
            var score = await GetScoreFromEpisodesAsync(episodes.data[0].mal_id);
            return new Result { Name = episodes.data[0].title, Score = score };
        }
    }

    public async Task<double> GetScoreFromEpisodesAsync(int id)
    {
        var baseUrl = _configuration["BaseUrlV4"];

        var client = new RestClient(baseUrl);
        var request = new RestRequest("anime/" + id + "/episodes");
        request.Timeout = 1000;
        try
        {
            var episodes = await client.GetAsync<Episodes>(request);
            double rating = 0;
            int total = 0;
            if (episodes.data.Count == 0)
                return 0;
            else
            {
                // I get TooManyRequests Exception if I exceed 3 calls
                for (int i = 1; i <= episodes.pagination.last_visible_page && i < 3; i++)
                {
                    await Task.Delay(300);
                    request = new RestRequest("anime/" + id + "/episodes");
                    request.AddParameter("page", i);
                    episodes = await client.GetAsync<Episodes>(request);
                    total += episodes.data.Count;
                    foreach (var ep in episodes.data)
                    {
                        if (ep.score != null)
                            rating += ep.score ?? 0;
                        else
                            total--;
                    }
                }
            }
            if (rating == 0 || total == 0)
                return 0;
            return Math.Round(rating / total, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }
    }
}

