using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SampleDLL;
using System.Runtime.InteropServices;
using System.Threading;
using sharpnow;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int hand_trackid = -1;
        int hand_locate = 0;
        int hand_maxx = -999999999;
        int hand_minx = 999999999;
        int hand_x_status = 0;
        int hand_x_status_true = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //int frame_counter = 0;
            SDK.RetrieveFrame(0);
            IntPtr getFrameInfoPtr = SDK.GetFrameInfo();
            IntPtr getFingerPtr = SDK.GetFinger(0);
            IntPtr getFingerFocusPtr = SDK.GetFingerFocus();
            IntPtr getHandPtr = SDK.GetHand(0);
            IntPtr getHandFocusPtr = SDK.GetHandFocus();

            Frame frame = (Frame)Marshal.PtrToStructure(getFrameInfoPtr, typeof(Frame));
            
            if (frame.updated == true)
            {

                // Get Frame
                //Console.WriteLine("Frame {0} has been updated!", frame_counter++);
                //Console.WriteLine(frame.mode.ToString());
                //Console.WriteLine(frame.blindfold);
                //Console.WriteLine(frame.hand_number);
                //Console.WriteLine(frame.finger_number);
                //*****************************************
                //blind
                 label2.Text = frame.blindfold.ToString();
                 label2.BackColor = (frame.blindfold > 20) ? Color.Red : Color.Green;
                //********************************************************************
                //hand

                 try
                 {
                     Hand Hand = (Hand)Marshal.PtrToStructure(getHandPtr, typeof(Hand));

                     label6.Text = Hand.gesture_counter.ToString();
                     label6.BackColor = (Hand.gesture_counter > 20) ? Color.Red : Color.Green;
                     if (Hand.gesture == HandGesture.HG_Grip)
                         pictureBox1.Image = handpic.grip;
                     if (Hand.gesture == HandGesture.HG_Phone) pictureBox1.Image = handpic.grip;
                     if (Hand.gesture == HandGesture.HG_Metal) pictureBox1.Image = handpic.metal;
                     if (Hand.gesture == HandGesture.HG_Gun) pictureBox1.Image = handpic.gun;
                     if (Hand.gesture == HandGesture.HG_Unknown) pictureBox1.Image = handpic.X;
                     if (Hand.gesture == HandGesture.HG_Point) pictureBox1.Image = handpic.point;
                     if (Hand.gesture == HandGesture.HG_Fork) pictureBox1.Image = handpic.fork;
                     if (Hand.gesture == HandGesture.HG_Five) pictureBox1.Image = handpic.five;
                     if (Hand.gesture == HandGesture.HG_Four) pictureBox1.Image = handpic.fore;
                     if (Hand.gesture == HandGesture.HG_Victory) pictureBox1.Image = handpic.victory;
                     if (Hand.gesture == HandGesture.HG_Three) pictureBox1.Image = handpic.three;
                     if (Hand.gesture == HandGesture.HG_Love) pictureBox1.Image = handpic.love;
                     //**************
                     hand_locate = (int)(Hand.axis_x.x*10000);
                     hand_maxx = hand_maxx > hand_locate ? hand_maxx : hand_locate;
                     hand_minx = hand_minx < hand_locate ? hand_minx : hand_locate;
                     hand_x_status = (hand_locate - hand_minx) * 50 / (hand_maxx - hand_minx);
                     hand_x_status_true = hand_locate / 200;
                     trackBar1.Value = hand_x_status;


                     label4.Text = hand_maxx.ToString();
                     label7.Text = hand_x_status_true.ToString() + "\n" + hand_x_status.ToString();
                     label8.Text = hand_minx.ToString();
                     if (Hand.track_id != hand_trackid)
                     {
                         hand_trackid = Hand.track_id;
                         hand_maxx = -999999999;
                         hand_minx = 999999999;
                       
                     }
                     else
                     {

                     }
                     //Hand.track_id
                 }
                 catch (Exception)
                 {


                 }

                     
                     
                 
                //********************************************************************
                //finger
                 try
                 {
                     Finger Finger = (Finger)Marshal.PtrToStructure(getFingerPtr, typeof(Finger));
                    // Finger.tap
                 }
                 catch (Exception)
                 {


                 }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
