using System.Collections.Generic;

namespace 視窗流程圖.Adapter
{
    public interface IGraphics
    {
        void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle);
        void DrawLine(float x1, float y1, float x2, float y2);
        void DrawString(string text, float x, float y);

        // 繪製矩形
        void DrawRectangle(float x, float y, float width, float height);

        // 繪製多邊形，使用 Point2D 數據結構來表示多邊形的頂點
        void DrawPolygon(List<Point2D> points);
    }
}