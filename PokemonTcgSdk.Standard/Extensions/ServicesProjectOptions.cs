namespace PokemonTcgSdk.Standard.Extensions
{
    using System.ComponentModel.DataAnnotations;

    public sealed class ServicesProjectOptions
    {
        [Required]
        public string ApiKey { get; set; }
    }
}