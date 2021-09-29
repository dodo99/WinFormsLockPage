using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLockPage
{
    public partial class Form1 : Form
    {

        bool page1Locked = false;
        bool page3Locked = false;
        int lockedPage = -1;
        int currentPage = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page1Locked = !page1Locked;

            if (page1Locked == true)
            {
                ((Button)sender).Text = "Realase page (1)";
                lockedPage = currentPage;
            }
            else
            {
                ((Button)sender).Text = "Lock this page (1)";
                lockedPage = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            page3Locked = !page3Locked;

            if (page3Locked == true)
            {
                ((Button)sender).Text = "Realase page (3)";
                lockedPage = currentPage;
            }
            else
            {
                ((Button)sender).Text = "Lock this page (3)";
                lockedPage = -1;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            currentPage = e.TabPageIndex;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (lockedPage >= 0 && e.TabPageIndex != lockedPage)
                e.Cancel = true;
        }

    }
}
