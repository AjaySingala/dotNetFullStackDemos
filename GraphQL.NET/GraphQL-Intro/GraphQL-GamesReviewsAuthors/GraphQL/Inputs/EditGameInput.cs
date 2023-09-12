using System.ComponentModel.DataAnnotations;

namespace GraphQL_GamesReviewsAuthors.GraphQL.Inputs
{
    public record EditGameInput(
        string? Title,
        List<string>? Platforms
    );
}
