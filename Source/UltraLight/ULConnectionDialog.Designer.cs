namespace OPlusDriver
{
    partial class ULConnectionDialog
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
            this.UIDField = new System.Windows.Forms.TextBox();
            this.PWDField = new System.Windows.Forms.TextBox();
            this.UIDLabel = new System.Windows.Forms.Label();
            this.PWDLabel = new System.Windows.Forms.Label();
            this.ULOKButton = new System.Windows.Forms.Button();
            this.ULCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UIDField
            // 
            this.UIDField.Location = new System.Drawing.Point(106, 12);
            this.UIDField.Name = "UIDField";
            this.UIDField.Size = new System.Drawing.Size(180, 20);
            this.UIDField.TabIndex = 0;
            // 
            // PWDField
            // 
            this.PWDField.Location = new System.Drawing.Point(106, 43);
            this.PWDField.Name = "PWDField";
            this.PWDField.PasswordChar = '*';
            this.PWDField.Size = new System.Drawing.Size(180, 20);
            this.PWDField.TabIndex = 1;
            // 
            // UIDLabel
            // 
            this.UIDLabel.AutoSize = true;
            this.UIDLabel.Location = new System.Drawing.Point(55, 15);
            this.UIDLabel.Name = "UIDLabel";
            this.UIDLabel.Size = new System.Drawing.Size(26, 13);
            this.UIDLabel.TabIndex = 0;
            this.UIDLabel.Text = "UID";
            // 
            // PWDLabel
            // 
            this.PWDLabel.AutoSize = true;
            this.PWDLabel.Location = new System.Drawing.Point(55, 46);
            this.PWDLabel.Name = "PWDLabel";
            this.PWDLabel.Size = new System.Drawing.Size(33, 13);
            this.PWDLabel.TabIndex = 0;
            this.PWDLabel.Text = "PWD";
            // 
            // ULOKButton
            // 
            this.ULOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ULOKButton.Location = new System.Drawing.Point(106, 80);
            this.ULOKButton.Name = "ULOKButton";
            this.ULOKButton.Size = new System.Drawing.Size(85, 20);
            this.ULOKButton.TabIndex = 2;
            this.ULOKButton.Text = "OK";
            this.ULOKButton.UseVisualStyleBackColor = true;
            this.ULOKButton.Click += new System.EventHandler(this.ULOKButton_Click);
            // 
            // ULCancelButton
            // 
            this.ULCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ULCancelButton.Location = new System.Drawing.Point(201, 80);
            this.ULCancelButton.Name = "ULCancelButton";
            this.ULCancelButton.Size = new System.Drawing.Size(85, 20);
            this.ULCancelButton.TabIndex = 3;
            this.ULCancelButton.Text = "Cancel";
            this.ULCancelButton.UseVisualStyleBackColor = true;
            this.ULCancelButton.Click += new System.EventHandler(this.ULCancelButton_Click);
            // 
            // ULConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 112);
            this.Controls.Add(this.ULCancelButton);
            this.Controls.Add(this.ULOKButton);
            this.Controls.Add(this.PWDLabel);
            this.Controls.Add(this.UIDLabel);
            this.Controls.Add(this.PWDField);
            this.Controls.Add(this.UIDField);
            this.Name = "ULConnectionDialog";
            this.Text = "DotNetUltraLight Connection Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UIDField;
        private System.Windows.Forms.TextBox PWDField;
        private System.Windows.Forms.Label UIDLabel;
        private System.Windows.Forms.Label PWDLabel;
        private System.Windows.Forms.Button ULOKButton;
        private System.Windows.Forms.Button ULCancelButton;
    }
}