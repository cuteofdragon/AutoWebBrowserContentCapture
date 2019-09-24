namespace AutoWebBrowserContentCapture
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submitButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.removeImageCheckBox = new System.Windows.Forms.CheckBox();
            this.removeHyperlinkCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "網址：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeHyperlinkCheckBox);
            this.panel1.Controls.Add(this.removeImageCheckBox);
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Controls.Add(this.urlTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 117);
            this.panel1.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.submitButton.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.submitButton.Location = new System.Drawing.Point(697, 14);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 30);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "轉換";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.urlTextBox.Location = new System.Drawing.Point(77, 15);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(605, 29);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.WordWrap = false;
            this.urlTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.urlTextBox_KeyUp);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 117);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(784, 20);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // removeImageCheckBox
            // 
            this.removeImageCheckBox.AutoSize = true;
            this.removeImageCheckBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.removeImageCheckBox.Location = new System.Drawing.Point(16, 61);
            this.removeImageCheckBox.Name = "removeImageCheckBox";
            this.removeImageCheckBox.Size = new System.Drawing.Size(92, 24);
            this.removeImageCheckBox.TabIndex = 3;
            this.removeImageCheckBox.Text = "移除圖片";
            this.removeImageCheckBox.UseVisualStyleBackColor = true;
            // 
            // removeHyperlinkCheckBox
            // 
            this.removeHyperlinkCheckBox.AutoSize = true;
            this.removeHyperlinkCheckBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.removeHyperlinkCheckBox.Location = new System.Drawing.Point(131, 61);
            this.removeHyperlinkCheckBox.Name = "removeHyperlinkCheckBox";
            this.removeHyperlinkCheckBox.Size = new System.Drawing.Size(108, 24);
            this.removeHyperlinkCheckBox.TabIndex = 3;
            this.removeHyperlinkCheckBox.Text = "移除超連結";
            this.removeHyperlinkCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 101);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自動網頁轉換文件";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.CheckBox removeHyperlinkCheckBox;
        private System.Windows.Forms.CheckBox removeImageCheckBox;
    }
}

