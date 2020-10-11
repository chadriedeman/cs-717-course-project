using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;
using WeightTrackerApi.Business.Services;
using WeightTrackerApi.DataAccess;
using WeightTrackerApi.DataAccess.Repositories;

namespace WeightTrackerApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(options => options.EnableEndpointRouting = false);

            services.AddScoped<IDbConnection>(serviceProvider => new SqlConnection(GetDatabaseConnectionString()));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, MockUserRepository>(); // TODO: Change back to UserRepository when DB is setup
            services.AddScoped<IDatabaseConnectionProvider, DatabaseConnectionProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private string GetDatabaseConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = _configuration.GetValue<string>("DatabaseConnectionString"),
                MultipleActiveResultSets = true,
                IntegratedSecurity = false,
                TrustServerCertificate = true
            }
            .ConnectionString;
        }
    }
}
