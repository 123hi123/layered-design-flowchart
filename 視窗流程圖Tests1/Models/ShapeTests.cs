using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;
using System.Collections.Generic;

namespace 視窗流程圖Tests.Models
{
    [TestClass]
    public class ShapeTests
    {
        private class TestShape : Shape
        {
            public override void Draw(IGraphics g)
            {
                // Do nothing for test
            }

            public override bool ContainsPoint(int x, int y)
            {
                return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
            }
        }

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
        public void Properties_ShouldSetAndGetCorrectly()
        {
            var shape = new TestShape
            {
                ShapeName = "Test",
                X = 10,
                Y = 20,
                TextX = 15,
                TextY = 25,
                Width = 100,
                Height = 50
            };

            Assert.AreEqual("Test", shape.ShapeName);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(15, shape.TextX);
            Assert.AreEqual(25, shape.TextY);
            Assert.AreEqual(100, shape.Width);
            Assert.AreEqual(50, shape.Height);
        }

        [TestMethod]
        public void IsWithinOrangeDotRange_ShouldReturnTrue_WhenPointIsWithinRange()
        {
            var shape = new TestShape
            {
                TextX = 100,
                TextY = 100,
                ShapeName = "Test" // This will set TextWidth to 40 (4 * 10) in our mock
            };
            shape.UpdateTextWidth(new MockGraphics());

            // The orange dot should be at (120, 100) with a radius of 4
            Assert.IsTrue(shape.IsWithinOrangeDotRange(100 + (int)(shape.TextWidth / 2), 100)); // Center
        }

        [TestMethod]
        public void IsWithinOrangeDotRange_ShouldReturnFalse_WhenPointIsOutOfRange()
        {
            var shape = new TestShape
            {
                TextX = 100,
                TextY = 100,
                ShapeName = "Test" // This will set TextWidth to 40 (4 * 10) in our mock
            };
            shape.UpdateTextWidth(new MockGraphics());

            // The orange dot should be at (120, 100) with a radius of 4
            Assert.IsFalse(shape.IsWithinOrangeDotRange(125, 100)); // Just outside right edge
            Assert.IsFalse(shape.IsWithinOrangeDotRange(120, 105)); // Just outside bottom edge
            Assert.IsFalse(shape.IsWithinOrangeDotRange(150, 150)); // Far away
        }



        [TestMethod]
        public void ContainsPoint_ShouldReturnTrue_WhenPointIsInside()
        {
            var shape = new TestShape
            {
                X = 10,
                Y = 10,
                Width = 100,
                Height = 50
            };

            Assert.IsTrue(shape.ContainsPoint(50, 30));
        }

        [TestMethod]
        public void ContainsPoint_ShouldReturnFalse_WhenPointIsOutside()
        {
            var shape = new TestShape
            {
                X = 10,
                Y = 10,
                Width = 100,
                Height = 50
            };

            Assert.IsFalse(shape.ContainsPoint(5, 5));
            Assert.IsFalse(shape.ContainsPoint(150, 150));
        }
    }
}
