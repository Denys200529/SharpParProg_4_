using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int sim = 1; sim <= 15; sim++)
            {
                Console.WriteLine($"\n>>> Simulation #{sim}");

                Fork[] forks = new Fork[5];
                for (int i = 0; i < 5; i++)
                    forks[i] = new Fork();

                Waiter waiter = new Waiter(4); 

                Philosopher[] philosophers = new Philosopher[5];
                for (int i = 0; i < 5; i++)
                {
                    Fork left = forks[i];
                    Fork right = forks[(i + 1) % 5];
                    philosophers[i] = new Philosopher(i, left, right, waiter);
                }

                foreach (var p in philosophers)
                    p.Start();

                foreach (var p in philosophers)
                    p.Join();

                Console.WriteLine($">>> Simulation #{sim} complete.");
            }

            Console.WriteLine("\nAll simulations finished.");
        }
    }
}
