using System;
using System.IO;
using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖.States
{
    public class DrawingLineState : IState
    {
        private Point2D? _startPoint;
        private Point2D? _currentPoint;
        public string DrawingFrameType { get; private set; } = null;

        public Point2D? CurrentPoint => _currentPoint;
        public Point2D? StartPoint => _startPoint;
        public Shape SelectedShape { get; private set; } = null;
        public Line Line;
        public int StartId, EndId;
        public Point2D? TempStart { get; private set; } = null;
        
        public Point2D? TempEnd { get; private set; } = null;
        public Point2D? TouchedPoint { get; private set; } = null;


        public int SelectedIndex { get; private set; } = -1;

        protected ShapesModel _model;

        public void SetModel(ShapesModel model)
        {
            _model = model;
            DrawingFrameType = "DrawingLine";
        }
        public void MouseDown(int x, int y, bool isDrawingMode)
        {
            if (SelectedShape != null)
            {
                int Direct= SelectedShape.CheckPointInSmallCircle(x, y);
                if (Direct != -1)
                {
                    TempStart = SelectedShape.GetSmallCirclePosition(Direct);
                    Line = new Line(SelectedIndex, 0, Direct, 0, _model);
                }
            }

        }

        public void MouseMove(int x, int y)
        {
            TouchedPoint = null;
            var result = _model.FindShapeAtPosition(x, y);
            SelectedIndex = result.Item1;
            SelectedShape = result.Item2;
            if (SelectedShape != null)
            {
                int Direct = SelectedShape.CheckPointInSmallCircle(x, y);
                if (Direct != -1)
                {
                    TouchedPoint= SelectedShape.GetSmallCirclePosition(Direct);
                }
            }
            TempEnd = new Point2D(x, y);
        }

        public void MouseUp(int x, int y)
        {
            // 先保存起始點，再清空 for command
            if (SelectedShape != null && Line !=null)
            {
                int Direct = SelectedShape.CheckPointInSmallCircle(x, y);
                if (Direct != -1 && !(Line.StartConnectionPoint==Direct&&Line.StartShapeId==SelectedIndex))
                {
                    Line.EndShapeId = SelectedIndex;
                    Line.EndConnectionPoint = Direct;
                    _model.AddLine(Line);
                }
                
            }
            TempStart = null;
            Line = null;
            _model.IntoSelection();
        }
    }
}
