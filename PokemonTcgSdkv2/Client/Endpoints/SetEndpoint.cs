using System;

namespace PokemonTcgSdkV2.Client.Endpoints
{
    public class SetEndpoint : IQueryableApiEndpoint, ISupportsIdApiEndpoint<string>
    {
        public string ApiUri()
        {
            return "sets";
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