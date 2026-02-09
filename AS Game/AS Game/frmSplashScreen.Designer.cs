
namespace AS_Game
{
    partial class frmSplashScreen
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
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.pnlLoadingBar = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblLoad = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.Black;
            this.pnlBack.Controls.Add(this.pnlLoading);
            this.pnlBack.Controls.Add(this.pnlLoadingBar);
            this.pnlBack.Location = new System.Drawing.Point(0, 637);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(811, 64);
            this.pnlBack.TabIndex = 0;
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlLoading.Location = new System.Drawing.Point(22, 19);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(15, 27);
            this.pnlLoading.TabIndex = 2;
            // 
            // pnlLoadingBar
            // 
            this.pnlLoadingBar.BackColor = System.Drawing.Color.White;
            this.pnlLoadingBar.Location = new System.Drawing.Point(22, 19);
            this.pnlLoadingBar.Name = "pnlLoadingBar";
            this.pnlLoadingBar.Size = new System.Drawing.Size(753, 27);
            this.pnlLoadingBar.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.BackColor = System.Drawing.Color.Brown;
            this.lblLoad.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoad.Location = new System.Drawing.Point(3, 577);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(268, 57);
            this.lblLoad.TabIndex = 1;
            this.lblLoad.Text = "Loading...";
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AS_Game.Properties.Resources.mapdraft11;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.pnlBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplashScreen";
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Panel pnlLoading;
        private System.Windows.Forms.Panel pnlLoadingBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblLoad;
    }
}