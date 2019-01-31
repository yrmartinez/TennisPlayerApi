using GraphQL.Types;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class SeasonInputType : InputObjectGraphType
    {
        public SeasonInputType()
        {
            Name = "SeasonInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}