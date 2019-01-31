using GraphQL.Types;
using TennisPlayerApiAwsLambda.Models;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class SeasonType : ObjectGraphType<Season>
    {
        public SeasonType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
        }
    }
}
