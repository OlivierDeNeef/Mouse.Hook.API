using System;
using System.Drawing;

namespace Mouse.Hook.Api
{
    public class MouseEventArgs : EventArgs
    {
        public MouseButtons Button { get; }
        public int Clicks { get; }
        public int X { get; }
        public int Y { get; }

        public Point Location => new(X, Y);

        public int Delta { get; }


        /// <summary>
        /// These hold a collection of mouse actions data.
        /// </summary>
        /// <param name="button">Used button.</param>
        /// <param name="clicks">Totale of clicks.</param>
        /// <param name="x">Position of X coordinate.</param>
        /// <param name="y">Position of Y coordinate.</param>
        /// <param name="delta">A signed count of the number of detents the mouse wheel has rotated, multiplied by the WHEEL_DELTA constant.</param>
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
        {
            Button = button;
            Clicks = clicks;
            X = x;
            Y = y;
            Delta = delta;
        }
    }
}
