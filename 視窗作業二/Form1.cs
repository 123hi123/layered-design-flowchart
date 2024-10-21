using System;
using System.Windows.Forms;
using 視窗作業二.Controllers;
using 視窗作業二.Models;

namespace 視窗作業二
{
    public partial class Form1 : Form
    {
        private ShapesController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new ShapesController(this);
        }

        // 調用 Controller 的 AddShape 方法
        private void button_add_new_Click_1(object sender, EventArgs e)
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
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // 檢查是否點擊了 "刪除" 按鈕列
            if (e.ColumnIndex == dataGridView.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                _controller.DeleteShape(e.RowIndex);
            }
        }

        // Controller 用於添加行的方法
        public void AddShapeToGrid(int id, ShapeData shapeData)
        {
            dataGridView.Rows.Add("刪除", id, shapeData.ShapeType, shapeData.ShapeName, shapeData.X, shapeData.Y, shapeData.Width, shapeData.Height);
        }

        // Controller 用於移除行的方法
        public void RemoveShapeFromGrid(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count)
            {
                dataGridView.Rows.RemoveAt(rowIndex);
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
            return Convert.ToInt32(dataGridView.Rows[rowIndex].Cells["ID"].Value);
        }
    }
}