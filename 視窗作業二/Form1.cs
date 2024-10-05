// Form1.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 視窗作業二.Controllers;

namespace 視窗作業二
{
    public partial class Form1 : Form
    {
        private ShapesController controller;

        public Form1()
        {
            InitializeComponent();
            controller = new ShapesController(this);
        }

        // 調用 Controller 的 AddShape 方法
        private void button_add_new_Click_1(object sender, EventArgs e)
        {
            List<string> shapeData = new List<string>
            {
                comboBox_shape.SelectedItem?.ToString() ?? "",
                textBox_Text.Text,
                textBox_X.Text,
                textBox_Y.Text,
                textBox_Width.Text,
                textBox_Height.Text
            };

            controller.AddShape(shapeData);
        }

        // DataGridView 刪除按鈕點擊事件處理，調用 Controller 的 DeleteShape 方法
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // 檢查是否點擊了 "刪除" 按鈕列
            if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                controller.DeleteShape(e.RowIndex);
            }
        }

        // Controller 用於添加行的方法
        public void AddShapeToGrid(int id, List<string> shapeData)
        {
            dataGridView1.Rows.Add("刪除", id, shapeData[0], shapeData[1], shapeData[2], shapeData[3], shapeData[4], shapeData[5]);
        }

        // Controller 用於移除行的方法
        public void RemoveShapeFromGrid(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
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
            return Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
        }
    }
}