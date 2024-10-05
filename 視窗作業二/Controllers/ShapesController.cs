// Controllers/ShapesController.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 視窗作業二.Models;

namespace 視窗作業二.Controllers
{
    public class ShapesController
    {
        private readonly ShapesModel model;
        private readonly Form1 view;

        public ShapesController(Form1 view)
        {
            this.view = view;
            this.model = new ShapesModel();
        }

        // 添加形狀的方法
        public void AddShape(List<string> shapeData)
        {
            if (model.Valid(shapeData))
            {
                int id = model.AddShape(shapeData);
                view.AddShapeToGrid(id, shapeData);
            }
            else
            {
                view.ShowError("輸入數據有誤，請檢查後重試。");
            }
        }

        // 刪除形狀的方法
        public void DeleteShape(int rowIndex)
        {
            int id = Convert.ToInt32(view.GetIdFromRow(rowIndex));
            model.RemoveShape(id);
            view.RemoveShapeFromGrid(rowIndex);
        }
    }
}