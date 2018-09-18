using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int BOARD_SIZE = 8;
        const int WIDTH = 50;
        const int HEIGHT = 50;
        int intCounter = 1;
        Button[,] buttons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 5; i <= 8; i++)
                comboBox1.Items.Add(i.ToString());
   
        }
        private void DrawBoard()
        {
            int x, y = 0;

            for (x = 0; x < BOARD_SIZE; x++)
            {
                for (y = 0; y < BOARD_SIZE; y++)
                {
                    buttons[x, y] = new Button();
                    buttons[x,y].Visible = true;
                    buttons[x,y].Size = new System.Drawing.Size(30, 30);
                    buttons[x,y].Location = new System.Drawing.Point(WIDTH + x * 30, HEIGHT + y * 30);
                    buttons[x, y].Text = "";
                    if ((y % 2==0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1))
                        buttons[x, y].BackColor = Color.Yellow;
                    else
                        buttons[x, y].BackColor = Color.White;
                    this.Controls.Add(buttons[x,y]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int x = 0; x < BOARD_SIZE; x++)            
                for (int y=0; y < BOARD_SIZE; y++)
                    StepMe(x, y);
            
        }

        private void StepMe(int x,int y)
        {
            if (x > BOARD_SIZE - 1) return;
            if (y > BOARD_SIZE - 1) return;
            if (x < 0) return;
            if (y < 0) return;

            Application.DoEvents();

            if (buttons[x, y].Text != "") return;
            buttons[x, y].Text = intCounter.ToString();

            if (intCounter == BOARD_SIZE * BOARD_SIZE)
            {
                if (MessageBox.Show("Solution found. Do you want to continue to find next solution?", "Knight Tour", MessageBoxButtons.YesNo) == DialogResult.No)
                    Application.Exit();
            }

            intCounter++;
            StepMe(x + 1, y + 2);
            StepMe(x + 2, y + 1);
            StepMe(x + 2, y - 1);
            StepMe(x + 1, y - 2);
            StepMe(x - 1, y - 2);
            StepMe(x - 2, y - 1);
            StepMe(x - 2, y + 1);
            StepMe(x - 1, y + 2);


            buttons[x, y].Text = "";
            intCounter--;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BOARD_SIZE = Convert.ToUInt16(comboBox1.Text.ToString());
            buttons = new Button[BOARD_SIZE, BOARD_SIZE];
            DrawBoard();
            comboBox1.Enabled = false;
        }
    }
}
