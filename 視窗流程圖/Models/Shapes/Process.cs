using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Shapes
{
    public class Process : Shape
    {
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
            g.DrawString(ShapeName, X + Width / 2 - 10, Y + Height / 2 - 10);
        }
    }
}