using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.Shapes;
using 視窗流程圖.Adapter;
using System.Collections.Generic;

namespace 視窗流程圖Tests1.Models
{
    [TestClass]
    public class ProcessTests
    {
        private class MockGraphics : IGraphics
        {
            public List<string> DrawCalls { get; } = new List<string>();

            public void DrawRectangle(float x, float y, float width, float height)
            {
                DrawCalls.Add($"DrawRectangle: ({x}, {y}, {width}, {height})");
            }

            public void DrawString(string text, float x, float y)
            {
                DrawCalls.Add($"DrawString: {text} at ({x}, {y})");
            }

            public void DrawLine(float x1, float y1, float x2, float y2) { }
            public void DrawPolygon(List<Point2D> points) { }
            public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle) { }
            public void DrawSelectionFrame(float x, float y, float width, float height) { }
            public void DrawTextWithRedFrame(float x, float y, string text) { }
            public void DrawOrangeDot(float x, float y) { }
            public float GetTextWidth(string text) { return 0; }
        }

        [TestMethod]
        public void TestProcessContainsPoint()
        {
            // Arrange
            Process process = new Process
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 50
            };

            // Act & Assert
            // Test points inside
            Assert.IsTrue(process.ContainsPoint(150, 125), "Center point should be inside");
            
            // Test points on edges
            Assert.IsTrue(process.ContainsPoint(100, 100), "Top-left corner should be inside");
            Assert.IsTrue(process.ContainsPoint(200, 100), "Top-right corner should be inside");
            Assert.IsTrue(process.ContainsPoint(100, 150), "Bottom-left corner should be inside");
            Assert.IsTrue(process.ContainsPoint(200, 150), "Bottom-right corner should be inside");
            Assert.IsTrue(process.ContainsPoint(100, 125), "Left edge should be inside");
            Assert.IsTrue(process.ContainsPoint(200, 125), "Right edge should be inside");
            Assert.IsTrue(process.ContainsPoint(150, 100), "Top edge should be inside");
            Assert.IsTrue(process.ContainsPoint(150, 150), "Bottom edge should be inside");

            // Test points outside
            Assert.IsFalse(process.ContainsPoint(99, 125), "Point to the left should be outside");
            Assert.IsFalse(process.ContainsPoint(201, 125), "Point to the right should be outside");
            Assert.IsFalse(process.ContainsPoint(150, 99), "Point above should be outside");
            Assert.IsFalse(process.ContainsPoint(150, 151), "Point below should be outside");

            // Test with negative coordinates
            Process negativeProcess = new Process
            {
                X = -100,
                Y = -100,
                Width = 100,
                Height = 50
            };
            Assert.IsTrue(negativeProcess.ContainsPoint(-50, -75), "Point should be inside negative coordinates process");
            Assert.IsFalse(negativeProcess.ContainsPoint(0, 0), "Point should be outside negative coordinates process");
        }

        [TestMethod]
        public void TestProcessDraw()
        {
            // Arrange
            Process process = new Process
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 50,
                ShapeName = "TestProcess"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            process.Draw(mockGraphics);
        }

        [TestMethod]
        public void TestProcessDrawWithInvalidDimensions()
        {
            // Arrange
            Process process = new Process
            {
                X = 100,
                Y = 100,
                Width = 0,
                Height = 50,
                ShapeName = "TestProcess"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            process.Draw(mockGraphics);

            // Assert
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for invalid width");

            // Test with negative dimensions
            process.Width = 100;
            process.Height = -50;
            process.Draw(mockGraphics);
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for negative height");

            // Test with both width and height as 0
            process.Width = 0;
            process.Height = 0;
            process.Draw(mockGraphics);
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls when both width and height are 0");
        }
    }
}
