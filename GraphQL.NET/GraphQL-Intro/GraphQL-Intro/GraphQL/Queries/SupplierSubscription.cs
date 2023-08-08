using GraphQL_Intro.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL_Intro.GraphQL.Queries
{
    public class SupplierSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<Supplier>>> OnSuppliersGet(
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<List<Supplier>>(
                "Returned Suppliers", cancellationToken);
        }
    }
}
