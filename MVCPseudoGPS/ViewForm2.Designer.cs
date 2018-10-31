namespace MVCPseudoGPS
{
    partial class ViewForm2
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
            this.components = new System.ComponentModel.Container();
            this.gBControl = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblCusVal = new System.Windows.Forms.Label();
            this.rbTrainStation = new System.Windows.Forms.RadioButton();
            this.rbMall = new System.Windows.Forms.RadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.rbShop = new System.Windows.Forms.RadioButton();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.toolTipVF2 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBControl.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBControl
            // 
            this.gBControl.Controls.Add(this.txtName);
            this.gBControl.Controls.Add(this.lblName);
            this.gBControl.Controls.Add(this.btnClear);
            this.gBControl.Controls.Add(this.txtValue);
            this.gBControl.Controls.Add(this.lblCusVal);
            this.gBControl.Controls.Add(this.rbTrainStation);
            this.gBControl.Controls.Add(this.rbMall);
            this.gBControl.Controls.Add(this.lblType);
            this.gBControl.Controls.Add(this.rbShop);
            this.gBControl.Controls.Add(this.txtY);
            this.gBControl.Controls.Add(this.lblY);
            this.gBControl.Controls.Add(this.txtX);
            this.gBControl.Controls.Add(this.lblX);
            this.gBControl.Location = new System.Drawing.Point(540, 34);
            this.gBControl.Name = "gBControl";
            this.gBControl.Size = new System.Drawing.Size(248, 189);
            this.gBControl.TabIndex = 35;
            this.gBControl.TabStop = false;
            this.gBControl.Text = "Control";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 20);
            this.txtName.TabIndex = 34;
            this.toolTipVF2.SetToolTip(this.txtName, "The name of the Building.");
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Name:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(167, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear Input";
            this.toolTipVF2.SetToolTip(this.btnClear, "Clear\'s all fields.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(84, 162);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(61, 20);
            this.txtValue.TabIndex = 33;
            this.toolTipVF2.SetToolTip(this.txtValue, "Rating is a Double, Capacity is a Int and Line is a String.");
            // 
            // lblCusVal
            // 
            this.lblCusVal.AutoSize = true;
            this.lblCusVal.Location = new System.Drawing.Point(6, 165);
            this.lblCusVal.Name = "lblCusVal";
            this.lblCusVal.Size = new System.Drawing.Size(72, 13);
            this.lblCusVal.TabIndex = 32;
            this.lblCusVal.Text = "Custom Input:";
            this.toolTipVF2.SetToolTip(this.lblCusVal, "This input required is determined by the type of Building, Shop is double, Mall i" +
        "s int and Train Station is Line.");
            // 
            // rbTrainStation
            // 
            this.rbTrainStation.AutoSize = true;
            this.rbTrainStation.Location = new System.Drawing.Point(6, 133);
            this.rbTrainStation.Name = "rbTrainStation";
            this.rbTrainStation.Size = new System.Drawing.Size(85, 17);
            this.rbTrainStation.TabIndex = 31;
            this.rbTrainStation.TabStop = true;
            this.rbTrainStation.Text = "Train Station";
            this.toolTipVF2.SetToolTip(this.rbTrainStation, "The type of building is a Train Station.");
            this.rbTrainStation.UseVisualStyleBackColor = true;
            this.rbTrainStation.CheckedChanged += new System.EventHandler(this.rbTrainStation_CheckedChanged);
            // 
            // rbMall
            // 
            this.rbMall.AutoSize = true;
            this.rbMall.Location = new System.Drawing.Point(6, 110);
            this.rbMall.Name = "rbMall";
            this.rbMall.Size = new System.Drawing.Size(44, 17);
            this.rbMall.TabIndex = 30;
            this.rbMall.TabStop = true;
            this.rbMall.Text = "Mall";
            this.toolTipVF2.SetToolTip(this.rbMall, "The type of building is a Mall.");
            this.rbMall.UseVisualStyleBackColor = true;
            this.rbMall.CheckedChanged += new System.EventHandler(this.rbMall_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 71);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(74, 13);
            this.lblType.TabIndex = 29;
            this.lblType.Text = "Building Type:";
            // 
            // rbShop
            // 
            this.rbShop.AutoSize = true;
            this.rbShop.Location = new System.Drawing.Point(6, 87);
            this.rbShop.Name = "rbShop";
            this.rbShop.Size = new System.Drawing.Size(50, 17);
            this.rbShop.TabIndex = 28;
            this.rbShop.TabStop = true;
            this.rbShop.Text = "Shop";
            this.toolTipVF2.SetToolTip(this.rbShop, "The type of building is a Shop.");
            this.rbShop.UseVisualStyleBackColor = true;
            this.rbShop.CheckedChanged += new System.EventHandler(this.rbShop_CheckedChanged);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(127, 48);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(69, 20);
            this.txtY.TabIndex = 26;
            this.toolTipVF2.SetToolTip(this.txtY, "Maximum Value is 420.");
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(104, 51);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 27;
            this.lblY.Text = "Y:";
            this.toolTipVF2.SetToolTip(this.lblY, "The Y coordinate.");
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(29, 48);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(69, 20);
            this.txtX.TabIndex = 24;
            this.toolTipVF2.SetToolTip(this.txtX, "Maximum Value is 520.");
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(6, 51);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 25;
            this.lblX.Text = "X:";
            this.toolTipVF2.SetToolTip(this.lblX, "The X coordinate.");
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(630, 404);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(711, 404);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDraw.Location = new System.Drawing.Point(12, 34);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(520, 420);
            this.pnlDraw.TabIndex = 36;
            this.toolTipVF2.SetToolTip(this.pnlDraw, "Display\'s Building.");
            this.pnlDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseDown);
            this.pnlDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseMove);
            this.pnlDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseUp);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dat";
            this.saveFileDialog.FileName = "Data";
            this.saveFileDialog.Filter = "\"Dat files (*.dat)|*.dat|All files (*.*)|*.*\"";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "dat";
            this.openFileDialog.Filter = "\"Dat files (*.dat)|*.dat|All files (*.*)|*.*\"";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 37;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.ctxSave_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.ctxLoad_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.ctxClose_Click);
            // 
            // ViewForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.gBControl);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "ViewForm2";
            this.Text = "ViewForm2";
            this.gBControl.ResumeLayout(false);
            this.gBControl.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gBControl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblCusVal;
        private System.Windows.Forms.RadioButton rbTrainStation;
        private System.Windows.Forms.RadioButton rbMall;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbShop;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.ToolTip toolTipVF2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}