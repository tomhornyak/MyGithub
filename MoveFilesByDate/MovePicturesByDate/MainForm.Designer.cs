namespace MovePicturesByDate
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this._btnTarget = new System.Windows.Forms.Button();
            this._btnGo = new System.Windows.Forms.Button();
            this._txtTarget = new System.Windows.Forms.TextBox();
            this._txtSource = new System.Windows.Forms.TextBox();
            this._btnSource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(6, 118);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(478, 440);
            this.treeView1.TabIndex = 0;
            // 
            // _btnTarget
            // 
            this._btnTarget.Location = new System.Drawing.Point(6, 46);
            this._btnTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnTarget.Name = "_btnTarget";
            this._btnTarget.Size = new System.Drawing.Size(87, 28);
            this._btnTarget.TabIndex = 2;
            this._btnTarget.Text = "Target";
            this._btnTarget.UseVisualStyleBackColor = true;
            this._btnTarget.Click += new System.EventHandler(this._btnTarget_Click);
            // 
            // _btnGo
            // 
            this._btnGo.Location = new System.Drawing.Point(6, 82);
            this._btnGo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnGo.Name = "_btnGo";
            this._btnGo.Size = new System.Drawing.Size(87, 28);
            this._btnGo.TabIndex = 3;
            this._btnGo.Text = "Go";
            this._btnGo.UseVisualStyleBackColor = true;
            this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
            // 
            // _txtTarget
            // 
            this._txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTarget.Location = new System.Drawing.Point(99, 49);
            this._txtTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtTarget.Name = "_txtTarget";
            this._txtTarget.Size = new System.Drawing.Size(364, 22);
            this._txtTarget.TabIndex = 5;
            // 
            // _txtSource
            // 
            this._txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSource.Location = new System.Drawing.Point(99, 13);
            this._txtSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._txtSource.Name = "_txtSource";
            this._txtSource.Size = new System.Drawing.Size(364, 22);
            this._txtSource.TabIndex = 7;
            // 
            // _btnSource
            // 
            this._btnSource.Location = new System.Drawing.Point(6, 10);
            this._btnSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSource.Name = "_btnSource";
            this._btnSource.Size = new System.Drawing.Size(87, 28);
            this._btnSource.TabIndex = 6;
            this._btnSource.Text = "Source";
            this._btnSource.UseVisualStyleBackColor = true;
            this._btnSource.Click += new System.EventHandler(this._btnSource_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 559);
            this.Controls.Add(this._txtSource);
            this.Controls.Add(this._btnSource);
            this.Controls.Add(this._txtTarget);
            this.Controls.Add(this._btnGo);
            this.Controls.Add(this._btnTarget);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Copy Files by Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button _btnTarget;
        private System.Windows.Forms.Button _btnGo;
        private System.Windows.Forms.TextBox _txtTarget;
        private System.Windows.Forms.TextBox _txtSource;
        private System.Windows.Forms.Button _btnSource;
    }
}

