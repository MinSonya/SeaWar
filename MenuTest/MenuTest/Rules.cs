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
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void RulesMainMenu_Click(object sender, EventArgs e)
        {
            Menu MainMenu = new Menu();
            this.Hide();
            MainMenu.Show();
        }
    }
}
