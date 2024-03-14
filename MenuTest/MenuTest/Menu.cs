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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game SeaWar = new Game();
            this.Hide();
            SeaWar.Show();

        }

        private void оСоздателеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Игра была создана студентом группы О715Б Векслером Александром";
            MessageBox.Show(message);

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recs Records = new Recs();
            this.Hide();
            Records.Show();
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            Rules Window = new Rules();
            this.Hide();
            Window.Show();
        }

    }
}
