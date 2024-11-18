using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using 視窗流程圖.Controllers;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;  // 引入 Adapter 命名空間


namespace 視窗流程圖
{
    public partial class Form1 : Form
    {
        private ShapesController _controller;
        private ShapesModel _model;
        private ShapeSelectPreModel _shapeSelectPreModel;
        private ShapeInputPreModel _shapeInputPreModel;
        
        public Form1()
        {
            InitializeComponent();
            _model = new ShapesModel();
            
            _shapeSelectPreModel = new ShapeSelectPreModel();
            _shapeInputPreModel = new ShapeInputPreModel();
            
            _controller = new ShapesController(this, _model);// 共用model

            this.MouseDown += (sender, e) => _controller.HandleMouseDown(e);
            this.MouseUp += (sender, e) => _controller.HandleMouseUp(e);
            this.MouseMove += (sender, e) => _controller.HandleMouseMove(e);
            
            this.DoubleBuffered = true;
            // 訂閱 ShapeTypeChanged 事件
            _shapeSelectPreModel.ShapeTypeChanged += ShapeTypeChanged;
            _shapeSelectPreModel.DrawStateIn += DrawStateIn;
            _shapeSelectPreModel.NormalStateIn += NormalStateIn;

            // 綁定 ToolStrip 按鈕的點擊事件
            toolStripButton1.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Start);
            toolStripButton2.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Terminator);
            toolStripButton3.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Process);
            toolStripButton4.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Decision);
            toolStripButton5.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Select);
            comboBox_shape.SelectedIndexChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.ShapeType), comboBox_shape.SelectedItem.ToString());
            textBox_Text.TextChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.ShapeName), textBox_Text.Text);
            textBox_X.TextChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.X), textBox_X.Text);
            textBox_Y.TextChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.Y), textBox_Y.Text);
            textBox_Width.TextChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.Width), textBox_Width.Text);
            textBox_Height.TextChanged += (s, e) => _shapeInputPreModel.UpdateProperty(nameof(_shapeInputPreModel.Height), textBox_Height.Text);
            AddNewShapeButton.DataBindings.Add("Enabled", _shapeInputPreModel, "IsValid");
            UpdateToolStrip();
        }

        public void UpdateShapeInGrid(int id, Shape shape)
        {
            foreach (DataGridViewRow row in ShapeDataGridView.Rows)
            {
                if (Convert.ToInt32(row.Cells["ID"].Value) == id)
                {
                    row.Cells["X"].Value = shape.X;
                    row.Cells["Y"].Value = shape.Y;
                    break;
                }
            }
        }
        public void NormalStateIn(object sender, EventArgs e)
        {
            _controller.SetNormalState();
        }

        public void DrawStateIn(object sender, EventArgs e)
        {
            _controller.SetDrawingState();
        }

        public void IntoSelectMode()
        {
            _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Select);
        }
        private void ShapeTypeChanged(object sender, EventArgs e)
        {
            UpdateToolStrip();
        }

        private void UpdateToolStrip()
        {
            toolStripButton1.Checked = _shapeSelectPreModel.SelectedShapeType == ShapeSelectPreModel.ShapeType.Start;
            toolStripButton2.Checked = _shapeSelectPreModel.SelectedShapeType == ShapeSelectPreModel.ShapeType.Terminator;
            toolStripButton3.Checked = _shapeSelectPreModel.SelectedShapeType == ShapeSelectPreModel.ShapeType.Process;
            toolStripButton4.Checked = _shapeSelectPreModel.SelectedShapeType == ShapeSelectPreModel.ShapeType.Decision;
            toolStripButton5.Checked = _shapeSelectPreModel.SelectedShapeType == ShapeSelectPreModel.ShapeType.Select;
        }
        

        // 使用 OnPaint 來重繪所有的形狀
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 使用 GraphicsAdapter 將 System.Drawing.Graphics 適配為 IGraphics
            var adapter = new GraphicsAdapter(e.Graphics);

            // 清除畫布內容（可選）
            e.Graphics.Clear(this.BackColor);

            // 獲取所有形狀
            var shapes = _model.GetShapes();

            // 檢查是否有形狀
            if (shapes != null && shapes.Count > 0)
            {
                // 繪製所有形狀
                foreach (var shape in shapes)
                {
                    shape.Draw(adapter);  // 使用 IGraphics 進行繪製
                }
            }

            // 向 Controller 請求繪製臨時的形狀
            _controller.RenderTempShape(adapter);
            _controller.RenderTempSlection(adapter);
        }


        // 獲取當前選中的圖形類型
        public string GetSelectedShapeType()
        {
            return _shapeSelectPreModel.SelectedShapeType.ToString();
        }

        // 判斷是否處於繪畫模式（工具列有按鈕被選中，並且當前游標為十字）
        public bool IsDrawingCursor()
        {
            // 判斷當前游標是否是十字形          
            return this.Cursor == Cursors.Cross;
        }

        // 當滑鼠進入控件時，恢復預設游標
        private void ControlMouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        // 當滑鼠離開控件時，檢查是否應該變成十字光標
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            // 檢查當前滑鼠是否在繪畫區，以及是否有工具列按鈕被選中 -> 判斷當前的狀態
            if (_shapeSelectPreModel.SelectedShapeType != ShapeSelectPreModel.ShapeType.Select)
            {
                Cursor = Cursors.Cross;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        // 調用 Controller 的 AddShape 方法
        private void AddNewShapeButtomClick(object sender, EventArgs e)
        {
            _controller.InputShape(_shapeInputPreModel.GetShapeData());
        }

        // DataGridView 刪除按鈕點擊事件處理，調用 Controller 的 DeleteShape 方法
        private void ShapeDataGridViewClick(object sender, DataGridViewCellEventArgs e)
        {
            // 檢查是否點擊了 "刪除" 按鈕列
            if (e.ColumnIndex == ShapeDataGridView.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                _controller.DeleteShape(e.RowIndex);
            }
        }

        // Controller 用於添加行的方法
        public void AddShapeToGrid(int id, ShapeData shapeData)
        {
            ShapeDataGridView.Rows.Add("刪除", id, shapeData.ShapeType, shapeData.ShapeName, shapeData.X, shapeData.Y, shapeData.Height, shapeData.Width);
        }

        // Controller 用於移除行的方法
        public void RemoveShapeFromGrid(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < ShapeDataGridView.Rows.Count)
            {
                ShapeDataGridView.Rows.RemoveAt(rowIndex);
            }
        }

        // 從指定行獲取 ID
        public int GetIdFromRow(int rowIndex)
        {
            if (int.TryParse(ShapeDataGridView.Rows[rowIndex].Cells["ID"].Value?.ToString(), out int id))
            {
                return id;
            }
            else
            {
                return -1; // 或者任何適合的錯誤值
            }
        } 
    }
}