using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartWarsQL.DotNetCore.Data;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StarWarsQL.DotNetApi.GraphQL;

namespace StarWarsQL.DotNetApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  Add data as a singleton because we only want one instance of the data
            //services.AddDbContext<LocalSqlDb>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SQLLocalDb")));
            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IStarWarsData, StarWarsData>();

            //  I believe we want the Schema to be scoped, so that on each request it instaniates
            //  a new instance
            services.AddScoped<ISchema, StarWarsSchema>();

            services.AddGraphQL(options => {
                options.EnableMetrics = true;
            })
            .AddErrorInfoProvider(opts => opts.ExposeExceptionStackTrace = true)
            .AddSystemTextJson()
            .AddUserContextBuilder(httpsContext => new GraphQLUserContext { User = httpsContext.User });
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            // app.UseRouting();
            //  Use Cross Origin Resource Sharing
            app.UseCors();

            //  Add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>();

            //  Use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();

            // Not using authorization
            // app.UseAuthorization();

            //  Not use REST so no need to map endpoints
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
        }
    }
}
