using System;
using 視窗流程圖.Models;

namespace 視窗流程圖.PresentationModels
{
    internal class TextEditPreModel
    {
        public event Action<int, Shape> ShapeUpdated; // 事件：形狀已更新

        public void UpdateShapeName(int id, Shape shape, string newText)
        {
            if (shape != null && shape.ShapeName != newText)
            {
                shape.ShapeName = newText;
                ShapeUpdated?.Invoke(id, shape); // 觸發事件
            }
        }
    }
}