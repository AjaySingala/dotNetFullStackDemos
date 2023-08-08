using GraphQL_Intro.GraphQL.Inputs;
using GraphQL_Intro.GraphQL.Payloads;
using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;

#region Sample GraphQL Query

/*
mutation AddAuthor {
  addAuthor(input: {
    name: "Scott"
  })
  {
    author {
      id
    }
  }
}
*/

#endregion

namespace GraphQL_Intro.GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<AddAuthorPayload> AddAuthorAsync(
            AddAuthorInput input,
            [Service] IAuthorRepository repository,
            CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = input.Name
            };

            //await repository.AddAuthorAsync(author, cancellationToken);
            await repository.AddAuthorAsync(author);

            return new AddAuthorPayload(author);
        }
    }
}
