namespace RenOutliner
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
            this.renderPanel = new System.Windows.Forms.Panel();
            this.pasteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.posLabel = new System.Windows.Forms.Label();
            this.breakButton = new System.Windows.Forms.Button();
            this.renderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // renderPanel
            // 
            this.renderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderPanel.Controls.Add(this.breakButton);
            this.renderPanel.Controls.Add(this.posLabel);
            this.renderPanel.Controls.Add(this.copyButton);
            this.renderPanel.Controls.Add(this.pasteButton);
            this.renderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPanel.Location = new System.Drawing.Point(0, 0);
            this.renderPanel.Name = "renderPanel";
            this.renderPanel.Size = new System.Drawing.Size(1144, 759);
            this.renderPanel.TabIndex = 0;
            this.renderPanel.Click += new System.EventHandler(this.RenderPanel_Click);
            this.renderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderPanel_Paint);
            this.renderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RenderPanel_MouseMove);
            this.renderPanel.Resize += new System.EventHandler(this.RenderPanel_Resize);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(12, 12);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 0;
            this.pasteButton.Text = "Paste Image";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(93, 12);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Copy Image";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.Location = new System.Drawing.Point(255, 17);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(63, 13);
            this.posLabel.TabIndex = 2;
            this.posLabel.Text = "LP: () MP: ()";
            // 
            // breakButton
            // 
            this.breakButton.Location = new System.Drawing.Point(174, 12);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(75, 23);
            this.breakButton.TabIndex = 3;
            this.breakButton.Text = "Break Line";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.BreakButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 759);
            this.Controls.Add(this.renderPanel);
            this.Name = "MainForm";
            this.Text = "RenOutliner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.renderPanel.ResumeLayout(false);
            this.renderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel renderPanel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Button breakButton;
    }
}

