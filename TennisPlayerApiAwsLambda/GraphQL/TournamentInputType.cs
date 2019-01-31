using GraphQL.Types;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    internal class TournamentInputType : InputObjectGraphType
    {
        public TournamentInputType()
        {
            Name = "TournamentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("seasonId");
        }
    }
}