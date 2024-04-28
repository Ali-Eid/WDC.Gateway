using System;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Ocelot
            await app.UseOcelot();
        }
    }
}

//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

//var builder = WebApplication.CreateBuilder(args);

//// Configure ocelot.json (if used)
//if (File.Exists("ocelot.json"))
//{
//    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
//}
//builder.Services.AddOcelot(builder.Configuration);

//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//await app.UseOcelot();  // Use Ocelot as the final middleware

//app.Run();