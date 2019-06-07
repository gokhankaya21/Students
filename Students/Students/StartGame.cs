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
    public partial class StartGame : Form
    {
        
        public enum GameType { Easy, Medium, Hard }
        GameType gameType;
        List<int> mines = new List<int>();
        List<Button> fields = new List<Button>();
        Random rnd = new Random();
        
        int score = 0;
        Form1 form1;
        public StartGame(Form1 sender)
        {
            InitializeComponent();
            this.form1 = sender;
        }
        public StartGame(Form1 sender,GameType gameType)
        {
            InitializeComponent();
            this.form1 = sender;
            this.gameType = gameType;
        }
            private void StartGame_Load(object sender, EventArgs e)
        {
            createMinefield(30,30);            
        }
        private void createMinefield(int width,int height)
        {
            
            int buttonSize = 12;
            int margin = 1;

            for(int row=0; row < height; row++)
            {
                for(int col=0; col < width; col++)
                {
                    var field = new Button();
                    field.Size = new Size(buttonSize, buttonSize);
                    field.Top = (buttonSize + margin) * row;
                    field.Left = (buttonSize + margin) * col;
                    field.Tag = (row + 1) * col;
                    field.FlatStyle = FlatStyle.Popup;
                    field.Click += new EventHandler(this.fieldButton_Click);
                    this.Controls.Add(field);
                    fields.Add(field);
                }
            }
            createMines(height * width);
        }
        private void createMines(int fieldCount)
        {
            int mineCount = 0;
            switch (gameType)
            {
                case GameType.Easy:
                    mineCount = Convert.ToInt16(fieldCount * 0.10);
                    break;
                case GameType.Medium:
                    mineCount = Convert.ToInt16(fieldCount * 0.25);
                    break;
                case GameType.Hard:
                    mineCount = Convert.ToInt16(fieldCount * 0.50);
                    break;
                default:
                    break;
            }
            
            for (int i = 0; i <= mineCount; i++)
            {
                mines.Add(createMine(fieldCount));
                
            }
        }
        private int createMine(int fieldCount)
        {
            int m = rnd.Next(0,fieldCount);
            if (mines.Contains(m))
            {
                return createMine(fieldCount);
            }
            else
            {
                return m;
            }
        }
        void fieldButton_Click(object sender,EventArgs e)
        {
            var field = (Button)sender;
            if (mines.Contains(Convert.ToInt16(field.Tag)))
            {
                field.BackColor = Color.Red;   
                foreach(int mine in mines)
                {
                    var b = fields[mine];
                    if (b!=field)
                    {
                        b.BackColor = Color.Black;
                    }
                }
                gameOver();
            }
            else
            {
                field.BackColor = Color.Green;
                switch (gameType)
                {
                    case GameType.Easy:
                        score += 1;
                        scoreLabel.Text = score.ToString();
                        break;
                    case GameType.Medium:
                        score += 5;
                        scoreLabel.Text = score.ToString();
                        break;
                    case GameType.Hard:
                        score += 10;
                        scoreLabel.Text = score.ToString();
                        break;
                    default:
                        break;
                }
                field.Enabled = false;
            }
        }
        private void gameOver()
        {
            var result = MessageBox.Show("GAME OVER");
            var student = new Student();
            student = student.GenerateStudent(0);
            student.grade = score;
            form1.insertStudent(student);
            this.Close();            
        }
    }
}
