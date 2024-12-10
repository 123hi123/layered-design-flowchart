﻿using System;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Models
{
    public abstract class Shape
    {
        public string ShapeName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TextX { get; set; }
        public int TextY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float TextWidth { get; private set; }

        // 抽象繪製方法，具體的子類會實現這個方法，改用 IGraphics
        public abstract void Draw(IGraphics g);

        public abstract bool ContainsPoint(int x, int y);

        public bool IsWithinOrangeDotRange(int x, int y)
        {
            float dotX = this.TextX + this.TextWidth / 2;
            float dotY = this.TextY;

            // Assuming the orange dot has a diameter of 8 pixels, its radius is 4 pixels
            int dotRadius = 4;

            // Check if the point (x, y) is within the circle with radius 'dotRadius'
            return Math.Pow(x - dotX, 2) + Math.Pow(y - dotY, 2) <= Math.Pow(dotRadius, 2);
        }

        public void UpdateTextWidth(IGraphics graphics)
        {
            this.TextWidth = graphics.GetTextWidth(this.ShapeName);
        }

        public Point2D? GetSmallCirclePosition(int circleNumber)
        {
            int halfWidth = Width / 2;
            int halfHeight = Height / 2;

            switch (circleNumber)
            {
                case 1: return new Point2D(X + halfWidth, Y); // 上中
                case 2: return new Point2D(X + halfWidth, Y + Height); // 下中
                case 3: return new Point2D(X, Y + halfHeight); // 左中
                case 4: return new Point2D(X + Width, Y + halfHeight); // 右中
                default: return null; // 返回 null 代替 new Point2D()
            }
        }

        // 修改：檢查點是否在小圓點內，使用 int 參數
        public int CheckPointInSmallCircle(int x, int y)
        {
            int halfWidth = Width / 2;
            int halfHeight = Height / 2;
            int radius = 10; // 假設小圓點的半徑為3像素（直徑6像素）

            if (IsPointInCircle(x, y, X + halfWidth, Y, radius)) return 1; // 上中
            if (IsPointInCircle(x, y, X, Y + halfHeight, radius)) return 3; // 左中
            if (IsPointInCircle(x, y, X + Width, Y + halfHeight, radius)) return 4; // 右中
            if (IsPointInCircle(x, y, X + halfWidth, Y + Height, radius)) return 2; // 下中

            return -1; // 不在任何小圓點內
        }

        // 修改：輔助方法使用 int 參數
        private bool IsPointInCircle(int px, int py, int cx, int cy, int r)
        {
            int dx = px - cx;
            int dy = py - cy;
            return dx * dx + dy * dy <= r * r;
        }
    }
}
