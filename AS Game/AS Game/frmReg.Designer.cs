
namespace AS_Game
{
    partial class frmReg
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblCon = new System.Windows.Forms.Label();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblAlr = new System.Windows.Forms.Label();
            this.txtAbbrev = new System.Windows.Forms.TextBox();
            this.lblAbbrev = new System.Windows.Forms.Label();
            this.lblMus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Brown;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.FlatAppearance.BorderSize = 5;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(12, 642);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 46);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.BackColor = System.Drawing.Color.Brown;
            this.lblAcc.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcc.Location = new System.Drawing.Point(164, 203);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(497, 57);
            this.lblAcc.TabIndex = 7;
            this.lblAcc.Text = "Create an Account";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Brown;
            this.txtUser.Location = new System.Drawing.Point(299, 287);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(208, 20);
            this.txtUser.TabIndex = 8;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Brown;
            this.lblUser.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(152, 279);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(137, 29);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "Username";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Brown;
            this.txtPass.Location = new System.Drawing.Point(299, 368);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(208, 20);
            this.txtPass.TabIndex = 10;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Brown;
            this.lblPass.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(152, 359);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(137, 29);
            this.lblPass.TabIndex = 11;
            this.lblPass.Text = "Password";
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.BackColor = System.Drawing.Color.Brown;
            this.lblCon.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCon.Location = new System.Drawing.Point(41, 403);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(248, 29);
            this.lblCon.TabIndex = 12;
            this.lblCon.Text = "Confirm Password";
            // 
            // txtCon
            // 
            this.txtCon.BackColor = System.Drawing.Color.Brown;
            this.txtCon.Location = new System.Drawing.Point(299, 410);
            this.txtCon.Name = "txtCon";
            this.txtCon.PasswordChar = '●';
            this.txtCon.Size = new System.Drawing.Size(208, 20);
            this.txtCon.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Brown;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.FlatAppearance.BorderSize = 4;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(299, 436);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 31);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.Brown;
            this.btnReg.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReg.FlatAppearance.BorderSize = 4;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.Location = new System.Drawing.Point(404, 436);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(103, 31);
            this.btnReg.TabIndex = 15;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Brown;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShow.FlatAppearance.BorderSize = 2;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Location = new System.Drawing.Point(513, 407);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(26, 26);
            this.btnShow.TabIndex = 16;
            this.btnShow.Text = "👁";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblAlr
            // 
            this.lblAlr.AutoSize = true;
            this.lblAlr.BackColor = System.Drawing.Color.Brown;
            this.lblAlr.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlr.Location = new System.Drawing.Point(12, 610);
            this.lblAlr.Name = "lblAlr";
            this.lblAlr.Size = new System.Drawing.Size(344, 29);
            this.lblAlr.TabIndex = 17;
            this.lblAlr.Text = "Already have an account?";
            // 
            // txtAbbrev
            // 
            this.txtAbbrev.BackColor = System.Drawing.Color.Brown;
            this.txtAbbrev.Location = new System.Drawing.Point(299, 329);
            this.txtAbbrev.Name = "txtAbbrev";
            this.txtAbbrev.Size = new System.Drawing.Size(208, 20);
            this.txtAbbrev.TabIndex = 18;
            // 
            // lblAbbrev
            // 
            this.lblAbbrev.AutoSize = true;
            this.lblAbbrev.BackColor = System.Drawing.Color.Brown;
            this.lblAbbrev.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbbrev.Location = new System.Drawing.Point(40, 320);
            this.lblAbbrev.Name = "lblAbbrev";
            this.lblAbbrev.Size = new System.Drawing.Size(249, 29);
            this.lblAbbrev.TabIndex = 19;
            this.lblAbbrev.Text = "3 Letter Username";
            // 
            // lblMus
            // 
            this.lblMus.AutoSize = true;
            this.lblMus.BackColor = System.Drawing.Color.Brown;
            this.lblMus.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMus.Location = new System.Drawing.Point(510, 320);
            this.lblMus.Name = "lblMus";
            this.lblMus.Size = new System.Drawing.Size(69, 32);
            this.lblMus.TabIndex = 20;
            this.lblMus.Text = "(Must be\r\nall caps)";
            // 
            // frmReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AS_Game.Properties.Resources.mapdraft11;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.lblMus);
            this.Controls.Add(this.lblAbbrev);
            this.Controls.Add(this.txtAbbrev);
            this.Controls.Add(this.lblAlr);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.lblCon);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblCon;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblAlr;
        private System.Windows.Forms.TextBox txtAbbrev;
        private System.Windows.Forms.Label lblAbbrev;
        private System.Windows.Forms.Label lblMus;
    }
}