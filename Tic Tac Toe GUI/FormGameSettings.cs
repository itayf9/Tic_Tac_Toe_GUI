﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeConsole.Utillity;

namespace Tic_Tac_Toe_GUI
{
    public partial class FormGameSettings : Form
    {
        private const string k_ComputerName = "Computer";
        private const string k_NameOfNumbericUpDownRows = "numericUpDownRows";

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            string nameOfplayer2 = checkBoxPlayer2.Checked ? textBoxPlayer2.Text : k_ComputerName;
            this.Hide();
            new FormTicTacToeMisere((eBoardSize)numericUpDownRows.Value, !checkBoxPlayer2.Checked, textBoxPlayer1.Text, nameOfplayer2).ShowDialog();
            this.Close();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            const bool v_IsTextBoxEnable = true;

            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = v_IsTextBoxEnable;
                textBoxPlayer2.Text = string.Empty;
            }
            else
            {
                textBoxPlayer2.Enabled = !v_IsTextBoxEnable;
                textBoxPlayer2.Text = string.Format("[{0}]", k_ComputerName);
            }
        }

        private void numericUpDownRowOrCols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown senderAsNumbericUpDown = sender as NumericUpDown;
            if (senderAsNumbericUpDown.Name == k_NameOfNumbericUpDownRows)
            {
                numericUpDownCols.Value = numericUpDownRows.Value;
            }
            else
            {
                numericUpDownRows.Value = numericUpDownCols.Value;
            }
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = textBoxPlayer1.Text != string.Empty;
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            buttonStartGame.Enabled = textBoxPlayer2.Text != string.Empty;
        }
    }
}
