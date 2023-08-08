using GraphQL_Intro.Models;

namespace GraphQL_Intro.GraphQL.Queries
{
    public class SupplierType : ObjectType<Supplier>
    {
        protected override void Configure(IObjectTypeDescriptor<Supplier> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.FirstName).Type<StringType>();
            descriptor.Field(a => a.LastName).Type<StringType>();
        }
    }
}
