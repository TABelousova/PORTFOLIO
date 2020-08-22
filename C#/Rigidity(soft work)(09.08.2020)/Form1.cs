using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Жесткости
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Ed = new string[dataGridView1.RowCount];
            int[] ED = new int[dataGridView1.RowCount];
            int [] Vs = new int[dataGridView1.RowCount];
            string[] P = new string[dataGridView1.RowCount];
            double[] flt_P = new double[dataGridView1.RowCount];
            float[] Rigidty = new float[dataGridView1.RowCount];
            bool Check = true;
            for (int i=0; i< dataGridView1.RowCount - 1 ; i++)
            {
                if (dataGridView1[0, i].Value != null && dataGridView1[1, i].Value != null)
                {
                    Ed[i] = dataGridView1[0, i].Value.ToString();
                    P[i] = dataGridView1[1, i].Value.ToString();
                    if (Check == int.TryParse(Ed[i], out ED[i]) && Check == double.TryParse(P[i], out flt_P[i]))
                    {

                        flt_P[i] = Convert.ToDouble(P[i]);
                        ED[i] = Convert.ToInt32(Ed[i]);
                        Vs[i] = (int)Math.Pow(10, Math.Log10(ED[i]) * 0.6 + 1.55);
                        Rigidty[i] = (float)((Vs[i] * Vs[i] * flt_P[i]) / 160);
                        dataGridView1[3, i].Value = Vs[i];
                        dataGridView1[4, i].Value = Rigidty[i];
                        
                    }
                    else
                    {
                        MessageBox.Show("Не верный ввод данных");
                        break;
                    }
                        
                }
                else
                {
                    MessageBox.Show("Не верный ввод данных");
                    break;
                }
                
            }
          
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}
        private void button2_Click(object sender, EventArgs e)
        {
            while(dataGridView1.Rows.Count>1)
            {
                for(int i=0; i< dataGridView1.Rows.Count-1; i++)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            }
        }
        private void српавкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа разработна для рассчета поперечных волн и пределов сжаия по инженерно-геологичским данным. Разработанна в Центре Геофизического мониторинга НАНРБ Галковским Тимуром Вячеславовичем в 2020 году.");

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
