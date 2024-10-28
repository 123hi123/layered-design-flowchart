using System.Drawing;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Decision : Shape
    {
        // 實現 Decision 的繪製邏輯
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // 定義菱形的四個點
                Point[] points = new Point[4];
                points[0] = new Point(X + Width / 2, Y); // 頂點
                points[1] = new Point(X + Width, Y + Height / 2); // 右點
                points[2] = new Point(X + Width / 2, Y + Height); // 底點
                points[3] = new Point(X, Y + Height / 2); // 左點

                // 繪製菱形
                g.DrawPolygon(pen, points);

                // 在菱形內部繪製文字（可選）
                using (Font font = new Font("Arial", 7))
                {
                    g.DrawString(ShapeName, font, Brushes.Black, X + Width / 2 - 10, Y + Height / 2 - 10);
                }
            }
        }
    }
}