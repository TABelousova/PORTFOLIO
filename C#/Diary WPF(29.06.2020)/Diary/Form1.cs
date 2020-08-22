using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Diary;

namespace Diary
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Колекция хранящая данные из класса Model
        /// </summary>
        private BindingList<Model> _model;

        public Form1()
        {
            InitializeComponent();
            //Добавил что бы сохроняло понятным файлом и можно было открыть и без VS
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            // Initialize our collection
            _model = new BindingList<Model>();
            // Bind our collection to DataGridView
            dataGridView1.DataSource = _model;

        }
        /// <summary>
        /// Метод заполения dgv.1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            // Create new object row from input data
            Model newObj = new Model()
            {
                Date = DateTime.Now,
                Name = textBox1.Text,
                Status = textBox2.Text,
                Them = textBox3.Text,
                Coments = textBox4.Text
            };

            // Add new object to collection
            _model.Add(newObj);

            MessageBox.Show("Данные записанны");
        }
        /// <summary>
        /// метод для удаления конкретной строки(строки в dg.v1)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button2_Click(object sender, EventArgs e)
        {
            //int Remov = dataGridView1.SelectedCells[0].RowIndex;
            //dataGridView1.Rows.RemoveAt(Remov);
            _model.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            MessageBox.Show("Данные удалены");
        }

        /// <summary>
        /// метод для открытия файла, так как решил все создавать с помощью dgv
        /// пришлось использовать цикл, что бы он проходил по строкам и колонкам соотвественно 
        /// добавил еще операторы try/catch 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            // Clear our collection to load new from file
            _model = new BindingList<Model>();
            dataGridView1.DataSource = _model;

            Stream Load = null;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if ((Load = openFileDialog1.OpenFile()) != null);
                {
                    StreamReader read = new StreamReader(Load);
                    string[] loadedStrings;
                    try
                    {
                        loadedStrings = read.ReadToEnd().Split('\n');

                        foreach (var currenString in loadedStrings)
                        {
                            // Check if currentString is empty
                            if (String.IsNullOrEmpty(currenString))
                                continue;

                            string[] splitedString = currenString.Split('~');

                            // Create new object from loaded data
                            Model newObj = new Model
                            {
                                Date = DateTime.Parse(splitedString[0]),
                                Name = splitedString[1],
                                Status = splitedString[2],
                                Coments = splitedString[3],
                                Them = splitedString[4]
                            };

                            // Add new object to our collection
                            _model.Add(newObj);
                        }

                    }
                    catch (Exception Error)
                    {
                        MessageBox.Show(Error.Message);
                    }
                    finally
                    {
                        read.Close();
                    }
                    Load.Close();
                    MessageBox.Show("Данные загруженны");
                }
            }
            
        }

        /// <summary>
        /// Шутка 1 видел панели элементов есть форма для добавления и редактирования печати, потом 
        /// думаю побаловаться и все же сделать что бы работало, только пока не знаю как именно все это 
        /// связать, там же должна быть привязка к принтеру 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я еще не придумал как впендюрить сюда принтер, так " +
                "что это больше для вида:))))");
        }

        /// <summary>
        /// Шутка 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Справки не будет - помоги себе сам!");
        }
        /// <summary>
        /// еще один способ закрыть программу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// метод для сохранения данных в виде массива(таблица же все таки) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream Save;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)// вызов окна
            {
                if((Save = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(Save); //выделяем место под последующий цикл
                    try
                    {
                        foreach (var currentObj in _model)
                        {
                            writer.WriteLine(currentObj.ToString());
                        }

                    }
                    catch (Exception Error)//обработа ошибки 
                    {
                        MessageBox.Show(Error.Message);
                    }
                    finally
                    {
                        writer.Close();
                    }
                    Save.Close();
                    MessageBox.Show("Данные сохранены");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear our collection to load new from file
            _model = new BindingList<Model>();
            dataGridView1.DataSource = _model;

            Stream Load = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((Load = openFileDialog1.OpenFile()) != null) ;
                {
                    StreamReader read = new StreamReader(Load);
                    string[] loadedStrings;
                    try
                    {
                        loadedStrings = read.ReadToEnd().Split('\n');

                        foreach (var currenString in loadedStrings)
                        {
                            // Check if currentString is empty
                            if (String.IsNullOrEmpty(currenString))
                                continue;

                            string[] splitedString = currenString.Split('~');

                            // Create new object from loaded data
                            DateTime date = DateTime.Parse(splitedString[0]);

                            // Check if date included in range
                            if (date < dateTimePicker1.Value || date > dateTimePicker2.Value)
                                continue;

                            Model newObj = new Model
                            {
                                Date = date,
                                Name = splitedString[1],
                                Status = splitedString[2],
                                Coments = splitedString[3],
                                Them = splitedString[4]
                            };

                            // Add new object to our collection
                            _model.Add(newObj);
                        }

                    }
                    catch (Exception Error)
                    {
                        MessageBox.Show(Error.Message);
                    }
                    finally
                    {
                        read.Close();
                    }
                    Load.Close();
                    MessageBox.Show("Данные загруженны");
                }
            }
        }

        // Sort by Name
        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.Count != 0)
            {
                _model = new BindingList<Model>(_model.OrderByDescending(x => x.Name).ToList());
                dataGridView1.DataSource = _model;
            }
        }
        
        // Sort by Date
        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.Count != 0)
            {
                _model = new BindingList<Model>(_model.OrderByDescending(x => x.Date).ToList());
                dataGridView1.DataSource = _model;
            }
        }

        private void byStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.Count != 0)
            {
                _model = new BindingList<Model>(_model.OrderByDescending(x => x.Status).ToList());
                dataGridView1.DataSource = _model;
            }
        }

        private void byThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.Count != 0)
            {
                _model = new BindingList<Model>(_model.OrderByDescending(x => x.Them).ToList());
                dataGridView1.DataSource = _model;
            }
        }

        private void byComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_model.Count != 0)
            {
                _model = new BindingList<Model>(_model.OrderByDescending(x => x.Coments).ToList());
                dataGridView1.DataSource = _model;
            }
        }
    }
}
