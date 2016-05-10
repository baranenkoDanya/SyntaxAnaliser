﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompleteLab3
{
    public partial class Form1 : Form
    {
        private string stack;
        private string token;
        public Form1()
        {
            InitializeComponent();

            string test1 = @"for (i = 1; i < 10; i = i + 1) 
{ 
_break_fast98 = 14.332e+123 / 134; 
AcceptButton[i + 1] = 123.5*i;
}";
            string test2 = @"while(i<10/2)
{
b = i * 200.342 + 1033.2e2;
}";
            comboBox1.Items.Add(test1);
            comboBox1.Items.Add(test2);
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            MainLogic temp = new MainLogic();
            //var lexemeText = temp.LexicalAnalyzer(textBox1.Text);
            lexeme.Text = temp.Launch(textBox1.Text);
            Identificate.Text = "Identificators:\n" + InputHandler.ShowStringArray(temp.IdentifiersTable.ToArray());
            Constant.Text = "Constants:\n" + InputHandler.ShowStringArray(temp.ConstantsTable.ToArray());
            stack = temp.StackState;
            token = temp.Tokens;
            if (lexeme.Text.Contains("NOT"))
            {
                BackColor = Color.FromArgb(191, 40, 61);
            }
            else
            {
                BackColor = Color.FromArgb(0, 70, 102);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form info = new Form();
            Label temp = new Label();
            temp.Text = "variable - 1\nconstant - 2\noperations - 3\ncomparison - 4\nbraces - 5\nend of statement - 6\nfor - 7\nif - 8\nwhile - 9";
            info.Controls.Add(temp);
            info.StartPosition = FormStartPosition.CenterScreen;
            info.BackColor = Color.FromArgb(136, 255, 155);
            temp.Font = new Font("Consolas", 12, FontStyle.Bold);
            temp.ForeColor = Color.Black;
            temp.TextAlign = ContentAlignment.MiddleCenter;
            temp.Dock = DockStyle.Fill;
            info.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stacks info = new Stacks();
            info.textBox1.Text += this.stack;
            info.textBox2.Text += this.token;
            info.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text.ToString();
        }
    }
}
