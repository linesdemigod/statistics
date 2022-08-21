using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace statistic_and_probability
{
    public partial class Progressbar : Form
    {
        public Progressbar()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;
            if (panel2.Width >= 406)
            {
                Form1 app = new Form1();
                //OPEN THE APP FORM
                app.Show();

                //hide the progressbar
                Hide();
                timer2.Enabled = false;
            }
        }
    }
}
