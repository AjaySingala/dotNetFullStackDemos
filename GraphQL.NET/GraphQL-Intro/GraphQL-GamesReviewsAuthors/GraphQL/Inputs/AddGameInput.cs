using System.ComponentModel.DataAnnotations;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Inputs
{
    public record AddGameInput(
        [Required]
        string Title,
        [Required]
        List<string> Platforms
    );
}
