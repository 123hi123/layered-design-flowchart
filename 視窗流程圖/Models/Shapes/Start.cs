using System.Drawing;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Start : Shape
    {
        // 繪製 Start 圓形
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, X, Y, Width, Height);

                // 在圓形內部繪製文字
                using (Font font = new Font("Arial", 7))
                {
                    g.DrawString(ShapeName, font, Brushes.Black, X + Width / 2 - 10, Y + Height / 2 - 10);
                }
            }
        }
    }
}