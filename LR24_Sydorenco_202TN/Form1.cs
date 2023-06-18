using System;
using System.Collections.Generic;
//using System.Componentmodel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;


namespace LR24_Sydorenco_202TN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread thread1, thread2, thread3;
        private bool stopThread1, stopThread2, stopThread3;

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Запустить поток 1";
            button2.Text = "Запустить поток 2";
            button3.Text = "Запустить поток 3";
            button4.Text = "Запустить все потоки";
            button5.Text = "Остановить поток 1";
            button6.Text = "Остановить поток 2";
            button7.Text = "Остановить поток 3";
            button8.Text = "Остановить все потоки";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thread1 == null)
            {
                thread1 = new Thread(GenerateNumbers3);
                thread1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thread2 == null)
            {
                thread2 = new Thread(GenerateNumbers2);
                thread2.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (thread3 == null)
            {
                thread3 = new Thread(Diffe, 10);
                thread3.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (thread1 == null)
            {
                thread1 = new Thread(GenerateNumbers3);
                thread1.Start();
            }
            if (thread2 == null)
            {
                thread2 = new Thread(GenerateNumbers2);
                thread2.Start();
            }
            if (thread3 == null)
            {
                thread3 = new Thread(Diffe);
                thread3.Start();
                // Потоковий шифр Діффі
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                stopThread1 = true;
                thread1 = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (thread2 != null)
            {
                stopThread2 = true;
                thread2 = null;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (thread3 != null)
            {
                stopThread3 = true;
                thread3 = null;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            button1.Text = "Запустить поток 1";
            button2.Text = "Запустить поток 2";
            button3.Text = "Запустить поток 3";
            button4.Text = "Запустить все потоки";
            button5.Text = "Остановить поток 1";
            button6.Text = "Остановить поток 2";
            button7.Text = "Остановить поток 3";
            button8.Text = "Остановить все потоки";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                stopThread1 = true;
                thread1 = null;
            }
            if (thread2 != null)
            {
                stopThread2 = true;
                thread2 = null;
            }
            if (thread3 != null)
            {
                stopThread3 = true;
                thread3 = null;
            }
        }

        private void Diffe()
        {
            int p = 6;
            int g = 11;
            Random random = new Random();
            while (!stopThread1)
            {
                int number = random.Next();
                double k = Math.Pow(p, number) % g;
                int polu = random.Next();
                double s = Math.Pow(p, polu) % g;
                double d = Math.Pow(p, polu) % g;
                double hh = Math.Pow(p, number) % g;
                double ds = Math.Pow(s, number) % g;
                double gs = Math.Pow(k, polu) % g;
                richTextBox1.AppendText(ds.ToString() + gs.ToString() + "\n");
            }
        }

        private void GenerateNumbers2()
        {
            Random rand = new Random();
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            while (!stopThread2)
            {
                char letter = letters[rand.Next(letters.Length)];
                richTextBox1.AppendText(letter.ToString());
                Application.DoEvents(); 
                // обновляем интерфейс
            }
        }

        private void GenerateNumbers3()
        {
            Random random = new Random();
            while (!stopThread3)
            {
                int number = random.Next();
                Invoke(new Action(() => richTextBox3.AppendText(number.ToString() + Environment.NewLine)));
            }
        }
    }
}
