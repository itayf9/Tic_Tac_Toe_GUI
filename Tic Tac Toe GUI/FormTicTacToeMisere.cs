using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeConsole.Model;
using TicTacToeConsole.Utillity;

namespace Tic_Tac_Toe_GUI
{
    public partial class FormTicTacToeMisere : Form
    {
        private GameLogic m_GameLogic;
        private readonly Button[,] r_GameBoardButtonMatrix;

        public FormTicTacToeMisere(eBoardSize i_BoardSize, bool i_IsGameAgainstMachine)
        {
            InitializeComponent();

            int boardSizeAsInteger = (int)i_BoardSize;

            this.m_GameLogic = new GameLogic(i_BoardSize, i_IsGameAgainstMachine);
            this.r_GameBoardButtonMatrix = new Button[boardSizeAsInteger, boardSizeAsInteger];

        }

        private void FormTicTacToeMisere_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_GameLogic.GameBoardSize; i++)
            {
                for (int j = 0; j < m_GameLogic.GameBoardSize; j++)
                {
                    Button boardMarkButton = new Button();
                    boardMarkButton.Height = (flowLayoutPanelGameBoard.Height - 50) / m_GameLogic.GameBoardSize;
                    boardMarkButton.Width = (flowLayoutPanelGameBoard.Width - 50) / m_GameLogic.GameBoardSize;
                    boardMarkButton.Name = string.Format("button{0}_{1}", i, j);
                    this.r_GameBoardButtonMatrix[i,j] = boardMarkButton;
                    flowLayoutPanelGameBoard.Controls.Add(boardMarkButton);
                }
            }


        }

        private void FormTicTacToeMisere_SizeChanged(object sender, EventArgs e)
        {
            /*tableLayoutPanelGameBoard.Height = this.Height - 10;
            tableLayoutPanelGameBoard.Width = this.Width - 10;*/
        }

        private void labelScorePlayer1_Click(object sender, EventArgs e)
        {

        }
    }
}
