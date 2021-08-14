namespace PokemonTcgSdk.Client
{
    public class ApiResponse
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }
    }
}