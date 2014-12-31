using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigiSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void refresh()
        {
            //graphical representation of the form
            Graphics g = this.CreateGraphics();
            AndGate Test = new AndGate(964, 330);
            Pin[] all = new Pin[8];
            all[0] = new Pin(false);
            for (int i = 1; i < all.Length; i++)
            {
                all[i] = new Pin(true);
            }
            Test.setPins(all);
            Test.draw(ref g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
