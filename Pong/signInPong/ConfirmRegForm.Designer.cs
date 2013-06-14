namespace signInPong
{
    partial class ConfirmRegForm
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
            this.guidTxtBox = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the key emailed to you below.";
            // 
            // guidTxtBox
            // 
            this.guidTxtBox.Location = new System.Drawing.Point(16, 52);
            this.guidTxtBox.Name = "guidTxtBox";
            this.guidTxtBox.Size = new System.Drawing.Size(256, 20);
            this.guidTxtBox.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(16, 97);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(256, 42);
            this.ok.TabIndex = 2;
            this.ok.Text = "Submit";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // ConfirmRegForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 151);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.guidTxtBox);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmRegForm";
            this.Text = "Confirm Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmRegForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok;
        internal System.Windows.Forms.TextBox guidTxtBox;
    }
}