using GraphQL_Intro.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL_Intro.GraphQL.Books
{
    public class AuthorSubscription
    {
        public async ValueTask<ISourceStream<List<Author>>> OnAuthorGet(
            [Service] ITopicEventReceiver eventReceiver,
                       CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<List<Author>>(
                               "Returned Authors", cancellationToken);
        }
    }
}
