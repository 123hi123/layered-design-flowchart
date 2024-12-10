using System;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.Models
{
    public class Line
    {
        public int StartShapeId { get; set; }
        public int EndShapeId { get; set; }
        public int StartConnectionPoint { get; set; }
        public int EndConnectionPoint { get; set; }
        private ShapesModel _shapesModel;

        public Line(int startShapeId, int endShapeId, int startConnectionPoint, int endConnectionPoint, ShapesModel shapesModel)
        {
            StartShapeId = startShapeId;
            EndShapeId = endShapeId;
            StartConnectionPoint = startConnectionPoint;
            EndConnectionPoint = endConnectionPoint;
            _shapesModel = shapesModel ?? throw new ArgumentNullException(nameof(shapesModel));
        }

        private Shape GetStartShape()
        {
            return _shapesModel.GetShape(StartShapeId);
        }

        private Shape GetEndShape()
        {
            return _shapesModel.GetShape(EndShapeId);
        }

        public Point2D? GetStartPoint()
        {
            Shape startShape = GetStartShape();
            return startShape?.GetSmallCirclePosition(StartConnectionPoint);
        }

        public Point2D? GetEndPoint()
        {
            Shape endShape = GetEndShape();
            return endShape?.GetSmallCirclePosition(EndConnectionPoint);
        }

        public void Draw(IGraphics graphics)
        {
            Point2D? startPoint = GetStartPoint();
            Point2D? endPoint = GetEndPoint();

            if (startPoint.HasValue && endPoint.HasValue)
            {
                graphics.DrawLine(startPoint.Value.X, startPoint.Value.Y, endPoint.Value.X, endPoint.Value.Y);
            }
        }

        public bool ContainsPoint(int x, int y)
        {
            Point2D? start = GetStartPoint();
            Point2D? end = GetEndPoint();

            if (!start.HasValue || !end.HasValue)
            {
                return false;
            }

            double lineLength = Math.Sqrt(Math.Pow(end.Value.X - start.Value.X, 2) + Math.Pow(end.Value.Y - start.Value.Y, 2));
            double distance = Math.Abs((end.Value.Y - start.Value.Y) * x - (end.Value.X - start.Value.X) * y + end.Value.X * start.Value.Y - end.Value.Y * start.Value.X) / lineLength;

            return distance < 5;
        }
    }
}
