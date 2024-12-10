using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public class DrawingState : IState
    {
        private Point2D? _startPoint;
        private Point2D? _currentPoint;
        public Point2D? TempStart { get; private set; } = null;
        public Point2D? TempEnd { get; private set; } = null;
        protected ShapesModel _model;
        public string DrawingFrameType { get; private set; } = null;
        public void SetModel(ShapesModel model)
        {
            _model = model;
        }

        public Point2D? CurrentPoint => _currentPoint;
        public Point2D? StartPoint => _startPoint;
        public Shape SelectedShape { get; private set; } = null;
        public int SelectedIndex { get; private set; } = -1;
        public Point2D? TouchedPoint { get; private set; } = null;

        public void MouseDown(int x, int y, bool isDrawingMode)
        {
            if (isDrawingMode)
            {
                _startPoint = new Point2D(x, y);
            }
        }

        public void MouseMove(int x, int y)
        {
            _currentPoint = new Point2D(x, y);
        }
        public void MouseUp(int x, int y)
        {
            _startPoint = null;
            _model.IntoSelection();
        }
    }
}