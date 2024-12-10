﻿using System;
using System.Drawing;
using System.Windows.Forms;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;  // 引入 Adapter 命名空間
using 視窗流程圖.States;
using 視窗流程圖.Commands;


namespace 視窗流程圖.Controllers
{
    public class ShapesController
    {
        private readonly ShapesModel _model;
        private IState _currentState;
        private readonly Form1 _view;

        public ShapesController(Form1 view, ShapesModel model)
        {
            this._view = view;
            this._model = model;  // 使用外部傳入的 Model，而不是創建新的
            SetNormalState();
            _model.ReRenderSign += ReRenderSign; // 綁定模型的 ShapeAdded 
        }
        public void SetNormalState()
        {
            _currentState = new NormalState();
            _currentState.SetModel(_model);
        }
        public void SetDrawingLineState()
        {
            _currentState = new DrawingLineState();
            _currentState.SetModel(_model);
        }

        public void SetDrawingState()
        {
            _currentState = new DrawingState();
            _currentState.SetModel(_model);
        }
        public void ReRenderSign()
        {
            _view.Invalidate();
        }
        public void HandleMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _currentState.MouseDown(e.Location.X, e.Location.Y, _view.IsDrawingCursor());                
            }
            _view.Invalidate();
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            _currentState.MouseMove(e.Location.X, e.Location.Y);
            _view.Invalidate();  // 這裡會重新執行 OnPaint，進而調用我們的 RenderTempShape
        }

        // 處理滑鼠是否繪畫完成？
        public void HandleMouseUp(MouseEventArgs e)
        {
            // 有圖形，先算圖形再把圖形的內容重置 不過目前的實現方法不是很好
            if (e.Button == MouseButtons.Left && _currentState.StartPoint.HasValue && _currentState.CurrentPoint.HasValue && _currentState.CurrentPoint!=_currentState.StartPoint)
            {
                // 通過模型計算圖形數據
                ShapeData shapeData = _model.CalculateShapeData(_currentState.StartPoint.Value, _currentState.CurrentPoint.Value, _view.GetSelectedShapeType());
                _model.AddShapeByShapeData(shapeData);
            }
            _view.Cursor = Cursors.Default;
            _currentState.MouseUp(e.Location.X, e.Location.Y);
        }

        // 使用 IGraphics 處理臨時形狀的繪製
        public void RenderTempShape(IGraphics g)
        {
            if (_currentState.StartPoint.HasValue && _currentState.CurrentPoint.HasValue && _view.GetSelectedShapeType() != "Select")
            {
                // 計算臨時形狀數據
                ShapeData tempShapeData = _model.CalculateShapeData(_currentState.StartPoint.Value, _currentState.CurrentPoint.Value, _view.GetSelectedShapeType());

                // 創建臨時形狀並進行繪製
                Shape tempShape = Factories.ShapeFactory.CreateShape(tempShapeData);
                tempShape?.Draw(g); // 使用 IGraphics 進行繪製
            }
        }
        public void RenderTempLine(IGraphics g)
        {
            if (_currentState.TempStart.HasValue && _currentState.TempEnd.HasValue)
            {
                g.DrawLine(_currentState.TempStart.Value.X, _currentState.TempStart.Value.Y, _currentState.TempEnd.Value.X, _currentState.TempEnd.Value.Y);
            }
            if (_currentState.TouchedPoint.HasValue)
            {
                g.DrawLineRedDot(_currentState.TouchedPoint.Value.X, _currentState.TouchedPoint.Value.Y);
            }
        }
        public void RenderTempSlection(IGraphics g)
        {
            if (_currentState.SelectedShape != null)
            {
                Shape shape = _currentState.SelectedShape;
                if (_currentState.DrawingFrameType == "Normal")
                {
                    g.DrawSelectionFrame(shape.X, shape.Y, shape.Width, shape.Height);
                    g.DrawTextWithRedFrame(shape.TextX, shape.TextY, shape.ShapeName);
                }
                else if (_currentState.DrawingFrameType == "DrawingLine")
                {
                    g.DrawLineSelectionFrame(shape.X, shape.Y, shape.Width, shape.Height);
                }
            }
        }

        // 添加輸入形狀的方法
        public void InputShape(ShapeData shapeData)
        {
            _model.AddShapeByShapeData(shapeData);
        }

        // 刪除形狀的方法
        public void DeleteShape(int rowIndex)
        {
            int id = Convert.ToInt32(_view.GetIdFromRow(rowIndex));
            _model.RemoveShapeCommand(id); // to command
        }
        public void DeleteLine(int rowIndex)
        {
            int id = Convert.ToInt32(_view.GetIdFromRow(rowIndex));
            _model.RemoveLineCommand(id);
        }

        // 根據 rowIndex 獲取 Shape
        public Shape GetShapeByRowIndex(int rowIndex)
        {
            int id = _view.GetIdFromRow(rowIndex);
            return _model.GetShape(id);
        }
    }
}
