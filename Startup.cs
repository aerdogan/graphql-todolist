using GraphQL.Server.Ui.Voyager;
using graphql_todolist.Data;
using graphql_todolist.GraphQL;
using graphql_todolist.GraphQL.Lists;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace graphql_todolist
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApiDbContext>( options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddGraphQLServer()
                        .AddQueryType<Query>()
                        .AddType<ListType>()
                        .AddProjections()
                        .AddMutationType<Mutation>()
                        .AddFiltering()
                        .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
            });

            app.UseGraphQLVoyager(new VoyagerOptions(){
                GraphQLEndPoint = "/graphql"
            }, "graphql-ui");
        }
    }
}
