using System;
using System.Collections.Generic;
using 視窗作業二.Models;

namespace 視窗作業二.Factories
{
    public class Start : Shape { }
    public class Terminator : Shape { }
    public class Process : Shape { }
    public class Decision : Shape { }

    public static class ShapeFactory
    {
        public static Shape CreateShape(List<string> shapeData)
        {
            Shape newShape;

            switch (shapeData[0])
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
                    throw new ArgumentException($"Unknown shape type: {shapeData[0]}");
            }

            // Copy properties from baseShape to newShape
            newShape.ShapeName = shapeData[1];
            newShape.X = int.Parse(shapeData[2]);
            newShape.Y = int.Parse(shapeData[3]);
            newShape.Width = int.Parse(shapeData[4]);
            newShape.Height = int.Parse(shapeData[5]);

            return newShape;
        }
    }
}