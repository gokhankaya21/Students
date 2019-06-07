using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class Minefield : Form
    {
        Form1 form1;
        StartGame.GameType gameType = StartGame.GameType.Easy;
        public Minefield()
        {
            InitializeComponent();
            
        }
        public Minefield(Form1 sender)
        {
            InitializeComponent();
            this.form1 = sender;
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            gameType = StartGame.GameType.Hard;
            hardButton.BackColor = Color.Blue;
            easyButton.BackColor = Color.NavajoWhite;
            mediumButton.BackColor = Color.NavajoWhite;
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            gameType = StartGame.GameType.Medium;
            mediumButton.BackColor = Color.Blue;
            easyButton.BackColor = Color.NavajoWhite;
            hardButton.BackColor = Color.NavajoWhite;
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            gameType = StartGame.GameType.Easy;
            easyButton.BackColor = Color.Blue;
            mediumButton.BackColor = Color.NavajoWhite;
            hardButton.BackColor = Color.NavajoWhite;
        }
        private void startGameButton_Click(object sender, EventArgs e)
        {
            var startGame = new StartGame(form1,gameType);
            startGame.Show();
        }
    }
}
