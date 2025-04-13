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
        private HashSet<string> wylosowanePrzyciski = new HashSet<string>();
        private HashSet<string> wylosowanePrzyciskidydelf = new HashSet<string>();
        private HashSet<string> wylosowanePrzyciskikrok = new HashSet<string>();
        private void losu()
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

                if (uniqueNumbers.Add(szop)) { uniqueNumbersszop.Add(szop);
                    int j = szop / globaln.Y;
                    int i = szop % globaln.Y;
                    string nazwa = $"button{i}_{j}";
                    wylosowanePrzyciski.Add(nazwa);
                }
            }
            while (uniqueNumbers.Count < 3 + globaln.dydelf)
            {
                int dydelf = rand.Next(0, globaln.Y * globaln.X); 
                
               if( uniqueNumbers.Add(dydelf)){ uniqueNumbersdydelf.Add(dydelf);
                    int j = dydelf / globaln.Y;
                    int i = dydelf % globaln.Y;
                    string nazwa = $"button{i}_{j}";
                    wylosowanePrzyciskidydelf.Add(nazwa);
                }
            }
            while (uniqueNumbers.Count < 3 + globaln.dydelf + globaln.krokodyl)
            {
                int krok = rand.Next(0, globaln.Y * globaln.X);

                if (uniqueNumbers.Add(krok)) {
                    uniqueNumberskrok.Add(krok);
                    int j = krok / globaln.Y;
                    int i = krok % globaln.Y;
                    string nazwa = $"button{i}_{j}";
                    wylosowanePrzyciskikrok.Add(nazwa);
                }
            
            }
            Console.WriteLine("Wylosowane liczby:");
            List<Tuple<int, int>> tabela = new List<Tuple<int, int>>();
       
            foreach (int num in uniqueNumbers)
            {
                Console.WriteLine(num);
                

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
                    button.BackColor = Color.Gray;
                    button.Width = 50;
                    button.Height = 50;
                    button.Click += async (sender, e) =>
                    {
                        Button btn = sender as Button;
                        {
                            string name = btn.Name;

                            string typ = "";

                            if (wylosowanePrzyciski.Contains(name))
                                typ = "szop";
                            else if (wylosowanePrzyciskidydelf.Contains(name))
                                typ = "dydelf";
                            else if (wylosowanePrzyciskikrok.Contains(name))
                                typ = "krokodyl";
                            else
                                typ = "inny";

                            switch (typ)
                            {
                                case "szop":
                                    btn.BackColor = Color.Blue;
                                    string[] parts = name.Replace("button", "").Split('_');
                                    int x = int.Parse(parts[0]);
                                    int y = int.Parse(parts[1]);

                                    List<Tuple<int, int>> sasiedzi = new List<Tuple<int, int>>()
                                      {
                                     new Tuple<int, int>(x + 1, y),
                                     new Tuple<int, int>(x - 1, y),
                                     new Tuple<int, int>(x, y + 1),
                                     new Tuple<int, int>(x, y - 1)};

                                    await Task.Delay(2000);

                                    foreach (var sasiad in sasiedzi)
                                    {
                                        int sx = sasiad.Item1;
                                        int sy = sasiad.Item2;
                                        if (sx >= 0 && sx < globaln.X && sy >= 0 && sy < globaln.Y)
                                        {
                                            string nazwaSasiada = $"button{sx}_{sy}";
                                            var przyciskSasiad = this.Controls.Find(nazwaSasiada, true).FirstOrDefault() as Button;
                                            if (przyciskSasiad != null)
                                            {
                                                przyciskSasiad.BackColor = Color.Gray;
                                            }
                                        }
                                    }
                                    break;
                                case "dydelf":
                                    btn.BackColor = Color.Green;
                                    break;
                                case "krokodyl":
                                    if (btn.Tag != null && btn.Tag.ToString() == "clicked")
                                    {
                                        btn.BackColor = Color.Red;
                                        return;
                                    }
                                    btn.Tag = "clicked";

                                    
                                    btn.BackColor = Color.Yellow;
                                    Console.WriteLine("Kliknięto po raz pierwszy!");
                                    break;
                                default:
                                    btn.BackColor = Color.Gray;
                                    break;
                            }
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
