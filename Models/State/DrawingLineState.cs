using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public class DrawingLineState : IState
    {
        private Point2D? _startPoint;
        private Point2D? _currentPoint;
        protected ShapesModel _model;

        public void SetModel(ShapesModel model)
        {
            _model = model;
        }

        public Point2D? CurrentPoint => _currentPoint;
        public Point2D? StartPoint => _startPoint;
        public Shape SelectedShape { get; private set; } = null;
        public int SelectedIndex { get; private set; } = -1;
        public void MouseDown(int x, int y, bool isDrawingMode)
        {
            
        }

        public void MouseMove(int x, int y)
        {
            
        }
        public void MouseUp()
        {
            
        }
    }
}