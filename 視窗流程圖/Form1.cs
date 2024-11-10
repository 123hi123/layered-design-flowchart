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
        // 綁定滑鼠事件
        
        public Form1()
        {
            InitializeComponent();
            _model = new ShapesModel();
            this.MouseDown += (sender, e) => _controller.HandleMouseDown(e);
            this.MouseUp += (sender, e) => _controller.HandleMouseUp(e);
            this.MouseMove += (sender, e) => _controller.HandleMouseMove(e);
            _model.ReRenderSign += ReRenderSign; // 綁定模型的 ShapeAdded 
            this.DoubleBuffered = true;
            _controller = new ShapesController(this, _model);
            
        }

        // 重繪所有形狀(當模型有變更時)
        public void ReRenderSign()
        {
            this.Invalidate(); // 觸發 OnPaint 進行重繪
        }

        // 使用 OnPaint 來重繪所有的形狀
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 使用 GraphicsAdapter 將 System.Drawing.Graphics 適配為 IGraphics
            var adapter = new GraphicsAdapter(e.Graphics);

            // 清除畫布內容（可選）
            e.Graphics.Clear(this.BackColor);

            // 繪製所有形狀
            foreach (var shape in _model.GetShapes())
            {
                shape.Draw(adapter);  // 使用 IGraphics 進行繪製
            }

            // 向 Controller 請求繪製臨時的形狀
            _controller.RenderTempShape(adapter);  // 使用 IGraphics 進行繪製
        }

        // 獲取當前選中的圖形類型
        public string GetSelectedShapeType()
        {
            if (toolStripButton1.Checked) return "Start";
            if (toolStripButton2.Checked) return "Terminator";
            if (toolStripButton3.Checked) return "Process";
            if (toolStripButton4.Checked) return "Decision";
            return string.Empty;
        }

        // 判斷是否處於繪畫模式（工具列有按鈕被選中，並且當前游標為十字）
        public bool IsDrawingMode()
        {
            // 判斷當前游標是否是十字形
            bool isCursorCross = this.Cursor == Cursors.Cross;

            // 判斷是否有工具列的按鈕被選中
            bool isAnyButtonChecked = toolStripButton1.Checked || toolStripButton2.Checked || toolStripButton3.Checked || toolStripButton4.Checked;

            // 只有游標為十字形且有按鈕被選中時，才處於繪畫模式
            return isCursorCross && isAnyButtonChecked;
        }

        // 當滑鼠進入控件時，恢復預設游標
        private void ControlMouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        // 當滑鼠離開控件時，檢查是否應該變成十字光標
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            // 檢查當前滑鼠是否在繪畫區，以及是否有工具列按鈕被選中
            if (toolStripButton1.Checked || toolStripButton2.Checked || toolStripButton3.Checked || toolStripButton4.Checked)
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
            ShapeData shapeData = new ShapeData
            {
                ShapeType = comboBox_shape.SelectedItem?.ToString() ?? "",
                ShapeName = textBox_Text.Text,
                X = textBox_X.Text,
                Y = textBox_Y.Text,
                Width = textBox_Width.Text,
                Height = textBox_Height.Text
            };

            _controller.InputShape(shapeData);
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
            ShapeDataGridView.Rows.Add("刪除", id, shapeData.ShapeType, shapeData.ShapeName, shapeData.X, shapeData.Y, shapeData.Width, shapeData.Height);
        }

        // Controller 用於移除行的方法
        public void RemoveShapeFromGrid(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < ShapeDataGridView.Rows.Count)
            {
                ShapeDataGridView.Rows.RemoveAt(rowIndex);
            }
        }

        // Controller 用於顯示錯誤訊息的方法
        public void ShowError(string message)
        {
            MessageBox.Show(message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ShowError("ID 格式無效");
                return -1; // 或者任何適合的錯誤值
            }
        }

        // 重置所有 Toolbar 按鈕的 Checked 屬性為 false
        public void ResetToolbarCheckedState()
        {
            toolStripButton1.Checked = false; // Start 對應的按鈕
            toolStripButton2.Checked = false; // Terminator 對應的按鈕
            toolStripButton3.Checked = false; // Process 對應的按鈕
            toolStripButton4.Checked = false; // Decision 對應的按鈕
        }

        // 當按下形狀按鈕時
        private void StartToolStripButtonClick(object sender, EventArgs e)
        {
            if (toolStripButton1.Checked)
            {
                // 如果按鈕已經選中，點擊後取消所有按鈕的選中狀態
                ResetToolbarCheckedState();
            }
            else
            {
                // 如果按鈕未被選中，重置其他按鈕，並選中當前按鈕
                ResetToolbarCheckedState();
                toolStripButton1.Checked = true;
            }
        }

        private void TerminatorToolStripButtonClick(object sender, EventArgs e)
        {
            if (toolStripButton2.Checked)
            {
                ResetToolbarCheckedState(); // 如果按鈕已經被選中，點擊後取消所有按鈕的選中狀態
            }
            else
            {
                ResetToolbarCheckedState(); // 重置其他按鈕
                toolStripButton2.Checked = true; // 選中當前按鈕
            }
        }

        private void ProcessToolStripButtonClick(object sender, EventArgs e)
        {
            if (toolStripButton3.Checked)
            {
                ResetToolbarCheckedState(); // 如果按鈕已經被選中，點擊後取消所有按鈕的選中狀態
            }
            else
            {
                ResetToolbarCheckedState(); // 重置其他按鈕
                toolStripButton3.Checked = true; // 選中當前按鈕
            }
        }

        private void DecisionToolStripButtonClick(object sender, EventArgs e)
        {
            if (toolStripButton4.Checked)
            {
                ResetToolbarCheckedState(); // 如果按鈕已經被選中，點擊後取消所有按鈕的選中狀態
            }
            else
            {
                ResetToolbarCheckedState(); // 重置其他按鈕
                toolStripButton4.Checked = true; // 選中當前按鈕
            }
        }

        private void SelectToolStripButtonClick(object sender, EventArgs e)
        {
            
        }
    }
}