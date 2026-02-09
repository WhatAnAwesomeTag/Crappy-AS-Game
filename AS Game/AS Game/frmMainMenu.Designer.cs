
namespace AS_Game
{
    partial class frmMainMenu
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
            this.lblMai = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnLead = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.menuStripHelp = new System.Windows.Forms.MenuStrip();
            this.needHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHelp.SuspendLayout();
            this.menuStripHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMai
            // 
            this.lblMai.AutoSize = true;
            this.lblMai.BackColor = System.Drawing.Color.Brown;
            this.lblMai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMai.Font = new System.Drawing.Font("Stencil", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMai.Location = new System.Drawing.Point(205, 32);
            this.lblMai.Name = "lblMai";
            this.lblMai.Size = new System.Drawing.Size(383, 78);
            this.lblMai.TabIndex = 8;
            this.lblMai.Text = "Main Menu";
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Brown;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlay.FlatAppearance.BorderSize = 5;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(248, 194);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(274, 68);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnLead
            // 
            this.btnLead.BackColor = System.Drawing.Color.Brown;
            this.btnLead.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLead.FlatAppearance.BorderSize = 5;
            this.btnLead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLead.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLead.Location = new System.Drawing.Point(248, 284);
            this.btnLead.Name = "btnLead";
            this.btnLead.Size = new System.Drawing.Size(274, 68);
            this.btnLead.TabIndex = 10;
            this.btnLead.Text = "Leaderboard";
            this.btnLead.UseVisualStyleBackColor = false;
            this.btnLead.Click += new System.EventHandler(this.btnLead_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Brown;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogOut.FlatAppearance.BorderSize = 5;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(12, 520);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(181, 68);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Brown;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(644, 520);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 68);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = System.Drawing.Color.Brown;
            this.pnlHelp.Controls.Add(this.btnClose);
            this.pnlHelp.Controls.Add(this.lblHelp);
            this.pnlHelp.Controls.Add(this.txtHelp);
            this.pnlHelp.Location = new System.Drawing.Point(171, 32);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(484, 521);
            this.pnlHelp.TabIndex = 14;
            this.pnlHelp.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Brown;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.FlatAppearance.BorderSize = 5;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(428, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 40);
            this.btnClose.TabIndex = 59;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Brown;
            this.lblHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHelp.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(191, 13);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(106, 42);
            this.lblHelp.TabIndex = 52;
            this.lblHelp.Text = "Help";
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(37, 62);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.Size = new System.Drawing.Size(409, 441);
            this.txtHelp.TabIndex = 0;
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.BackColor = System.Drawing.Color.Brown;
            this.menuStripHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.needHelpToolStripMenuItem});
            this.menuStripHelp.Location = new System.Drawing.Point(0, 0);
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(800, 24);
            this.menuStripHelp.TabIndex = 15;
            this.menuStripHelp.Text = "menuStrip1";
            // 
            // needHelpToolStripMenuItem
            // 
            this.needHelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem});
            this.needHelpToolStripMenuItem.Name = "needHelpToolStripMenuItem";
            this.needHelpToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.needHelpToolStripMenuItem.Text = "Need Help?";
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.howToPlayToolStripMenuItem.Text = "How to Play";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AS_Game.Properties.Resources.mapdraft11;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLead);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblMai);
            this.Controls.Add(this.menuStripHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripHelp;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainMenu";
            this.pnlHelp.ResumeLayout(false);
            this.pnlHelp.PerformLayout();
            this.menuStripHelp.ResumeLayout(false);
            this.menuStripHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMai;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnLead;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MenuStrip menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem needHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
    }
}