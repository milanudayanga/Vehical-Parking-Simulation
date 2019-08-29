using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_Parking_Simulation
{
    public partial class GUI : Form
    {
        static Random random = new Random();

        static Color randomColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

        private SectionThread pEnterA, pEnterB, p2, p3, p4, pExitA, p12, p13, p14, pExitB, p11, p10mid, p9, p8, p7, p6mid, p5, p16, p15, p17, p18, p19, p20, p21;

        private ButtonThread   pPark1, pPark2, pPark3, pPark8, pPark10, pPark12, pPark7, pPark9, pPark11, pPark4, pPark6; 

        private Thread thread1, thread2, thread3, thread4, threadExitA,
                  threadEnterB, thread12, thread13, thread14, threadExitB,
                  threadPark1, threadPark2, threadPark3, thread16, thread15,
                  thread5, thread6, thread7, thread8, thread9, thread11, thread10,
                  threadPark8, threadPark10, threadPark12, threadPark7, 
                  threadPark9, threadPark11,threadPark4, threadPark6,thread17, thread18,thread19, thread20, thread21; 

        private Semaphore semaphore1, semaphore2, semaphore3, semaphore4, semaphoreExitA, semaphore15, semaphore16,
           semaphoreEnterB, semaphore12, semaphore13, semaphore14,
           semaphoreExitB, semaphorefree1, semaphorefree2, semaphorePark1, 
           semaphorePark2, semaphorePark3, semaphore7, semaphore6,
           semaphore8, semaphore9, semaphore10, semaphore11, semaphore5, 
           semaphorePark8, semaphorePark10, semaphorePark12, semaphorePark7, 
           semaphorePark9, semaphorePark11, semaphorePark4,  semaphorePark6, 
           semaphore17, semaphore18, semaphore19, semaphore20, semaphore21;

        private Buffer buffer1, buffer2, buffer3, buffer4, bufferExitA, buffer15, buffer16,
            bufferEnterB, buffer12, buffer13, buffer14, bufferExitB,
            bufferfree1, bufferfree2, bufferPark1, bufferPark2, bufferPark3,
            buffer11, buffer10, buffer9, buffer8, buffer6, buffer7, buffer5, bufferPark8, bufferPark10, bufferPark12, bufferPark7, bufferPark9, bufferPark11, bufferPark4, bufferPark6, buffer17, buffer18, buffer19, buffer20, buffer21;

        public GUI()
        { 
            InitializeComponent();
          

            semaphore2 = new Semaphore();                        semaphore1 = new Semaphore();
            semaphore3 = new Semaphore();                        semaphore4 = new Semaphore();
            semaphoreExitA = new Semaphore();                    semaphoreEnterB = new Semaphore();
           semaphore12 = new Semaphore();                        semaphore13 = new Semaphore();
            semaphore14 = new Semaphore();
            semaphoreExitB = new Semaphore();

            semaphorefree1 = new Semaphore();
            semaphorefree2 = new Semaphore();


            semaphorePark1 = new Semaphore();
            semaphorePark2 = new Semaphore();
            semaphorePark3 = new Semaphore();

            semaphore11 = new Semaphore();
            semaphore10 = new Semaphore();
            semaphore9 = new Semaphore();
            semaphore8 = new Semaphore();
            semaphore7 = new Semaphore();
            semaphore6 = new Semaphore();
            semaphore5 = new Semaphore();

            semaphore17 = new Semaphore();
            semaphore18 = new Semaphore();
            semaphore19 = new Semaphore();
            semaphore20 = new Semaphore();
            semaphore21 = new Semaphore();

            semaphorePark8 = new Semaphore();
            semaphorePark10 = new Semaphore();
            semaphorePark12 = new Semaphore();
            semaphorePark7 = new Semaphore();
             semaphore16 = new Semaphore();
            semaphore15 = new Semaphore();
            semaphorePark9 = new Semaphore();
            semaphorePark11 = new Semaphore();
            semaphorePark4 = new Semaphore();
         
            semaphorePark6 = new Semaphore();

            buffer1 = new Buffer();
            buffer2 = new Buffer();
            buffer3 = new Buffer();
            buffer4 = new Buffer();
            bufferExitA = new Buffer();

            bufferEnterB = new Buffer();
            buffer12 = new Buffer();
            buffer13 = new Buffer();
            buffer14 = new Buffer();

            bufferExitB = new Buffer();
            bufferfree1 = new Buffer();
            bufferfree2 = new Buffer();

            bufferPark1 = new Buffer();
            bufferPark2 = new Buffer();
            bufferPark3 = new Buffer();

            buffer5 = new Buffer();
            buffer6 = new Buffer();
            buffer7 = new Buffer();
            buffer8 = new Buffer();
            buffer9 = new Buffer();
            buffer11 = new Buffer();
            buffer10 = new Buffer();

            bufferPark8 = new Buffer();
            bufferPark10 = new Buffer();
            bufferPark12 = new Buffer();
            bufferPark7 = new Buffer();
            buffer15 = new Buffer();
            buffer16 = new Buffer();
            bufferPark9 = new Buffer();
            bufferPark11 = new Buffer();
            bufferPark4 = new Buffer();
       
             bufferPark6 = new Buffer();

             buffer17 = new Buffer();
             buffer18 = new Buffer();
             buffer19 = new Buffer();
             buffer20 = new Buffer();
             buffer21 = new Buffer();

            pEnterA = new SectionThread(new Point(45, 10), 100, 0, 6, pnlEntrance1, Color.White, 110,
                                   semaphore1, buffer1, semaphore2, buffer2, semaphore11, buffer11, semaphore2, buffer2, 10);


            p2 = new SectionThread(new Point(45, 0), 90, 0, 6, pnl2, Color.White, 11,
                                       semaphore2, buffer2, semaphore3, buffer3, semaphorePark1, bufferPark1, 7);


            pPark1 = new ButtonThread(new Point(100, 80), 100, -6, 0, pnlPark1, Color.White, 1,
                                    semaphorePark1, bufferPark1, semaphore3, buffer3, btnPark1, 7);


            pPark3 = new ButtonThread(new Point(100, 80), 100, -6, 0, pnlPark3, Color.White, 3,
                                    semaphorePark3, bufferPark3, semaphore4, buffer4, btnPark3, 7);

            p3 = new SectionThread(new Point(45, 0), 80, 0, 6, pnl3, Color.White, 33,
                                    semaphore3, buffer3, semaphore4, buffer4, semaphorePark3, bufferPark3, 7);


            p4 = new SectionThread(new Point(45, 0), 100, 0, 8, pnl4, Color.White,2,
                                  semaphore4, buffer4, semaphoreExitA, bufferExitA, 6);

            pExitA = new SectionThread(new Point(45, 30), 100, 0, 10, pnlExit1, Color.White,0,
                                   semaphoreExitA, bufferExitA, semaphorefree1, bufferfree1, 6);





            //...................................................................................................

            pEnterB = new SectionThread (new Point(45, 10), 80, 0, 6, pnlEntrance2, Color.White, 160,
                                   semaphoreEnterB, bufferEnterB, semaphore12, buffer12, semaphore16, buffer16, 15);

       
            p7 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl7, Color.White, 1100,
                               semaphore7, buffer7, semaphore6, buffer6, semaphorePark11, bufferPark11, 4);

            p8 = new SectionThread(new Point(20, 0), 90, 0, 8, pnl8, Color.White, 99,
                                     semaphore8, buffer8, semaphore7, buffer7, semaphorePark9, bufferPark9, 4);

            p9 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl9, Color.White, 77,
                     semaphore9, buffer9, semaphore8, buffer8, semaphorePark7, bufferPark7, 4);


            p10mid = new SectionThread(new Point(20, 30), 80, 0, 8, pnl10mid, Color.White, 240,
                                 semaphore10, buffer10, semaphore9,buffer9, semaphore17,buffer17,semaphore16,buffer16, 3);


            p11 = new SectionThread(new Point(180, 30), 80, -8, 0, pnl11, Color.White, 888,
                                 semaphore11, buffer11, semaphore17, buffer17,null,null, semaphore1, buffer1, 15);
          
            p12 = new SectionThread(new Point(45, 10), 80, 0, 8, pnl12, Color.White, 88,
                                 semaphore12, buffer12, semaphore13, buffer13, semaphorePark8, bufferPark8, 5);

            p13 = new SectionThread(new Point(45, 0), 80, 0, 8, pnl13, Color.White, 100,
                                semaphore13, buffer13, semaphore14, buffer14, semaphorePark10, bufferPark10, 5);
            
            p14 = new SectionThread(new Point(45, 0), 80, 0, 8, pnl14, Color.White, 120,
                                semaphore14, buffer14, semaphoreExitB, bufferExitB, semaphorePark12, bufferPark12,5);

            pExitB = new SectionThread(new Point(45, 30), 100, 0, 10, pnlExit2, Color.White, 0,
                             semaphoreExitB, bufferExitB, semaphorefree2, bufferfree2, 6);

            p15 = new SectionThread(new Point(200, 30), 80, -8, 0, pnl15, Color.White, 2,
                                 semaphore15, buffer15, semaphoreExitB, bufferExitB, 20);

            p16 = new SectionThread(new Point(60, 30), 80, 8, 0, pnl16, Color.White, 288,
                                 semaphore16, buffer16, semaphore10, buffer10, semaphoreEnterB, bufferEnterB, 12);

            p17 = new SectionThread(new Point(20, 30), 80, 0, 8, pnl17, Color.White, 245,
                                      semaphore17, buffer17, semaphore18, buffer18,semaphore10, buffer10,semaphore11,buffer11, 3);

            p18 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl18, Color.White, 23,
                                 semaphore18, buffer18, semaphore19, buffer19, semaphorePark2, bufferPark2, 4);

            p19 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl19, Color.White, 44,
                                 semaphore19, buffer19, semaphore20, buffer20, semaphorePark4, bufferPark4, 4);

            p20 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl20, Color.White, 66,
                                 semaphore20, buffer20, semaphore21, buffer21, semaphorePark6, bufferPark6, 4);

            p21 = new SectionThread(new Point(20, 0), 80, 0, 8, pnl21, Color.White, 2,
                                 semaphore21, buffer21, semaphore5, buffer5, 4);

          

            p6mid = new SectionThread(new Point(20, 0), 100, 0, 6, pnl6mid, Color.White, 2,
                                 semaphore6, buffer6, semaphore15, buffer15, 4);

            p5 = new SectionThread(new Point(0, 30), 100, 8, 0, pnl5, Color.White, 2,
                                 semaphore5, buffer5, semaphoreExitA, bufferExitA, 20);


            //   ..................................................................................

            pPark8 = new ButtonThread(new Point(100,0), 80, 8, 0, pnlPark8, Color.LightYellow, 80,
                                  semaphorePark8, bufferPark8, semaphore13, buffer13, btnPark8, 10);

            pPark10 = new ButtonThread(new Point(100, 0), 80, 8, 0, pnlPark10, Color.LightYellow, 100,
                              semaphorePark10, bufferPark10, semaphore14, buffer14, btnPark10, 10);


            pPark12 = new ButtonThread(new Point(100, 0), 80, 8, 0, pnlPark12, Color.LightYellow, 120,
                              semaphorePark12, bufferPark12, semaphoreExitB, bufferExitB, btnPark12, 10);

            pPark7 = new ButtonThread(new Point(-10, 0), 100, -8, 0, pnlPark7, Color.LightYellow, 7,
                              semaphorePark7, bufferPark7, semaphore8, buffer8, btnPark7, 10);

            pPark9 = new ButtonThread(new Point(90, 20), 100, -8, 0, pnlPark9, Color.LightYellow, 9,
                              semaphorePark9, bufferPark9, semaphore7, buffer7, btnPark9, 10);

            pPark11 = new ButtonThread(new Point(90, 20), 100, -8, 0, pnlPark11, Color.LightYellow, 11,
                              semaphorePark11, bufferPark11, semaphore6, buffer6, btnPark11, 10);

            pPark2 = new ButtonThread(new Point(100, 0), 100, 8, 0, pnlPark2, Color.LightYellow, 20,
                            semaphorePark2, bufferPark2, semaphore19, buffer19, btnPark2, 10);

            pPark4 = new ButtonThread(new Point(100, 0), 70, 8, 0, pnlPark4, Color.LightYellow, 40,
                                   semaphorePark4, bufferPark4, semaphore20, buffer20, btnPark4, 10);

            pPark6 = new ButtonThread(new Point(100, 0), 70, 8, 0, pnlPark6, Color.LightYellow, 60,
                                   semaphorePark6, bufferPark6, semaphore21, buffer21, btnPark6, 10);


          


            thread1 = new Thread(new ThreadStart(pEnterA.Start));
            thread2 = new Thread(new ThreadStart(p2.Start));
            thread3 = new Thread(new ThreadStart(p3.Start));
            thread4 = new Thread(new ThreadStart(p4.Start));
            threadExitA = new Thread(new ThreadStart(pExitA.Start));
            threadEnterB = new Thread(new ThreadStart(pEnterB.Start));
            thread12 = new Thread(new ThreadStart(p12.Start));
            thread13 = new Thread(new ThreadStart(p13.Start));
            thread14 = new Thread(new ThreadStart(p14.Start));
            threadExitB = new Thread(new ThreadStart(pExitB.Start));
            threadPark1 = new Thread(new ThreadStart(pPark1.Starts));
            threadPark3 = new Thread(new ThreadStart(pPark3.Starts));
            thread11 = new Thread(new ThreadStart(p11.Start));
            thread10 = new Thread(new ThreadStart(p10mid.Start));
            thread9 = new Thread(new ThreadStart(p9.Start));
            thread8 = new Thread(new ThreadStart(p8.Start));
            thread7 = new Thread(new ThreadStart(p7.Start));
            thread16 = new Thread(new ThreadStart(p16.Start));
            thread15 = new Thread(new ThreadStart(p15.Start));
            thread6 = new Thread(new ThreadStart(p6mid.Start));
            thread5 = new Thread(new ThreadStart(p5.Start));
            threadPark2 = new Thread(new ThreadStart(pPark2.Starts));
            threadPark8 = new Thread(new ThreadStart(pPark8.Starts));
            threadPark10 = new Thread(new ThreadStart(pPark10.Starts));
            threadPark12 = new Thread(new ThreadStart(pPark12.Starts));
            threadPark7 = new Thread(new ThreadStart(pPark7.Starts));
            threadPark9 = new Thread(new ThreadStart(pPark9.Starts));
            threadPark11 = new Thread(new ThreadStart(pPark11.Starts));
            threadPark4 = new Thread(new ThreadStart(pPark4.Starts));
        
            threadPark6 = new Thread(new ThreadStart(pPark6.Starts));


            thread17 = new Thread(new ThreadStart(p17.Start));
            thread18 = new Thread(new ThreadStart(p18.Start));
            thread19 = new Thread(new ThreadStart(p19.Start));
            thread20 = new Thread(new ThreadStart(p20.Start));
            thread21 = new Thread(new ThreadStart(p21.Start));


            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            threadExitA.Start();

            threadEnterB.Start();
            thread12.Start();
            thread13.Start();
            thread14.Start();
            threadExitB.Start();
            threadPark1.Start();
            threadPark3.Start();

            threadPark2.Start();
            thread8.Start();
            thread9.Start();
            thread11.Start();
            thread10.Start();
            thread7.Start();
            thread6.Start();
            thread5.Start();
          
            thread16.Start();
            thread15.Start();
            threadPark7.Start();
            threadPark9.Start();
            threadPark11.Start();
            threadPark8.Start();
            threadPark10.Start();
            threadPark12.Start();
            threadPark4.Start();
            threadPark6.Start();

            thread17.Start();
            thread18.Start();
            thread19.Start();
            thread20.Start();
            thread21.Start();

        }





        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbtA.Checked == true)
            {
              
                int endPoint = 0;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(50, 255), random.Next(100, 255)), endPoint);
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtB.Checked == true)
            {
              
               
             
                int endPoint = 0;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(50, 255), random.Next(100, 255)), endPoint);
            }
        }

        private void btnPark1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark1.Checked == true)
            {
                
               
                int endPoint = 1;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(50, 255), random.Next(100, 255)), endPoint);
            }
        }

        private void rbt3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark3.Checked == true)
            {
               
                int endPoint = 3;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(50, 255), random.Next(100, 255)), endPoint);
            }

        }

        private void btnPark1_Click(object sender, EventArgs e)
        {

        }

        private void pnl9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtPark2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbtPark2.Checked == true)
            {
               
                int endPoint = 22;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtPark8.Checked == true)
            {
               
                int endPoint = 8;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (rbtPark10.Checked == true)
            {
                
                int endPoint = 10;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }

        }

        private void rbtPark7_CheckedChanged(object sender, EventArgs e)
        {
         if (rbtPark7.Checked == true)
            {
                
                int endPoint = 7;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark9_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark9.Checked == true)
            {
                
                int endPoint = 9;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }

        }

        private void rbtPark11_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark11.Checked == true)
            {
                
                int endPoint = 11;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark12_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark12.Checked == true)
            {
               
                int endPoint = 12;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark4.Checked == true)
            {
                
                int endPoint = 4;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark5_CheckedChanged(object sender, EventArgs e)
        {
        
 
        }

        private void rbtPark6_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark6.Checked == true)
            {
              
                int endPoint = 6;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void pnlPark10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DexitBA_CheckedChanged(object sender, EventArgs e)
        {
            if (DexitBA.Checked == true)
            {

                int endPoint = 24;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark2BA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark2BA.Checked == true)
            {

                int endPoint = 120;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark4BA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark4BA.Checked == true)
            {

                int endPoint = 140;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark6BA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark6BA.Checked == true)
            {

                int endPoint = 161;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void DirectExitAB_CheckedChanged(object sender, EventArgs e)
        {
            if (DirectExitAB.Checked == true)
            {

                int endPoint = 401;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark7AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark7AB.Checked == true)
            {

                int endPoint = 700;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark9AB.Checked == true)
            {

                int endPoint = 900;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtPark11AB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPark11AB.Checked == true)
            {

                int endPoint = 1101;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtParkingBA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtExitBA1.Checked == true)
            {

                int endPoint = 9001;

                bufferEnterB.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }

        private void rbtExitAB2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtExitAB2.Checked == true)
            {

                int endPoint = 8001;

                buffer1.Write(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), endPoint);
            }
        }
    }
}


