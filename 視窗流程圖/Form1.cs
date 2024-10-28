using System;
using System.Drawing;
using System.Windows.Forms;
using 視窗流程圖.Controllers;
using 視窗流程圖.Models;

namespace 視窗流程圖
{
    public partial class Form1 : Form
    {
        private ShapesController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new ShapesController(this);
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
            return Convert.ToInt32(ShapeDataGridView.Rows[rowIndex].Cells["ID"].Value);
        }

        // 重置所有 Toolbar 按鈕的 Checked 屬性為 false
        private void ResetToolbarCheckedState()
        {
            toolStripButton1.Checked = false; // Start 對應的按鈕
            toolStripButton2.Checked = false; // Terminator 對應的按鈕
            toolStripButton3.Checked = false; // Process 對應的按鈕
            toolStripButton4.Checked = false; // Decision 對應的按鈕
        }

        // 當按下 Start 按鈕時
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

        // 當滑鼠進入窗體且不在已知UI控件上時，將游標設為十字形
        // 繪畫區的邊界，根據你提供的數值
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            // 檢查滑鼠當前位置是否在任何控件上
            Control hoveredControl = GetChildAtPoint(e.Location);

            // 如果滑鼠不在任何控件上，並且工具列按鈕有一個是選中的，那麼改為十字光標
            if (hoveredControl == null &&
                (toolStripButton1.Checked || toolStripButton2.Checked || toolStripButton3.Checked || toolStripButton4.Checked))
            {
                Cursor = Cursors.Cross; // 沒有碰到控件，認為進入繪畫區，游標變成十字
            }
            else
            {
                Cursor = Cursors.Default; // 碰到控件，恢復預設的游標
            }
        }
    }
}