namespace Ascension
{
    partial class EndGameForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlayer1Honor = new System.Windows.Forms.Label();
            this.lblPlayer2Honor = new System.Windows.Forms.Label();
            this.lblPlayer4Honor = new System.Windows.Forms.Label();
            this.lblPlayer3Honor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player2";
            // 
            // lblPlayer1Honor
            // 
            this.lblPlayer1Honor.AutoSize = true;
            this.lblPlayer1Honor.Location = new System.Drawing.Point(52, 119);
            this.lblPlayer1Honor.Name = "lblPlayer1Honor";
            this.lblPlayer1Honor.Size = new System.Drawing.Size(13, 13);
            this.lblPlayer1Honor.TabIndex = 3;
            this.lblPlayer1Honor.Text = "0";
            this.lblPlayer1Honor.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblPlayer2Honor
            // 
            this.lblPlayer2Honor.AutoSize = true;
            this.lblPlayer2Honor.Location = new System.Drawing.Point(152, 119);
            this.lblPlayer2Honor.Name = "lblPlayer2Honor";
            this.lblPlayer2Honor.Size = new System.Drawing.Size(13, 13);
            this.lblPlayer2Honor.TabIndex = 4;
            this.lblPlayer2Honor.Text = "0";
            // 
            // lblPlayer4Honor
            // 
            this.lblPlayer4Honor.AutoSize = true;
            this.lblPlayer4Honor.Location = new System.Drawing.Point(345, 119);
            this.lblPlayer4Honor.Name = "lblPlayer4Honor";
            this.lblPlayer4Honor.Size = new System.Drawing.Size(13, 13);
            this.lblPlayer4Honor.TabIndex = 8;
            this.lblPlayer4Honor.Text = "0";
            this.lblPlayer4Honor.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // lblPlayer3Honor
            // 
            this.lblPlayer3Honor.AutoSize = true;
            this.lblPlayer3Honor.Location = new System.Drawing.Point(245, 119);
            this.lblPlayer3Honor.Name = "lblPlayer3Honor";
            this.lblPlayer3Honor.Size = new System.Drawing.Size(13, 13);
            this.lblPlayer3Honor.TabIndex = 7;
            this.lblPlayer3Honor.Text = "0";
            this.lblPlayer3Honor.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Player4";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Player3";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 215);
            this.Controls.Add(this.lblPlayer4Honor);
            this.Controls.Add(this.lblPlayer3Honor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPlayer2Honor);
            this.Controls.Add(this.lblPlayer1Honor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EndGameForm";
            this.Text = "EndGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlayer1Honor;
        private System.Windows.Forms.Label lblPlayer2Honor;
        private System.Windows.Forms.Label lblPlayer4Honor;
        private System.Windows.Forms.Label lblPlayer3Honor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}