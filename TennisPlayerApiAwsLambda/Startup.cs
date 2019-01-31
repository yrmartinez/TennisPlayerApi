using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TennisPlayerApiAwsLambda.Data;
using TennisPlayerApiAwsLambda.GraphQL;
using TennisPlayerApiAwsLambda.Models;
using TennisPlayerApiAwsLambda.Services;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddScoped<DbContextProvider<Player>>();
            services.AddScoped<DbContextProvider<Season>>();
            services.AddScoped<DbContextProvider<Tournament>>();
            services.AddTransient<ICrudBaseService<Player>, CrudBaseService<Player>>();
            services.AddTransient<ICrudBaseService<Season>, CrudBaseService<Season>>();
            services.AddTransient<ICrudBaseService<Tournament>, CrudBaseService<Tournament>>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<TennisPlayerQuery>();
            services.AddSingleton<TennisPlayerMutation>();
            services.AddSingleton<PlayerType>();
            services.AddSingleton<PlayerInputType>();
            services.AddSingleton<SeasonType>();
            services.AddSingleton<SeasonInputType>();
            services.AddSingleton<TournamentType>();
            services.AddSingleton<TournamentInputType>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new TennisPlayerSchema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphiQl("/tennisPlayer/graphql", "/Prod/tennisPlayer");
            app.UseMvc();
        }
    }
}
