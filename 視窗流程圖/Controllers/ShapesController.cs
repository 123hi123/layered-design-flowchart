using System;
using System.Drawing;
using System.Windows.Forms;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;  // 引入 Adapter 命名空間

namespace 視窗流程圖.Controllers
{
    public class ShapesController
    {
        private readonly ShapesModel _model;
        private readonly Form1 _view;
        private Point2D? _startPoint; // 用於記錄起始點 (改為 Point2D)
        private Point2D? _currentPoint;   // 用於記錄當前滑鼠位置
        private bool _isDrawing = false; // 用於記錄是否正在繪製

        public ShapesController(Form1 view, ShapesModel model)
        {
            this._view = view;
            this._model = model;  // 使用外部傳入的 Model，而不是創建新的
        }

        // 處理滑鼠是否正在繪畫？(沒有問題了)
        public void HandleMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _view.IsDrawingMode())
            {
                // 將 System.Drawing.Point 轉換為 Point2D
                _startPoint = new Point2D(e.Location.X, e.Location.Y);
                _currentPoint = new Point2D(e.Location.X, e.Location.Y); // 初始當前點設為起始點
                _isDrawing = true;          // 標記正在繪製
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if (_isDrawing)
            {
                // 更新當前滑鼠位置
                _currentPoint = new Point2D(e.Location.X, e.Location.Y);

                // 觸發 View 重繪
                _view.Invalidate();  // 這裡會重新執行 OnPaint，進而調用我們的 RenderTempShape
            }
        }

        // 處理滑鼠是否繪畫完成？
        public void HandleMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isDrawing)
            {
                _isDrawing = false;
                Point2D endPoint = new Point2D(e.Location.X, e.Location.Y);

                // 通過模型計算圖形數據
                ShapeData shapeData = _model.CalculateShapeData(_startPoint.Value, endPoint, _view.GetSelectedShapeType());
                int id = _model.AddShape(shapeData);

                _view.AddShapeToGrid(id, shapeData);

                // 重置狀態
                _startPoint = null;
                _view.Cursor = Cursors.Default;
                _view.ResetToolbarCheckedState(); // 重置工具列狀態
            }
        }

        // 使用 IGraphics 處理臨時形狀的繪製
        public void RenderTempShape(IGraphics g)
        {
            if (_isDrawing && _startPoint.HasValue && _currentPoint.HasValue)
            {
                // 計算臨時形狀數據
                ShapeData tempShapeData = _model.CalculateShapeData(_startPoint.Value, _currentPoint.Value, _view.GetSelectedShapeType());

                // 創建臨時形狀並進行繪製
                Shape tempShape = Factories.ShapeFactory.CreateShape(tempShapeData);
                tempShape?.Draw(g); // 使用 IGraphics 進行繪製
            }
        }

        // 添加輸入形狀的方法
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