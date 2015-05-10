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
    public partial class LoadGameForm : Form
    {
        private SaveManager SaveManager;
        private Gameplay gamePlay;
        public LoadGameForm(SaveManager sm, Gameplay gp)
        {
            this.SaveManager = sm;
            gamePlay = gp;
            InitializeComponent();
        }

        private void LoadGameForm_Load(object sender, EventArgs e)
        {
            
            string[] Jmena = SaveManager.GetNameArray();
            listBox1.Items.AddRange(Jmena);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem !=null)
            {
                gamePlay.LoadGameByname(listBox1.SelectedItem.ToString());
                this.Close();
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox1.SelectedItem.ToString();
        }
    }
}
