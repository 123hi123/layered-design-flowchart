using Microsoft.VisualStudio.TestTools.UnitTesting;
using 視窗流程圖.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 視窗流程圖.PresentationModels.Tests
{
    [TestClass]
    public class ShapeSelectPreModelTests
    {
        private ShapeSelectPreModel _model;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new ShapeSelectPreModel();
        }

        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(ShapeSelectPreModel.ShapeType.Select, _model.SelectedShapeType);
            Assert.IsFalse(_model.IsCursor);
            Assert.AreEqual(5, _model.ButtonStates.Count);
            Assert.IsTrue(_model.ButtonStates[ShapeSelectPreModel.ShapeType.Select]);
        }
        [TestMethod]
        public void TestUpdateCursorStateWithSelectShape()
        {
            _model.SelectShape(ShapeSelectPreModel.ShapeType.Select);
            bool enterDrawingModeCalled = false;
            bool exitDrawingModeCalled = false;
            _model.EnterDrawingMode += (sender, args) => enterDrawingModeCalled = true;
            _model.ExitDrawingMode += (sender, args) => exitDrawingModeCalled = true;

            _model.UpdateCursorState(true);
            Assert.IsFalse(_model.IsCursor);
            Assert.IsFalse(enterDrawingModeCalled);
            Assert.IsTrue(exitDrawingModeCalled);
        }

        [TestMethod]
        public void TestUpdateCursorStateWithNullEventHandlers()
        {
            // 確保事件處理器為 null 不會導致異常
            _model.SelectShape(ShapeSelectPreModel.ShapeType.Process);
            

            // 這不應拋出異常
            _model.UpdateCursorState(true);
            Assert.IsTrue(_model.IsCursor);

            _model.UpdateCursorState(false);
            Assert.IsFalse(_model.IsCursor);
        }
        [TestMethod]
        public void TestUpdateCursorState()
        {
            bool enterDrawingModeCalled = false;
            bool exitDrawingModeCalled = false;

            _model.EnterDrawingMode += (sender, args) => enterDrawingModeCalled = true;
            _model.ExitDrawingMode += (sender, args) => exitDrawingModeCalled = true;

            // 初始狀態下，UpdateCursorState(true) 不會改變 IsCursor
            _model.UpdateCursorState(true);
            Assert.IsFalse(_model.IsCursor);
            Assert.IsFalse(enterDrawingModeCalled);
            Assert.IsTrue(exitDrawingModeCalled);  // 這裡會觸發 ExitDrawingMode

            exitDrawingModeCalled = false;  // 重置標誌

            // 選擇非 Select 的形狀
            _model.SelectShape(ShapeSelectPreModel.ShapeType.Process);

            // 現在 UpdateCursorState(true) 會設置 IsCursor 為 true
            _model.UpdateCursorState(true);
            Assert.IsTrue(_model.IsCursor);
            Assert.IsTrue(enterDrawingModeCalled);
            Assert.IsFalse(exitDrawingModeCalled);

            enterDrawingModeCalled = false;  // 重置標誌

            // UpdateCursorState(false) 會設置 IsCursor 為 false
            _model.UpdateCursorState(false);
            Assert.IsFalse(_model.IsCursor);
            Assert.IsFalse(enterDrawingModeCalled);
            Assert.IsTrue(exitDrawingModeCalled);
        }

        [TestMethod]
        public void TestSelectShape()
        {
            bool shapeTypeChangedCalled = false;
            bool normalStateInCalled = false;
            bool drawStateInCalled = false;

            _model.ShapeTypeChanged += (sender, args) => shapeTypeChangedCalled = true;
            _model.NormalStateIn += (sender, args) => normalStateInCalled = true;
            _model.DrawStateIn += (sender, args) => drawStateInCalled = true;

            _model.SelectShape(ShapeSelectPreModel.ShapeType.Process);
            Assert.AreEqual(ShapeSelectPreModel.ShapeType.Process, _model.SelectedShapeType);
            Assert.IsTrue(shapeTypeChangedCalled);
            Assert.IsFalse(normalStateInCalled);
            Assert.IsTrue(drawStateInCalled);
            Assert.IsTrue(_model.ButtonStates[ShapeSelectPreModel.ShapeType.Process]);
            Assert.IsFalse(_model.ButtonStates[ShapeSelectPreModel.ShapeType.Select]);

            shapeTypeChangedCalled = false;
            normalStateInCalled = false;
            drawStateInCalled = false;

            _model.SelectShape(ShapeSelectPreModel.ShapeType.Select);
            Assert.AreEqual(ShapeSelectPreModel.ShapeType.Select, _model.SelectedShapeType);
            Assert.IsTrue(shapeTypeChangedCalled);
            Assert.IsTrue(normalStateInCalled);
            Assert.IsFalse(drawStateInCalled);
            Assert.IsTrue(_model.ButtonStates[ShapeSelectPreModel.ShapeType.Select]);
            Assert.IsFalse(_model.ButtonStates[ShapeSelectPreModel.ShapeType.Process]);
        }
    }
}