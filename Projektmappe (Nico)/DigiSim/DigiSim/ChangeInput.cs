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
    public partial class ChangeInput : Form
    {
        //Attribute
        bool complete = false;
        int Anzahl = 2;
        public ChangeInput()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ChangeInput_FormClosed);
        }

        void ChangeInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            complete = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Anzahl = Convert.ToInt32(textBox1.Text);
                complete = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ungültige Eingabe", "Fehler");
            }
        }
        public bool getComplete()
        {
            return complete;
        }
        public int getValue()
        {
            return Anzahl;
        }
    }
}
