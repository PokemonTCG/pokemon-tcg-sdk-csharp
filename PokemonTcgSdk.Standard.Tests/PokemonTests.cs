namespace PokemonTcgSdk.Standard.Tests
{
    using Features.FilterBuilder.Energy;
    using Features.FilterBuilder.Pokemon;
    using Features.FilterBuilder.Set;
    using Features.FilterBuilder.Trainer;
    using Infrastructure.HttpClients;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Infrastructure.HttpClients.Base;
    using Infrastructure.HttpClients.Cards;
    using Infrastructure.HttpClients.Rarities;
    using Infrastructure.HttpClients.Set;
    using Infrastructure.HttpClients.SubTypes;
    using Infrastructure.HttpClients.SuperTypes;
    using Infrastructure.HttpClients.Types;
    using RichardSzalay.MockHttp;

    public class PokemonTests
    {
        [Test]
        public async Task GetApiResourcePageAsync()
        {
            // assemble
            var set = new ApiResourceList<Set>();

            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect("*sets").Respond("application/json", JsonConvert.SerializeObject(set));

            var client = new PokemonApiClient(mockHttp);

            // act
            var page = await client.GetApiResourceAsync<Set>();

            // assert
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Test]
        public async Task GetSet_ApiResourcePageAsync_Pagination()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetApiResourceAsync<Set>(take: 10, skip: 2);

            // assert
            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetSet_ApiResourcePageAsync_Filter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            var filter = new SetFilterCollection<string, string> {{"legalities.standard", "legal"}};

            // act
            var page = await pokeClient.GetApiResourceAsync<Set>(filter);

            // assert
            Assert.That(page.Results.FirstOrDefault()?.Legalities.Standard, Is.EqualTo("Legal"));
            Assert.That(page.Results.LastOrDefault()?.Legalities.Standard, Is.EqualTo("Legal"));
        }

        [Test]
        public async Task GetSet_ApiResourcePageAsync_PaginationWithFilter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);
            var filter = new SetFilterCollection<string, string> { { "legalities.standard", "legal" } };

            // act
            var page = await pokeClient.GetApiResourceAsync<Set>(5, 2, filter);

            // assert
            Assert.That(page.Results.FirstOrDefault()?.Legalities.Standard, Is.EqualTo("Legal"));
            Assert.That(page.Results.LastOrDefault()?.Legalities.Standard, Is.EqualTo("Legal"));

            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("5").NoClip);
        }

        [Test]
        public async Task GetCard_Resource_ApiResourcePageAsyncPagination()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetApiResourceAsync<Card>(take: 10, skip: 2);

            // assert
            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetCard_ApiResourcePageAsync_PaginationWithFilter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);
            var filter = new Dictionary<string, string>();
            filter.Add("hp", "60");

            // act
            var page = await pokeClient.GetApiResourceAsync<Card>(5, 2, filter);

            // assert
            Assert.That(page.Results.FirstOrDefault()?.Hp, Is.EqualTo(60));
            Assert.That(page.Results.LastOrDefault()?.Hp, Is.EqualTo(60));

            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("5").NoClip);
        }

        [Test]
        public async Task GetPokemon_Resource_ApiResourcePageAsyncPagination()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetApiResourceAsync<PokemonCard>(take: 10, skip: 2);

            // assert
            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetPokemon_ApiResourcePageAsync_PaginationWithFilter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            var filter = new PokemonFilterCollection<string, string>()
                .AddName("Darkrai");
            filter.Add("legalities.standard", "legal");


            // act
            var page = await pokeClient.GetApiResourceAsync<PokemonCard>(10, 2, filter);

            // assert
            StringAssert.Contains("Darkrai", page.Results.FirstOrDefault()?.Name);
            StringAssert.Contains("Darkrai", page.Results.LastOrDefault()?.Name);

            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetTrainer_Resource_ApiResourcePageAsyncPagination()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetApiResourceAsync<TrainerCard>(take: 10, skip: 2);

            // assert
            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetTrainer_ApiResourcePageAsync_PaginationWithFilter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);
            var filter = new TrainerFilterCollection<string, string>().AddName("Tropical Wind");
            // act
            var page = await pokeClient.GetApiResourceAsync<TrainerCard>(2, 2, filter);

            // assert
            Assert.That(page.Results.FirstOrDefault()?.Name, Is.EqualTo("Tropical Wind"));
            Assert.That(page.Results.LastOrDefault()?.Name, Is.EqualTo("Tropical Wind"));

            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("2").NoClip);
        }

        [Test]
        public async Task GetEnergy_Resource_ApiResourcePageAsyncPagination()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetApiResourceAsync<EnergyCard>(take: 10, skip: 2);

            // assert
            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("10").NoClip);
        }

        [Test]
        public async Task GetEnergy_ApiResourcePageAsync_PaginationWithFilter()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);
            var filter = new EnergyFilterCollection<string, string>().AddName("Double Rainbow Energy");
            // act
            var page = await pokeClient.GetApiResourceAsync<TrainerCard>(2, 2, filter);

            // assert
            Assert.That(page.Results.FirstOrDefault()?.Name, Is.EqualTo("Double Rainbow Energy"));
            Assert.That(page.Results.LastOrDefault()?.Name, Is.EqualTo("Double Rainbow Energy"));

            Assert.That(page.Page, Is.EqualTo("2").NoClip);
            Assert.That(page.PageSize, Is.EqualTo("2").NoClip);
        }

        [Test]
        public async Task GetSubtypes_ApiResourcePageAsync()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetStringResourceAsync<SubTypes>();

            // assert
            Assert.That(page.SubType, Is.Not.Empty);
            Assert.That(page.SubType.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task GetSuperTypes_ApiResourcePageAsync()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetStringResourceAsync<SuperTypes>();

            // assert
            Assert.That(page.SuperType, Is.Not.Empty);
            Assert.That(page.SuperType.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task GetElementTypes_ApiResourcePageAsync()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetStringResourceAsync<ElementTypes>();

            // assert
            Assert.That(page.ElementType, Is.Not.Empty);
            Assert.That(page.ElementType.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task GetRarities_ApiResourcePageAsync()
        {
            // assemble
            var httpclient = new HttpClient();
            var pokeClient = new PokemonApiClient(httpclient);

            // act
            var page = await pokeClient.GetStringResourceAsync<Rarities>();

            // assert
            Assert.That(page.Rarity, Is.Not.Empty);
            Assert.That(page.Rarity.Count, Is.GreaterThanOrEqualTo(1));
        }
    }
}