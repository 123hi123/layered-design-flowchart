using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public interface IState
    {
        void MouseDown(int x, int y, bool isDrawingMode);
        Point2D? CurrentPoint { get; }
        Point2D? StartPoint { get; }
        Shape SelectedShape { get; }
        int SelectedIndex { get; }

        void MouseMove(int x, int y);
        void MouseUp();
        void SetModel(ShapesModel model);

    }
}