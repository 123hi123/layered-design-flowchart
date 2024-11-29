using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter; // 僅使用於Point2D

namespace 視窗流程圖.Models.Tests
{
    [TestClass]
    public class ShapesModelTests
    {
        private ShapesModel _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new ShapesModel();
        }

        [TestMethod]
        public void TestFindShapeAtPosition()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                ShapeType = "Process",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "100",
                Height = "100"
            };
            int addedId = _model.AddShape(shapeData);

            // Act
            var result = _model.FindShapeAtPosition(10, 10);

            // Assert
            Assert.AreEqual(addedId, result.Item1);
            Assert.IsNotNull(result.Item2);
            Assert.AreEqual("Process", result.Item2.GetType().Name);
        }

        [TestMethod]
        public void TestFindShapeAtPositionNoShapeFound()
        {
            // Act
            var result = _model.FindShapeAtPosition(1000, 1000);

            // Assert
            Assert.AreEqual(-1, result.Item1);
            Assert.IsNull(result.Item2);
        }
        
        
        [TestMethod]
        public void FindShapeAtPosition_ShapeContainsPoint_ReturnsShape()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                ShapeType = "Process",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "10",
                Height = "10"
            };
            int addedId = _model.AddShape(shapeData);

            // Act
            var result = _model.FindShapeAtPosition(1000, 1000);

            // Assert
            Assert.AreEqual(-1, result.Item1);
            Assert.IsNull(result.Item2);
        }


        [TestMethod]
        public void FindShapeAtPosition_EmptyShapesCollection_ReturnsNegativeOneAndNull()
        {
            // Arrange
            var model = new ShapesModel();

            // Act
            var result = model.FindShapeAtPosition(10, 10);

            // Assert
            Assert.AreEqual(-1, result.id);
            Assert.IsNull(result.shape);
        }
        


        //[TestMethod]
        //public void TestValid()
        //{
        //    // Arrange
        //    var validData = new ShapeData
        //    {
        //        ShapeType = "Decision",
        //        ShapeName = "Test",
        //        X = "10",
        //        Y = "10",
        //        Width = "100",
        //        Height = "100"
        //    };

        //    var invalidData = new ShapeData
        //    {
        //        ShapeType = "",
        //        ShapeName = "Test",
        //        X = "10",
        //        Y = "10",
        //        Width = "-100",
        //        Height = "100"
        //    };

        //    // Act & Assert
        //    Assert.IsTrue(_model.Valid(validData));
        //    Assert.IsFalse(_model.Valid(invalidData));
        //}

        //[TestMethod]
        //public void TestValidEdgeCases()
        //{
        //    // Arrange
        //    var zeroSizeShape = new ShapeData
        //    {
        //        ShapeType = "Process",
        //        ShapeName = "ZeroSize",
        //        X = "10",
        //        Y = "10",
        //        Width = "0",
        //        Height = "0"
        //    };

        //    var negativeSizeShape = new ShapeData
        //    {
        //        ShapeType = "Process",
        //        ShapeName = "NegativeSize",
        //        X = "10",
        //        Y = "10",
        //        Width = "-10",
        //        Height = "-10"
        //    };

        //    var invalidTypeShape = new ShapeData
        //    {
        //        ShapeType = "",
        //        ShapeName = "Invalid",
        //        X = "10",
        //        Y = "10",
        //        Width = "100",
        //        Height = "100"
        //    };

        //    // Act & Assert
        //    Assert.IsFalse(_model.Valid(zeroSizeShape));
        //    Assert.IsFalse(_model.Valid(negativeSizeShape));
        //    Assert.IsFalse(_model.Valid(invalidTypeShape));
        //}

        [TestMethod]
        public void TestCalculateShapeData()
        {
            // Arrange
            var startPoint = new Point2D(10, 10);
            var endPoint = new Point2D(110, 110);

            // Act
            var result = _model.CalculateShapeData(startPoint, endPoint, "Start");

            // Assert
            Assert.AreEqual("Start", result.ShapeType);
            Assert.AreEqual("10", result.X);
            Assert.AreEqual("10", result.Y);
            Assert.AreEqual("100", result.Width);
            Assert.AreEqual("100", result.Height);
            Assert.IsNotNull(result.ShapeName);
        }

        [TestMethod]
        public void TestCalculateShapeDataDifferentTypes()
        {
            // Arrange
            var startPoint = new Point2D(10, 10);
            var endPoint = new Point2D(110, 110);

            // Act & Assert
            var processResult = _model.CalculateShapeData(startPoint, endPoint, "Process");
            Assert.AreEqual("Process", processResult.ShapeType);

            var decisionResult = _model.CalculateShapeData(startPoint, endPoint, "Decision");
            Assert.AreEqual("Decision", decisionResult.ShapeType);

            var terminatorResult = _model.CalculateShapeData(startPoint, endPoint, "Terminator");
            Assert.AreEqual("Terminator", terminatorResult.ShapeType);
        }

        [TestMethod]
        public void TestAddAndRemoveShape()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                ShapeType = "Terminator",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "100",
                Height = "100"
            };

            // Act
            int id = _model.AddShape(shapeData);
            var shapes = _model.GetShapes();

            // Assert
            Assert.AreEqual(1, shapes.Count);

            // Act
            _model.RemoveShape(id);
            shapes = _model.GetShapes();

            // Assert
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void TestGetShape()
        {
            // Arrange
            var shapeData = new ShapeData
            {
                ShapeType = "Process",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "100",
                Height = "100"
            };
            int id = _model.AddShape(shapeData);

            // Act
            var shape = _model.GetShape(id);

            // Assert
            Assert.IsNotNull(shape);
            Assert.AreEqual("Process", shape.GetType().Name);
        }
        [TestMethod]
        public void TestGetNoShape()
        {
            // Arrange

            // Act
            var shape = _model.GetShape(1);

            // Assert
            Assert.IsNull(shape);
        }

        [TestMethod]
        public void TestReRenderSignEvent()
        {
            // Arrange
            bool eventRaised = false;
            _model.ReRenderSign += () => eventRaised = true;

            var shapeData = new ShapeData
            {
                ShapeType = "Decision",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "100",
                Height = "100"
            };

            // Act
            _model.AddShape(shapeData);

            // Assert
            Assert.IsTrue(eventRaised);
        }
        [TestMethod]
        public void TestAddShapeReRenderSignEvent()
        {
            // Arrange
            bool eventRaised = false;
            _model.ReRenderSign += () => eventRaised = true;

            var shapeData = new ShapeData
            {
                ShapeType = "Decision",
                ShapeName = "Test",
                X = "10",
                Y = "10",
                Width = "100",
                Height = "100"
            };
            int id=_model.AddShape(shapeData);

            // Act
            _model.AddShape(5,_model.GetShape(id));

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void TestPoint2DEquality()
        {
            // Arrange
            var point1 = new Point2D(10, 20);
            var point2 = new Point2D(10, 20);
            var point3 = new Point2D(20, 30);

            // Act & Assert
            Assert.AreEqual(point1, point2);
            Assert.IsTrue(point1 == point2);
            Assert.IsFalse(point1 != point2);
            Assert.AreNotEqual(point1, point3);
            Assert.IsTrue(point1 != point3);
            Assert.IsFalse(point1 == point3);
        }


    }
}
