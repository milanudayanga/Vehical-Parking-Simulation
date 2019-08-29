using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_Parking_Simulation
{
    class ButtonThread
    {
        
            private Point origin;
            private int delay;
            private Panel panel;
            private Color colour;
            private int endPoint;
            private int panelID;
            private Point car;
            private int xDelta;
            private int yDelta;
            private Semaphore semaphore;
            private Buffer buffer;
            private Semaphore semaphore1;
            private Buffer buffer1;
            private Button btn;
            private bool locked = true;
            private int steps;

            public ButtonThread(Point origin, int delay, int xDelta,
                                           int yDelta, Panel panel,Color colour, int panelID, Semaphore semaphore,
                                           Buffer buffer, Semaphore semaphore1, Buffer buffer1, Button btn, int steps)
            {

                this.origin = origin;
                this.delay = delay;
                this.panel = panel;
                this.colour = colour;
                this.car = origin;
                this.panel.Paint += new PaintEventHandler(this.panel_Paint);
                this.panelID = panelID;
                this.xDelta = xDelta;
                this.yDelta = yDelta;
                this.semaphore = semaphore;
                this.buffer = buffer;
                this.semaphore1 = semaphore1;
                this.buffer1 = buffer1;
                this.btn = btn;
                this.btn.Click += new System.EventHandler(this.btn_Click);
                this.steps = steps;

            }
       
            public ButtonThread(Color colour, int endPoint)
            {
                this.colour = colour;
                this.endPoint = endPoint;
         
                }

            public void Starts() // starts
            {
                Thread.Sleep(delay);
                locked = false;  // this means  the parking button is locked till the car is coming
                semaphore.Signal();

                for (; 0 == 0; )
                {
                   
                    buffer.Read(ref this.colour, ref this.endPoint);
                    if ((this.endPoint == this.panelID) || (this.endPoint ==700 && this.panelID==7)
                        || (this.endPoint == 900 && this.panelID == 9) || (this.endPoint == 1101 && this.panelID == 11)) // this is working for parking panels
                    {
                        this.origin = new Point(100, 30); // starting point of moving car 
                        this.zeroCar();
                        panel.Invalidate();

                        lock (this)
                        {
                            while (locked)
                            {
                                Monitor.Wait(this);
                            }
                        }
                        steps = 5;
                        for (int i = 1; i <= steps; i++)
                        {
                        
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }

                        locked = true;
                        this.btn.BackColor = locked ? Color.Red : Color.Green;
                        this.endPoint = 0;
                        this.origin = new Point(45, 30); //  parking slot stop point 

                        this.yDelta = 0; this.xDelta = 5; //  moving direction of the car in the parking panel ,once you clicked the parking button. 

                     
                        buffer.Write(this.colour, this.endPoint);

                    }


                    else if ((this.endPoint == 8 && this.panelID == 80) || (this.endPoint == 10 && this.panelID == 100) ||
                        (this.endPoint == 12 && this.panelID == 120) || (this.endPoint == 22 && this.panelID == 20) || 
                        (this.endPoint == 4 && this.panelID == 40) || (this.endPoint == 6 && this.panelID == 60) ||
                        (this.endPoint == 9 && this.panelID == 99) || (this.endPoint == 120 && this.panelID == 20) || (this.endPoint == 140 && this.panelID == 40) || (this.endPoint == 161 && this.panelID == 60))

                    {
                        this.origin = new Point(10, 30);
                        this.zeroCar();
                        panel.Invalidate();

                        lock (this)
                        {
                            while (locked)
                            {
                                Monitor.Wait(this);
                            }
                        }

                        steps = 5;
                        for (int i = 1; i <= steps; i++)
                        {

                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }

                        locked = true;
                        this.btn.BackColor = locked ? Color.Red : Color.Green;
                        this.endPoint = 0;
                        this.origin = new Point(45, 30); //  parking slot stop point 

                        this.yDelta = 0; this.xDelta = -5; // once clicked the parking button , moving direction of the car 
                        buffer.Write(this.colour, this.endPoint);

                    }
                    else
                    {

                        this.zeroCar();
                        panel.Invalidate();

                        lock (this)
                        {
                            while (locked)
                            {
                                Monitor.Wait(this);
                            }
                        }

                       
                        for (int i = 1; i <= steps; i++)
                        {

                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();

                        }
                        semaphore1.Wait();
                        buffer1.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.LightYellow;
                        panel.Invalidate();
                    }

                }
            }
            private void zeroCar()
            {
                car.X = origin.X;
                car.Y = origin.Y;
            }

            private void moveCar(int xDelta, int yDelta)
            {
                car.X += xDelta; car.Y += yDelta;
            }


            private void panel_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                SolidBrush brush = new SolidBrush(colour);
                g.FillRectangle(brush, car.X, car.Y, 10, 10);
                brush.Dispose();    //  Dispose graphics resources. 
                g.Dispose();
            }

            private void btn_Click(object sender, System.EventArgs e)
            {
                locked = !locked;
                this.btn.BackColor = locked ? Color.Red : Color.LightGreen;

                lock (this)
                {
                    if (!locked)
                        Monitor.Pulse(this);
                }
            }

    }
}
