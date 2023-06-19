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
        private readonly Dictionary<Button, Point> r_GameBoardButtonToLocation;

        public FormTicTacToeMisere(eBoardSize i_BoardSize, bool i_IsGameAgainstMachine, string i_NameOfPlayer1, string i_NameOfPlayer2)
        {
            InitializeComponent();

            int boardSizeAsInteger = (int)i_BoardSize;

            this.m_GameLogic = new GameLogic(i_BoardSize, i_IsGameAgainstMachine, i_NameOfPlayer1, i_NameOfPlayer2);
            this.r_GameBoardButtonToLocation = new Dictionary<Button, Point>();

        }

        private void FormTicTacToeMisere_Load(object sender, EventArgs e)
        {
            labelNamePlayer1.Text = m_GameLogic.GetNameOfPlayer(0);
            labelNamePlayer2.Text = m_GameLogic.GetNameOfPlayer(1);
            labelScorePlayer1.Text = m_GameLogic.GetScoreOfPlayer(0).ToString();
            labelScorePlayer2.Text = m_GameLogic.GetScoreOfPlayer(1).ToString();

            for (int i = 0; i < m_GameLogic.GameBoardSize; i++)
            {
                for (int j = 0; j < m_GameLogic.GameBoardSize; j++)
                {
                    Button boardMarkButton = new Button();
                    boardMarkButton.Height = (flowLayoutPanelGameBoard.Height - 50) / m_GameLogic.GameBoardSize;
                    boardMarkButton.Width = (flowLayoutPanelGameBoard.Width - 50) / m_GameLogic.GameBoardSize;
                    boardMarkButton.Name = string.Format("button{0}_{1}", i, j);
                    boardMarkButton.Click += BoardMarkButton_Click;
                    this.r_GameBoardButtonToLocation.Add(boardMarkButton, new Point(j, i));
                    flowLayoutPanelGameBoard.Controls.Add(boardMarkButton);
                }
            }


        }

        private void BoardMarkButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point locationOfClickedButton = this.r_GameBoardButtonToLocation[clickedButton];
            m_GameLogic.ApplyMove(locationOfClickedButton);

            // check how we made the validation on EX2

            // check Game_state

            // notification for finish game (with the overload static method of MessageBox.Show)

            // reset game

            // update the text of the button OR
            // implement bonus (also add a comment in the sumbmission mail if we did so)

            // decide if the game board is resizeable
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
