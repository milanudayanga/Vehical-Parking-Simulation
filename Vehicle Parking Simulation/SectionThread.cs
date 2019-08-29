using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Vehicle_Parking_Simulation
{
    class SectionThread
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
        private Semaphore semaphore2;
        private Buffer buffer2;
        private Semaphore semaphore3;
        private Buffer buffer3;
        private int steps;
      

        public SectionThread(Point origin, int delay, int xDelta,
                                       int yDelta, Panel panel, Color colour, int panelID, Semaphore semaphore,
                                       Buffer buffer, Semaphore semaphore1, Buffer buffer1, int steps)
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
            this.steps = steps;

        }

        public SectionThread(Point origin, int delay, int xDelta,
                                           int yDelta, Panel panel, Color colour, int panelID, Semaphore semaphore,
                                           Buffer buffer, Semaphore semaphore1, Buffer buffer1, Semaphore semaphore2, Buffer buffer2, int steps)
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
                this.semaphore2 = semaphore2;
                this.buffer2 = buffer2;
                this.steps = steps;

            }

        public SectionThread(Point origin, int delay, int xDelta,
                                           int yDelta, Panel panel, Color colour, int panelID, Semaphore semaphore,
                                           Buffer buffer, Semaphore semaphore1, Buffer buffer1, Semaphore semaphore2, Buffer buffer2, Semaphore semaphore3, Buffer buffer3, int steps)
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
            this.semaphore2 = semaphore2;
            this.buffer2 = buffer2;
            this.semaphore3 = semaphore3;
            this.buffer3 = buffer3;
            this.steps = steps;

        }

      
        public SectionThread(Color colour, int endPoint)
        {
            this.colour = colour;
            this.endPoint = endPoint;
        }

       
       


        public void Start()
        {

            Thread.Sleep(delay);
            semaphore.Signal();

            for (; 0 == 0; )
            {
               
                this.zeroCar();
                panel.Invalidate();
                buffer.Read(ref this.colour, ref this.endPoint);



                    if (((this.endPoint == 10 && this.panelID == 100) || (this.endPoint == 12 && this.panelID == 120) || 
                        (this.endPoint == 8 && this.panelID == 88) || (this.endPoint == 9 && this.panelID == 99)
                        || (this.endPoint == 7 && this.panelID == 77) || (this.endPoint == 11 && this.panelID == 1100) ||
                        (this.endPoint == 1 && this.panelID == 11) || (this.endPoint == 3 && this.panelID == 33) ||
                        (this.endPoint == 22 && this.panelID == 23) || (this.endPoint == 4 && this.panelID == 44)
                        || (this.endPoint == 6 && this.panelID == 66) || (this.endPoint == 120 && this.panelID == 23)
                        || (this.endPoint == 140 && this.panelID == 44) || (this.endPoint == 161 && this.panelID == 66)
                        || (this.endPoint == 700 && this.panelID == 77) || (this.endPoint == 900 && this.panelID == 99)||
                        (this.endPoint == 1101 && this.panelID == 1100)))
                    {

                        for (int i = 1; i <= steps; i++)
                        {

                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }
                        semaphore2.Wait();
                        buffer2.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();

                    }
                    else if ((this.endPoint == 0 && this.panelID == 0) || (this.endPoint == 24 && this.panelID == 0)
                        || (this.endPoint == 401 && this.panelID == 0) || (this.endPoint == 9001 && this.panelID == 0)||(this.endPoint == 8001 && this.panelID == 0))
                    {
                        
                            steps = 20;

                            for (int i = 1; i <= steps; i++)
                            {
                                this.moveCar(xDelta, yDelta);
                                Thread.Sleep(delay);
                                panel.Invalidate();
                            }
                            semaphore.Signal();
                            this.colour = Color.White;
                            panel.Invalidate();
                        

                    }


                    else if ((this.endPoint == 9 && this.panelID == 160)
                        || (this.endPoint == 7 && this.panelID == 160) || (this.endPoint == 11 && this.panelID == 160)|| 
                        (this.endPoint == 22 && this.panelID == 110)
                        || (this.endPoint == 4 && this.panelID == 110) || (this.endPoint == 6 && this.panelID == 110) ||
                        (this.endPoint == 24 && this.panelID == 160) || (this.endPoint == 120 && this.panelID == 160) ||
                        (this.endPoint == 140 && this.panelID == 160) || (this.endPoint == 161 && this.panelID == 160) 
                        || (this.endPoint == 401 && this.panelID == 110)|| (this.endPoint == 700 && this.panelID == 110)
                        || (this.endPoint == 900 && this.panelID == 110) || (this.endPoint == 1101 && this.panelID == 110)
                        || (this.endPoint == 9001 && this.panelID == 160)|| (this.endPoint == 8001 && this.panelID == 110))
                    {
                        for (int i = 1; i <= steps; i++)
                        {

                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }
                        semaphore2.Wait();
                        buffer2.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }
                    else if ((this.endPoint == 24 && this.panelID == 240) || (this.endPoint == 120 && this.panelID == 240)
                        || (this.endPoint == 140 && this.panelID == 240) || (this.endPoint == 161 && this.panelID == 240)
                        || (this.endPoint == 9001 && this.panelID == 240) )
                    {
                       
                        for (int i = 1; i <= steps; i++)
                        {
                            
                            this.car.X++;
                            Thread.Sleep(delay);
                            panel.Invalidate();
                            
                        }
                        semaphore2.Wait();
                        buffer2.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }
                    else if ((this.endPoint == 8001 && this.panelID == 240))
                    {
                        for (int i = 1; i <= steps; i++)
                        {

                            this.car.X--;
                            Thread.Sleep(delay);
                            panel.Invalidate();

                        }
                        semaphore3.Wait();
                        buffer3.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }

                    else if ((this.endPoint == 401 && this.panelID == 245) || (this.endPoint == 700 && this.panelID == 245)
                        || (this.endPoint == 900 && this.panelID == 245) || (this.endPoint == 1101 && this.panelID == 245)
                    )
                    {

                        for (int i = 1; i <= steps; i++)
                        {

                            this.car.X--;

                            Thread.Sleep(delay);
                            panel.Invalidate();

                        }
                        semaphore2.Wait();
                        buffer2.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }

                    else if ((this.endPoint == 9001 && this.panelID == 245))
                    {

                        for (int i = 1; i <= steps; i++)
                        {
                            this.car.X++;
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }
                        semaphore3.Wait();
                        buffer3.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }
                    else if (this.endPoint == 9001 && this.panelID == 888)
                    {
                        steps = 4;
                        for (int i = 1; i <= steps; i++)
                        {

                            this.car.X++;

                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }

                        semaphore3.Wait();
                        buffer3.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }
                    else if ((this.endPoint == 8001 && this.panelID == 245) || (this.endPoint == 8001 && this.panelID == 288))
                    {
                        if ((this.endPoint == 8001 && this.panelID == 288))
                            steps = 6;
                        for (int i = 1; i <= steps; i++)
                        {

                            this.car.X--;

                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }

                        semaphore2.Wait();
                        buffer2.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }
                    else
                    {
                        for (int i = 1; i <= steps; i++)
                        {
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                            panel.Invalidate();
                        }
                        semaphore1.Wait();
                        buffer1.Write(this.colour, this.endPoint);
                        semaphore.Signal();
                        this.colour = Color.White;
                        panel.Invalidate();
                    }

                
        
            }
        }


        private void zeroCar()
        {
            car.X = origin.X;  // start point 
            car.Y = origin.Y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta; car.Y += yDelta;  // speed 
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(colour);
            g.FillRectangle(brush, car.X, car.Y, 10, 10);
            brush.Dispose();    //  Dispose graphics resources. 
            g.Dispose();
        }
    }

}
