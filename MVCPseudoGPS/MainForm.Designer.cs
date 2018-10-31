namespace MVCPseudoGPS
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
            this.btnVF1 = new System.Windows.Forms.Button();
            this.btnVF2 = new System.Windows.Forms.Button();
            this.btnVF3 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVF1
            // 
            this.btnVF1.Location = new System.Drawing.Point(59, 35);
            this.btnVF1.Name = "btnVF1";
            this.btnVF1.Size = new System.Drawing.Size(75, 23);
            this.btnVF1.TabIndex = 0;
            this.btnVF1.Text = "Form 1";
            this.btnVF1.UseVisualStyleBackColor = true;
            this.btnVF1.Click += new System.EventHandler(this.btnVF1_Click);
            // 
            // btnVF2
            // 
            this.btnVF2.Location = new System.Drawing.Point(59, 64);
            this.btnVF2.Name = "btnVF2";
            this.btnVF2.Size = new System.Drawing.Size(75, 23);
            this.btnVF2.TabIndex = 1;
            this.btnVF2.Text = "Form 2";
            this.btnVF2.UseVisualStyleBackColor = true;
            this.btnVF2.Click += new System.EventHandler(this.btnVF2_Click);
            // 
            // btnVF3
            // 
            this.btnVF3.Location = new System.Drawing.Point(59, 93);
            this.btnVF3.Name = "btnVF3";
            this.btnVF3.Size = new System.Drawing.Size(75, 23);
            this.btnVF3.TabIndex = 2;
            this.btnVF3.Text = "Form 3";
            this.btnVF3.UseVisualStyleBackColor = true;
            this.btnVF3.Click += new System.EventHandler(this.btnVF3_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(59, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 201);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnVF3);
            this.Controls.Add(this.btnVF2);
            this.Controls.Add(this.btnVF1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVF1;
        private System.Windows.Forms.Button btnVF2;
        private System.Windows.Forms.Button btnVF3;
        private System.Windows.Forms.Button btnClose;
    }
}