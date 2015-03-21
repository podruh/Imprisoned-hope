using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imprisoned_Hope
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newGame_btn_Click(object sender, EventArgs e)
        {
            newGame_btn.Location = new Point(newGame_btn.Location.X, newGame_btn.Location.Y + 500);
            loadGame_btn.Location = new Point(loadGame_btn.Location.X, loadGame_btn.Location.Y + 500);
            optins_btn.Location = new Point(optins_btn.Location.X, optins_btn.Location.Y + 500);
            exit_btn.Location = new Point(exit_btn.Location.X, exit_btn.Location.Y + 500);
            PictureBox test_btn = new PictureBox();
            test_btn.BackgroundImage = Imprisoned_Hope.Properties.Resources.Options;
            test_btn.Location = new Point(721+500,397);
            test_btn.Location = new Point(test_btn.Location.X,test_btn.Location.Y - 500);
        }

        private void loadGame_btn_Click(object sender, EventArgs e)
        {

        }

        private void optins_btn_Click(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult konec_dr = MessageBox.Show("Opravdu ukončit?", "Konec", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (konec_dr == DialogResult.Yes)
                this.Close();
        }
    }
}
