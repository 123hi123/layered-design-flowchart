﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using 視窗流程圖.Controllers;
using 視窗流程圖.Models;
using 視窗流程圖.Adapter;
using 視窗流程圖.PresentationModels;
using 視窗流程圖.Commands;

namespace 視窗流程圖
{
    public partial class Form1 : Form
    {
        private ShapesController _controller;
        private ShapesModel _model;
        private ShapeSelectPreModel _shapeSelectPreModel;
        private ShapeInputPreModel _shapeInputPreModel;
        private DataGridPreModel _dataGridPreModel;
        private Label _shapeInputPreModelDisplay;
        private CommandManager _commandHistory;
        private TextEditPreModel _textEditPreModel;
        private UpdatePreModel _updatePreModel;


        public Form1()
        {
            InitializeComponent();
            _model = new ShapesModel();
            this.DoubleBuffered = true;
            _shapeSelectPreModel = new ShapeSelectPreModel();
            _shapeInputPreModel = new ShapeInputPreModel();
            _dataGridPreModel = new DataGridPreModel();
            _commandHistory = new CommandManager();
            _controller = new ShapesController(this, _model, _commandHistory);
            _textEditPreModel = new TextEditPreModel();
            _updatePreModel = new UpdatePreModel();
            _updatePreModel.AddNewRowEvent += AddNewRowToDataGridView;
            _updatePreModel.UpdateExistingRowEvent += UpdateExistingRowInDataGridView;

            // 綁定 ShapeUpdated 事件
            //_textEditPreModel.ShapeUpdated += (id, shape) => UpdateShapeInGrid(id, shape);
            _model.IntoSelectionSign += IntoSelectMode;


            InitializeShapeInputPreModelDisplay();
            SetupEventHandlers();
            SetupDataBindings();
            UpdateToolStrip();
            UpdateShapeInputPreModelDisplay();

            // Bind label colors to their respective validation properties
            Binding binding1 = new Binding("ForeColor", _shapeInputPreModel, "NameValid", true);
            binding1.Format += (s, e) => {
                e.Value = (bool)e.Value ? Color.Black : Color.Red;
            };
            label1.DataBindings.Add(binding1);

            Binding binding2 = new Binding("ForeColor", _shapeInputPreModel, "XValid", true);
            binding2.Format += (s, e) => {
                e.Value = (bool)e.Value ? Color.Black : Color.Red;
            };
            label2.DataBindings.Add(binding2);

            Binding binding3 = new Binding("ForeColor", _shapeInputPreModel, "YValid", true);
            binding3.Format += (s, e) => {
                e.Value = (bool)e.Value ? Color.Black : Color.Red;
            };
            label3.DataBindings.Add(binding3);

            Binding binding4 = new Binding("ForeColor", _shapeInputPreModel, "HeightValid", true);
            binding4.Format += (s, e) => {
                e.Value = (bool)e.Value ? Color.Black : Color.Red;
            };
            label4.DataBindings.Add(binding4);

            Binding binding5 = new Binding("ForeColor", _shapeInputPreModel, "WidthValid", true);
            binding5.Format += (s, e) => {
                e.Value = (bool)e.Value ? Color.Black : Color.Red;
            };
            label5.DataBindings.Add(binding5);

            // Subscribe to the DoubleClickOnTextEvent
            _model.DoubleClickOnTextEvent += HandleDoubleClickOnText;
        }

        private void InitializeShapeInputPreModelDisplay()
        {
            _shapeInputPreModelDisplay = new Label
            {
                AutoSize = true,
                Location = new Point(100, 400),
                Name = "shapeInputPreModelDisplay",
                Size = new Size(300, 20),
                TabIndex = 20,
                Visible = false
            };

            this.Controls.Add(_shapeInputPreModelDisplay);
        }

