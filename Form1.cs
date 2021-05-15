using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComGrafLab3
{
    public partial class Form1 : Form
    {
        Cube cube = new Cube();
        public Form1()
        {
            InitializeComponent();

            
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, pictureBox1.Height / 2, pictureBox1.Width / 2, pictureBox1.Height, pictureBox1.Width);
            e.Graphics.DrawLine(Pens.Red, pictureBox1.Height / 2, pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            e.Graphics.DrawLine(Pens.Red, pictureBox1.Height / 2, pictureBox1.Width / 2, 0, pictureBox1.Width / 2);
            cube.Draw(e.Graphics, Pens.Black, pictureBox1.Height, pictureBox1.Width);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            switch (e.KeyCode)
            {
                case (Keys.I):
                    {
                        cube.Rotx(10);
                        break;
                    }
                case (Keys.K):
                    {
                        cube.Rotx(-10);
                        break;
                    }
                case (Keys.U):
                    {
                        cube.Roty(-10);
                        break;
                    }
                case (Keys.O):
                    {
                        cube.Roty(10);
                        break;
                    }
                case (Keys.J):
                    {
                        cube.Rotz(-10);
                        break;
                    }
                case (Keys.L):
                    {
                        cube.Rotz(10);
                        break;
                    }
                case (Keys.M):
                    {
                        cube.Scale(1.1);
                        break;
                    }
                case (Keys.N):
                    {
                        cube.Scale(1 / 1.1);
                        break;
                    }



                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
