namespace WindowsFormsApplication2
{
    partial class AdjustSettings
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
            this.buttonApply = new System.Windows.Forms.Button();
            this.labelEnemy = new System.Windows.Forms.Label();
            this.labelObjective = new System.Windows.Forms.Label();
            this.labelBackground = new System.Windows.Forms.Label();
            this.textBoxEnemy = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxBackground = new System.Windows.Forms.TextBox();
            this.textBoxObjective = new System.Windows.Forms.TextBox();
            this.openFileDialogEnemy = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(72, 138);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(91, 23);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Apply Changes";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // labelEnemy
            // 
            this.labelEnemy.AutoSize = true;
            this.labelEnemy.Location = new System.Drawing.Point(12, 36);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.Size = new System.Drawing.Size(74, 13);
            this.labelEnemy.TabIndex = 1;
            this.labelEnemy.Text = "Enemy Image:";
            // 
            // labelObjective
            // 
            this.labelObjective.AutoSize = true;
            this.labelObjective.Location = new System.Drawing.Point(12, 64);
            this.labelObjective.Name = "labelObjective";
            this.labelObjective.Size = new System.Drawing.Size(87, 13);
            this.labelObjective.TabIndex = 2;
            this.labelObjective.Text = "Objective Image:";
            // 
            // labelBackground
            // 
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(12, 96);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(100, 13);
            this.labelBackground.TabIndex = 3;
            this.labelBackground.Text = "Background Image:";
            // 
            // textBoxEnemy
            // 
            this.textBoxEnemy.Location = new System.Drawing.Point(118, 33);
            this.textBoxEnemy.Name = "textBoxEnemy";
            this.textBoxEnemy.Size = new System.Drawing.Size(100, 20);
            this.textBoxEnemy.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(244, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // textBoxBackground
            // 
            this.textBoxBackground.Location = new System.Drawing.Point(118, 93);
            this.textBoxBackground.Name = "textBoxBackground";
            this.textBoxBackground.Size = new System.Drawing.Size(100, 20);
            this.textBoxBackground.TabIndex = 6;
            // 
            // textBoxObjective
            // 
            this.textBoxObjective.Location = new System.Drawing.Point(118, 61);
            this.textBoxObjective.Name = "textBoxObjective";
            this.textBoxObjective.Size = new System.Drawing.Size(100, 20);
            this.textBoxObjective.TabIndex = 7;
            // 
            // openFileDialogEnemy
            // 
            this.openFileDialogEnemy.FileName = "openFileDialog1";
            // 
            // AdjustSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 173);
            this.Controls.Add(this.textBoxObjective);
            this.Controls.Add(this.textBoxBackground);
            this.Controls.Add(this.textBoxEnemy);
            this.Controls.Add(this.labelBackground);
            this.Controls.Add(this.labelObjective);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdjustSettings";
            this.Text = "Edit Game Settings";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.Label labelObjective;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.TextBox textBoxEnemy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxBackground;
        private System.Windows.Forms.TextBox textBoxObjective;
        private System.Windows.Forms.OpenFileDialog openFileDialogEnemy;
    }
}

