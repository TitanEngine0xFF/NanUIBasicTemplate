using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NanUI_AutoTransfer
{
    internal class AutoClick
    {
      [DllImport("user32.dll")]
      private static extern int SetCursorPos(int x, int y);
      [DllImport("User32")]
        //下面这一行对应着下面的点击事件
        //    public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
      public extern static void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
      public const int MOUSEEVENTF_LEFTDOWN = 0x2;
      public const int MOUSEEVENTF_LEFTUP = 0x4;
       public static void Click() {
            int x = 30;
            int y = 30;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
    }
}
