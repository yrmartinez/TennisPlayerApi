using GraphQL.Types;
using TennisPlayerApiAwsLambda.Models;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class TennisPlayerQuery : ObjectGraphType
    {
        public TennisPlayerQuery(ICrudBaseService<Player> playerService, ICrudBaseService<Season> seasonService, ICrudBaseService<Tournament> tournamentService)
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => playerService.Get(context.GetArgument<string>("id")));

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => playerService.Get());

            Field<SeasonType>(
                "season",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => seasonService.Get(context.GetArgument<string>("id")));

            Field<ListGraphType<SeasonType>>(
                "seasons",
                resolve: context => seasonService.Get());

            Field<TournamentType>(
                "tournament",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context => tournamentService.Get(context.GetArgument<string>("id")));

            Field<ListGraphType<TournamentType>>(
                "tournaments",
                resolve: context => tournamentService.Get());
        }
    }
}
