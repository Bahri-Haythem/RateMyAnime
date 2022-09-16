public interface IDataService
{
    #region deprecatedJikanVersion
    Task<Reviews> GetReviewsAsync(int id);
    Task<string> GetAnimeAsync();
    #endregion
    Task<Result> GetRandomScoreAsync();
    Task<Result> GetAnimeScoreAsync(string animeName);
}