using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public interface IState
    {
        void MouseDown(int x, int y, bool isDrawingMode);
        Point2D? CurrentPoint { get; }
        Point2D? StartPoint { get; }
        Point2D? TempStart { get; }
        Point2D? TempEnd { get; }
        Shape SelectedShape { get; }
        int SelectedIndex { get; }
        string DrawingFrameType { get; }
        void MouseMove(int x, int y);
        void MouseUp(int x, int y);
        void SetModel(ShapesModel model);
        Point2D? TouchedPoint { get; }



    }
}