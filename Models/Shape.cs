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
    }
}
