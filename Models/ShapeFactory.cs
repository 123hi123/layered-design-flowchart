using System;
using System.Collections.Generic;
using 視窗流程圖.Models;
using 視窗流程圖.Shapes;

namespace 視窗流程圖.Factories
{

    public static class ShapeFactory
    {
        public static Shape CreateShape(ShapeData shapeData)
        {
            Shape newShape;

            switch (shapeData.ShapeType)
            {
                case "Start":
                    newShape = new Start();
                    break;
                case "Terminator":
                    newShape = new Terminator();
                    break;
                case "Process":
                    newShape = new Process();
                    break;
                case "Decision":
                    newShape = new Decision();
                    break;
                default:
                    throw new ArgumentException($"Unknown shape type: {shapeData.ShapeType}");
            }

            // Copy properties from shapeData to newShape
            newShape.ShapeName = shapeData.ShapeName;
            newShape.X = int.Parse(shapeData.X);
            newShape.Y = int.Parse(shapeData.Y);
            newShape.Width = int.Parse(shapeData.Width);
            newShape.Height = int.Parse(shapeData.Height);
            newShape.TextX = newShape.X + newShape.Width / 2 - 10;
            newShape.TextY = newShape.Y + newShape.Height / 2 - 10;
            

            return newShape;
        }
    }
}