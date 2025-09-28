// <copyright file="Program.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace EulersIdentity.Web.Server
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

    /// <summary>
    /// Class containing the main entry point for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);

            var app = builder.Build();

            // Debug code
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
                await next.Invoke();
                Console.WriteLine($"Response: {context.Response.StatusCode}");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // app.UseSpa must come after app.UseStaticFiles but before any call to app.MapFallbackToFile
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=2099682
                //spa.Options.SourcePath = "eulersidentity.web.client";
                spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "eulersidentity.web.client");
                if (app.Environment.IsDevelopment())
                {
                    //spa.UseReactDevelopmentServer("http://localhost:52943");
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");
            Console.WriteLine($"Current PATH: {Environment.GetEnvironmentVariable("PATH")}");

            app.Run();
        }
    }
}