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
            p1 = r.Next(0, this.Width - 100);
            p2 = -20;
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
        int p1, p2;

        private void FormThirdMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cntDown == 0)
            {
                inputButtonMas();
                timer1.Enabled = true;
                //timer2.Enabled = true;
            }
            cntDown++;
            foreach (Button btn in buttons)
            {
                if (e.KeyCode.ToString() == btn.Text)
                {
                    btn.Visible = false;
                    btn.Text = " ";
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            newButton();
            foreach (Button btn in buttons)
            {
                btn.Top = btn.Top + 20;
            }
        }

    }
}
