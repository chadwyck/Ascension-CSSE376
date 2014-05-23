namespace Ascension
{
    partial class BoardView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardView));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.playHand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playPlay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playDisc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.playDeck = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.playConstructs = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblHonorCount = new System.Windows.Forms.Label();
            this.runeNum = new System.Windows.Forms.Label();
            this.powNum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblYourHonor = new System.Windows.Forms.Label();
            this.voidCombo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.portalCombo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.currentPlayNum = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.mechRuneNum = new System.Windows.Forms.Label();
            this.constRuneNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(434, 277);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buy Mystic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(863, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Buy HI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(863, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Kill Cultist";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Center Row";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(699, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "End Turn";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // playHand
            // 
            this.playHand.FormattingEnabled = true;
            this.playHand.Location = new System.Drawing.Point(332, 392);
            this.playHand.Name = "playHand";
            this.playHand.Size = new System.Drawing.Size(121, 21);
            this.playHand.TabIndex = 7;
            this.playHand.SelectedIndexChanged += new System.EventHandler(this.playHand_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Current Hand";
            // 
            // playPlay
            // 
            this.playPlay.FormattingEnabled = true;
            this.playPlay.Location = new System.Drawing.Point(486, 392);
            this.playPlay.Name = "playPlay";
            this.playPlay.Size = new System.Drawing.Size(121, 21);
            this.playPlay.TabIndex = 9;
            this.playPlay.SelectedIndexChanged += new System.EventHandler(this.playPlay_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "On Table";
            // 
            // playDisc
            // 
            this.playDisc.FormattingEnabled = true;
            this.playDisc.Location = new System.Drawing.Point(648, 392);
            this.playDisc.Name = "playDisc";
            this.playDisc.Size = new System.Drawing.Size(121, 21);
            this.playDisc.TabIndex = 11;
            this.playDisc.SelectedIndexChanged += new System.EventHandler(this.playDisc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Discard Pile";
            // 
            // playDeck
            // 
            this.playDeck.FormattingEnabled = true;
            this.playDeck.Location = new System.Drawing.Point(182, 392);
            this.playDeck.Name = "playDeck";
            this.playDeck.Size = new System.Drawing.Size(121, 21);
            this.playDeck.TabIndex = 13;
            this.playDeck.SelectedIndexChanged += new System.EventHandler(this.playDeck_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Deck";
            // 
            // playConstructs
            // 
            this.playConstructs.FormattingEnabled = true;
            this.playConstructs.Location = new System.Drawing.Point(49, 469);
            this.playConstructs.Name = "playConstructs";
            this.playConstructs.Size = new System.Drawing.Size(121, 21);
            this.playConstructs.TabIndex = 15;
            this.playConstructs.SelectedIndexChanged += new System.EventHandler(this.playConstructs_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Constructs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(634, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Runes";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(634, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Power:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Honor";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblHonorCount
            // 
            this.lblHonorCount.AutoSize = true;
            this.lblHonorCount.Location = new System.Drawing.Point(294, 27);
            this.lblHonorCount.Name = "lblHonorCount";
            this.lblHonorCount.Size = new System.Drawing.Size(13, 13);
            this.lblHonorCount.TabIndex = 20;
            this.lblHonorCount.Text = "0";
            this.lblHonorCount.Click += new System.EventHandler(this.label10_Click);
            // 
            // runeNum
            // 
            this.runeNum.AutoSize = true;
//<<<<<<< HEAD
            this.runeNum.Location = new System.Drawing.Point(679, 28);

          //  this.runeNum.Location = new System.Drawing.Point(693, 28);

            this.runeNum.Name = "runeNum";
            this.runeNum.Size = new System.Drawing.Size(13, 13);
            this.runeNum.TabIndex = 21;
            this.runeNum.Text = "0";
            // 
            // powNum
            // 
            this.powNum.AutoSize = true;
//<<<<<<< HEAD
            this.powNum.Location = new System.Drawing.Point(682, 57);

           // this.powNum.Location = new System.Drawing.Point(696, 57);
            this.powNum.Name = "powNum";
            this.powNum.Size = new System.Drawing.Size(13, 13);
            this.powNum.TabIndex = 22;
            this.powNum.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 450);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Your Honor";
            // 
            // lblYourHonor
            // 
            this.lblYourHonor.AutoSize = true;
            this.lblYourHonor.Location = new System.Drawing.Point(270, 450);
            this.lblYourHonor.Name = "lblYourHonor";
            this.lblYourHonor.Size = new System.Drawing.Size(13, 13);
            this.lblYourHonor.TabIndex = 24;
            this.lblYourHonor.Text = "0";
            // 
            // voidCombo
            // 
            this.voidCombo.FormattingEnabled = true;
            this.voidCombo.Location = new System.Drawing.Point(29, 340);
            this.voidCombo.Name = "voidCombo";
            this.voidCombo.Size = new System.Drawing.Size(121, 21);
            this.voidCombo.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(60, 321);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "The Void";
            // 
            // portalCombo
            // 
            this.portalCombo.FormattingEnabled = true;
            this.portalCombo.Location = new System.Drawing.Point(29, 234);
            this.portalCombo.Name = "portalCombo";
            this.portalCombo.Size = new System.Drawing.Size(121, 21);
            this.portalCombo.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(46, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Portal (For Testing)";
            // 
            // currentPlayNum
            // 
            this.currentPlayNum.AutoSize = true;
            this.currentPlayNum.Location = new System.Drawing.Point(370, 45);
            this.currentPlayNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPlayNum.Name = "currentPlayNum";
            this.currentPlayNum.Size = new System.Drawing.Size(39, 13);
            this.currentPlayNum.TabIndex = 29;
            this.currentPlayNum.Text = "Player ";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(180, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 23);
            this.button6.TabIndex = 30;
            this.button6.Text = "Play All ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // mechRuneNum
            // 
            this.mechRuneNum.AutoSize = true;
            this.mechRuneNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mechRuneNum.ForeColor = System.Drawing.SystemColors.Control;
//<<<<<<< HEAD
            this.mechRuneNum.Location = new System.Drawing.Point(716, 28);
            //this.mechRuneNum.Location = new System.Drawing.Point(730, 28);

            this.mechRuneNum.Name = "mechRuneNum";
            this.mechRuneNum.Size = new System.Drawing.Size(13, 13);
            this.mechRuneNum.TabIndex = 30;
            this.mechRuneNum.Text = "0";
            // 
            // constRuneNum
            // 
            this.constRuneNum.AutoSize = true;
            this.constRuneNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.constRuneNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.constRuneNum.Location = new System.Drawing.Point(756, 28);
            this.constRuneNum.Name = "constRuneNum";
            this.constRuneNum.Size = new System.Drawing.Size(13, 13);
            this.constRuneNum.TabIndex = 31;
            this.constRuneNum.Text = "0";
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1004, 544);
//<<<<<<< HEAD
            this.Controls.Add(this.constRuneNum);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.mechRuneNum);
            this.Controls.Add(this.currentPlayNum);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.portalCombo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.voidCombo);
            this.Controls.Add(this.lblYourHonor);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.powNum);
            this.Controls.Add(this.runeNum);
            this.Controls.Add(this.lblHonorCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.playConstructs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.playDeck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playDisc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playHand);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "BoardView";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.BoardView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox playHand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox playPlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox playDisc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox playDeck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox playConstructs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label runeNum;
        private System.Windows.Forms.Label powNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblYourHonor;
        private System.Windows.Forms.ComboBox voidCombo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox portalCombo;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblHonorCount;
        private System.Windows.Forms.Label currentPlayNum;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label mechRuneNum;
        private System.Windows.Forms.Label constRuneNum;
    }
}