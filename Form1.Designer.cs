﻿using System;

namespace 視窗流程圖
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.textBox_Text = new System.Windows.Forms.TextBox();
            this.comboBox_shape = new System.Windows.Forms.ComboBox();
            this.AddNewShapeButton = new System.Windows.Forms.Button();
            this.ShapeDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShapeSelectToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.ShapeSelectToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Y);
            this.groupBox1.Controls.Add(this.textBox_Height);
            this.groupBox1.Controls.Add(this.textBox_Width);
            this.groupBox1.Controls.Add(this.textBox_X);
            this.groupBox1.Controls.Add(this.textBox_Text);
            this.groupBox1.Controls.Add(this.comboBox_shape);
            this.groupBox1.Controls.Add(this.AddNewShapeButton);
            this.groupBox1.Controls.Add(this.ShapeDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 9F);
            this.groupBox1.Location = new System.Drawing.Point(716, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(383, 538);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            this.groupBox1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.groupBox1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "W";
            this.label5.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "H";
            this.label4.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Y";
            this.label3.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "X";
            this.label2.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "文字";
            this.label1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(225, 46);
            this.textBox_Y.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(32, 22);
            this.textBox_Y.TabIndex = 10;
            this.textBox_Y.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.textBox_Y.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(260, 46);
            this.textBox_Height.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(33, 22);
            this.textBox_Height.TabIndex = 9;
            this.textBox_Height.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.textBox_Height.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(297, 46);
            this.textBox_Width.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(25, 22);
            this.textBox_Width.TabIndex = 8;
            this.textBox_Width.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.textBox_Width.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(196, 46);
            this.textBox_X.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(25, 22);
            this.textBox_X.TabIndex = 7;
            this.textBox_X.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.textBox_X.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(141, 46);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(52, 22);
            this.textBox_Text.TabIndex = 3;
            this.textBox_Text.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.textBox_Text.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // comboBox_shape
            // 
            this.comboBox_shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_shape.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_shape.FormattingEnabled = true;
            this.comboBox_shape.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox_shape.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.comboBox_shape.Location = new System.Drawing.Point(65, 47);
            this.comboBox_shape.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_shape.Name = "comboBox_shape";
            this.comboBox_shape.Size = new System.Drawing.Size(61, 20);
            this.comboBox_shape.TabIndex = 2;
            this.comboBox_shape.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.comboBox_shape.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // AddNewShapeButton
            // 
            this.AddNewShapeButton.AutoEllipsis = true;
            this.AddNewShapeButton.Location = new System.Drawing.Point(4, 16);
            this.AddNewShapeButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddNewShapeButton.Name = "AddNewShapeButton";
            this.AddNewShapeButton.Size = new System.Drawing.Size(56, 50);
            this.AddNewShapeButton.TabIndex = 1;
            this.AddNewShapeButton.Text = "新增";
            this.AddNewShapeButton.UseVisualStyleBackColor = true;
            this.AddNewShapeButton.Click += new System.EventHandler(this.AddNewShapeButtomClick);
            this.AddNewShapeButton.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.AddNewShapeButton.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // ShapeDataGridView
            // 
            this.ShapeDataGridView.AllowUserToAddRows = false;
            this.ShapeDataGridView.AllowUserToDeleteRows = false;
            this.ShapeDataGridView.AllowUserToResizeColumns = false;
            this.ShapeDataGridView.AllowUserToResizeRows = false;
            this.ShapeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ShapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteButton,
            this.ID,
            this.Shape,
            this.Text_grid,
            this.X,
            this.Y,
            this.Length_grid,
            this.Width_grid});
            this.ShapeDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShapeDataGridView.Location = new System.Drawing.Point(2, 80);
            this.ShapeDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ShapeDataGridView.Name = "ShapeDataGridView";
            this.ShapeDataGridView.ReadOnly = true;
            this.ShapeDataGridView.RowHeadersVisible = false;
            this.ShapeDataGridView.RowHeadersWidth = 51;
            this.ShapeDataGridView.RowTemplate.Height = 27;
            this.ShapeDataGridView.Size = new System.Drawing.Size(379, 456);
            this.ShapeDataGridView.TabIndex = 0;
            this.ShapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeDataGridViewClick);
            this.ShapeDataGridView.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.ShapeDataGridView.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "刪除";
            this.DeleteButton.MinimumWidth = 6;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteButton.Width = 54;
            // 
            // ID
            // 
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "形狀";
            this.Shape.MinimumWidth = 6;
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            this.Shape.Width = 54;
            // 
            // Text_grid
            // 
            this.Text_grid.HeaderText = "文字";
            this.Text_grid.MinimumWidth = 6;
            this.Text_grid.Name = "Text_grid";
            this.Text_grid.ReadOnly = true;
            this.Text_grid.Width = 54;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 38;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 38;
            // 
            // Length_grid
            // 
            this.Length_grid.HeaderText = "長";
            this.Length_grid.MinimumWidth = 6;
            this.Length_grid.Name = "Length_grid";
            this.Length_grid.ReadOnly = true;
            this.Length_grid.Width = 42;
            // 
            // Width_grid
            // 
            this.Width_grid.HeaderText = "寬";
            this.Width_grid.MinimumWidth = 6;
            this.Width_grid.Name = "Width_grid";
            this.Width_grid.ReadOnly = true;
            this.Width_grid.Width = 42;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 45);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(158, 562);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.dataGridView2.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 94);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 69);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 94);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.menuStrip1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            this.說明ToolStripMenuItem.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.說明ToolStripMenuItem.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            this.關於ToolStripMenuItem.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.關於ToolStripMenuItem.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // ShapeSelectToolStrip
            // 
            this.ShapeSelectToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ShapeSelectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton7,
            this.toolStripButton8});
            this.ShapeSelectToolStrip.Location = new System.Drawing.Point(0, 24);
            this.ShapeSelectToolStrip.Name = "ShapeSelectToolStrip";
            this.ShapeSelectToolStrip.Size = new System.Drawing.Size(1099, 27);
            this.ShapeSelectToolStrip.TabIndex = 6;
            this.ShapeSelectToolStrip.Text = "toolStrip1";
            this.ShapeSelectToolStrip.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.ShapeSelectToolStrip.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "StartToolStripButton";
            this.toolStripButton1.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.toolStripButton1.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "TerminatorToolStripButton";
            this.toolStripButton2.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.toolStripButton2.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "DecisionToolStripButton";
            this.toolStripButton4.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.toolStripButton4.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "ProcessToolStripButton";
            this.toolStripButton3.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.toolStripButton3.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.Undo);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.Redo);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 607);
            this.Controls.Add(this.ShapeSelectToolStrip);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ShapeSelectToolStrip.ResumeLayout(false);
            this.ShapeSelectToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.ComboBox comboBox_shape;
        private System.Windows.Forms.Button AddNewShapeButton;
        private System.Windows.Forms.DataGridView ShapeDataGridView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width_grid;
        private System.Windows.Forms.ToolStrip ShapeSelectToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

