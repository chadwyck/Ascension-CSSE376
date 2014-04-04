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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 41);
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
            this.label3.Location = new System.Drawing.Point(199, 83);
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
            this.lblPlayer2Honor.Location = new System.Drawing.Point(215, 119);
            this.lblPlayer2Honor.Name = "lblPlayer2Honor";
            this.lblPlayer2Honor.Size = new System.Drawing.Size(13, 13);
            this.lblPlayer2Honor.TabIndex = 4;
            this.lblPlayer2Honor.Text = "0";
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}