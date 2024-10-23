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
            this.shapeDataGridView = new System.Windows.Forms.DataGridView();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shapeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.shapeDataGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 9F);
            this.groupBox1.Location = new System.Drawing.Point(716, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(383, 583);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
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
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(225, 46);
            this.textBox_Y.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(32, 22);
            this.textBox_Y.TabIndex = 10;
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(260, 46);
            this.textBox_Height.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(33, 22);
            this.textBox_Height.TabIndex = 9;
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(297, 46);
            this.textBox_Width.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(25, 22);
            this.textBox_Width.TabIndex = 8;
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(196, 46);
            this.textBox_X.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(25, 22);
            this.textBox_X.TabIndex = 7;
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(141, 46);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(52, 22);
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
            this.comboBox_shape.Location = new System.Drawing.Point(65, 47);
            this.comboBox_shape.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_shape.Name = "comboBox_shape";
            this.comboBox_shape.Size = new System.Drawing.Size(61, 20);
            this.comboBox_shape.TabIndex = 2;
            // 
            // AddNewShapeButtom
            // 
            this.AddNewShapeButtom.AutoEllipsis = true;
            this.AddNewShapeButtom.Location = new System.Drawing.Point(4, 16);
            this.AddNewShapeButtom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddNewShapeButtom.Name = "AddNewShapeButtom";
            this.AddNewShapeButtom.Size = new System.Drawing.Size(56, 50);
            this.AddNewShapeButtom.TabIndex = 1;
            this.AddNewShapeButtom.Text = "新增";
            this.AddNewShapeButtom.UseVisualStyleBackColor = true;
            this.AddNewShapeButtom.Click += new System.EventHandler(this.button_add_new_Click_1);
            // 
            // shapeDataGridView
            // 
            this.shapeDataGridView.AllowUserToAddRows = false;
            this.shapeDataGridView.AllowUserToDeleteRows = false;
            this.shapeDataGridView.AllowUserToResizeColumns = false;
            this.shapeDataGridView.AllowUserToResizeRows = false;
            this.shapeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.shapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteButton,
            this.ID,
            this.Shape,
            this.Text_grid,
            this.X,
            this.Y,
            this.Length_grid,
            this.Width_grid});
            this.shapeDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.shapeDataGridView.Location = new System.Drawing.Point(2, 79);
            this.shapeDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.shapeDataGridView.Name = "shapeDataGridView";
            this.shapeDataGridView.ReadOnly = true;
            this.shapeDataGridView.RowHeadersVisible = false;
            this.shapeDataGridView.RowHeadersWidth = 51;
            this.shapeDataGridView.RowTemplate.Height = 27;
            this.shapeDataGridView.Size = new System.Drawing.Size(379, 502);
            this.shapeDataGridView.TabIndex = 0;
            this.shapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
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
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView2.Location = new System.Drawing.Point(0, 24);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(158, 583);
            this.dataGridView2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 130);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 94);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 32);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 94);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 607);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shapeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button AddNewShapeButtom;
        private System.Windows.Forms.DataGridView shapeDataGridView;
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
    }
}

