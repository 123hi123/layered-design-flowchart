using System;
using System.Drawing;
using System.Windows.Forms;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;  // 引入 Adapter 命名空間
using 視窗流程圖.States;

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
            
            if (e.Button == MouseButtons.Left && _currentState.StartPoint.HasValue && _currentState.CurrentPoint.HasValue && _currentState.CurrentPoint!=_currentState.StartPoint)
            {
                // 通過模型計算圖形數據
                ShapeData shapeData = _model.CalculateShapeData(_currentState.StartPoint.Value, _currentState.CurrentPoint.Value, _view.GetSelectedShapeType());
                int id = _model.AddShape(shapeData);

                _view.AddShapeToGrid(id, shapeData);

                // 重置狀態
                _view.Cursor = Cursors.Default;

                _view.IntoSelectMode();
            }
            if (e.Button == MouseButtons.Left && _currentState.SelectedIndex>-1)
            {
                _view.UpdateShapeInGrid(_currentState.SelectedIndex, _currentState.SelectedShape);
            }
            _currentState.MouseUp();
        }

        // 使用 IGraphics 處理臨時形狀的繪製
        public void RenderTempShape(IGraphics g)
        {
            if (_currentState.StartPoint.HasValue && _currentState.CurrentPoint.HasValue && _view.GetSelectedShapeType()!="Select")
            {
                // 計算臨時形狀數據
                ShapeData tempShapeData = _model.CalculateShapeData(_currentState.StartPoint.Value, _currentState.CurrentPoint.Value, _view.GetSelectedShapeType());

                // 創建臨時形狀並進行繪製
                Shape tempShape = Factories.ShapeFactory.CreateShape(tempShapeData);
                tempShape?.Draw(g); // 使用 IGraphics 進行繪製
            }
        }
        public void RenderTempSlection(IGraphics g)
        {
            if (_currentState.SelectedShape!=null)
            {
                Shape shape = _currentState.SelectedShape;
                g.DrawSelectionFrame(shape.X, shape.Y, shape.Width, shape.Height);
            }
        }

        // 添加輸入形狀的方法
        public void InputShape(ShapeData shapeData)
        {
            int id = _model.AddShape(shapeData);
            _view.AddShapeToGrid(id, shapeData);
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