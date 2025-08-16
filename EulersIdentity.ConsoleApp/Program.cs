// <copyright file="Program.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.ConsoleApp
{
    /// <summary>
    /// Class containing the main entry point for the console application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point for the console application.
        /// </summary>
        /// <param name="args">Optional command line arguments.</param>
        public static void Main(string[] args)
        {
            // This is the entry point of the console application.
            // You can add your code here to execute when the application starts.
            Console.WriteLine("Welcome to Euler's Identity Console App!");
            foreach (var arg in args)
            {
                Console.WriteLine($"Argument: {arg}");
            }

            Console.WriteLine("e^(iπ) + 1 = 0");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
