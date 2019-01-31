using GraphQL.Types;
using TennisPlayerApiAwsLambda.Models;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class TournamentType : ObjectGraphType<Tournament>
    {
        public TournamentType(ICrudBaseService<Season> seasonService)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.SeasonId);
            Field<SeasonType>("season", resolve: context => seasonService.Get(context.Source.SeasonId));
            //Field<Match>("season", resolve: context => context.Source);
        }
    }
}