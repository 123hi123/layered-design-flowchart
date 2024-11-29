﻿using System.Collections.Generic;
using System.Drawing;

namespace 視窗流程圖.Adapter
{
    public class GraphicsAdapter : IGraphics
    {
        private Graphics _graphics;

        public void DrawSelectionFrame(float x, float y, float width, float height)
        {
            // 繪製矩形框
            using (Pen pen = new Pen(Color.Red, 3))
            {
                _graphics.DrawRectangle(pen, x, y, width, height);
            }

            // 繪製八個小圓點
            using (Pen grayPen = new Pen(Color.Gray, 3))
            {
                float halfWidth = width / 2;
                float halfHeight = height / 2;

                DrawHollowCircle(x, y, grayPen);           // 左上
                DrawHollowCircle(x + halfWidth, y, grayPen);  // 上中
                DrawHollowCircle(x + width, y, grayPen);   // 右上
                DrawHollowCircle(x, y + halfHeight, grayPen); // 左中
                DrawHollowCircle(x + width, y + halfHeight, grayPen); // 右中
                DrawHollowCircle(x, y + height, grayPen);  // 左下
                DrawHollowCircle(x + halfWidth, y + height, grayPen); // 下中
                DrawHollowCircle(x + width, y + height, grayPen); // 右下
            }
        }

        private void DrawHollowCircle(float x, float y, Pen pen)
        {
            float diameter = 4; // 圓的直徑
            float radius = diameter / 2;

            // 繪製外圈
            _graphics.DrawEllipse(pen, x - radius, y - radius, diameter, diameter);
        }

        public GraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawArc(pen, x, y, width, height, startAngle, sweepAngle);
            }
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        public void DrawString(string text, float x, float y)
        {
            using (Font font = new Font("Arial", 7)) // 具體的 Font 由這裡管理
            {
                _graphics.DrawString(text, font, Brushes.Black, x, y);
            }
        }

        public void DrawRectangle(float x, float y, float width, float height)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                _graphics.DrawRectangle(pen, x, y, width, height);
            }
        }

        // 將 List<Point2D> 轉換為 PointF[]，並使用 Graphics 繪製多邊形
        public void DrawPolygon(List<Point2D> points)
        {
            using (Pen pen = new Pen(Color.Black, 2)) // 具體的 Pen 由這裡管理
            {
                // 將 Point2D 轉換為 PointF
                PointF[] pointFs = new PointF[points.Count];
                for (int i = 0; i < points.Count; i++)
                {
                    pointFs[i] = new PointF(points[i].X, points[i].Y);
                }

                // 使用 Graphics.DrawPolygon 繪製多邊形
                _graphics.DrawPolygon(pen, pointFs);
            }
        }

        public void DrawTextWithRedFrame(float x, float y, string text)
        {
            using (Font font = new Font("Arial", 7))
            using (Pen redPen = new Pen(Color.Red, 2))
            {
                // 測量文字大小
                SizeF textSize = _graphics.MeasureString(text, font);

                // 繪製紅色外框
                _graphics.DrawRectangle(redPen, x, y, textSize.Width, textSize.Height);

                // 繪製橘色點在上方線條的中間
                float dotX = x + textSize.Width / 2;
                float dotY = y;
                DrawOrangeDot(dotX, dotY);
            }
        }
        public float GetTextWidth(string text)
        {
            using (Font font = new Font("Arial", 7))
            {
                // 測量文字大小
                SizeF textSize = _graphics.MeasureString(text, font);
                return textSize.Width;
            }
        }

        public void DrawOrangeDot(float x, float y)
        {
            using (SolidBrush orangeBrush = new SolidBrush(Color.Orange))
            {
                float diameter = 8; // 點的直徑
                float radius = diameter / 2;
                _graphics.FillEllipse(orangeBrush, x - radius, y - radius, diameter, diameter);
            }
        }
    }
}
