using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;
using HotChocolate.Subscriptions;

#region Sample GraphQL Query

/* Write your query or mutation here
Suppliers:
query {
    allSuppliers {
        id
        firstName
        lastName
    }
    supplier(id: 2) {
        id
        firstName
        lastName
    }
}

Authors:
query {
  allAuthors {
    id
    name
  }
  author(id: 2) {
    id
    name
  }
}

Multiple queries:

query GetAllAuthors {
  allAuthors {
    id
    name
  }
}
query GetAuthor {
    author(id: 2) {
       id
       name
  }
}
*/

#endregion

namespace GraphQL_Intro.GraphQL.Queries
{
    public partial class Query
    {
        #region Suppliers.

        public async Task<List<Supplier>> GetAllSuppliers(
            [Service] ISupplierRepository supplierRepository,
            [Service] ITopicEventSender eventSender)
        {
            List<Supplier> suppliers = await supplierRepository.GetSuppliers();
            await eventSender.SendAsync("Returned a list of Suppliers",
              suppliers);
            return suppliers;
        }

        public async Task<Supplier> GetSupplier(
            [Service] ISupplierRepository supplierRepository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            Supplier supplier = await supplierRepository.GetSupplier(id);
            await eventSender.SendAsync("Returned a Supplier",
              supplier);
            return supplier;
        }

        #endregion

        #region Authors.

        public async Task<List<Author>> GetAllAuthorsAsync(
            [Service] IAuthorRepository repository,
            [Service] ITopicEventSender eventSender)
        {
            var authors = await repository.GetAuthorsAsync();
            await eventSender.SendAsync("Returned a list of Authors", authors);

            return authors;
        }

        public async Task<Author> GetAuthorAsync(
            [Service] IAuthorRepository repository,
            [Service] ITopicEventSender eventSender,
            int id)
        {
            var author = await repository.GetAuthorAsync(id);
            await eventSender.SendAsync("Returned an Author", author);

            return author;
        }



        #endregion
    }
}
