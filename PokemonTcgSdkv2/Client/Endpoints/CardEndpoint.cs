using System;

namespace PokemonTcgSdkV2.Client.Endpoints
{
    public class CardEndpoint : IQueryableApiEndpoint, ISupportsIdApiEndpoint<string>
    {
        public string ApiUri()
        {
            return "cards";
        }

        public string BuildQueryString(string query)
        {
            throw new NotImplementedException();
        }

        public string IdPath()
        {
            return "id";
        }
    }
}