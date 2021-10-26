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
        //bool page3Locked = false;
        bool page2Enabled = false;
        int lockedPage = -1;
        int currentPage = 0;
        TabPage myTabPage;
        MyUserPage myUserPage;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            page1Locked = !page1Locked;

            if (page1Locked == true)
            {
                ((Button)sender).Text = "Unlock \"Page 1\"";
                lockedPage = currentPage;
            }
            else
            {
                ((Button)sender).Text = "Lock \"Page 1\"";
                lockedPage = -1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            lockedPage = 3;
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

        private void button5_Click(object sender, EventArgs e)
        {

            page2Enabled = !page2Enabled;

            if (page2Enabled == true)
            {
                ((Button)sender).Text = "Enable \"Page 2\"";
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == "Page 2")
                        tab.Enabled = false;
                }
            }
            else
            {
                ((Button)sender).Text = "Disable \"Page 2\"";
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == "Page 2")
                        tab.Enabled = true;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked me.");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //make sure we don't shoot ourself in the foot
            if (lockedPage == 3 && currentPage == 3)
                lockedPage = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myTabPage = new TabPage();
            myTabPage.Location = new System.Drawing.Point(4, 22);
            myTabPage.Name = "myTaPage";
            myTabPage.Padding = new System.Windows.Forms.Padding(3);
            myTabPage.Size = new System.Drawing.Size(600, 300);
            myTabPage.TabIndex = 1;
            myTabPage.Text = "My Page";

            myUserPage = new MyUserPage();
            myTabPage.Controls.Add(myUserPage);

            tabControl1.Controls.Add(myTabPage);

            myUserPage.OnMyUserPageLocked += new MyUserPage.MyUserPageLocked(LockMyUserPage);
            myUserPage.OnMyUserPageUnLocked += new MyUserPage.MyUserPageUnLocked(UnLockMyUserPage);

        }

        private void LockMyUserPage(object sender, EventArgs e)
        {
            //4 is "My Page" index
            lockedPage = 4;
        }

        private void UnLockMyUserPage(object sender, EventArgs e)
        {
            //reset
            lockedPage = -1;
        }
    }
}
