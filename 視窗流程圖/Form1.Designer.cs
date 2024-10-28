using System;

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
            this.AddNewShapeButtom = new System.Windows.Forms.Button();
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
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
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
            this.groupBox1.Controls.Add(this.AddNewShapeButtom);
            this.groupBox1.Controls.Add(this.ShapeDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 9F);
            this.groupBox1.Location = new System.Drawing.Point(954, 86);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(511, 673);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "文字";
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(300, 58);
            this.textBox_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(41, 25);
            this.textBox_Y.TabIndex = 10;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(347, 58);
            this.textBox_Height.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(43, 25);
            this.textBox_Height.TabIndex = 9;
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(396, 58);
            this.textBox_Width.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(32, 25);
            this.textBox_Width.TabIndex = 8;
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(261, 58);
            this.textBox_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(32, 25);
            this.textBox_X.TabIndex = 7;
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(188, 58);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(68, 25);
            this.textBox_Text.TabIndex = 3;
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
            this.comboBox_shape.Location = new System.Drawing.Point(87, 59);
            this.comboBox_shape.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_shape.Name = "comboBox_shape";
            this.comboBox_shape.Size = new System.Drawing.Size(80, 23);
            this.comboBox_shape.TabIndex = 2;
            // 
            // AddNewShapeButtom
            // 
            this.AddNewShapeButtom.AutoEllipsis = true;
            this.AddNewShapeButtom.Location = new System.Drawing.Point(5, 20);
            this.AddNewShapeButtom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddNewShapeButtom.Name = "AddNewShapeButtom";
            this.AddNewShapeButtom.Size = new System.Drawing.Size(75, 62);
            this.AddNewShapeButtom.TabIndex = 1;
            this.AddNewShapeButtom.Text = "新增";
            this.AddNewShapeButtom.UseVisualStyleBackColor = true;
            this.AddNewShapeButtom.Click += new System.EventHandler(this.AddNewShapeButtomClick);
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
            this.ShapeDataGridView.Location = new System.Drawing.Point(3, 101);
            this.ShapeDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShapeDataGridView.Name = "ShapeDataGridView";
            this.ShapeDataGridView.ReadOnly = true;
            this.ShapeDataGridView.RowHeadersVisible = false;
            this.ShapeDataGridView.RowHeadersWidth = 51;
            this.ShapeDataGridView.RowTemplate.Height = 27;
            this.ShapeDataGridView.Size = new System.Drawing.Size(505, 570);
            this.ShapeDataGridView.TabIndex = 0;
            this.ShapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeDataGridViewClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "刪除";
            this.DeleteButton.MinimumWidth = 6;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteButton.Width = 66;
            // 
            // ID
            // 
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 51;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "形狀";
            this.Shape.MinimumWidth = 6;
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            this.Shape.Width = 66;
            // 
            // Text_grid
            // 
            this.Text_grid.HeaderText = "文字";
            this.Text_grid.MinimumWidth = 6;
            this.Text_grid.Name = "Text_grid";
            this.Text_grid.ReadOnly = true;
            this.Text_grid.Width = 66;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 46;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 46;
            // 
            // Length_grid
            // 
            this.Length_grid.HeaderText = "長";
            this.Length_grid.MinimumWidth = 6;
            this.Length_grid.Name = "Length_grid";
            this.Length_grid.ReadOnly = true;
            this.Length_grid.Width = 51;
            // 
            // Width_grid
            // 
            this.Width_grid.HeaderText = "寬";
            this.Width_grid.MinimumWidth = 6;
            this.Width_grid.Name = "Width_grid";
            this.Width_grid.ReadOnly = true;
            this.Width_grid.Width = 51;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 56);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(211, 703);
            this.dataGridView2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 208);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 118);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 86);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 118);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1465, 30);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // ShapeSelectToolStrip
            // 
            this.ShapeSelectToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ShapeSelectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.ShapeSelectToolStrip.Location = new System.Drawing.Point(0, 30);
            this.ShapeSelectToolStrip.Name = "ShapeSelectToolStrip";
            this.ShapeSelectToolStrip.Size = new System.Drawing.Size(1465, 31);
            this.ShapeSelectToolStrip.TabIndex = 6;
            this.ShapeSelectToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "StartToolStripButton";
            this.toolStripButton1.Click += new System.EventHandler(this.StartToolStripButtonClick);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton2.Text = "TerminatorToolStripButton";
            this.toolStripButton2.Click += new System.EventHandler(this.TerminatorToolStripButtonClick);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton3.Text = "ProcessToolStripButton";
            this.toolStripButton3.Click += new System.EventHandler(this.ProcessToolStripButtonClick);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton4.Text = "DecisionToolStripButton";
            this.toolStripButton4.Click += new System.EventHandler(this.DecisionToolStripButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 759);
            this.Controls.Add(this.ShapeSelectToolStrip);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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

            // 為 Labels 註冊事件
            label1.MouseEnter += new EventHandler(ControlMouseEnter);
            label1.MouseLeave += new EventHandler(ControlMouseLeave);
            label2.MouseEnter += new EventHandler(ControlMouseEnter);
            label2.MouseLeave += new EventHandler(ControlMouseLeave);
            label3.MouseEnter += new EventHandler(ControlMouseEnter);
            label3.MouseLeave += new EventHandler(ControlMouseLeave);
            label4.MouseEnter += new EventHandler(ControlMouseEnter);
            label4.MouseLeave += new EventHandler(ControlMouseLeave);
            label5.MouseEnter += new EventHandler(ControlMouseEnter);
            label5.MouseLeave += new EventHandler(ControlMouseLeave);

            // 為 TextBoxes 註冊事件
            textBox_X.MouseEnter += new EventHandler(ControlMouseEnter);
            textBox_X.MouseLeave += new EventHandler(ControlMouseLeave);
            textBox_Y.MouseEnter += new EventHandler(ControlMouseEnter);
            textBox_Y.MouseLeave += new EventHandler(ControlMouseLeave);
            textBox_Width.MouseEnter += new EventHandler(ControlMouseEnter);
            textBox_Width.MouseLeave += new EventHandler(ControlMouseLeave);
            textBox_Height.MouseEnter += new EventHandler(ControlMouseEnter);
            textBox_Height.MouseLeave += new EventHandler(ControlMouseLeave);
            textBox_Text.MouseEnter += new EventHandler(ControlMouseEnter);
            textBox_Text.MouseLeave += new EventHandler(ControlMouseLeave);

            // 為 Buttons 註冊事件
            AddNewShapeButtom.MouseEnter += new EventHandler(ControlMouseEnter);
            AddNewShapeButtom.MouseLeave += new EventHandler(ControlMouseLeave);
            // 為 DataGridView 註冊事件
            ShapeDataGridView.MouseEnter += new EventHandler(ControlMouseEnter);
            ShapeDataGridView.MouseLeave += new EventHandler(ControlMouseLeave);
            dataGridView2.MouseEnter += new EventHandler(ControlMouseEnter);
            dataGridView2.MouseLeave += new EventHandler(ControlMouseLeave);

            // 為 Buttons 註冊事件
            button1.MouseEnter += new EventHandler(ControlMouseEnter);
            button1.MouseLeave += new EventHandler(ControlMouseLeave);
            button2.MouseEnter += new EventHandler(ControlMouseEnter);
            button2.MouseLeave += new EventHandler(ControlMouseLeave);

            // 為 ToolStrip 註冊事件
            toolStripButton1.MouseEnter += new EventHandler(ControlMouseEnter);
            toolStripButton1.MouseLeave += new EventHandler(ControlMouseLeave);
            toolStripButton2.MouseEnter += new EventHandler(ControlMouseEnter);
            toolStripButton2.MouseLeave += new EventHandler(ControlMouseLeave);
            toolStripButton3.MouseEnter += new EventHandler(ControlMouseEnter);
            toolStripButton3.MouseLeave += new EventHandler(ControlMouseLeave);
            toolStripButton4.MouseEnter += new EventHandler(ControlMouseEnter);
            toolStripButton4.MouseLeave += new EventHandler(ControlMouseLeave);

            groupBox1.MouseEnter += new EventHandler(ControlMouseEnter);
            groupBox1.MouseLeave += new EventHandler(ControlMouseLeave);

            comboBox_shape.MouseEnter += new EventHandler(ControlMouseEnter);
            comboBox_shape.MouseLeave += new EventHandler(ControlMouseLeave);

            說明ToolStripMenuItem.MouseEnter += new EventHandler(ControlMouseEnter);
            說明ToolStripMenuItem.MouseLeave += new EventHandler(ControlMouseLeave);

            ShapeSelectToolStrip.MouseEnter += new EventHandler(ControlMouseEnter);
            ShapeSelectToolStrip.MouseLeave += new EventHandler(ControlMouseLeave);

            menuStrip1.MouseEnter += new EventHandler(ControlMouseEnter);
            menuStrip1.MouseLeave += new EventHandler(ControlMouseLeave);

            關於ToolStripMenuItem.MouseEnter += new EventHandler(ControlMouseEnter);
            關於ToolStripMenuItem.MouseLeave += new EventHandler(ControlMouseLeave);

            // 綁定滑鼠事件
            this.MouseDown += (sender, e) => _controller.HandleMouseDown(e);
            this.MouseUp += (sender, e) => _controller.HandleMouseUp(e);
            this.MouseMove += (sender, e) => _controller.HandleMouseMove(e);
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
        private System.Windows.Forms.Button AddNewShapeButtom;
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
    }
}

