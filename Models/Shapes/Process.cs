using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Shapes
{
    public class Process : Shape
    {
        public override bool ContainsPoint(int x, int y)
        {
            // 檢查點是否在矩形內
            return x >= X &&           // 點的 x 坐標大於等於矩形的左邊
                   x <= X + Width &&   // 點的 x 坐標小於等於矩形的右邊
                   y >= Y &&           // 點的 y 坐標大於等於矩形的上邊
                   y <= Y + Height;    // 點的 y 坐標小於等於矩形的下邊
        }
        // 繪製 Process 矩形
        public override void Draw(IGraphics g)
        {
            if (Width <= 0 || Height <= 0)
            {
                // 避免無效的繪製操作
                return;
            }

            // 繪製矩形
            g.DrawRectangle(X, Y, Width, Height);

            // 在矩形內部繪製文字
            g.DrawString(ShapeName, TextX, TextY);
        }
    }
}