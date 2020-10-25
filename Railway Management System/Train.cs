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
    public partial class Train : Form
    {
        string Role;
        int index = 0;
        public Train(string action)
        {
            InitializeComponent();
            this.Role = action; // This will get the Value from Login Page and will check who has login to the system according to which 
            // access can be given.
            if (this.Role == "Customer" || this.Role == "Aview") // This will not allow to customer to enter detail just to view it.
            {
                this.tNum.Enabled = false;
                this.Tname.Enabled = false;
                this.TType.Enabled = false;
                this.Save.Visible = false; // This will invisible Save Button for Customer
                this.CreateAccount.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;

            try
            {
                StreamReader Sr = new StreamReader("Train.csv"); // This will Read Data From File
                while (!Sr.EndOfStream)
                {
                    string line = Sr.ReadLine(); // This will Read Line from The file
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        index++;
                        string[] Values = line.Split(',');
                        if (Values[0].ToString() == tId.Text)
                        {
                            Tname.Text = Values[1];
                            TType.Text = Values[2];
                            tNum.Text = Values[3];
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
            if(id == 0)
                MessageBox.Show("No Record Found");
        }

        private void button2_Click(object sender, EventArgs e) // This will work when Save Button is Pressed
        {
            if (!string.IsNullOrWhiteSpace(tId.Text) && !string.IsNullOrWhiteSpace(Tname.Text) && !string.IsNullOrWhiteSpace(tNum.Text) && !string.IsNullOrWhiteSpace(TType.Text))
            {
                try
                {
                    StreamWriter sw = new StreamWriter("Train.csv",true);  // This will open file for writing.
                    sw.WriteLine(tId.Text +"," +Tname.Text+","+ TType.Text+","+ tNum.Text); // Saving all Recors in the file.
                    MessageBox.Show("Record Saved Successfully");
                    sw.Close(); // Close the file.
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error in Savind Data: " + ex);
                }
                this.tId.Text = null;
                this.TType.Text = null;
                this.Tname.Text = null;
                this.tNum.Text = null;

            }
            else
                MessageBox.Show("No fields can Remain Empty");
        }

        private void button3_Click(object sender, EventArgs e) // This will work when clicked on Time Table Button
        {
            new Time_Table(Role,index).ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e) //  This will work when clicked on Route Button
        {
            new Route(Role).ShowDialog();
                
        }

        private void button7_Click(object sender, EventArgs e) // This will work when clicked on Reset Button
        {
            this.tId.Text = null;
            this.TType.Text = null;
            this.Tname.Text = null;
            this.tNum.Text = null;
        }

        private void button5_Click(object sender, EventArgs e) // This will work when clicked on LogOut Button
        {
            this.Hide();
            new Admin_Login().ShowDialog(); // This will bring you back to the Login System.
            
        }

        private void button6_Click(object sender, EventArgs e) // This will work when clicked on Exit Button
        {
            Environment.Exit(0); // This will exit the Program
        }

        private void button4_Click(object sender, EventArgs e) // This will work when clicked on Station Button
        {
            new Stations(Role).ShowDialog(); // This willopen the station Dialogue
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e) //  This will Open SignUp Menu
        {
            if (Role == "Admin" || Role == "Aview" || Role == "User")
            {
                this.Hide();
                new UserLogin("Users").ShowDialog();

            }
            else
                MessageBox.Show("Customer has No right Create Account");

        }

        private void customerAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Role == "Admin" || Role == "Aview")
            {
                this.Hide();
                new UserLogin("Users").ShowDialog();

            }
            else
                MessageBox.Show("Only Admin has Right to Create User Account");
        }

        private void customerDataToolStripMenuItem_Click(object sender, EventArgs e) // It will work when user wants to View Customer Data
        {
            if (Role != "Customer")
            {
                this.Hide();
                new UserLogin("Cview").ShowDialog();
            }
            else
                MessageBox.Show("Customer can not see this Data");
        }

        private void userDataToolStripMenuItem_Click(object sender, EventArgs e) // This will work when View User is Pressed.
        {
            if (Role != "Admin")
                MessageBox.Show("This Option is only accessible for Admin");
            else
            {
                this.Hide();
                new UserLogin("Uview").ShowDialog();
            }
        }

        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Train("Aview").ShowDialog();
        }

        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Route("Aview").ShowDialog();
        }

        private void stationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Stations("Aview").ShowDialog();
        }
    }
}
