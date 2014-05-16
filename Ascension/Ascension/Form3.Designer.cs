namespace Ascension
{
    partial class CardView
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
            this.cardName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rCost = new System.Windows.Forms.Label();
            this.pCost = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Purchase = new System.Windows.Forms.Button();
            this.Kill = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cardName
            // 
            this.cardName.AutoSize = true;
            this.cardName.Location = new System.Drawing.Point(29, 25);
            this.cardName.Name = "cardName";
            this.cardName.Size = new System.Drawing.Size(97, 13);
            this.cardName.TabIndex = 0;
            this.cardName.Text = "Default Card Name";
            this.cardName.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rune Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Power Cost";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 532);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Abilities";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 529);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "Use Selected Ability";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "End-Game Honor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 631);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "0";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // rCost
            // 
            this.rCost.AutoSize = true;
            this.rCost.Location = new System.Drawing.Point(340, 24);
            this.rCost.Name = "rCost";
            this.rCost.Size = new System.Drawing.Size(13, 13);
            this.rCost.TabIndex = 8;
            this.rCost.Text = "0";
            // 
            // pCost
            // 
            this.pCost.AutoSize = true;
            this.pCost.Location = new System.Drawing.Point(340, 40);
            this.pCost.Name = "pCost";
            this.pCost.Size = new System.Drawing.Size(13, 13);
            this.pCost.TabIndex = 9;
            this.pCost.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 439);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Purchase
            // 
            this.Purchase.Location = new System.Drawing.Point(279, 570);
            this.Purchase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Purchase.Name = "Purchase";
            this.Purchase.Size = new System.Drawing.Size(122, 23);
            this.Purchase.TabIndex = 11;
            this.Purchase.Text = "Purchase";
            this.Purchase.UseVisualStyleBackColor = true;
            this.Purchase.Click += new System.EventHandler(this.button2_Click);
            // 
            // Kill
            // 
            this.Kill.Location = new System.Drawing.Point(278, 615);
            this.Kill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(123, 21);
            this.Kill.TabIndex = 12;
            this.Kill.Text = "Kill";
            this.Kill.UseVisualStyleBackColor = true;
            this.Kill.Click += new System.EventHandler(this.Kill_Click);
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(279, 660);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(122, 23);
            this.Play.TabIndex = 13;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // CardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 695);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.Kill);
            this.Controls.Add(this.Purchase);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pCost);
            this.Controls.Add(this.rCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cardName);
            this.Name = "CardView";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.CardView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cardName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label rCost;
        private System.Windows.Forms.Label pCost;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Purchase;
        private System.Windows.Forms.Button Kill;
        private System.Windows.Forms.Button Play;
    }
}