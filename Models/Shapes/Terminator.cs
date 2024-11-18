using System;
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

            float totalWidth = Math.Abs(Width);
            float arcWidth = totalWidth / 4f;
            float left = Math.Min(X, X + Width);
            float right = Math.Max(X, X + Width);

            // 檢查左半橢圓
            if (x < left + arcWidth)
            {
                return IsPointInEllipse(x, y, left + arcWidth, Y + Height / 2f, arcWidth, Height / 2f);
            }

            // 檢查右半橢圓
            if (x > right - arcWidth)
            {
                return IsPointInEllipse(x, y, right - arcWidth, Y + Height / 2f, arcWidth, Height / 2f);
            }

            // 點在中間矩形部分
            return true;
        }

        private bool IsPointInEllipse(float px, float py, float cx, float cy, float rx, float ry)
        {
            float dx = px - cx;
            float dy = py - cy;
            return (dx * dx) / (rx * rx) + (dy * dy) / (ry * ry) <= 1;
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
            if (Height <= 0 || Math.Abs(Width) <= 0)
            {
                return;
            }

            float left = Math.Min(X, X + Width);
            float right = Math.Max(X, X + Width);
            float totalWidth = Math.Abs(Width);

            // 圓弧的寬度為總寬度的1/4
            float arcWidth = totalWidth / 4;

            // 計算中間直線部分的寬度
            float middleWidth = totalWidth - 2 * arcWidth;

            // 繪製左右圓弧
            g.DrawArc(left, Y, arcWidth * 2, Height, 90, 180); // 左半圓
            g.DrawArc(right - arcWidth * 2, Y, arcWidth * 2, Height, 270, 180); // 右半圓

            // 繪製上方和下方的直線
            g.DrawLine(left + arcWidth, Y, right - arcWidth, Y); // 上直線
            g.DrawLine(left + arcWidth, Y + Height, right - arcWidth, Y + Height); // 下直線

            // 在圖形內部繪製文字
            float centerX = (left + right) / 2;
            g.DrawString(ShapeName, centerX - 10, Y + Height / 2 - 10);
        }
    }
}