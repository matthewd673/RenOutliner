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
            this.breakButton = new System.Windows.Forms.Button();
            this.posLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.posLabel.Location = new System.Drawing.Point(485, 17);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(65, 15);
            this.posLabel.TabIndex = 2;
            this.posLabel.Text = "LP: () MP: ()";
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
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(436, 12);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(43, 23);
            this.undoButton.TabIndex = 4;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // spaceLabel
            // 
            this.spaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spaceLabel.Location = new System.Drawing.Point(659, 9);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(110, 132);
            this.spaceLabel.TabIndex = 5;
            this.spaceLabel.Text = "(help)\r\nspace = toggle tools\r\nctrl+v = paste\r\nctrl+c = copy\r\nctrl+b = break line\r" +
    "\nctrl+p = pick color\r\nctrl+j = join polygon\r\nctrl+z = undo\r\n\r\nclick or toggle to" +
    " hide\r\n";
            this.spaceLabel.Click += new System.EventHandler(this.SpaceLabel_Click);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(255, 12);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(94, 23);
            this.colorButton.TabIndex = 6;
            this.colorButton.Text = "Color (Red)";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(355, 12);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(75, 23);
            this.joinButton.TabIndex = 7;
            this.joinButton.Text = "Join Polygon";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.spaceLabel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.posLabel);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.copyButton);
            this.Name = "MainForm";
            this.Text = "RenOutliner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Label posLabel;
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Label spaceLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button joinButton;
    }
}

