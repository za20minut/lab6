using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            generating();
        }

        
        private void generating()
        {
            for (int i = 0; i < globaln.X; i++)
            {
                for(int j = 0; j < globaln.Y; j++)
                {
                    Button button = new Button();
                    button.Name="button"+i+"_"+j;
                    button.Location=new Point(i*50,j*50);
                    button.Width = 50;
                    button.Height = 50;
                    button.Click += (sender, e) =>
                    {
                        Button btn = sender as Button;
                        if (btn != null)
                        {
                            btn.BackColor = Color.Black;
                        }
                    };
                    
                    this.Controls.Add(button);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
