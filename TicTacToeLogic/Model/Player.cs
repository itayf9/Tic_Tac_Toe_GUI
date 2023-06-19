using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeConsole.Utillity;

namespace TicTacToeConsole.Model
{
    public class Player
    {
        private int m_Score;
        private readonly eBoardMark r_Symbol;
        private readonly string r_Name;

        public Player(eBoardMark i_Symbol, string i_Name)
        {
            this.m_Score = 0;
            this.r_Symbol = i_Symbol;
            this.r_Name = i_Name;
        }

        public eBoardMark Symbol
        {
            get
            {
                 return r_Symbol;
            }
        }

        public int Score
        {
            get
            {
                 return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public string Name
        {
            get { return r_Name; }
        }
    }
}
