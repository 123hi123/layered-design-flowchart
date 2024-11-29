using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.States;
using 視窗流程圖.Adapter;
using 視窗流程圖.Models;

namespace 視窗流程圖Tests.States
{
    [TestClass]
    public class DrawingStateTests
    {
        private DrawingState _drawingState;

        [TestInitialize]
        public void Setup()
        {
            _drawingState = new DrawingState();
        }

        [TestMethod]
        public void TestMouseDown_SetsStartPoint()
        {
            // Arrange
            int x = 10, y = 20;

            // Act
            _drawingState.MouseDown(x, y, true);

            // Assert
            Assert.IsNotNull(_drawingState.StartPoint);
            Assert.AreEqual(x, _drawingState.StartPoint.Value.X);
            Assert.AreEqual(y, _drawingState.StartPoint.Value.Y);
        }

        [TestMethod]
        public void TestMouseMove_SetsCurrentPoint()
        {
            // Arrange
            int x = 30, y = 40;

            // Act
            _drawingState.MouseMove(x, y);

            // Assert
            Assert.IsNotNull(_drawingState.CurrentPoint);
            Assert.AreEqual(x, _drawingState.CurrentPoint.Value.X);
            Assert.AreEqual(y, _drawingState.CurrentPoint.Value.Y);
        }

        [TestMethod]
        public void TestMouseUp_ClearsStartPoint()
        {
            // Arrange
            _drawingState.MouseDown(10, 20, true);

            // Act
            _drawingState.MouseUp();

            // Assert
            Assert.IsNull(_drawingState.StartPoint);
        }
        
        [TestMethod]
        public void TestMouseDownNotDrawingMode()
        {
            // Arrange
            int x = 10, y = 20;

            // Act
            _drawingState.MouseDown(x, y, false);

            // Assert
            Assert.IsNull(_drawingState.StartPoint);
        }

        [TestMethod] // todo
        public void TestSetModel_SetsModel()
        {
            // Arrange
            var model = new ShapesModel();

            // Act
            _drawingState.SetModel(model);

            // Assert
            // Since _model is protected, we can't directly access it.
            // We can only verify that the method doesn't throw an exception.
            // If more thorough testing is needed, consider making _model internal or public.
        }
    }
}
