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
    public partial class Browser : Form
    {        
        public Browser()
        {
            InitializeComponent();
            title();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            title();
            if (e.KeyCode == Keys.Enter)
            {
                this.webBrowser1.Navigate(textBox1.Text);
            }            
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh();
            title();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
            title();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoForward();
            title();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://www.google.com");
            title();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = this.webBrowser1.Url.ToString();
            title();
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://www.google.com");
            title();
        }
        private void title()
        {
            string doc = webBrowser1.DocumentTitle;
            this.Text = doc;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.CurrentProgress < e.MaximumProgress)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                progressBar1.Value = Convert.ToInt32(e.MaximumProgress);
            }
            else
            {
                progressBar1.Value = 0;
            }
        }
    }
}
