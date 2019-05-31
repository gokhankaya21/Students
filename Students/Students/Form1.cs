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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
        private void generateStudents()
        {
            var student = new Student();
            for (int i = 1; i <= 100; i++)
            {
                students.Add(student.generateStudent(i));
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateStudents();
            dataGridView1.DataSource = students;            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var studentId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var student=(Student)students.Find(x => x.studentId == studentId);
            var form2 = new Form2(this, student);
            form2.Show();
        }
        public void insertStudent(Student student)
        {
            student.studentId = students.Count + 1;
            students.Add(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
        public void deleteStudent(Student student)
        {
            students.Remove(student);
            students.Add(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
    }
}
