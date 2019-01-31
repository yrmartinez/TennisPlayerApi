using GraphQL.Types;
using TennisPlayerApiAwsLambda.Models;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.GraphQL
{
    public class TennisPlayerMutation : ObjectGraphType
    {
        public TennisPlayerMutation(ICrudBaseService<Player> playerService, ICrudBaseService<Season> seasonService, ICrudBaseService<Tournament> tournamentService)
        {
            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return playerService.Create(player);
                });

            Field<StringGraphType>(
                "deletePlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var playerId = context.GetArgument<string>("id");
                    playerService.Remove(playerId);
                    return playerId;
                });

            Field<SeasonType>(
                "createSeason",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SeasonInputType>> { Name = "season" }
                ),
                resolve: context =>
                {
                    var season = context.GetArgument<Season>("season");
                    return seasonService.Create(season);
                });

            Field<StringGraphType>(
                "deleteSeason",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var seasonId = context.GetArgument<string>("id");
                    seasonService.Remove(seasonId);
                    return seasonId;
                });

            Field<TournamentType>(
                "createTournament",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TournamentInputType>> { Name = "tournament" }
                ),
                resolve: context =>
                {
                    var tournament = context.GetArgument<Tournament>("tournament");
                    return tournamentService.Create(tournament);
                });

            Field<StringGraphType>(
                "deleteTournament",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var tournamentId = context.GetArgument<string>("id");
                    tournamentService.Remove(tournamentId);
                    return tournamentId;
                });
        }
    }
}
