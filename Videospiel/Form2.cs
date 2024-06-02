using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videospiel
{
    public partial class Form2 : Form
    {
        private int mintKulickaX;
        private int mintKulickaY;
        public string txtbox;

        // Constructor accepting the values
        public Form2()
        {
            InitializeComponent();
            mintKulickaX = 200;
            mintKulickaY = 200;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            form1?.Close();
            this.Close();
        }
       
            private Form1 form1Instance;

            public Form2(Form1 form1)
            {
                InitializeComponent();
                form1Instance = form1;
            }

            // Example method that uses blVisible
            private void SomeMethod()
            {
                bool blVisible = form1Instance.blVisible;
                // Use isVisible as needed
            }
        
        private void btRestart_Click(object sender, EventArgs e)
        {
            mintKulickaX = 200;
            mintKulickaY = 200;
            bool blVisible = form1Instance.blVisible;
            blVisible = true;
        }
    }
}
