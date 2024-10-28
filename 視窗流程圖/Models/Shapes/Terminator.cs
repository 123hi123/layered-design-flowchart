using System.Drawing;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Terminator : Shape
    {
        // 繪製 Terminator 矩形帶圓弧的圖形
        public override void Draw(Graphics g)
        {
            if (Height <= 0 || Width <= 0)
            {
                // 直接跳過繪製操作，避免無效的繪製。
                return;
            }
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // 繪製左右圓弧
                g.DrawArc(pen, X, Y, Height, Height, 90, 180); // 左半圓
                g.DrawArc(pen, X + Width, Y, Height, Height, 270, 180); // 右半圓

                // 繪製上方和下方的直線
                g.DrawLine(pen, X + Height / 2, Y, X + Width + Height / 2, Y); // 上直線
                g.DrawLine(pen, X + Height / 2, Y + Height, X + Width + Height / 2, Y + Height); // 下直線

                // 在圖形內部繪製文字
                using (Font font = new Font("Arial", 7))
                {
                    g.DrawString(ShapeName, font, Brushes.Black, X + Width / 2 - 10, Y + Height / 2 - 10);
                }
            }
        }
    }
}