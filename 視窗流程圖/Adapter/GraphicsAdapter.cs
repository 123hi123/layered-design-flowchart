using System.Collections.Generic;
using System.Drawing;

namespace 視窗流程圖.Adapter
{
    public class GraphicsAdapter : IGraphics
    {
        private Graphics _graphics;

        public GraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
            }
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        public void DrawString(string text, float x, float y)
        {
            using (Font font = new Font("Arial", 7)) // 具體的 Font 由這裡管理
            {
                _graphics.DrawString(text, font, Brushes.Black, x, y);
            }
        }

        public void DrawRectangle(float x, float y, float width, float height)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawRectangle(pen, x, y, width, height);
            }
        }

        // 將 List<Point2D> 轉換為 PointF[]，並使用 Graphics 繪製多邊形
        public void DrawPolygon(List<Point2D> points)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                // 將 Point2D 轉換為 PointF
                PointF[] pointFs = new PointF[points.Count];
                for (int i = 0; i < points.Count; i++)
                {
                    pointFs[i] = new PointF(points[i].X, points[i].Y);
                }

                // 使用 Graphics.DrawPolygon 繪製多邊形
                _graphics.DrawPolygon(pen, pointFs);
            }
        }
    }
}