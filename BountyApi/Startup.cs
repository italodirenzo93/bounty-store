using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BountyApi.Models;

namespace BountyApi
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
            services.AddDbContext<BountyContext>(opts => opts.UseInMemoryDatabase("Bounties"));
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var context = app.ApplicationServices.GetService<BountyContext>();
            CreateTestData(context);

            // Accept requests from our client app
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080"));

            app.UseMvc();
        }

        private static void CreateTestData(BountyContext context)
        {
            Bounty[] testData =
            {
                new Bounty
                {
                    Name = "Filthy Hands Floyd",
                    Description = "",
                    AliveReward = 900.00m,
                    DeadReward = 300.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Boilz Booty",
                    Description = "",
                    AliveReward = 750.50m,
                    DeadReward = 230.15m,
                    Captured = true
                },
                new Bounty
                {
                    Name = "Packrat Polluka",
                    Description = "",
                    AliveReward = 1000.00m,
                    DeadReward = 100.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Dangerous Dave",
                    Description = "",
                    AliveReward = 550.00m,
                    DeadReward = 510.10m,
                    Captured = true
                },
                new Bounty
                {
                    Name = "Filthy Hands Floyd",
                    Description = "",
                    AliveReward = 900.00m,
                    DeadReward = 300.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Filthy Hands Floyd",
                    Description = "",
                    AliveReward = 900.00m,
                    DeadReward = 300.00m,
                    Captured = false
                },
            };

            context.AddRange(testData);
            context.SaveChanges();
        }
    }
}
