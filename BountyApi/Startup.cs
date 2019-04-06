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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BountyContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            CreateTestData(context);

            // Accept requests from our client app
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
        }

        private static void CreateTestData(BountyContext context)
        {
            Bounty[] testData =
            {
                new Bounty
                {
                    Name = "Filthy Hands Floyd",
                    Description = "He betrayed his partner and took off with all his loot. Filth ain't the only thing he's got on his hands.",
                    AliveReward = 900.00m,
                    DeadReward = 300.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Boilz Booty",
                    Description = "The value on this guy has shot up lately. Bring him back alive and we'll pay you handsomely.",
                    AliveReward = 750.50m,
                    DeadReward = 230.15m,
                    Captured = true
                },
                new Bounty
                {
                    Name = "Packrat Polluka",
                    Description = "He's packin' a whole load of cash he stole from the city bank. Find him and bring him back...dead or alive!",
                    AliveReward = 1000.00m,
                    DeadReward = 100.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Dangerous Dave",
                    Description = "Danger is his middle name and he's gonna make sure everyone knows it until he's caught!",
                    AliveReward = 550.00m,
                    DeadReward = 510.10m,
                    Captured = true
                },
                new Bounty
                {
                    Name = "Long John Silver",
                    Description = "Ol' Long John probably ain't got much life left in him. That doesn't mean he gets to spend the rest of it robbin' trains.",
                    AliveReward = 350.00m,
                    DeadReward = 300.00m,
                    Captured = false
                },
                new Bounty
                {
                    Name = "Red Sam",
                    Description = "He's scheduled to be executed once caught. Bring him back dead so we can save ourselves the time.",
                    AliveReward = 300.00m,
                    DeadReward = 1000.00m,
                    Captured = false
                },
            };

            context.AddRange(testData);
            context.SaveChanges();
        }
    }
}
