namespace PokemonTcgSdk.Standard.Tests
{
    using Moq;
    using NUnit.Framework;
    using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
    using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

    public class PokemonTests
    {
        private PokemonApiClient _client;

        [SetUp]
        public void Setup()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var client = new HttpClient();
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            var factory = mockFactory.Object;
            _client = new PokemonApiClient(factory.CreateClient(), string.Empty);
        }

        [Test]
        public async Task FetchSets()
        {
            var response = await _client.GetSets();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Result.TotalCount > 0);
        }
    }
}