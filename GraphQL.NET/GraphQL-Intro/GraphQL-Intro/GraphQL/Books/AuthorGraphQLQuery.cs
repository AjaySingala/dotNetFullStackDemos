using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;
using HotChocolate.Subscriptions;

namespace GraphQL_Intro.GraphQL.Books
{
    public class AuthorGraphQLQuery
    {
        //public async Task<List<Author>> GetAllAuthorsAsync(
        //    [Service] IAuthorRepository repository,
        //    [Service] ITopicEventSender eventSender)
        //{
        //    var authors = await repository.GetAuthorsAsync();
        //    await eventSender.SendAsync("Returned a list of Authors", authors);

        //    return authors;
        //}

        //public async Task<Author> GetAuthorAsync(
        //    [Service] IAuthorRepository repository,
        //    [Service] ITopicEventSender eventSender,
        //    int id)
        //{
        //    var author = await repository.GetAuthorAsync(id);
        //    await eventSender.SendAsync("Returned an Author", author);

        //    return author;
        //}
    }
}
