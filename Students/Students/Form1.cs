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
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        int sortedColumnIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);
            form2.Show();
        }
        private void generateStudent()
        {
            var student = new Student();
            students = student.GenerateStudents(100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateStudent();
            dataGridView1.DataSource = students;
            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Surname";
            dataGridView1.Columns[3].HeaderText = "Phone";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.Columns[5].HeaderText = "State";
            dataGridView1.Columns[6].HeaderText = "Grade";

            fillStateCombobox();
            averageLabel.Text = students.Average(x => x.grade).ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                var student = (Student)students.Find(x => x.studentId == studentId);
                var form2 = new Form2(this,student);
                form2.Show();
            }
        }
        public void insertStudent(Student student)
        {
            student.studentId = students.Count + 1;
            students.Add(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
            averageLabel.Text = students.Average(x => x.grade).ToString();
        }
        public void deleteStudent(Student student)
        {
            students.Remove(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
            averageLabel.Text = students.Average(x => x.grade).ToString();
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextbox.Text.Length == 0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var searchedStudents = students.FindAll(x => x.name.ToLower().Contains(searchTextbox.Text) || x.surname.ToLower().Contains(searchTextbox.Text.ToLower()));
                dataGridView1.DataSource = searchedStudents;
            }
        }
        private void fillStateCombobox()
        {
            var states = students.GroupBy(x => x.state).Select(grp => grp.First()).OrderBy(x => x.state).ToList();
            var s = new Student();
            s.state = "ALL";
            states.Insert(0, s);
            stateCombobox.DataSource = states;
            stateCombobox.ValueMember = "state";
            stateCombobox.DisplayMember = "state";
        }

        private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stateCombobox.SelectedIndex==0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var filtredStudents = students.FindAll(x => x.state == stateCombobox.SelectedValue.ToString());
                dataGridView1.DataSource = filtredStudents;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (sortedColumnIndex==e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.studentId).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.studentId).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 1:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.name).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.name).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 2:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.surname).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.surname).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 3:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.phone).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.phone).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 4:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.email).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.email).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 5:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.state).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.state).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 6:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.grade).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.grade).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.Yellow;
                }
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var browser = new Browser();
            browser.Show();
        }

        private void minefieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var minefield = new Minefield(this);
            minefield.Show();
        }
    }
}
