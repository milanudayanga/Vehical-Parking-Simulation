using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Vehicle_Parking_Simulation
{
    class Semaphore
    {
             private int count = 0; // set semaphore to available

        public void Wait()
        {
            lock (this)
            {
                // wait if semaphore unavailable
                while (count == 0)
                    Monitor.Wait(this);
                count = 0;
            }
        }

        public void Signal()
        {
            lock (this)
            {
                count = 1;
                Monitor.Pulse(this);
            }
        }

        public void Start()
        {
        }

    }
    
}
