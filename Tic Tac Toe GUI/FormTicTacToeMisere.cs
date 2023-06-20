using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeConsole.Model;
using TicTacToeConsole.Utillity;

namespace Tic_Tac_Toe_GUI
{
    public partial class FormTicTacToeMisere : Form
    {
        private readonly Dictionary<Button, Point> r_GameBoardButtonToLocation;
        private readonly Dictionary<Point, Button> r_LocationToGameBoardButton;
        private const bool v_IsButtonEnabled = true;
        private const string k_WinnerMessageBoxTitle = "A Win!";
        private const string k_TieMessageBoxTitle = "A Tie!";
        private GameLogic m_GameLogic;

        public FormTicTacToeMisere(eBoardSize i_BoardSize, bool i_IsGameAgainstMachine, string i_NameOfPlayer1, string i_NameOfPlayer2)
        {
            InitializeComponent();

            int boardSizeAsInteger = (int)i_BoardSize;

            this.m_GameLogic = new GameLogic(i_BoardSize, i_IsGameAgainstMachine, i_NameOfPlayer1, i_NameOfPlayer2);
            this.r_GameBoardButtonToLocation = new Dictionary<Button, Point>();
            this.r_LocationToGameBoardButton = new Dictionary<Point, Button>();
            m_GameLogic.TurnChanged += labels_TurnChanged;
            m_GameLogic.BoardChanged += markButtons_BoardChanged;
        }

        private void markButtons_BoardChanged(Point i_LocationOfChange, eBoardMark i_SymbolToPutInLocation)
        {
            Button gameBoardButtonToChangeText = r_LocationToGameBoardButton[i_LocationOfChange];
            gameBoardButtonToChangeText.Text = ((char)i_SymbolToPutInLocation).ToString();
            gameBoardButtonToChangeText.Enabled = !v_IsButtonEnabled;
        }

        private void FormTicTacToeMisere_Load(object sender, EventArgs e)
        {
            labelNamePlayer1.Text = m_GameLogic.GetNameOfPlayer(0);
            labelSemicolonPlayer1.Location = new Point(labelNamePlayer1.Location.X + labelNamePlayer1.Width, labelSemicolonPlayer1.Location.Y);
            labelScorePlayer1.Text = m_GameLogic.GetScoreOfPlayer(0).ToString();
            labelScorePlayer1.Location = new Point(labelSemicolonPlayer1.Location.X + labelSemicolonPlayer1.Width + 2, labelScorePlayer1.Location.Y);

            labelNamePlayer2.Text = m_GameLogic.GetNameOfPlayer(1);
            labelNamePlayer2.Location = new Point(labelScorePlayer1.Location.X + labelScorePlayer1.Width + 10, labelNamePlayer2.Location.Y);
            labelSemicolonPlayer2.Location = new Point(labelNamePlayer2.Location.X + labelNamePlayer2.Width, labelSemicolonPlayer2.Location.Y);
            labelScorePlayer2.Text = m_GameLogic.GetScoreOfPlayer(1).ToString();
            labelScorePlayer2.Location = new Point(labelSemicolonPlayer2.Location.X + labelSemicolonPlayer2.Width + 2, labelScorePlayer2.Location.Y);

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

            this.Height = flowLayoutPanelGameBoard.Height + 20;
            this.Width = flowLayoutPanelGameBoard.Width + 140;
            flowLayoutPanelGameBoard.Left = 70;
        }

        private void BoardMarkButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Point locationOfClickedButton = this.r_GameBoardButtonToLocation[clickedButton];

            m_GameLogic.ApplyMove(locationOfClickedButton);

            if (m_GameLogic.IsGameAgainstMachine)
            {
                if (!checkIsGameOver())
                {
                    Point locationOfComputerButtonMove = m_GameLogic.GenerateMachineMove();
                    m_GameLogic.ApplyMove(locationOfComputerButtonMove);
                    Button computerButtonMove = r_LocationToGameBoardButton[locationOfComputerButtonMove];
                }
            }

            if (checkIsGameOver())
            {
                displayGameOverMessage(m_GameLogic.GameState);
            }
        }

        private bool checkIsGameOver()
        {
            eGameState gameStateAfterMove = m_GameLogic.GameState;
            return gameStateAfterMove != eGameState.Running;
        }

        private void displayGameOverMessage(eGameState i_GameStateAfterMove)
        {
            labelScorePlayer1.Text = m_GameLogic.GetScoreOfPlayer(0).ToString();
            labelScorePlayer2.Text = m_GameLogic.GetScoreOfPlayer(1).ToString();

            string nameOfPlayer1 = m_GameLogic.GetNameOfPlayer(0);
            string nameOfPlayer2 = m_GameLogic.GetNameOfPlayer(1);

            string messageForUI = generateUIMessageFromGameState(i_GameStateAfterMove, nameOfPlayer1, nameOfPlayer2);
            string gameOverMessageBoxTitle = i_GameStateAfterMove == eGameState.FinishedTie ? k_TieMessageBoxTitle : k_WinnerMessageBoxTitle;
            DialogResult result = MessageBox.Show(messageForUI, gameOverMessageBoxTitle, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                restartGame();
            }

            if (result == DialogResult.No)
            {
                this.Close();
            }
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

        private void labels_TurnChanged(int i_NewTurnValue)
        {
            if (i_NewTurnValue == 0)
            {
                labelNamePlayer1.Font = new Font(labelNamePlayer1.Font, FontStyle.Bold);
                labelSemicolonPlayer1.Font = new Font(labelSemicolonPlayer1.Font, FontStyle.Bold);
                labelScorePlayer1.Font = new Font(labelScorePlayer1.Font, FontStyle.Bold);
                labelNamePlayer2.Font = new Font(labelNamePlayer2.Font, FontStyle.Regular);
                labelSemicolonPlayer2.Font = new Font(labelSemicolonPlayer2.Font, FontStyle.Regular);
                labelScorePlayer2.Font = new Font(labelScorePlayer2.Font, FontStyle.Regular);
            }
            else if (i_NewTurnValue == 1)
            {
                labelNamePlayer2.Font = new Font(labelNamePlayer2.Font, FontStyle.Bold);
                labelSemicolonPlayer2.Font = new Font(labelSemicolonPlayer2.Font, FontStyle.Bold);
                labelScorePlayer2.Font = new Font(labelScorePlayer2.Font, FontStyle.Bold);
                labelNamePlayer1.Font = new Font(labelNamePlayer1.Font, FontStyle.Regular);
                labelSemicolonPlayer1.Font = new Font(labelSemicolonPlayer1.Font, FontStyle.Regular);
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
