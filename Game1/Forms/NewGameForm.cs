using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Imprisoned_Hope
{
    public partial class NewGameForm : Form
    {
        private MenuComponent MC;
        private string Trida;
        public NewGameForm(MenuComponent mc, string trida)
        {
            MC = mc;
            Trida = trida;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                MC.NewGame(textBox1.Text, Trida);
                this.Close();
            }
            else
            {
                MessageBox.Show("zadejte jméno!");
            }
        }

        private void NewGameForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
