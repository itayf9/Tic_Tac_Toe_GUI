using System;
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
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {



            this.Hide();
            new FormTicTacToeMisere((eBoardSize)numericUpDownRows.Value, checkBoxPlayer2.Checked, textBoxPlayer1.Text, textBoxPlayer2.Text).ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            const bool v_IsTextBoxEnable = true;
            const string k_ComputerName = "[Computer]";

            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = v_IsTextBoxEnable;
                textBoxPlayer2.Text = "";
            }
            else
            {
                textBoxPlayer2.Enabled = !v_IsTextBoxEnable;
                textBoxPlayer2.Text = k_ComputerName;
            }
        }

        private void numericUpDownRowOrCols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown senderAsNumbericUpDown = sender as NumericUpDown;
            if (senderAsNumbericUpDown.Name == "numericUpDownRows")
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
    }
}
