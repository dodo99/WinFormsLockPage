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
    public partial class MyUserPage : UserControl
    {

        public delegate void MyUserPageLocked(object sender, EventArgs e);
        public MyUserPageLocked OnMyUserPageLocked;
        public delegate void MyUserPageUnLocked(object sender, EventArgs e);
        public MyUserPageUnLocked OnMyUserPageUnLocked;

        private bool isPageLocked = false;

        public MyUserPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isPageLocked)
            {
                button1.Text = "Unlock Me";
                OnMyUserPageLocked?.Invoke(this, null);
                button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            }
            else
            {
                button1.Text = "Lock Me";
                button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                OnMyUserPageUnLocked?.Invoke(this, null);
            }
            isPageLocked = !isPageLocked;
        }
    }
}
