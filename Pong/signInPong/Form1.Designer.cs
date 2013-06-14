namespace signInPong
{
    partial class Form1
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
            this.namel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.ComboBox();
            this.labelp = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.sign = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.iconChooser = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // namel
            // 
            this.namel.AutoSize = true;
            this.namel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namel.Location = new System.Drawing.Point(12, 9);
            this.namel.Name = "namel";
            this.namel.Size = new System.Drawing.Size(68, 25);
            this.namel.TabIndex = 0;
            this.namel.Text = "Name";
            // 
            // name
            // 
            this.name.FormattingEnabled = true;
            this.name.Location = new System.Drawing.Point(12, 37);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(296, 21);
            this.name.TabIndex = 1;
            // 
            // labelp
            // 
            this.labelp.AutoSize = true;
            this.labelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelp.Location = new System.Drawing.Point(12, 61);
            this.labelp.Name = "labelp";
            this.labelp.Size = new System.Drawing.Size(106, 25);
            this.labelp.TabIndex = 2;
            this.labelp.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 89);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(296, 20);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // sign
            // 
            this.sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign.Location = new System.Drawing.Point(12, 115);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(92, 36);
            this.sign.TabIndex = 4;
            this.sign.Text = "Sign In";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(111, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Icon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // iconChooser
            // 
            this.iconChooser.Filter = "JPG Images|*.jpg|PNG Images|*.png";
            // 
            // Form1
            // 
            this.AcceptButton = this.sign;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 168);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sign);
            this.Controls.Add(this.password);
            this.Controls.Add(this.labelp);
            this.Controls.Add(this.name);
            this.Controls.Add(this.namel);
            this.Name = "Form1";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label namel;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.Label labelp;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog iconChooser;
    }
}

