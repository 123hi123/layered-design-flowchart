//using System;
//using System.Collections.Generic;
//using 視窗流程圖.Models;
//using 視窗流程圖.PresentationModels;

//namespace 視窗流程圖.Commands
//{
//    public class DataGridCommand : ICommand
//    {
//        private readonly ShapesController _controller;
//        private readonly int _rowIndex;
//        private readonly string _operation;
//        private readonly ShapeData _shapeData;

//        public DataGridCommand(ShapesController controller, int rowIndex, string operation, List<ShapeData> shapesData)
//        {
//            _controller = controller;
//            _rowIndex = rowIndex;
//            _operation = operation;

//            // 获取对应的 ShapeData
//            _shapeData = new DataGridPreModel().GetShapeDataFromRow(rowIndex, shapesData);
//        }

//        public void Execute()
//        {
//            if (_operation == "Add")
//            {
//                _controller.AddShape(_shapeData);
//            }
//            else if (_operation == "Remove")
//            {
//                _controller.RemoveShape(_rowIndex);
//            }
//        }

//        public void Undo()
//        {
//            if (_operation == "Add")
//            {
//                _controller.RemoveShape(_controller.GetRowIndexByShapeId(_shapeData.Id));
//            }
//            else if (_operation == "Remove")
//            {
//                _controller.AddShape(_shapeData);
//            }
//        }
//    }
//}
