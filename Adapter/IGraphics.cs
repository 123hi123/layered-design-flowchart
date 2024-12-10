using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace 視窗流程圖.Adapter
{
    public interface IGraphics
    {
        void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle);
        void DrawLine(float x1, float y1, float x2, float y2);
        void DrawString(string text, float x, float y);
        void DrawRectangle(float x, float y, float width, float height);
        void DrawPolygon(List<Point2D> points);
        void DrawSelectionFrame(float x, float y, float width, float height);
        void DrawLineSelectionFrame(float x, float y, float width, float height);

        // New methods for text rendering
        void DrawTextWithRedFrame(float x, float y, string text);
        void DrawOrangeDot(float x, float y);
        void DrawLineRedDot(float x, float y);

        float GetTextWidth(string text);
    }
}
