namespace ThhTransTracker.Infrastructure.Helpers
{
    public static class HelperMethods
    {
        public static string GetPaginationInfo<T>(Result<PagedList<T>> result)
        {
            var metadata = new
            {
                result.Content.TotalCount,
                result.Content.PageSize,
                result.Content.CurrentPage,
                result.Content.TotalPages,
                result.Content.HasNext,
                result.Content.HasPrevious
            };
            var options = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(metadata, options);
        }
    }
}
