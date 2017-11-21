using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateKey
{
    public class Program
    {
        private const string DefaultText = "Hello World";
        private const int DefaultDelay = 1000;
        private const int DefaultStartDelay = 5000;
        private const int DefaultIterations = 0;

        public static void Main(string[] args)
        {
            var text = ConfigureText();
            var iterations = ConfigureIterations();
            var delay = ConfigureDelay();
            var startDelay = ConfigureStartDelay();

            var currentIteration = 0;

            Console.WriteLine($"Press Enter to start Script:");
            Console.ReadLine();

            Console.WriteLine($"Script Configured - Wait {startDelay} milliseconds to start it...");
            Console.WriteLine();

            Task.Delay(startDelay).Wait();

            Console.WriteLine("Script is started");
            Console.WriteLine();

            while (iterations == 0 || currentIteration < iterations)
            {
                SendKeys.SendWait($"{text}{{ENTER}}");
                Console.WriteLine($"{text}");
                Task.Delay(delay).Wait();
                currentIteration++;
            }
        }

        private static string ConfigureText()
        {
            Console.WriteLine($"Text to repeat [{DefaultText}]:");
            var text = Console.ReadLine();
            return string.IsNullOrEmpty(text) ? DefaultText : text;
        }

        private static int ConfigureDelay()
        {
            Console.WriteLine($"Delay between iterance (milliseconds) [{DefaultDelay}]:");
            var text = Console.ReadLine();
            return ParseInt(text, DefaultDelay);
        }

        private static int ConfigureStartDelay()
        {
            Console.WriteLine($"Delay to start script (milliseconds) [{DefaultStartDelay}]:");
            var text = Console.ReadLine();
            return ParseInt(text, DefaultStartDelay);
        }

        private static int ConfigureIterations()
        {
            Console.WriteLine($"Number of iterations (0 for infinite) [{DefaultIterations}]:");
            var text = Console.ReadLine();
            return ParseInt(text, DefaultIterations);
        }

        private static int ParseInt(string text, int defaultValue)
        {
            if (!int.TryParse(text, out int delay))
            {
                delay = defaultValue;
            }

            return delay;
        }
    }
}
