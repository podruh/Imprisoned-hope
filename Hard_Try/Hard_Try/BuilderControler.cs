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
        private MapManager manager;
        public BuilderControler(MapManager map)
        {
            manager = map;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BuilderControler_Load(object sender, EventArgs e)
        {
            string[] names = manager.GetMapNameArray();
            comboBox1.Items.AddRange(names);
        }
    }
}
