
namespace AS_Game
{
    partial class frmLeaderboard
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
            this.listViewLeaderboard = new System.Windows.Forms.ListView();
            this.colHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLea = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewLeaderboard
            // 
            this.listViewLeaderboard.BackColor = System.Drawing.Color.Brown;
            this.listViewLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLeaderboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeader1,
            this.colHeader2});
            this.listViewLeaderboard.HideSelection = false;
            this.listViewLeaderboard.Location = new System.Drawing.Point(119, 125);
            this.listViewLeaderboard.Name = "listViewLeaderboard";
            this.listViewLeaderboard.Size = new System.Drawing.Size(550, 450);
            this.listViewLeaderboard.TabIndex = 0;
            this.listViewLeaderboard.UseCompatibleStateImageBehavior = false;
            this.listViewLeaderboard.View = System.Windows.Forms.View.Details;
            // 
            // colHeader1
            // 
            this.colHeader1.Text = "Player";
            this.colHeader1.Width = 275;
            // 
            // colHeader2
            // 
            this.colHeader2.Text = "Score";
            this.colHeader2.Width = 275;
            // 
            // lblLea
            // 
            this.lblLea.AutoSize = true;
            this.lblLea.BackColor = System.Drawing.Color.Brown;
            this.lblLea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLea.Font = new System.Drawing.Font("Stencil", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLea.Location = new System.Drawing.Point(158, 9);
            this.lblLea.Name = "lblLea";
            this.lblLea.Size = new System.Drawing.Size(483, 78);
            this.lblLea.TabIndex = 9;
            this.lblLea.Text = "Leaderboard";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Brown;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.FlatAppearance.BorderSize = 5;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 620);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(181, 68);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AS_Game.Properties.Resources.mapdraft11;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblLea);
            this.Controls.Add(this.listViewLeaderboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLeaderboard";
            this.Load += new System.EventHandler(this.frmLeaderboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLeaderboard;
        private System.Windows.Forms.Label lblLea;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ColumnHeader colHeader1;
        private System.Windows.Forms.ColumnHeader colHeader2;
    }
}