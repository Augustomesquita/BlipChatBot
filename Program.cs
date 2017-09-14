using System;
using Take.Blip.Client.Console;

namespace MyBot
{
    class Program
    {
        static int Main(string[] args) => ConsoleRunner.RunAsync(args).GetAwaiter().GetResult();
    }
}