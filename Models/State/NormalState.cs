using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public class NormalState : IState
    {
        private Point2D? _startPoint;
        private Point2D? _currentPoint;
        public Point2D? CurrentPoint => _currentPoint;
        public Point2D? StartPoint => _startPoint;
        public Shape SelectedShape { get; private set; } = null;

        public int SelectedIndex { get; private set; } = -1;

        protected ShapesModel _model;

        public void SetModel(ShapesModel model)
        {
            _model = model;
        }
        public void MouseDown(int x, int y, bool isDrawingMode)
        {
            var result = _model.FindShapeAtPosition(x, y);
            SelectedIndex = result.Item1;
            SelectedShape = result.Item2;
            if (SelectedShape != null)
            {
                // 記錄開始點
                _startPoint = new Point2D(x, y);
            }
        }

        public void MouseMove(int x, int y)
        {
            if (SelectedShape != null && StartPoint.HasValue)
            {
                // 計算移動距離
                int deltaX = (int)(x - StartPoint.Value.X);
                int deltaY = (int)(y - StartPoint.Value.Y);

                // 更新選中形狀的位置
                SelectedShape.X += deltaX;
                SelectedShape.Y += deltaY;

                // 更新起始點
                _startPoint = new Point2D(x, y);
            }
        }

        public void MouseUp()
        {
            _startPoint = null;
        }

    }
}