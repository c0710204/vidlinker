using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using sharpnow;

namespace SampleDLL
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            int frame_counter = 0;

            while (true)
            {
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
                    Console.WriteLine("Frame {0} has been updated!", frame_counter++);
                    Console.WriteLine(frame.mode.ToString());
                    Console.WriteLine(frame.blindfold);
                    Console.WriteLine(frame.hand_number);
                    Console.WriteLine(frame.finger_number);
                    if (frame.blindfold > 20)
                        break;

                    /*
                    // Get Finger
                    if (!getFingerFocusPtr.Equals(IntPtr.Zero))
                    {
                        Finger fingerFocused = (Finger)Marshal.PtrToStructure(getFingerFocusPtr, typeof(Finger));
                        Console.WriteLine("Got Finger");
                        Console.WriteLine("Finger Order Id : " + fingerFocused.order_id);
                        Console.WriteLine(fingerFocused.position.x + " , " + fingerFocused.position.y + " , " + fingerFocused.position.z + "\n");
                    }
                    
                     // Get Hand
                    if (!getHandFocusPtr.Equals(IntPtr.Zero))
                    {
                        Sharpnow.Hand handFocused = (Hand)Marshal.PtrToStructure(getHandFocusPtr, typeof(Hand));
                        Console.WriteLine("Got Hand\n");
                        Console.WriteLine("Fingers show on this hand: " + handFocused.finger_number + " \n");
                        Console.WriteLine(handFocused.position.x + " , " + handFocused.position.y + " , " + handFocused.position.z + "\n");
                    }
                    */
                }

            }
        }

    }

}
