using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using 視窗流程圖.Models; // 僅使用於ShapeData資料驗證
using 視窗流程圖.PresentationModels;


namespace 視窗流程圖.PresentationModels.Tests
{

    [TestClass]
    public class ShapeInputPreModelTests
    {
        private ShapeInputPreModel _preModel;

        [TestInitialize]
        public void Initialize()
        {
            _preModel = new ShapeInputPreModel();
        }

        [TestMethod]
        public void TestGetShapeData()
        {
            _preModel.ShapeType = "Rectangle";
            _preModel.ShapeName = "TestShape";
            _preModel.X = "10";
            _preModel.Y = "20";
            _preModel.Width = "100";
            _preModel.Height = "50";

            ShapeData shapeData = _preModel.GetShapeData();

            Assert.AreEqual("Rectangle", shapeData.ShapeType);
            Assert.AreEqual("TestShape", shapeData.ShapeName);
            Assert.AreEqual("10", shapeData.X);
            Assert.AreEqual("20", shapeData.Y);
            Assert.AreEqual("100", shapeData.Width);
            Assert.AreEqual("50", shapeData.Height);
        }

        [TestMethod]
        public void TestUpdateProperty()
        {
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeType), "Circle");
            Assert.AreEqual("Circle", _preModel.ShapeType);

            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeName), "MyCircle");
            Assert.AreEqual("MyCircle", _preModel.ShapeName);

            _preModel.UpdateProperty(nameof(ShapeInputPreModel.X), "15");
            Assert.AreEqual("15", _preModel.X);

            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Y), "25");
            Assert.AreEqual("25", _preModel.Y);

            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Width), "75");
            Assert.AreEqual("75", _preModel.Width);

            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Height), "75");
            Assert.AreEqual("75", _preModel.Height);
        }

        [TestMethod]
        public void TestUpdatePropertyValidation()
        {
            // Set valid values
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeType), "Rectangle");
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeName), "TestShape");
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.X), "10");
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Y), "20");
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Width), "100");
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Height), "50");
            Assert.IsTrue(_preModel.IsValid);

            // Test invalid shape type
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeType), "");
            Assert.IsFalse(_preModel.IsValid);

            // Reset to valid
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.ShapeType), "Rectangle");
            Assert.IsTrue(_preModel.IsValid);

            // Test invalid width
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Width), "0");
            Assert.IsFalse(_preModel.IsValid);

            // Test invalid height
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.Height), "-10");
            Assert.IsFalse(_preModel.IsValid);

            // Test non-numeric value
            _preModel.UpdateProperty(nameof(ShapeInputPreModel.X), "NotANumber");
            Assert.IsFalse(_preModel.IsValid);
        }

        [TestMethod]
        public void TestUpdatePropertyInvalidProperty()
        {
            // Test invalid property name
            _preModel.UpdateProperty("InvalidProperty", "SomeValue");
            // Ensure no changes to the model
            Assert.IsNull(_preModel.ShapeType);
            Assert.IsNull(_preModel.ShapeName);
            Assert.IsNull(_preModel.X);
            Assert.IsNull(_preModel.Y);
            Assert.IsNull(_preModel.Width);
            Assert.IsNull(_preModel.Height);
        }

        [TestMethod]
        public void TestGetShapeDataWithNullValues()
        {
            // Test GetShapeData with null values
            ShapeData shapeData = _preModel.GetShapeData();
            Assert.IsNull(shapeData.ShapeType);
            Assert.IsNull(shapeData.ShapeName);
            Assert.IsNull(shapeData.X);
            Assert.IsNull(shapeData.Y);
            Assert.IsNull(shapeData.Width);
            Assert.IsNull(shapeData.Height);
        }
    }

}