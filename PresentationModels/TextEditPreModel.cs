using System;
using 視窗流程圖.Models;

namespace 視窗流程圖.PresentationModels
{
    internal class TextEditPreModel
    {

        public void UpdateShapeName(int id, Shape shape, string newText)
        {
            if (shape != null && shape.ShapeName != newText)
            {
                shape.ShapeName = newText;

            }
        }
    }
}