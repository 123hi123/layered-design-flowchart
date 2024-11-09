using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Start : Shape
    {
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
            g.DrawString(ShapeName, X + Width / 2 - 10, Y + Height / 2 - 10);
        }
    }
}