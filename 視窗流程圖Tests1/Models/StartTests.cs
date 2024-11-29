using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.Shapes;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;
using System;
using System.Collections.Generic;

namespace 視窗流程圖Tests.Models
{
    [TestClass]
    public class StartTests
    {
        private class MockGraphics : IGraphics
        {
            public List<string> DrawCalls { get; } = new List<string>();

            public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle)
            {
                DrawCalls.Add($"DrawArc: ({x}, {y}, {width}, {height}, {startAngle}, {sweepAngle})");
            }

            public void DrawString(string text, float x, float y)
            {
                DrawCalls.Add($"DrawString: {text} at ({x}, {y})");
            }

            public void DrawLine(float x1, float y1, float x2, float y2) { }
            public void DrawRectangle(float x, float y, float width, float height) { }
            public void DrawPolygon(List<Point2D> points) { }
            public void DrawSelectionFrame(float x, float y, float width, float height) { }
            public void DrawTextWithRedFrame(float x, float y, string text) { }
            public void DrawOrangeDot(float x, float y) { }
            public float GetTextWidth(string text) { return 0; }
        }

        [TestMethod]
        public void TestStartContainsPoint()
        {
            // Arrange
            Start start = new Start
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 100
            };

            // Act & Assert
            // Test points inside the start shape
            Assert.IsTrue(start.ContainsPoint(150, 150), "Center point should be inside");
            Assert.IsTrue(start.ContainsPoint(100, 150), "Left point should be inside");
            Assert.IsTrue(start.ContainsPoint(200, 150), "Right point should be inside");
            Assert.IsTrue(start.ContainsPoint(150, 100), "Top point should be inside");
            Assert.IsTrue(start.ContainsPoint(150, 200), "Bottom point should be inside");

            // Test points outside the start shape
            Assert.IsFalse(start.ContainsPoint(50, 150), "Point far to the left should be outside");
            Assert.IsFalse(start.ContainsPoint(250, 150), "Point far to the right should be outside");
            Assert.IsFalse(start.ContainsPoint(150, 50), "Point far above should be outside");
            Assert.IsFalse(start.ContainsPoint(150, 250), "Point far below should be outside");
            Assert.IsFalse(start.ContainsPoint(100, 100), "Corner point should be outside");
        }
        [TestMethod]
        public void TestStartContainsPointHeight()
        {
            // Arrange
            Start start = new Start
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 110
            };

            // Act & Assert
            // Test points inside the start shape
            Assert.IsTrue(start.ContainsPoint(150, 150), "Center point should be inside");
        }
        [TestMethod]
        public void TestStartContainsPointWidth()
        {
            // Arrange
            Start start = new Start
            {
                X = 100,
                Y = 100,
                Width = 110,
                Height = 100
            };

            // Act & Assert
            // Test points inside the start shape
            Assert.IsTrue(start.ContainsPoint(150, 150), "Center point should be inside");
        }

        [TestMethod]
        public void TestStartDraw()
        {
            // Arrange
            Start start = new Start
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 100,
                ShapeName = "TestStart"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            start.Draw(mockGraphics);

            // Assert
            Assert.AreEqual(2, mockGraphics.DrawCalls.Count, "Expected 2 draw calls");
        }

        [TestMethod]
        public void TestStartDrawWithInvalidDimensions()
        {
            // Arrange
            Start start = new Start
            {
                X = 100,
                Y = 100,
                Width = 0,
                Height = 100,
                ShapeName = "TestStart"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            start.Draw(mockGraphics);

            // Assert
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for invalid dimensions");
        }
    }
}
