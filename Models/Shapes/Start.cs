using System;
using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Start : Shape
    {
        public override bool ContainsPoint(int x, int y)
        {
            // 計算圓的中心和半徑
            float centerX = X + Width / 2f;
            float centerY = Y + Height / 2f;
            float radius = Math.Min(Width, Height) / 2f;

            // 計算點到圓心的距離
            float dx = x - centerX;
            float dy = y - centerY;

            // 如果 Width 和 Height 不相等，我們需要調整 x 或 y 坐標
            if (Width > Height)
            {
                // 橢圓形比較寬，調整 x 坐標
                dx *= Height / (float)Width;
            }
            else if (Height > Width)
            {
                // 橢圓形比較高，調整 y 坐標
                dy *= Width / (float)Height;
            }

            // 計算調整後的距離
            float distanceSquared = dx * dx + dy * dy;

            // 如果調整後的距離小於或等於半徑的平方，則點在圓內
            return distanceSquared <= radius * radius;
        }
        // 繪製 Start 圓形
        public override void Draw(IGraphics g)
        {
            if (Width <= 0 || Height <= 0)
            {
                // 避免無效的繪製操作
                return;
            }

            // 繪製圓形
            g.DrawArc(X, Y, Width, Height, 0, 360);  // 使用 DrawArc 畫出一個完整的圓形

            // 在圓形內部繪製文字
            g.DrawString(ShapeName, TextX, TextY);
        }
    }
}