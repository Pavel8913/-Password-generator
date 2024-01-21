using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Генератор_паролей
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len_pass = (int)numericUpDown1.Value;
            int quantity= (int)numericUpDown2.Value;
            bool symbols = checkBox1.Checked;
            Random rand = new Random();
            Random type = new Random();
            for (int j = 0; j < quantity; j++)
            {
                for (int i = 0; i < len_pass; i++)
                {
                    int type_num = type.Next();
                    if (type_num == 0)
                    {
                        int value = rand.Next();
                        richTextBox1.Text += value.ToString();
                        continue;
                    }
                    else
                    {
                        if (symbols == true)
                        {
                            char value = (char)rand.Next();
                            if (value == '\\' || value == '/')
                            {
                                value = (char)rand.Next(33, 91);
                                richTextBox1.Text += value.ToString();
                            }
                            else
                            {
                                richTextBox1.Text += value.ToString();
                            }
                            continue;



                        }
                    }

                }
                richTextBox1.Text += "\n";
            }
               
                
               


        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*textBox1.Text = richTextBox1.Text;

            if (richTextBox1.Text != null)
            {
                SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя место, в которое он захочет сохранить файл. 
                save.Filter = "TXT|*.txt"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
                {
                    richTextBox1.SaveFile(save.FileName);
                    textBox1.Text.Save(save.FileName); 
                }

            }
            else
            {
                MessageBox.Show("Сначало создайте QR код.", "Ошибка!");
            }*/
            if(richTextBox1.Text!="")
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.txt";
                saveFile1.Filter = "TXT|*.txt|RTF Files|*.rtf";

                if (saveFile1.ShowDialog() == DialogResult.OK && saveFile1.FileName.Length > 0)
                {
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
            else
            {
                MessageBox.Show("Сначало сгенерируйте пароль.", "Ошибка!");
            }

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == ',')
            {
                if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;

                return;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.KeyChar = Convert.ToChar(Keys.None);



            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Издатель: Pavlentyi_22\nВерсия: 1\nОписание: Генератор паролей", "Свойства");
        }
    }
}
