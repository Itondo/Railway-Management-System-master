using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Management_System
{
    public partial class Admin_Login : Form

    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // action performed when sign in Button is Pressed.
        {
            string file = "";
            string set = Role.Text; // getting the value of Combo Box 
            if (set == "Customer")
                file = "Customer.csv";
            else if (set == "User")
                file = "users.csv";
            if (set == "Select")
                MessageBox.Show("Please Select Your Role"); // show dialgue box on screen.
            else if (set == "Admin")
            {
                if (ID.Text == "Admin" && Password.Text == "12345") //It will get the value from ID text field , if you want to change Admin ID change it from here
                {
                    this.Hide();
                    new Train("Admin").ShowDialog();
                   

                }
                else MessageBox.Show("Invalid Credential");
            }
            else 
            {
                int id = 0;

                try
                {
                    StreamReader Sr = new StreamReader(file); // This will Read Data From File
                    while (!Sr.EndOfStream)
                    {
                        string line = Sr.ReadLine(); // This will Read Line from The file
                        if (!String.IsNullOrWhiteSpace(line))
                        {
                            string[] Values = line.Split(',');
                            if (Values[0].ToString() == ID.Text && Values[2].ToString() == Password.Text) // This will get data from file and match credential
                            {
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
                    MessageBox.Show("InValid Credential");
                else if (set == "Customer")
                {
                    this.Hide();
                    new Train("Customer").ShowDialog();
                }
                else if (set == "User")
                {
                    this.Hide();
                    new Train("User").ShowDialog();
                }
            }
            


            }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    }

