namespace Tic_Tac_Toe_GUI
{
    partial class FormTicTacToeMisere
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
            this.labelScorePlayer1 = new System.Windows.Forms.Label();
            this.labelScorePlayer2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelGameBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // labelScorePlayer1
            // 
            this.labelScorePlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelScorePlayer1.AutoSize = true;
            this.labelScorePlayer1.Location = new System.Drawing.Point(127, 510);
            this.labelScorePlayer1.Name = "labelScorePlayer1";
            this.labelScorePlayer1.Size = new System.Drawing.Size(82, 20);
            this.labelScorePlayer1.TabIndex = 0;
            this.labelScorePlayer1.Text = "Player 1: 0";
            this.labelScorePlayer1.Click += new System.EventHandler(this.labelScorePlayer1_Click);
            // 
            // labelScorePlayer2
            // 
            this.labelScorePlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelScorePlayer2.AutoSize = true;
            this.labelScorePlayer2.Location = new System.Drawing.Point(329, 510);
            this.labelScorePlayer2.Name = "labelScorePlayer2";
            this.labelScorePlayer2.Size = new System.Drawing.Size(96, 20);
            this.labelScorePlayer2.TabIndex = 1;
            this.labelScorePlayer2.Text = "Computer: 0";
            // 
            // flowLayoutPanelGameBoard
            // 
            this.flowLayoutPanelGameBoard.Location = new System.Drawing.Point(63, 34);
            this.flowLayoutPanelGameBoard.Name = "flowLayoutPanelGameBoard";
            this.flowLayoutPanelGameBoard.Size = new System.Drawing.Size(450, 450);
            this.flowLayoutPanelGameBoard.TabIndex = 3;
            // 
            // FormTicTacToeMisere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 565);
            this.Controls.Add(this.flowLayoutPanelGameBoard);
            this.Controls.Add(this.labelScorePlayer2);
            this.Controls.Add(this.labelScorePlayer1);
            this.Name = "FormTicTacToeMisere";
            this.Text = "Tic Tac Toe Misere";
            this.Load += new System.EventHandler(this.FormTicTacToeMisere_Load);
            this.SizeChanged += new System.EventHandler(this.FormTicTacToeMisere_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelScorePlayer1;
        private System.Windows.Forms.Label labelScorePlayer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGameBoard;
    }
}