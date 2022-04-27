using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetHTMLService;

namespace HTMLReadTest
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = urlText.Text;

            //値が空なら処理はスキップする
            if (String.IsNullOrEmpty(url)) return;

            try
            {
                GetHTMLClass getHTML = new GetHTMLClass();
                var value = await getHTML.GetAsync(url);
                ResultText.Text = value;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GetHTMLClass getHTML = new GetHTMLClass();
                string value =  getHTML.DllTestString();
                ResultText.Text = value;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
