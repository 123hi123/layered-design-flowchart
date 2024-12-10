using System;
using System.Collections.Generic;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;

namespace 視窗流程圖.PresentationModels
{
    public class UpdatePreModel
    {
        public event Action<object[]> AddNewRowEvent;
        public event Action<int, object[]> UpdateExistingRowEvent;

        public void ProcessShapeData(int rowIndex, int id, Shape shape)
        {
            var data = new object[]
            {
                "刪除",
                id,
                shape.GetType().Name,
                shape.ShapeName,
                shape.X,
                shape.Y,
                shape.Height,
                shape.Width
            };

            TriggerAppropriateEvent(rowIndex, data);
        }

        public void ProcessLineData(int rowIndex, int id, Line line)
        {
            Point2D? startPoint = line.GetStartPoint();
            Point2D? endPoint = line.GetEndPoint();
            var data = new object[]
            {
                "刪除",
                id,
                "Line",
                "",
                startPoint?.X.ToString() ?? "N/A",
                startPoint?.Y.ToString() ?? "N/A",
                endPoint?.X.ToString() ?? "N/A",
                endPoint?.Y.ToString() ?? "N/A"
            };

            TriggerAppropriateEvent(rowIndex, data);
        }

        private void TriggerAppropriateEvent(int rowIndex, object[] data)
        {
            if (rowIndex == -1)
            {
                AddNewRowEvent?.Invoke(data);
            }
            else
            {
                UpdateExistingRowEvent?.Invoke(rowIndex, data);
            }
        }
    }
}
