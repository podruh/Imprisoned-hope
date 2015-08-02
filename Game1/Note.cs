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
    public partial class Note : Form
    {
        BuilderComponent BC;
        public int X, Y;
        public Note(int x, int y, BuilderComponent bc)
        {
            this.X = x;
            this.Y = y;
            this.BC = bc;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BC.VytvorNote(cmbNote.Text, txbNote.Text, this.X, this.Y);
            this.Close();
        }

        private void Note_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1000, 500);
        }
    }
}
