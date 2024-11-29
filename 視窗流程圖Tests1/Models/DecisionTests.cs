using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.Shapes;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;
using System.Collections.Generic;
using System;

namespace 視窗流程圖Tests.Models
{
    [TestClass]
    public class DecisionTests
    {
        private class MockGraphics : IGraphics
        {
            public List<string> DrawCalls { get; } = new List<string>();

            public void DrawPolygon(List<Point2D> points)
            {
                DrawCalls.Add($"DrawPolygon: {string.Join(", ", points)}");
            }

            public void DrawString(string text, float x, float y)
            {
                DrawCalls.Add($"DrawString: {text} at ({x}, {y})");
            }

            public void DrawLine(float x1, float y1, float x2, float y2) { }
            public void DrawRectangle(float x, float y, float width, float height) { }
            public void DrawArc(float x, float y, float width, float height, float startAngle, float sweepAngle) { }
            public void DrawSelectionFrame(float x, float y, float width, float height) { }
            public void DrawTextWithRedFrame(float x, float y, string text) { }
            public void DrawOrangeDot(float x, float y) { }
            public float GetTextWidth(string text) { return 0; }
        }

        [TestMethod]
        public void TestDecisionContainsPoint()
        {
            // Arrange
            Decision decision = new Decision
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 100
            };

            // Act & Assert
            // Test points inside the decision shape
            Assert.IsTrue(decision.ContainsPoint(150, 150), "Center point should be inside");
           
        }

        [TestMethod]
        public void TestDecisionDraw()
        {
            // Arrange
            Decision decision = new Decision
            {
                X = 100,
                Y = 100,
                Width = 100,
                Height = 100,
                ShapeName = "TestDecision"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            decision.Draw(mockGraphics);
        }

        [TestMethod]
        public void TestDecisionDrawWithInvalidDimensions()
        {
            // Arrange
            Decision decision = new Decision
            {
                X = 100,
                Y = 100,
                Width = 0,
                Height = 100,
                ShapeName = "TestDecision"
            };

            MockGraphics mockGraphics = new MockGraphics();

            // Act
            decision.Draw(mockGraphics);

            // Assert
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for invalid dimensions");

            // Test with negative dimensions
            decision.Width = -50;
            decision.Height = -50;
            decision.Draw(mockGraphics);
            Assert.AreEqual(0, mockGraphics.DrawCalls.Count, "Expected no draw calls for negative dimensions");
        }
    }
}
