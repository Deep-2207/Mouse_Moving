using System;
using System.Threading;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    static void Main(string[] args)
    {
        Console.WriteLine("Starting mouse click simulation...");
        POINT previousMousePosition;
        GetCursorPos(out previousMousePosition);
        while (true)
        {
            POINT currentMousePosition;
            GetCursorPos(out currentMousePosition);
            if (currentMousePosition.X != previousMousePosition.X || currentMousePosition.Y != previousMousePosition.Y)
            {
                Console.WriteLine("Original mouse moved");
                //break;
            }
            else
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                Console.WriteLine("Mouse clicked at: " + DateTime.Now.ToString());
            }
            previousMousePosition = currentMousePosition;
            Thread.Sleep(2000);
            //Thread.Sleep(30000);
        }
    }
}
