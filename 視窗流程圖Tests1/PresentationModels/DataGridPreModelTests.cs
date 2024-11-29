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
    public class DataGridPreModelTests
    {
        private DataGridPreModel _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new DataGridPreModel();
        }

        [TestMethod]
        public void TestHandleDeleteRequest_DeleteButtonClicked_EventTriggered()
        {
            int eventRowIndex = -1;
            _model.DeleteRequested += (sender, rowIndex) => eventRowIndex = rowIndex;

            _model.HandleDeleteRequest(2, 1, 2);

            Assert.AreEqual(1, eventRowIndex);
        }

        [TestMethod]
        public void TestHandleDeleteRequest_DeleteButtonClicked_EventNotTriggered()
        {
            int eventRowIndex = -1;
            _model.DeleteRequested += (sender, rowIndex) => eventRowIndex = rowIndex;

            _model.HandleDeleteRequest(2, 1, 22);

            Assert.AreEqual(-1, eventRowIndex);
        }

        [TestMethod]
        public void TestHandleDeleteRequest_NotDeleteButton_EventNotTriggered()
        {
            bool eventTriggered = false;
            _model.DeleteRequested += (sender, rowIndex) => eventTriggered = true;

            _model.HandleDeleteRequest(1, 1, 2);

            Assert.IsFalse(eventTriggered);
            _model.HandleDeleteRequest(2, -1, 2);

            Assert.IsFalse(eventTriggered);
            _model.HandleDeleteRequest(2, -1, 52);

            Assert.IsFalse(eventTriggered);
        }

        [TestMethod]
        public void TestGetIdFromCellValue_ValidId_ReturnsCorrectId()
        {
            object cellValue = "123";
            int result = _model.GetIdFromCellValue(cellValue);
            Assert.AreEqual(123, result);
        }

        [TestMethod]
        public void TestGetIdFromCellValue_InvalidId_ReturnsNegativeOne()
        {
            object cellValue = "abc";
            int result = _model.GetIdFromCellValue(cellValue);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestGetIdFromCellValue_NullValue_ReturnsNegativeOne()
        {
            object cellValue = null;
            int result = _model.GetIdFromCellValue(cellValue);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestFindRowIndexById_ExistingId_ReturnsCorrectIndex()
        {
            object[] idValues = { 1, 2, 3, 4, 5 };
            int result = _model.FindRowIndexById(idValues, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestFindRowIndexById_NonExistingId_ReturnsNegativeOne()
        {
            object[] idValues = { 1, 2, 3, 4, 5 };
            int result = _model.FindRowIndexById(idValues, 6);
            Assert.AreEqual(-1, result);
        }

    }
}