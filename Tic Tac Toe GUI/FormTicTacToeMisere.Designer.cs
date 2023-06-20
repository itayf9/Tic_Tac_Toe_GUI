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
            this.labelNamePlayer1 = new System.Windows.Forms.Label();
            this.labelNamePlayer2 = new System.Windows.Forms.Label();
            this.labelSemicolonPlayer1 = new System.Windows.Forms.Label();
            this.labelSemicolonPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelScorePlayer1
            // 
            this.labelScorePlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelScorePlayer1.AutoSize = true;
            this.labelScorePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelScorePlayer1.Location = new System.Drawing.Point(161, 509);
            this.labelScorePlayer1.Name = "labelScorePlayer1";
            this.labelScorePlayer1.Size = new System.Drawing.Size(19, 20);
            this.labelScorePlayer1.TabIndex = 0;
            this.labelScorePlayer1.Text = "0";
            this.labelScorePlayer1.Click += new System.EventHandler(this.labelScorePlayer1_Click);
            // 
            // labelScorePlayer2
            // 
            this.labelScorePlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelScorePlayer2.AutoSize = true;
            this.labelScorePlayer2.Location = new System.Drawing.Point(338, 509);
            this.labelScorePlayer2.Name = "labelScorePlayer2";
            this.labelScorePlayer2.Size = new System.Drawing.Size(18, 20);
            this.labelScorePlayer2.TabIndex = 1;
            this.labelScorePlayer2.Text = "0";
            // 
            // flowLayoutPanelGameBoard
            // 
            this.flowLayoutPanelGameBoard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanelGameBoard.Location = new System.Drawing.Point(63, 34);
            this.flowLayoutPanelGameBoard.Name = "flowLayoutPanelGameBoard";
            this.flowLayoutPanelGameBoard.Size = new System.Drawing.Size(450, 450);
            this.flowLayoutPanelGameBoard.TabIndex = 3;
            // 
            // labelNamePlayer1
            // 
            this.labelNamePlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNamePlayer1.AutoSize = true;
            this.labelNamePlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelNamePlayer1.Location = new System.Drawing.Point(71, 509);
            this.labelNamePlayer1.Name = "labelNamePlayer1";
            this.labelNamePlayer1.Size = new System.Drawing.Size(73, 20);
            this.labelNamePlayer1.TabIndex = 4;
            this.labelNamePlayer1.Text = "Player 1";
            // 
            // labelNamePlayer2
            // 
            this.labelNamePlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNamePlayer2.AutoSize = true;
            this.labelNamePlayer2.Location = new System.Drawing.Point(240, 509);
            this.labelNamePlayer2.Name = "labelNamePlayer2";
            this.labelNamePlayer2.Size = new System.Drawing.Size(79, 20);
            this.labelNamePlayer2.TabIndex = 5;
            this.labelNamePlayer2.Text = "Computer";
            // 
            // labelSemicolonPlayer1
            // 
            this.labelSemicolonPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelSemicolonPlayer1.AutoSize = true;
            this.labelSemicolonPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSemicolonPlayer1.Location = new System.Drawing.Point(142, 509);
            this.labelSemicolonPlayer1.Name = "labelSemicolonPlayer1";
            this.labelSemicolonPlayer1.Size = new System.Drawing.Size(14, 20);
            this.labelSemicolonPlayer1.TabIndex = 6;
            this.labelSemicolonPlayer1.Text = ":";
            // 
            // labelSemicolonPlayer2
            // 
            this.labelSemicolonPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelSemicolonPlayer2.AutoSize = true;
            this.labelSemicolonPlayer2.Location = new System.Drawing.Point(319, 509);
            this.labelSemicolonPlayer2.Name = "labelSemicolonPlayer2";
            this.labelSemicolonPlayer2.Size = new System.Drawing.Size(13, 20);
            this.labelSemicolonPlayer2.TabIndex = 7;
            this.labelSemicolonPlayer2.Text = ":";
            // 
            // FormTicTacToeMisere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 564);
            this.Controls.Add(this.labelSemicolonPlayer2);
            this.Controls.Add(this.labelSemicolonPlayer1);
            this.Controls.Add(this.labelNamePlayer2);
            this.Controls.Add(this.labelNamePlayer1);
            this.Controls.Add(this.flowLayoutPanelGameBoard);
            this.Controls.Add(this.labelScorePlayer2);
            this.Controls.Add(this.labelScorePlayer1);
            this.MinimumSize = new System.Drawing.Size(600, 620);
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
        private System.Windows.Forms.Label labelNamePlayer1;
        private System.Windows.Forms.Label labelNamePlayer2;
        private System.Windows.Forms.Label labelSemicolonPlayer1;
        private System.Windows.Forms.Label labelSemicolonPlayer2;
    }
}