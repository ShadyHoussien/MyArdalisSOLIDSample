using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var reader = new JsonFileReader();
            var factory = new PolicyRaterFactory(logger);

            logger.Log("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine(logger, reader, factory);
            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }

        }
    }
}
