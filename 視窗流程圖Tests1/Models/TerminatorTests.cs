using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.Shapes;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;
using System;
using System.Collections.Generic;

namespace 視窗流程圖Tests.Models
{
    [TestClass]
    public class TerminatorTests
    {
        private class MockGraphics : IGraphics
        {
            public List<string> DrawCalls { get; } = new List<string>();

            public void DrawLine(float x1, float y1, float x2, float y2)
            {
                DrawCalls.Add($"DrawLine: ({x1}, {y1}) to ({x2}, {y2})");
            }

            public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle)
            {
                DrawCalls.Add($"DrawArc: ({x}, {y}) {width}x{height}, {startAngle}° to {sweepAngle}°");
            }

            public void DrawString(string text, float x, float y)
            {
                DrawCalls.Add($"DrawString: {text} at ({x}, {y})");
            }

            public void DrawPolygon(List<Point2D> points) { }
            public void DrawRectangle(float x, float y, float width, float height) { }
            public void DrawSelectionFrame(float x, float y, float width, float height) { }
            public void DrawTextWithRedFrame(float x, float y, string text) { }
            public void DrawOrangeDot(float x, float y) { }
            public float GetTextWidth(string text) { return 0; }
        }

        [TestMethod]
        public void TestTerminatorContainsPoint()
        {
            // Arrange
            Terminator terminator = new Terminator
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 50
            };

            // Act & Assert
            // Test points inside the terminator shape
            Assert.IsTrue(terminator.ContainsPoint(150, 125), "Center point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(100, 125), "Left point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(200, 125), "Right point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(125, 100), "Top-left point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(175, 100), "Top-right point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(125, 150), "Bottom-left point should be inside");
            Assert.IsTrue(terminator.ContainsPoint(175, 150), "Bottom-right point should be inside");

            // Test points outside the terminator shape
            Assert.IsFalse(terminator.ContainsPoint(50, 125), "Point far to the left should be outside");
            Assert.IsFalse(terminator.ContainsPoint(250, 125), "Point far to the right should be outside");
            Assert.IsFalse(terminator.ContainsPoint(150, 50), "Point far above should be outside");
            Assert.IsFalse(terminator.ContainsPoint(150, 200), "Point far below should be outside");

            // Test edge cases
            Assert.IsTrue(terminator.ContainsPoint(100, 125), "Point on left edge should be inside");
            Assert.IsTrue(terminator.ContainsPoint(200, 125), "Point on right edge should be inside");
            Assert.IsTrue(terminator.ContainsPoint(150, 100), "Point on top edge should be inside");
            Assert.IsTrue(terminator.ContainsPoint(150, 150), "Point on bottom edge should be inside");
        }

        [TestMethod]
        public void TestTerminatorDraw()
        {
            // Arrange
            Terminator terminator = new Terminator
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 50,
                ShapeName = "TestTerminator"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            terminator.Draw(mockGraphics);

           
        }

        [TestMethod]
        public void TestTerminatorDrawWithInvalidDimensions()
        {
            // Arrange
            Terminator terminator = new Terminator
            {
                X = 100,
                Y = 100,
                Width = 0,
                Height = 50,
                ShapeName = "TestTerminator"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            terminator.Draw(mockGraphics);

            // Assert
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for invalid width");

            // Test with negative dimensions
            terminator.Width = 100;
            terminator.Height = -50;
            terminator.Draw(mockGraphics);
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for negative height");
        }

        
    }
}
