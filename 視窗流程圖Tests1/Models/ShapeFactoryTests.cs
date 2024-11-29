using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.Factories;
using 視窗流程圖.Models;
using 視窗流程圖.Shapes;
using System;

namespace 視窗流程圖Tests.Models
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        public void TestCreateStartShape()
        {
            // Arrange
            ShapeData shapeData = new ShapeData
            {
                ShapeType = "Start",
                ShapeName = "TestStart",
                X = "100",
                Y = "100",
                Width = "50",
                Height = "50"
            };

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Start));
            Assert.AreEqual("TestStart", shape.ShapeName);
            Assert.AreEqual(100, shape.X);
            Assert.AreEqual(100, shape.Y);
            Assert.AreEqual(50, shape.Width);
            Assert.AreEqual(50, shape.Height);
        }

        [TestMethod]
        public void TestCreateTerminatorShape()
        {
            // Arrange
            ShapeData shapeData = new ShapeData
            {
                ShapeType = "Terminator",
                ShapeName = "TestTerminator",
                X = "200",
                Y = "200",
                Width = "60",
                Height = "40"
            };

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Terminator));
            Assert.AreEqual("TestTerminator", shape.ShapeName);
            Assert.AreEqual(200, shape.X);
            Assert.AreEqual(200, shape.Y);
            Assert.AreEqual(60, shape.Width);
            Assert.AreEqual(40, shape.Height);
        }

        [TestMethod]
        public void TestCreateProcessShape()
        {
            // Arrange
            ShapeData shapeData = new ShapeData
            {
                ShapeType = "Process",
                ShapeName = "TestProcess",
                X = "300",
                Y = "300",
                Width = "70",
                Height = "70"
            };

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Process));
            Assert.AreEqual("TestProcess", shape.ShapeName);
            Assert.AreEqual(300, shape.X);
            Assert.AreEqual(300, shape.Y);
            Assert.AreEqual(70, shape.Width);
            Assert.AreEqual(70, shape.Height);
        }

        [TestMethod]
        public void TestCreateDecisionShape()
        {
            // Arrange
            ShapeData shapeData = new ShapeData
            {
                ShapeType = "Decision",
                ShapeName = "TestDecision",
                X = "400",
                Y = "400",
                Width = "80",
                Height = "60"
            };

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeData);

            // Assert
            Assert.IsInstanceOfType(shape, typeof(Decision));
            Assert.AreEqual("TestDecision", shape.ShapeName);
            Assert.AreEqual(400, shape.X);
            Assert.AreEqual(400, shape.Y);
            Assert.AreEqual(80, shape.Width);
            Assert.AreEqual(60, shape.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateInvalidShape()
        {
            // Arrange
            ShapeData shapeData = new ShapeData
            {
                ShapeType = "InvalidShape",
                ShapeName = "TestInvalid",
                X = "500",
                Y = "500",
                Width = "50",
                Height = "50"
            };

            // Act
            Shape shape = ShapeFactory.CreateShape(shapeData);

            // Assert
            // ExpectedException attribute will handle the assertion
        }
    }
}
