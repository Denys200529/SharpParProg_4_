using System;
using System.Threading;

namespace Lab4
{
    public class Philosopher
    {
        private int id;
        private Fork leftFork;
        private Fork rightFork;
        private Thread thread;
        private Waiter waiter;

        public Philosopher(int id, Fork leftFork, Fork rightFork, Waiter waiter)
        {
            this.id = id;
            this.leftFork = leftFork;
            this.rightFork = rightFork;
            this.waiter = waiter;
            thread = new Thread(Dine);
        }

        public void Start() => thread.Start();
        public void Join() => thread.Join();

        private void Dine()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Philosopher {id} is thinking ({i + 1})");

                waiter.RequestPermission(); // попросити дозволу поїсти

                leftFork.PickUp();
                rightFork.PickUp();

                Console.WriteLine($"Philosopher {id} is eating ({i + 1})");

                rightFork.PutDown();
                leftFork.PutDown();

                waiter.ReleasePermission(); // повідомити, що звільнив місце
            }
        }
    }
}
