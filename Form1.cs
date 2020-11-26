using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gadget
{
    public partial class Form1 : Form
    {
        private List<Vehicle> vehiclesList = new List<Vehicle>();
        private int jetCount;
        private int carCount;
        private int bikeCount;
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vehiclesList.Clear();
            var rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        vehiclesList.Add(Jet.Generate());
                        break;
                    case 1:
                        vehiclesList.Add(Car.Generate());
                        break;
                    case 2:
                        vehiclesList.Add(Bike.Generate());
                        break;
                }

            }
            ShowInfo();
        }
        private void ShowInfo()
        {
            jetCount = 0;
            carCount = 0;
            bikeCount = 0;

            // пройдемся по всему списку
            foreach (var vehicle in this.vehiclesList)
            {

                if (vehicle is Jet)
                {
                    jetCount += 1;
                }
                else if (vehicle is Car)
                {
                    carCount += 1;
                }
                else if (vehicle is Bike)
                {
                    bikeCount += 1;
                }
            }
            richTextBox2.Text = "Самолет         Велосипед        Автомобиль";
            richTextBox2.Text += "\n";
            richTextBox2.Text += String.Format("{0}\t\t{1}\t\t{2}", jetCount, bikeCount, carCount);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(vehiclesList.Count == 0)
            {
                richTextBox1.Text = "Пусто";
                pictureBox1.Image = null;
                return;
            }
            var vehicle = vehiclesList[0];
            vehiclesList.RemoveAt(0);
            richTextBox1.Text = vehicle.GetInfo();
            pictureBox1.Image = vehicle.GetImage();
            ShowInfo();
        }
    }
}
