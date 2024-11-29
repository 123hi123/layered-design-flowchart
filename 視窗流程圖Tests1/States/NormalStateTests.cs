using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.States;
using 視窗流程圖.Models;  // 僅使用於mock shapemodel 與shape資料型別
using 視窗流程圖.Adapter; // 僅使用於mock igraphic
using System.Collections.Generic;

namespace 視窗流程圖Tests.States
{
    [TestClass]
    public class NormalStateTests
    {
        private NormalState _normalState;
        private MockShapesModel _mockModel;

        [TestInitialize]
        public void Setup()
        {
            _normalState = new NormalState();
            _mockModel = new MockShapesModel();
            _normalState.SetModel(_mockModel);
        }

        [TestMethod]
        public void MouseDown_SelectsShape_WhenShapeExists()
        {
            // Arrange
            var shape = new MockShape { X = 10, Y = 10 };
            _mockModel.Shapes.Add(shape);

            // Act
            _normalState.MouseDown(15, 15, false);

            // Assert
            Assert.AreEqual(shape, _normalState.SelectedShape);
            Assert.AreEqual(0, _normalState.SelectedIndex);
            Assert.IsNotNull(_normalState.StartPoint);
            Assert.AreEqual(15, _normalState.StartPoint.Value.X);
            Assert.AreEqual(15, _normalState.StartPoint.Value.Y);
            Assert.IsNull(_normalState.CurrentPoint);

        }

        [TestMethod]
        public void MouseDown_DoesNotSelectShape_WhenNoShapeExists()
        {
            // Act
            _normalState.MouseDown(15, 15, false);

            // Assert
            Assert.IsNull(_normalState.SelectedShape);
            Assert.AreEqual(-1, _normalState.SelectedIndex);
            Assert.IsNull(_normalState.StartPoint);
        }

        [TestMethod]
        public void MouseMove_UpdatesShapePosition_WhenShapeIsSelected()
        {
            // Arrange
            var shape = new MockShape { X = 10, Y = 10 };
            _mockModel.Shapes.Add(shape);
            _normalState.MouseDown(10, 10, false);

            // Act
            _normalState.MouseMove(20, 20);

            // Assert
            Assert.AreEqual(20, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(20, _normalState.StartPoint.Value.X);
            Assert.AreEqual(20, _normalState.StartPoint.Value.Y);
        }

        [TestMethod]
        public void MouseMove_DoesNotUpdatePosition_WhenNoShapeIsSelected()
        {
            // Act
            _normalState.MouseMove(20, 20);

            // Assert
            Assert.IsNull(_normalState.SelectedShape);
            Assert.IsNull(_normalState.StartPoint);
        }

        [TestMethod]
        public void MouseUp_ResetsStartPoint()
        {
            // Arrange
            var shape = new MockShape { X = 10, Y = 10 };
            _mockModel.Shapes.Add(shape);
            _normalState.MouseDown(10, 10, false);

            // Act
            _normalState.MouseUp();

            // Assert
            Assert.IsNull(_normalState.StartPoint);
        }
    }

    // Mock class for ShapesModel
    public class MockShapesModel : ShapesModel
    {
        public List<Shape> Shapes { get; } = new List<Shape>();

        public override (int, Shape) FindShapeAtPosition(int x, int y)
        {
            // Mock implementation
            if (Shapes.Count > 0)
            {
                return (0, Shapes[0]);
            }
            return (-1, null);
        }
    }

    // Mock class for Shape
    public class MockShape : Shape
    {
        public override void Draw(IGraphics graphics)
        {
            // Mock implementation
        }

        public override bool ContainsPoint(int x, int y)
        {
            // Mock implementation
            return X <= x && x <= X + Width && Y <= y && y <= Y + Height;
        }
    }
}
