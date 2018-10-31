namespace MVCPseudoGPS
{
    partial class ViewForm3
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
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.cbSelectType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDraw.Location = new System.Drawing.Point(12, 12);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(649, 426);
            this.pnlDraw.TabIndex = 23;
            // 
            // cbSelectType
            // 
            this.cbSelectType.FormattingEnabled = true;
            this.cbSelectType.Items.AddRange(new object[] {
            "Train Station",
            "Mall",
            "Shop"});
            this.cbSelectType.Location = new System.Drawing.Point(667, 12);
            this.cbSelectType.Name = "cbSelectType";
            this.cbSelectType.Size = new System.Drawing.Size(121, 21);
            this.cbSelectType.TabIndex = 25;
            this.cbSelectType.Text = "Select Building Type";
            this.cbSelectType.SelectedIndexChanged += new System.EventHandler(this.cbSelectType_SelectedIndexChanged);
            // 
            // ViewForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbSelectType);
            this.Controls.Add(this.pnlDraw);
            this.Name = "ViewForm3";
            this.Text = "ViewForm3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.ComboBox cbSelectType;
    }
}