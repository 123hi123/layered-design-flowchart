using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 視窗流程圖.Models;

namespace 視窗流程圖.Controllers
{
    public class ShapesController
    {
        private readonly ShapesModel _model;
        private readonly Form1 _view;

        public ShapesController(Form1 view)
        {
            this._view = view;
            this._model = new ShapesModel();
        }

        // 添加形狀的方法
        public void InputShape(ShapeData shapeData)
        {
            if (_model.Valid(shapeData))
            {
                int id = _model.AddShape(shapeData);
                _view.AddShapeToGrid(id, shapeData);
            }
            else
            {
                _view.ShowError("輸入數據有誤，請檢查後重試。");
            }
        }

        // 刪除形狀的方法
        public void DeleteShape(int rowIndex)
        {
            int id = Convert.ToInt32(_view.GetIdFromRow(rowIndex));
            _model.RemoveShape(id);
            _view.RemoveShapeFromGrid(rowIndex);
        }
    }
}