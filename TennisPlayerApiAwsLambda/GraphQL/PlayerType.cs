using GraphQL.Types;
using TennisPlayerApiAwsLambda.Models;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.BirthPlace);
            Field(x => x.Residence);
            Field(x => x.WeightLbs);
            Field<StringGraphType>("birthDate", resolve: context => context.Source.BirthDate.ToShortDateString());
            //Field<ListGraphType<SkaterStatisticType>>("skaterSeasonStats",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //    resolve: context => skaterStatisticRepository.Get(context.Source.Id), description: "Player's skater stats");
        }
    }
}
