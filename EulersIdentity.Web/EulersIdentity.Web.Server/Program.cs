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

            // Map API controllers first
            app.MapControllers();

            // Only proxy non-API routes to the SPA dev server
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "eulersidentity.web.client");
            //    if (app.Environment.IsDevelopment())
            //    {
            //        spa.UseProxyToSpaDevelopmentServer("http://localhost:52943");
            //    }
            //});

            //// Custom fallback for SPA routes only
            //app.MapWhen(
            //    context =>
            //        !context.Request.Path.StartsWithSegments("/api") &&
            //        !context.Request.Path.StartsWithSegments("/swagger") &&
            //        !context.Request.Path.StartsWithSegments("/favicon.ico") &&
            //        !context.Request.Path.StartsWithSegments("/swagger-ui") &&
            //        !context.Request.Path.StartsWithSegments("/v3"),
            //    spaApp => spaApp.UseSpa(spa =>
            //    {
            //        spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "eulersidentity.web.client");
            //        if (app.Environment.IsDevelopment())
            //        {
            //            spa.UseProxyToSpaDevelopmentServer("http://localhost:52943");
            //        }
            //    })
            //);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // Fallback for SPA routes (after API and static files)
            app.MapFallbackToFile("/index.html");

            Console.WriteLine($"Current PATH: {Environment.GetEnvironmentVariable("PATH")}");
            app.Run();
        }
    }
}