using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Vehicle_Parking_Simulation
{
    class Buffer
    {
        
            private Color CarColor;
            private int endPoint;

            private bool empty = true;

            public void Read(ref Color CarColor, ref int endPoint)
            {
                lock (this)
                {
                    // Check whether the buffer is empty.
                    if (empty)
                        Monitor.Wait(this);
                    empty = true;
                    CarColor = this.CarColor;
                    endPoint = this.endPoint;

                    Monitor.Pulse(this);
                }
            }

            public void Write(Color CarColor, int endPoint)
            {
                lock (this)
                {
                    // Check whether the buffer is full.
                    if (!empty)
                        Monitor.Wait(this);
                    empty = false;
                    this.CarColor = CarColor;
                    this.endPoint = endPoint;
                    Monitor.Pulse(this);
                }
                
            }

            public void Start()
            {
            }
        }

    }