        private void SetupEventHandlers()
        {
            this.MouseDown += (sender, e) => _controller.HandleMouseDown(e);
            this.MouseUp += (sender, e) => _controller.HandleMouseUp(e);
            this.MouseMove += (sender, e) => _controller.HandleMouseMove(e);

            _shapeSelectPreModel.ShapeTypeChanged += ShapeTypeChanged;
            _shapeSelectPreModel.DrawStateIn += DrawStateIn;
            _shapeSelectPreModel.NormalStateIn += NormalStateIn;
            _shapeSelectPreModel.DrawLineStateIn += DrawLineStateIn;

            _dataGridPreModel.DeleteShapeRequested += (sender, rowIndex) => _controller.DeleteShape(rowIndex);
            _dataGridPreModel.DeleteLineRequested += (sender, rowIndex) => _controller.DeleteLine(rowIndex);

            _shapeSelectPreModel.EnterDrawingMode += (sender, args) => SetDrawingCursor();
            _shapeSelectPreModel.ExitDrawingMode += (sender, args) => SetDefaultCursor();

            toolStripButton1.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Start);
            toolStripButton2.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Terminator);
            toolStripButton3.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Process);
            toolStripButton4.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Decision);
            toolStripButton5.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.Select);
            toolStripButton6.Click += (sender, e) => _shapeSelectPreModel.SelectShape(ShapeSelectPreModel.ShapeType.DrawLine);

            comboBox_shape.SelectedIndexChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.ShapeType), comboBox_shape.SelectedItem?.ToString());
            textBox_Text.TextChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.ShapeName), textBox_Text.Text);
            textBox_X.TextChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.X), textBox_X.Text);
            textBox_Y.TextChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.Y), textBox_Y.Text);
            textBox_Width.TextChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.Width), textBox_Width.Text);
            textBox_Height.TextChanged += (s, e) => UpdateShapeInputPreModel(nameof(_shapeInputPreModel.Height), textBox_Height.Text);

            _shapeInputPreModel.PropertyChanged += (s, e) => UpdateShapeInputPreModelDisplay();
        }

        private void AddNewRowToDataGridView(object[] data)
        {
            ShapeDataGridView.Rows.Add(data);
        }

        private void UpdateExistingRowInDataGridView(int rowIndex, object[] data)
        {
            for (int i = 0; i < data.Length && i < ShapeDataGridView.Columns.Count; i++)
            {
                ShapeDataGridView.Rows[rowIndex].Cells[i].Value = data[i];
            }
        }
        private void SetupDataBindings()
        {
            AddNewShapeButton.DataBindings.Clear();
            AddNewShapeButton.DataBindings.Add("Enabled", _shapeInputPreModel, "IsValid", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void UpdateShapeInputPreModel(string propertyName, string value)
        {
            _shapeInputPreModel.UpdateProperty(propertyName, value);
        }

        private void UpdateShapeInputPreModelDisplay()
        {
            _shapeInputPreModelDisplay.Text = $"ShapeType: {_shapeInputPreModel.ShapeType}, " +
                                              $"ShapeName: {_shapeInputPreModel.ShapeName}, " +
                                              $"X: {_shapeInputPreModel.X}, " +
                                              $"Y: {_shapeInputPreModel.Y}, " +
                                              $"Width: {_shapeInputPreModel.Width}, " +
                                              $"Height: {_shapeInputPreModel.Height}, " +
                                              $"ButtonEnabled: {AddNewShapeButton.Enabled}, " +
                                              $"IsValid: {_shapeInputPreModel.IsValid}";
        }

        public void NormalStateIn(object sender, EventArgs e)
        {
            _controller.SetNormalState();
        }

        public void DrawStateIn(object sender, EventArgs e)
        {
            _controller.SetDrawingState();
        }
        public void DrawLineStateIn(object sender, EventArgs e)
        {
            _controller.SetDrawingLineState();
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
            toolStripButton1.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.Start];
            toolStripButton2.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.Terminator];
            toolStripButton3.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.Process];
            toolStripButton4.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.Decision];
            toolStripButton5.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.Select];
            toolStripButton6.Checked = _shapeSelectPreModel.ButtonStates[ShapeSelectPreModel.ShapeType.DrawLine];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var adapter = new GraphicsAdapter(e.Graphics);
            e.Graphics.Clear(this.BackColor);

            var shapes = _model.GetShapesWithIds();
            var lines = _model.GetLinesWithIds();
            object[] ids = new object[ShapeDataGridView.Rows.Count];
            for (int i = 0; i < ShapeDataGridView.Rows.Count; i++)
            {
                ids[i] = ShapeDataGridView.Rows[i].Cells["ID"].Value;
            }
            foreach (var kvp in shapes)
            {
                int id = kvp.Key;
                Shape shape = kvp.Value;
                shape.UpdateTextWidth(adapter);
                shape.Draw(adapter);
                int rowIndex = _dataGridPreModel.FindRowIndexById(ids, id);
                _updatePreModel.ProcessShapeData(rowIndex, id, shape);
            }
            foreach (var kvp in lines)
            {
                int id = kvp.Key;
                Line line = kvp.Value;
                line.Draw(adapter);
                int rowIndex = _dataGridPreModel.FindRowIndexById(ids, id);
                _updatePreModel.ProcessLineData(rowIndex, id, line);
            }

            _controller.RenderTempShape(adapter);
            _controller.RenderTempSlection(adapter);
            _controller.RenderTempLine(adapter);
        }

        public string GetSelectedShapeType()
        {
            return _shapeSelectPreModel.SelectedShapeType.ToString();
        }

        public bool IsDrawingCursor()
        {
            return _shapeSelectPreModel.IsCursor;
        }

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            _shapeSelectPreModel.UpdateCursorState(false);
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            _shapeSelectPreModel.UpdateCursorState(true);
        }

        private void SetDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }

        private void SetDrawingCursor()
        {
            this.Cursor = Cursors.Cross;
        }

        private void AddNewShapeButtomClick(object sender, EventArgs e)
        {
            _controller.InputShape(_shapeInputPreModel.GetShapeData());
        }

        private void ShapeDataGridViewClick(object sender, DataGridViewCellEventArgs e)
        {
            int deleteButtonColumnIndex = ShapeDataGridView.Columns["DeleteButton"].Index;
            _dataGridPreModel.HandleDeleteRequest(e.ColumnIndex, e.RowIndex, deleteButtonColumnIndex, ShapeDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        public void RemoveFromGrid(int rowIndex)
        {
            ShapeDataGridView.Rows.RemoveAt(rowIndex);
            //object[] row = new object[ShapeDataGridView.ColumnCount];
            //for (int i = 0; i < ShapeDataGridView.ColumnCount; i++)
            //{
            //    row[i] = ShapeDataGridView.Rows[rowIndex].Cells[i].Value;
            //}
            //int id = Convert.ToInt32(row[1]);
            //ShapeData delShapeData = new ShapeData { ShapeType = row[2].ToString(), ShapeName = row[3].ToString(), X = row[4].ToString(), Y = row[5].ToString(), Width = row[6].ToString(), Height = row[7].ToString() };

        }

        public int GetIdFromRow(int rowIndex)
        {
            object cellValue = ShapeDataGridView.Rows[rowIndex].Cells["ID"].Value;
            return _dataGridPreModel.GetIdFromCellValue(cellValue);
        }

        public void Undo(object sender, EventArgs e)
        {
            _commandHistory.Undo();
        }

        public void Redo(object sender, EventArgs e)
        {
            _commandHistory.Redo();
        }

        private void HandleDoubleClickOnText(int id, Shape shape)
        {
            string originalText = shape.ShapeName;
            using (var form = new TextEditForm(originalText))
            {
                form.TextConfirmedOk += (newText) => _textEditPreModel.UpdateShapeName(id, shape, newText);
                form.ShowDialog();
            }
        }
    }
}
