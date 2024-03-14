using SeaWars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTest
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void NameString_TextChanged(object sender, EventArgs e)
        {
            string Name = NameString.Text;
            RecordsWriter.nickname = NameString.Text;
        }

        private void EnteringName_Click(object sender, EventArgs e)
        {
            Menu MainMenu = new Menu();
            this.Hide();
            MainMenu.Show();
        }
    }
}
