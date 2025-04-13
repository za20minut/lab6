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
            losu();
        }
        static void losu()
        {
            int liczbapol = globaln.X * globaln.Y;
            Random rand = new Random();
            HashSet<int> uniqueNumbers = new HashSet<int>();
            HashSet<int> uniqueNumbersszop = new HashSet<int>();
            HashSet<int> uniqueNumbersdydelf = new HashSet<int>();
            HashSet<int> uniqueNumberskrok = new HashSet<int>();

            while (uniqueNumbersszop.Count < 3)
            {
                int szop = rand.Next(0, globaln.Y*globaln.X); 
                
                if(uniqueNumbers.Add(szop)) uniqueNumbersszop.Add(szop);
            }
            while (uniqueNumbers.Count < 3 + globaln.dydelf)
            {
                int dydelf = rand.Next(0, globaln.Y * globaln.X); 
                
               if( uniqueNumbers.Add(dydelf)) uniqueNumbersdydelf.Add(dydelf);
            }
            while (uniqueNumbers.Count < 3 + globaln.dydelf + globaln.krokodyl)
            {
                int krok = rand.Next(0, globaln.Y * globaln.X); 
                
                if(uniqueNumbers.Add(krok)) uniqueNumberskrok.Add(krok);
            }
            Console.WriteLine("Wylosowane liczby:");
            int[,] tab;
            int pierm;
            int drugm;
            foreach (int num in uniqueNumbers)
            {
                Console.WriteLine(num);
                pierm=
            }

            
            

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
