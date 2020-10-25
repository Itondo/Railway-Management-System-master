using System;
using System.Collections;
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
    public partial class UserLogin : Form
    {
        string action;
        public UserLogin(string action)
        {
            InitializeComponent();
            this.action = action;
            if (action == "Customer")
            {
                this.Title.Text = "Customer Log In"; // This will set the main title of the Page to Customer Login
                this.EmailLabel.Text = "Address"; // This will set label Address;
            }
            if(action == "Cview" || action == "Uview")
            {
                this.UName.Enabled = false;
                this.UPass.Text = "You Can not See the Password";
                this.UPass.Enabled = false;
                this.UPhone.Enabled = false;
                this.UEmail.Enabled = false;
                this.Search.Visible = true;
                if (action == "Cview")
                    this.Title.Text = "View Customer Data";
                else
                    this.Title.Text = "View User Data";
            }
        }

        private void button2_Click(object sender, EventArgs e) // This will work when create button is pressed.
        {
            if (!String.IsNullOrWhiteSpace(UId.Text) && !String.IsNullOrWhiteSpace(UName.Text) && !String.IsNullOrWhiteSpace(UPass.Text) && !String.IsNullOrWhiteSpace(UEmail.Text) && !String.IsNullOrWhiteSpace(UPhone.Text)) // This will ensure that No fields is empty or white spaces.
            { 
                    try
                    {
                        StreamWriter sw = new StreamWriter(action+".csv", true);  // This will open file for writing.
                        sw.WriteLine(UId.Text + "," + UName.Text + "," + UPass.Text +","+UPhone.Text+","+UEmail.Text); // Saving all Recors in the file.
                        MessageBox.Show("Record Saved Successfully");
                        sw.Close(); // Close the file.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Saving Data: " + ex);
                    }
                    this.Hide();
                    new Train("Admin").ShowDialog(); // This will take Admin to the main SCreen.
            }
            else
                MessageBox.Show("No Field Should Remain Empty");
        }

        private void button3_Click(object sender, EventArgs e) // Reset Button
        {
            this.UId.Text = null;
            this.UEmail.Text = null;
            this.UEmail.Text = null;
            this.UName.Text = null;
            this.UPass.Text = null;
        }

        private void button4_Click(object sender, EventArgs e) // This will work when Exit button is pressed
        {
            Environment.Exit(0); // This will Close the Application
        }

        private void button1_Click(object sender, EventArgs e) // This will take you back to the Main Menu
        {
            this.Hide();
            new Train(action).ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e) // This will work when search button is Pressed
        {
            int id = 0;
            string file = "";
            if (action == "Cview")
                file = "Customer.csv";
            else
                file = "Users.csv";

            try
            {
                StreamReader Sr = new StreamReader(file); // This will Read Data From File
                while (!Sr.EndOfStream)
                {
                    string line = Sr.ReadLine(); // This will Read Line from The file
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] Values = line.Split(',');
                        if (Values[0].ToString() == UId.Text)
                        {
                            UName.Text = Values[1];
                            UPhone.Text = Values[3];
                            UEmail.Text = Values[4];
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

        private void customerAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (action == "Admin" ||action == "Aview" || action == "User")
            {
                this.Hide();
                new UserLogin("Users").ShowDialog();

            }
            else
                MessageBox.Show("Customer has No right to view this Data");
        }

        private void userAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (action == "Admin" )
            {
                this.Hide();
                new UserLogin("Users").ShowDialog();

            }
            else
                MessageBox.Show("Only Admin has Right to see the Data");
        }

        private void customerDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (action != "Customer")
            {
                this.Hide();
                new UserLogin("Cview").ShowDialog();
            }
            else
                MessageBox.Show("Customer can not see this Data");
        }

        private void userDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (action != "Admin")
                MessageBox.Show("This Option is only accessible for Admin");
            else
            {
                this.Hide();
                new UserLogin("Uview").ShowDialog();
            }
        }

        private void trainToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Train("Aview").ShowDialog();
        }

        private void routeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Route("Aview").ShowDialog();
        }

        private void stationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Stations("Aview").ShowDialog();
        }
    }
}
