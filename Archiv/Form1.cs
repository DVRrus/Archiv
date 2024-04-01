using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Xml.Linq;

namespace Archiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         */
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Введите формат", "Ошибка");
                return;

            }

            string fo = comboBox1.Text;

            string text = textBox1.Text;
            MessageBox.Show("Файл: "+text);
            SaveFileDialog open = new SaveFileDialog();

            // открываем окно сохранения
            open.ShowDialog();

            // присваниваем строке путь из открытого нами окна
            string path = open.FileName;

            try
            {
                // создаем файл используя конструкцию using

                using (FileStream fs = File.Create(path))
                {

                    // создаем переменную типа массива байтов
                    // и присваиваем ей метод перевода текста в байты
                    byte[] info = new UTF8Encoding(true).GetBytes(text);
                    // производим запись байтов в файл
                    fs.Write(info, 0, info.Length);
                    MessageBox.Show("Успешно сохранился файл");

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                MessageBox.Show("Ошибка" + ex);
            }
        }
    }
   
}
