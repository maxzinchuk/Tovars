using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Tovars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string allowed = "qwertyuiopasdgfhjklzxcvbvnmQWERTYUIOPASDFGHJKLZXCVBBNMM";
        int newIndexes = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox2.Text);
             }
            catch (Exception)
            {
                textBox2.Text = "0";
                return;
            }
            foreach (char item in textBox1.Text)
            {
                if (!allowed.Contains(item))
                {
                    textBox1.Text = "Tovar";
                    return;
                }
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows[newIndexes].Cells[0].Value = newIndexes;
            dataGridView1.Rows[newIndexes].Cells[1].Value = textBox1.Text;
            dataGridView1.Rows[newIndexes].Cells[2].Value = textBox2.Text;
            newIndexes++;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selected == dataGridView1.Rows.Count - 1) return;
            try
            {
                Convert.ToInt32(textBox2.Text);
            }
            catch (Exception)
            {
                textBox2.Text = "0";
                return;
            }
            foreach (char item in textBox1.Text)
            {
                if (!allowed.Contains(item))
                {
                    textBox1.Text = "Tovar";
                    return;
                }
            }
            try
            {
                dataGridView1.Rows[selected].Cells[1].Value = textBox1.Text;
                dataGridView1.Rows[selected].Cells[2].Value = textBox2.Text;
            }
            catch
            {

            }

            // newIndexes++;
        }

        public void save(string path) {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                    {
                        writer.WriteLine(dataGridView1.Rows[i].Cells[j].Value);
                    }
                }
                writer.Close();
            }

        }

        public void load(string path)
        {
            dataGridView1.Rows.Clear();
            newIndexes = 0;
            using (StreamReader writer = new StreamReader(path))
            {
                int lenght = 0;
                string line;
                while ((line = writer.ReadLine()) != null)
                {
                    if(lenght % 3 == 0)
                    {
                        newIndexes++;
                        dataGridView1.Rows.Add();
                    }
                    dataGridView1.Rows[lenght / 3].Cells[lenght % 3].Value = line;
                    lenght++;
                }
                writer.Close();
            }

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        int selected = 0;

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selected = e.RowIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save("Save.DBS");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            load("Save.DBS");

        }
    }
}
