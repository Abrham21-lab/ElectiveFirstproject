namespace ElectiveClassProject
{
    using System;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            // Subscribe to events
            stopwatch.OnStarted += MessageHandler;
            stopwatch.OnStopped += MessageHandler;
            stopwatch.OnReset += MessageHandler;

            bool running = true;
            Console.WriteLine("Stopwatch Console Application");
            Console.WriteLine("Press S to Start, T to Stop, R to Reset, Q to Quit.");

            while (running)
            {
                Console.Write("\nEnter your choice: ");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.S:
                        stopwatch.Start();
                        break;

                    case ConsoleKey.T:
                        stopwatch.Stop();
                        break;

                    case ConsoleKey.R:
                        stopwatch.Reset();
                        break;

                    case ConsoleKey.Q:
                        stopwatch.Stop();
                        running = false;
                        Console.WriteLine("Exiting the application.");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }
        }

        private static void MessageHandler(string message)
        {
            Console.WriteLine(message);
        }
    }
}
