using System.Threading;

namespace Lab4
{
    public class Waiter
    {
        private Semaphore semaphore;

        public Waiter(int maxAllowed)
        {
            semaphore = new Semaphore(maxAllowed, maxAllowed);
        }

        public void RequestPermission()
        {
            semaphore.WaitOne();
        }

        public void ReleasePermission()
        {
            semaphore.Release();
        }
    }
}
