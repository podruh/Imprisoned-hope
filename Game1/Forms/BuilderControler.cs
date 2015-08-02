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
    public partial class BuilderControler : Form
    {
        private BuilderComponent BC;
        private MapManager Manager;
        public BuilderControler(BuilderComponent bc, MapManager mana)
        {
            this.BC = bc;
            this.Manager = mana;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BC.PrepniMapu(comboBox1.SelectedItem.ToString()); 
            
        }

        private void BuilderControler_Load(object sender, EventArgs e)
        {
            string[] names = Manager.GetMapNameArray();
            comboBox1.Items.AddRange(names);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            BC.UlozMapy();            
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            Manager.Nahrat();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Manager.GetMapNameArray());
        }

        private void newMapBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Zadej název nové mapy!");
            }
            else
            {
                BC.NovaMapa(textBox1.Text);
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(Manager.GetMapNameArray());

                foreach (var item in comboBox1.Items)
                {
                    if (item.ToString() == textBox1.Text)
                    {
                        comboBox1.SelectedItem = item;
                    }
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BuilderControler_FormClosing(object sender, FormClosingEventArgs e)
        {
            BC.Zavri();
        }

        private void BuilderControler_MouseEnter(object sender, EventArgs e)
        {
        }

        private void BuilderControler_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BC.ChangePromptState(true);
        }
    }
}
