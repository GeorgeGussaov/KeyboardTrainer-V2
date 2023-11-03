using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTrainer
{
    public partial class FormThirdMode : Form
    {
        public FormThirdMode()
        {
            InitializeComponent();
        }
        int cntDown = 0;
        int cntMiss = 0;
        int cntDeparted = 0;
        List<Button> buttons = new List<Button>();

        Button[] keyboard = new Button[26];
        void inputButtonMas() //вводим визуальную клавиатуру
        {
            string[] keyboardButtons = {"Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A",
                "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            int left = 4;
            for (int i = 0; i < 26; i++)
            {
                left++;
                keyboard[i] = new Button();
                if (i == 10) left = 4;
                else if (i == 19) left = 4;
                if (i < 10) keyboard[i].Location = new Point(0, 550);
                else if (i < 19) keyboard[i].Location = new Point(0, 600); //сложные и не очень процессы ввода кнопок
                else if (i < 26) keyboard[i].Location = new Point(0, 650);
                keyboard[i].Text = keyboardButtons[i];
                keyboard[i].Left = left * 45 + 15;
                keyboard[i].Size = new Size(40, 40);
                Controls.Add(keyboard[i]);
            }
        }

        void newButton() //появление новых кнопок
        {
            Random r = new Random();
            Button newBtn = new Button();
            int p1 = r.Next(0, this.Width - 100);
            int p2 = -20;
            //newBtn.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            newBtn.Location = new Point(p1, p2);
            newBtn.Name = "newbtn";
            newBtn.Size = new Size(50, 50);
            newBtn.TabIndex = 3;
            newBtn.Text = Convert.ToChar(r.Next('A', 'Z')).ToString();
            newBtn.UseVisualStyleBackColor = true;
            buttons.Add(newBtn);
            Controls.Add(newBtn);
        }
        //int p1, p2;

        private void FormThirdMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cntDown == 0)
            {
                inputButtonMas();
                labelText.Visible = false;
                timerSpawnButtons.Enabled = true;
                timerMoveButtons.Enabled = true;
                sw = Stopwatch.StartNew();
            }
            cntDown++;
            foreach (Button btn in buttons)
            {
                if (e.KeyCode.ToString() == btn.Text)
                {
                    btn.Visible = false;
                    buttons.Remove(btn);
                    foreach (Button let in keyboard)
                    {
                        if (let.Text == btn.Text) let.BackColor = Color.Green;
                        else let.BackColor = Color.White;
                    }
                    btn.Text = " ";
                    
                    break;
                }
                else
                {
                    foreach (Button let in keyboard)
                    {
                        if (let.Text == e.KeyCode.ToString())
                        {
                            let.BackColor = Color.Red;
                            cntMiss++;
                        }
                    }
                }
            }
        }
        Stopwatch sw;

        private void timerMoveButtons_Tick(object sender, EventArgs e)
        {
            if (sw.Elapsed.Minutes > 2)
            {
                timerMoveButtons.Interval = 100;
                timerSpawnButtons.Interval = 350;
            }
            else if (sw.Elapsed.Minutes > 1)
            {
                timerMoveButtons.Interval = 150;
                timerSpawnButtons.Interval = 450;
            }
            else if (sw.Elapsed.Seconds > 30)
            {
                timerMoveButtons.Interval = 250;
                timerSpawnButtons.Interval = 650;
            }
            if (cntDeparted > 4)
            {
                sw.Stop();
                timerMoveButtons.Enabled = false;
                timerSpawnButtons.Enabled = false;
                MessageBox.Show($"Слишком много упавших клавиш(5)\n" +
                    $"Вы продержались времени: {sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}\n" +
                    $"Количество промахов: {cntMiss}");
                this.Close();
            }
            foreach (Button btn in buttons)
            {
                btn.Top = btn.Top + 20;
                if (btn.Top > 500)
                {
                    btn.Visible = false;
                    cntDeparted++;
                    foreach (Button let in keyboard)
                    {
                        if (let.Text == btn.Text) let.BackColor = Color.Yellow;
                    }
                    btn.Text = "";
                }
            }
        }

        private void timerSpawnButtons_Tick(object sender, EventArgs e)
        {
            newButton();
            
        }


    }
}
