using System.Threading;

namespace Lab4
{
    public class Fork
    {
        private readonly object _lock = new object();

        public void PickUp()
        {
            Monitor.Enter(_lock);
        }

        public void PutDown()
        {
            Monitor.Exit(_lock);
        }
    }
}
