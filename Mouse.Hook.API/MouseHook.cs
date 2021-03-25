using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Mouse.Hook.Api
{
    /// <summary>
    /// This class provides a mousehook and the associated events.
    /// </summary>
    public sealed class MouseHook
    {
        private Point _point;
        private Point Point
        {
            set
            {
                if (_point == value) return;
                _point = value;
                if (MouseMoveEvent == null) return;
                var e = new MouseEventArgs(MouseButtons.None, 0, _point.X, _point.Y, 0);
                MouseMoveEvent(this, e);
            }
        }
        private int _hHook;
        private const int WmLbuttondown = 0x201;
        private const int WmRbuttondown = 0x204;
        private const int WmMbuttondown = 0x207;
        private const int WmLbuttonup = 0x202;
        private const int WmRbuttonup = 0x205;
        private const int WmMbuttonup = 0x208;
        private const int WhMouseLl = 14;
        private Win32Api.HookProc _hProc;
        public MouseHook()
        {
            Point = new Point();
        }
        /// <summary>
        /// this method sets up the golbal mousehook to start listening to each mouseEvent.
        /// </summary>
        public void SetHook()
        {
            _hProc = MouseHookProc;
            _hHook = Win32Api.SetWindowsHookEx(WhMouseLl, _hProc, IntPtr.Zero, 0);
        }


        /// <summary>
        /// This methode dipose the mouse hook.this operation must always be called when mousehook no longer has any function in the application
        /// </summary>
        public void UnHook()
        {
            Win32Api.UnhookWindowsHookEx(_hHook);
        }

        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var myMouseHookStruct = (Win32Api.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseHookStruct));
            if (nCode < 0)
            {
                return Win32Api.CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            MouseButtons button;

            int clickCount;
            switch ((int)wParam)
            {
                case WmLbuttondown:
                    button = MouseButtons.Left;
                    clickCount = 1;
                    MouseDownEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;
                case WmRbuttondown:
                    button = MouseButtons.Right;
                    clickCount = 1;
                    MouseDownEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;
                case WmMbuttondown:
                    button = MouseButtons.Middle;
                    clickCount = 1;
                    MouseDownEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;
                case WmLbuttonup:
                    button = MouseButtons.Left;
                    clickCount = 1;
                    MouseUpEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;
                case WmRbuttonup:
                    button = MouseButtons.Right;
                    clickCount = 1;
                    MouseUpEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;
                case WmMbuttonup:
                    button = MouseButtons.Middle;
                    clickCount = 1;
                    MouseUpEvent?.Invoke(this, new MouseEventArgs(button, clickCount, _point.X, _point.Y, 0));
                    break;

            }

            if (myMouseHookStruct != null) Point = new Point(myMouseHookStruct.pt.x, myMouseHookStruct.pt.y);
            return Win32Api.CallNextHookEx(_hHook, nCode, wParam, lParam);
        }

        public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
        /// <summary>
        /// When mousehook is hooked, this event rises when the mouse moves.
        /// </summary>
        public event MouseMoveHandler MouseMoveEvent;


        public delegate void MouseDownHandler(object sender, MouseEventArgs e);
        /// <summary>
        /// When mousehook is hooked, this event rises when a mouse button is pressed.
        /// </summary>
        public event MouseDownHandler MouseDownEvent;

        public delegate void MouseUpHandler(object sender, MouseEventArgs e);
        /// <summary>
        /// When mousehook is hooked, this event rises when a mouse button is released.
        /// </summary>
        public event MouseUpHandler MouseUpEvent;


    }
}
