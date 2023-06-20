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
        private const bool v_IsButtonEnabled = true;
        private const string k_GameOverMessageBoxTitle = "Game Over!";
        private GameLogic m_GameLogic;
        private readonly Dictionary<Button, Point> r_GameBoardButtonToLocation;
        private readonly Dictionary<Point, Button> r_LocationToGameBoardButton;

        public FormTicTacToeMisere(eBoardSize i_BoardSize, bool i_IsGameAgainstMachine, string i_NameOfPlayer1, string i_NameOfPlayer2)
        {
            InitializeComponent();

            int boardSizeAsInteger = (int)i_BoardSize;

            this.m_GameLogic = new GameLogic(i_BoardSize, i_IsGameAgainstMachine, i_NameOfPlayer1, i_NameOfPlayer2);
            this.r_GameBoardButtonToLocation = new Dictionary<Button, Point>();
            this.r_LocationToGameBoardButton = new Dictionary<Point, Button>();
            m_GameLogic.TurnChanged += changeTurnInUI;

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
                    Point locationOfButton = new Point(j, i);
                    this.r_GameBoardButtonToLocation.Add(boardMarkButton, locationOfButton);
                    this.r_LocationToGameBoardButton.Add(locationOfButton, boardMarkButton);
                    flowLayoutPanelGameBoard.Controls.Add(boardMarkButton);
                }
            }
        }

        private void BoardMarkButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point locationOfClickedButton = this.r_GameBoardButtonToLocation[clickedButton];

            m_GameLogic.ApplyMove(locationOfClickedButton);
            clickedButton.Enabled = !v_IsButtonEnabled;
            if (m_GameLogic.IsGameAgainstMachine)
            {
                clickedButton.Text = ((char)eBoardMark.PlayerX).ToString();
                if (!checkIsGameOverAndDisplayMessage())
                {
                    Point locationOfComputerButtonMove = m_GameLogic.GenerateMachineMove();
                    m_GameLogic.ApplyMove(locationOfComputerButtonMove);
                    Button computerButtonMove = r_LocationToGameBoardButton[locationOfComputerButtonMove];
                    computerButtonMove.Text = ((char)eBoardMark.PlayerO).ToString();
                    computerButtonMove.Enabled = !v_IsButtonEnabled;
                }
            }
            else
            {
                clickedButton.Text = m_GameLogic.Turn == 0 ? ((char)eBoardMark.PlayerX).ToString() : ((char)eBoardMark.PlayerO).ToString();
            }

            checkIsGameOverAndDisplayMessage();

            // check how we made the validation on EX2 // DONE

            // check Game_state // DONE

            // notification for finish game (with the overload static method of MessageBox.Show) // DONE

            // reset game // DONE

            // update the text of the button OR
            // implement bonus (also add a comment in the sumbmission mail if we did so), All Yours

            // decide if the game board is resizeable, All Yours
        }

        private bool checkIsGameOverAndDisplayMessage()
        {
            eGameState gameStateAfterMove = m_GameLogic.GameState;
            bool isGameOver = gameStateAfterMove != eGameState.Running;
            if (isGameOver)
            {
                labelScorePlayer1.Text = m_GameLogic.GetScoreOfPlayer(0).ToString();
                labelScorePlayer2.Text = m_GameLogic.GetScoreOfPlayer(1).ToString();

                string nameOfPlayer1 = m_GameLogic.GetNameOfPlayer(0);
                string nameOfPlayer2 = m_GameLogic.GetNameOfPlayer(1);

                string messageForUI = generateUIMessageFromGameState(gameStateAfterMove, nameOfPlayer1, nameOfPlayer2);
                DialogResult result = MessageBox.Show(messageForUI, k_GameOverMessageBoxTitle, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    restartGame();
                }

                if (result == DialogResult.No)
                {
                    this.Close();
                }
            }

            return isGameOver;
        }

        private string generateUIMessageFromGameState(eGameState i_GameState, string i_NameOfPlayer1, string i_NameOfPlayer2)
        {
            string messageForUI = string.Empty;
            string winnerMessage = "The winner is {0}!\nWould you like to play another round?";
            string tieMessage = "Tie!\nWould you like to play another round?";

            switch (i_GameState)
            {
                case eGameState.FinishedTie:
                    messageForUI = tieMessage;
                    break;
                case eGameState.FinishedP1:
                    messageForUI = string.Format(winnerMessage, i_NameOfPlayer1);
                    break;
                case eGameState.FinishedP2:
                    messageForUI = string.Format(winnerMessage, i_NameOfPlayer2);
                    break;
            }

            return messageForUI;
        }

        private void FormTicTacToeMisere_SizeChanged(object sender, EventArgs e)
        {
        }

        private void labelScorePlayer1_Click(object sender, EventArgs e)
        {
        }

        private void changeTurnInUI(int i_NewTurnValue)
        {
            if (i_NewTurnValue == 0)
            {
                labelNamePlayer1.Font = new Font(labelNamePlayer1.Font, FontStyle.Bold);
                labelScorePlayer1.Font = new Font(labelScorePlayer1.Font, FontStyle.Bold);
                labelNamePlayer2.Font = new Font(labelNamePlayer2.Font, FontStyle.Regular);
                labelScorePlayer2.Font = new Font(labelScorePlayer2.Font, FontStyle.Regular);
            }
            else if (i_NewTurnValue == 1)
            {
                labelNamePlayer2.Font = new Font(labelNamePlayer2.Font, FontStyle.Bold);
                labelScorePlayer2.Font = new Font(labelScorePlayer2.Font, FontStyle.Bold);
                labelNamePlayer1.Font = new Font(labelNamePlayer1.Font, FontStyle.Regular);
                labelScorePlayer1.Font = new Font(labelScorePlayer1.Font, FontStyle.Regular);
            }
        }

        private void restartGame()
        {
            m_GameLogic.ResetGameBoard();
            foreach (Button boardMarkbutton in r_GameBoardButtonToLocation.Keys)
            {
                boardMarkbutton.Text = string.Empty;
                boardMarkbutton.Enabled = v_IsButtonEnabled;
            }
        }
    }
}
