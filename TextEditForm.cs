using System;
using System.Drawing;
using System.Windows.Forms;

namespace 視窗流程圖 // 使用您的專案命名空間
{
    public partial class TextEditForm : Form, IDisposable
    {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;

        public event Action<string> TextConfirmedOk;

        public TextEditForm(string initialText)
        {

            // 設置標題
            Text = "文字編輯方塊";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 創建 TextBox
            textBox = new TextBox
            {
                Text = initialText,
                BorderStyle = BorderStyle.FixedSingle, // 添加邊框
                Width = 200 // 設定寬度
            };

            // 創建按鈕
            okButton = new Button { Text = "確定", Enabled = false };
            cancelButton = new Button { Text = "取消" };

            // 添加 TextBox 的事件處理，啟用/禁用 OK 按鈕
            textBox.TextChanged += (sender, e) => okButton.Enabled = textBox.Text != initialText;

            // 設置佈局
            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            // 添加控件到 TableLayoutPanel
            panel.Controls.Add(new Label { Text = "文字編輯方塊", TextAlign = ContentAlignment.MiddleCenter, Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold) }, 0, 0);
            panel.SetColumnSpan(panel.GetControlFromPosition(0, 0), 2);
            panel.Controls.Add(textBox, 0, 1);
            panel.SetColumnSpan(textBox, 2);
            panel.Controls.Add(okButton, 0, 2);
            panel.Controls.Add(cancelButton, 1, 2);

            Controls.Add(panel);

            // 設定其他屬性
            AcceptButton = okButton;
            CancelButton = cancelButton;

            // 按鈕點擊事件處理
            okButton.Click += okButton_Click;
            cancelButton.Click += cancelButton_Click;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            TextConfirmedOk?.Invoke(textBox.Text); // 觸發事件，傳遞 id 和新的文字
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string EditText => textBox.Text; // 保留 EditText 屬性，以防其他地方使用

        public new void Dispose()
        {
            textBox?.Dispose();
            okButton?.Dispose();
            cancelButton?.Dispose();
            base.Dispose();
        }
    }
}