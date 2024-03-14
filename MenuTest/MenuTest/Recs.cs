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
    public partial class Recs : Form
    {
        public Recs()
        {
            InitializeComponent();
        }

        private void RecMainMenu_Click(object sender, EventArgs e)
        {
            Menu MainMenu = new Menu();
            this.Hide();
            MainMenu.Show();
        }

        private void RecExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Recs_Load(object sender, EventArgs e)
        {
                Font font = new Font("Franklin Gothic Medium", 11.25f);
                RecordsWriter.OpenNewFile("records");
                Label NameRecords = new Label();
                NameRecords.Text = "";
                NameRecords.Location = new Point(165, 140);
                NameRecords.AutoSize = true;
                NameRecords.Font = font;
                Label Records = new Label();
                Records.Text = "";
                NameRecords.Font = font;
                Records.Location = new Point(474, 140);
                Records.AutoSize = true;
                Records.Font = font;
                for (int i = 0; i < RecordsWriter.maxRecordsAmount; i++)
                {
                    if (RecordsWriter.records[i] != 999999999) // Если запись имеется (999999999 - значение создаётся по умолчанию, записи нет, не выводим)
                        NameRecords.Text += RecordsWriter.GetNameRecordString(i) + "\n";
                }
                for (int i = 0; i < RecordsWriter.maxRecordsAmount; i++)
                {
                    if (RecordsWriter.records[i] != 999999999) // Если запись имеется (999999999 - значение создаётся по умолчанию, записи нет, не выводим)
                        Records.Text += RecordsWriter.GetRecordString(i) + "\n";
                }
                this.Controls.Add(NameRecords);
            this.Controls.Add(Records);
        }
    }
}