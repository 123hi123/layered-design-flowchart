using System.Collections.Generic;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Shapes
{
    public class Decision : Shape
    {
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
            g.DrawString(ShapeName, X + Width / 2 - 10, Y + Height / 2 - 10);
        }
    }
}