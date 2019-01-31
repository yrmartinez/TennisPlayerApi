using GraphQL;
using GraphQL.Types;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class TennisPlayerSchema : Schema
    {
        public TennisPlayerSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TennisPlayerQuery>();
            Mutation = resolver.Resolve<TennisPlayerMutation>();
        }
    }
}
