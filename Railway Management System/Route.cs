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
    public partial class Route : Form
    {
        string action;
        public Route(string action)
        {
            this.action = action;
            InitializeComponent();
            if (action == "Customer" || action == "Aview") ;
            {
                RName.Enabled = false;
                RDestination.Enabled = false;
                Save.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e) //  Cancel Button
        {
            if (action == "Aview")
            {
                this.Hide();
                new Train("Admin").ShowDialog();
            }
            else
                this.Dispose();
        }

        private void Reset_Click(object sender, EventArgs e) // Reset Button
        {
            RId.Text = null; // this will reset Values to Null
            RName.Text = null;
            RDestination.Text = null;
        }

        private void Save_Click(object sender, EventArgs e) //  save Button
        {
            if (!string.IsNullOrWhiteSpace(RId.Text) && !string.IsNullOrWhiteSpace(RName.Text) && !string.IsNullOrWhiteSpace(RDestination.Text))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("Route.csv", true);  // This will open file for writing.
                    sw.WriteLine(RId.Text + "," + RName.Text + "," + RDestination.Text); // Saving all Recors in the file.
                    MessageBox.Show("Record Saved Successfully");
                    sw.Close(); // Close the file.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Saving Data: " + ex);
                }
                RName.Text = null;
                RDestination.Text = null;
                RId.Text = null;
            }
            else
                MessageBox.Show("No Field Sould Remain Empty");
        }

        private void button2_Click(object sender, EventArgs e) // Search Button
        {
            int id = 0;

            try
            {
                StreamReader Sr = new StreamReader("Route.csv"); // This will Read Data From File
                while (!Sr.EndOfStream)
                {
                    string line = Sr.ReadLine(); // This will Read Line from The file
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] Values = line.Split(','); // This will split the whole string into multiple Values
                        if (Values[0].ToString() == RId.Text)
                        {
                            RName.Text = Values[1];
                            RDestination.Text = Values[2];
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
    }
}
