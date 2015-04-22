using Microsoft.Xna.Framework.Graphics;
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
    public partial class BuilderPromtp : Form
    {
        BuilderComponent BC;
        int X, Y;

        public BuilderPromtp(BuilderComponent build, int x, int y)
        {
            BC = build;
            this.X = x;
            this.Y = y;
            InitializeComponent();
        }

        private void BuilderPromtp_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BC.VytvorBlok(comboBox1.SelectedItem.ToString(), Convert.ToInt32(numericUpDown1.Value), comboBox2.SelectedItem.ToString(), X, Y);
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuilderPromtp_FormClosing(object sender, FormClosingEventArgs e)
        {
            BC.PrepniPrompt();
        }
    }
}
