﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KeyboardTrainer
{
    public partial class FormFirstMode : Form
    {
        int check = 0;
        int cntErr = 0;
        string title = "";
        int ind = 0;
        string filmText;
        public FormFirstMode()
        {
            InitializeComponent();
            Random rnd = new Random();
            int ind = rnd.Next(0, 10);

            string[] ans = { "Крестный отец", "Хранители снов", "Великолепная семерка", "Ведьмак 2: Убийца королей", "Хоббит: Неожиданное путешествие",
                "Назад в будущее", "Бэтмен: Начало", "Джентельмены", "Бешеные псы", "Во все тяжкие"};

            StreamReader sr = new StreamReader("text" + ind + ".txt");
            title = ans[ind];
            filmText = sr.ReadToEnd();
            labelText.Text = filmText;
            sr.Close();                     //если что файл закрыт
            labelCurrentWord.Text = "Текущее слово: " + labelText.Text.Split()[0];

            inputButtonMas();
            text = new List<string>(filmText.Split(new string[] { " ", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }
        List<string> text = new List<string>();
        //взято с инета, нужно чтобы сплитнуть ентеры. Идея с инициализацией перед описанием тоже, т.к. иначе ругается на нестатическое поле labelText


        Button[] keyboard = new Button[46];
        void inputButtonMas() //вводим визуальную клавиатуру
        {
            string[] keyboardButtons = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0","-","й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з","х","ъ", "ф",
                "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э", "shift", "я", "ч", "с", "м", "и", "т", "ь", "б", "ю", ".", "space" };
            int left = 3;
            for (int i = 0; i < 46; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 11) left = 3;
                else if (i == 23) left = 3;
                else if (i == 34) left = 3;
                else if (i == 45) left = 8;
                if (i < 11) keyboard[i].Location = new Point(0, 450);
                else if (i < 23) keyboard[i].Location = new Point(0, 500); //сложные и не очень процессы ввода кнопок
                else if (i < 34) keyboard[i].Location = new Point(0, 550);
                else if (i < 45) keyboard[i].Location = new Point(0, 600);
                else
                {
                    keyboard[i].Location = new Point(0, 650);
                    keyboard[i].Text = keyboardButtons[i];
                    keyboard[i].Left = left * 45 + 15;
                    keyboard[i].Size = new Size(100, 40);                   //и это все чтобы удлинить пробел
                    base.Controls.Add(keyboard[i]);
                    break;
                }
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                keyboard[i].BackColor = Color.White;
                base.Controls.Add(keyboard[i]);
            }
        }

        

        Stopwatch sw = Stopwatch.StartNew(); //таймер
        private void textBoxTrainingField_TextChanged(object sender, EventArgs e)
        {
            string user = textBoxTrainingField.Text;
            if (check < text.Count)
            {
                if (ind < text[check].Length && ind < user.Length && user[ind] != text[check][ind])
                {
                    cntErr++;                                                           //подсчет ошибок
                    labelCntError.Text = "Количество ошибок: " + cntErr;
                }
                ind++;
            }

            
            if (user == "")
            {
                for (int i = 0; i < keyboard.Length; i++)   //очищаем клаву
                    keyboard[i].BackColor = Color.White;
                ind = 0;
            }
            else
                for (int i = 0; i < keyboard.Length; i++)
                    if (keyboard[i].Text == "space") keyboard[i].BackColor = Color.White;   //очищаем пробел



            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < keyboard.Length; j++)
                {
                    if (user.Length <= text[check].Length)
                    {
                        if (user[i].ToString().ToLower() == keyboard[j].Text && text[check][i] == user[i])  //это кошмар, но на этом кошмаре
                            keyboard[j].BackColor = Color.Green;                                            //работает визуальная клавиатура
                        else if (user[i] == ',')
                        {
                            keyboard[34].BackColor = Color.Yellow;  //клавиши, нажимаемые парно, закрашиваются желтым, остальные зеленым
                            keyboard[44].BackColor = Color.Yellow;
                        }
                        else if (user[i] == '?' && text[check][i] == user[i])
                        {
                            keyboard[34].BackColor = Color.Yellow;              //шифт - 34, остальное подходящие клавиши
                            keyboard[6].BackColor = Color.Yellow;
                        }
                        else if (user[i] == '!' && text[check][i] == user[i])
                        {
                            keyboard[34].BackColor = Color.Yellow;
                            keyboard[0].BackColor = Color.Yellow;
                        }
                        else if (user[i] == '*' && text[check][i] == user[i])
                        {
                            keyboard[34].BackColor = Color.Yellow;
                            keyboard[1].BackColor = Color.Yellow;
                        }
                        else if (user[i].ToString().ToLower() == keyboard[j].Text && text[check][i] != user[i])
                            keyboard[j].BackColor = Color.Red;  //нерпавильные красным
                    }
                    else if (keyboard[j].Text == user[i].ToString()) keyboard[j].BackColor = Color.Red;

                }
            }


            //далее основная работа программы
            if (textBoxTrainingField.Text.Split().Length > 1) //опустошаем строку после введенного слова, попутно проверяя
            {

                if (text[check] + " " == user) //проверка слова на совпадение в тексте
                    check++;

                textBoxTrainingField.Text = ""; //опустошение

                if (check == text.Count)
                {
                    sw.Stop();
                    MessageBox.Show("Текст из: " + title + "\nКоличество ошибок: " + cntErr +
                        "\nВремени затрачено: " + sw.Elapsed.Minutes + ":" + sw.Elapsed.Seconds + "\nСреднее кол-во символов в минуту: "
                        + labelText.Text.Length / ((sw.Elapsed.Minutes * 60 + sw.Elapsed.Seconds) / 60)); //среднее количество символов в минуту
                    this.Close();
                }
                else labelCurrentWord.Text = "Текущее слово: " + text[check];

                for (int i = 0; i < keyboard.Length; i++)
                {
                    if (keyboard[i].Text == "space") keyboard[i].BackColor = Color.Yellow;
                }
            }
        }
    }
    
}
