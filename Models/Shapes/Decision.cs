using System.Collections.Generic;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Shapes
{
    public class Decision : Shape
    {
        public override bool ContainsPoint(int x, int y)
        {
            // 定義菱形的四個頂點
            List<Point2D> points = new List<Point2D>
            {
                new Point2D(X + Width / 2f, Y),               // 頂點
                new Point2D(X + Width, Y + Height / 2f),      // 右邊
                new Point2D(X + Width / 2f, Y + Height),      // 底邊
                new Point2D(X, Y + Height / 2f)               // 左邊
            };

            // 檢查點是否在菱形內
            return IsPointInPolygon(new Point2D(x, y), points);
        }

        private bool IsPointInPolygon(Point2D p, List<Point2D> polygon)
        {
            int n = polygon.Count;
            bool inside = false;

            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if (((polygon[i].Y > p.Y) != (polygon[j].Y > p.Y)) &&
                    (p.X < (polygon[j].X - polygon[i].X) * (p.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    inside = !inside;
                }
            }

            return inside;
        }
        // 繪製 Decision 的菱形
        public override void Draw(IGraphics g)
        {
            if (Width <= 0 || Height <= 0)
            {
                // 避免無效的繪製操作
                return;
            }

            // 定義菱形的四個點，使用 Point2D 結構
            List<Point2D> points = new List<Point2D>();
            points.Add(new Point2D(X + Width / 2f, Y));               // 頂點
            points.Add(new Point2D(X + Width, Y + Height / 2f));      // 右邊
            points.Add(new Point2D(X + Width / 2f, Y + Height));      // 底邊
            points.Add(new Point2D(X, Y + Height / 2f));              // 左邊

            // 使用 DrawPolygon 繪製菱形
            g.DrawPolygon(points);

            // 在菱形內部繪製文字
            g.DrawString(ShapeName, TextX, TextY);
        }
    }
}