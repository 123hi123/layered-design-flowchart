using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.Shapes
{
    public class Terminator : Shape
    {
        public override bool ContainsPoint(int x, int y)
        {
            // 首先檢查點是否在整體的邊界矩形內
            if (x < X || x > X + Width || y < Y || y > Y + Height)
            {
                return false;
            }

            float halfHeight = Height / 2f;
            float centerY = Y + halfHeight;

            // 檢查左半圓
            if (x < X + halfHeight)
            {
                return IsPointInCircle(x, y, X + halfHeight, centerY, halfHeight);
            }

            // 檢查右半圓
            if (x > X + Width - halfHeight)
            {
                return IsPointInCircle(x, y, X + Width - halfHeight, centerY, halfHeight);
            }

            // 點在中間矩形部分
            return true;
        }

        private bool IsPointInCircle(float px, float py, float cx, float cy, float radius)
        {
            float dx = px - cx;
            float dy = py - cy;
            return dx * dx + dy * dy <= radius * radius;
        }
        // 繪製 Terminator 矩形帶圓弧的圖形
        public override void Draw(IGraphics g)
        {
            if (Height <= 0 || Width <= 0)
            {
                // 直接跳過繪製操作，避免無效的繪製。
                return;
            }

            float arcDiameter = Height; // 圓弧的直徑等於高度

            // 繪製左右圓弧
            g.DrawArc(X, Y, arcDiameter, arcDiameter, 90, 180); // 左半圓
            g.DrawArc(X + Width - arcDiameter, Y, arcDiameter, arcDiameter, 270, 180); // 右半圓

            // 繪製上方和下方的直線
            g.DrawLine(X + arcDiameter / 2, Y, X + Width - arcDiameter / 2, Y); // 上直線
            g.DrawLine(X + arcDiameter / 2, Y + Height, X + Width - arcDiameter / 2, Y + Height); // 下直線

            // 在圖形內部繪製文字
            g.DrawString(ShapeName, X + Width / 2 - 10, Y + Height / 2 - 10);
        }
    }
}