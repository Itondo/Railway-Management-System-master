using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Management_System
{
    public partial class Time_Table : Form
    {
        int index;
        public Time_Table(string action, int index )
        {
            InitializeComponent();
            if(action == "Customer") // This will set the limitation for Customer
            {
                DTime.Enabled = false;
                ATime.Enabled = false;
                Save.Visible = false;
            }
            this.index = index;
        }

        private void button3_Click(object sender, EventArgs e) // Cancel Button
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DTime.Text) && !string.IsNullOrWhiteSpace(ATime.Text))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("Time.csv", true);  // This will open file for writing.
                    sw.WriteLine(DTime.Text+","+ATime.Text); // Saving all Recors in the file.
                    MessageBox.Show("Record Saved Successfully");
                    sw.Close(); // Close the file.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Saving Data: " + ex);
                }
            }
            else
                MessageBox.Show("No Field Should Remain Empty");
        }

        private void Time_Table_Load(object sender, EventArgs e)
        {
            int i = 0;
            if (index != 0)
            {
                StreamReader sr = new StreamReader("Time.csv");
                while(!sr.EndOfStream)
                {
                    i++;
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');
                    if(i == index)
                    {
                        DTime.Text = data[0]; // This will assign Departure Timings get from file
                        ATime.Text = data[1]; // This will assign Arrival Timings get from file
                    }
                }
            }
            else
            {
                MessageBox.Show("You must Search Train First for View Its Correspondings Timmings");
            }

        }
    }
}
