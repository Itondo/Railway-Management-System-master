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
    public partial class Stations : Form
    {
        string action;
        public Stations(string action)
        {
            this.action = action;
            InitializeComponent();
            if (action == "Customer" || action == "Aview")
            {
                SName.Enabled = false;
                SType.Enabled = false;
                Save.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) // Save Button
        {
            if (!string.IsNullOrWhiteSpace(SID.Text) && !string.IsNullOrWhiteSpace(SName.Text) && !string.IsNullOrWhiteSpace(SType.Text))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("Stations.csv", true);  // This will open file for writing.
                    sw.WriteLine(SID.Text + "," + SName.Text + "," + SType.Text); // Saving all Recors in the file.
                    MessageBox.Show("Record Saved Successfully");
                    sw.Close(); // Close the file.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Saving Data: " + ex);
                }
                SName.Text = null;
                SType.Text = null;
                SID.Text = null;
            }
            else
                MessageBox.Show("No Field Sould Remain Empty");
        }

        private void button2_Click(object sender, EventArgs e) // This code will work when Search button is clicked.
        {
            int id = 0;

            try
            {
                StreamReader Sr = new StreamReader("Stations.csv"); // This will Read Data From File
                while (!Sr.EndOfStream)
                {
                    string line = Sr.ReadLine(); // This will Read Line from The file
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] Values = line.Split(',');
                        if (Values[0].ToString() == SID.Text)
                        {
                            SName.Text = Values[1];
                            SType.Text = Values[2];
                            id++;
                            break;
                        }
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error in Loading File: " + EX);
            }
            if (id == 0)
                MessageBox.Show("No Record Found");
        }

        private void Reset_Click(object sender, EventArgs e) // Reset Button
        {
            SName.Text = null;
            SType.Text = null;
            SID.Text = null;
        }

        private void button3_Click(object sender, EventArgs e) // Cancel Button
        {
            if (action == "Aview")
            {
                this.Hide();
                new Train("Admin").ShowDialog();
            }
            else
                this.Dispose();
        }
    }
}
