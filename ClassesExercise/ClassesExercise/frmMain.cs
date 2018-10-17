using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ClassesExercise
{
    public partial class frmMain : Form
    {
        List<Deets> people = new List<Deets>();
        public frmMain()
        {
            Thread t = new Thread(new ThreadStart(StartSplash));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void StartSplash()
        {
            Application.Run(new frmSplash());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create object and populate its properties
            Deets newPerson = new Deets();
            newPerson.Fname = txtFirstName.Text;
            newPerson.Lname = txtLastName.Text;
            newPerson.Age = int.Parse(txtAge.Text);
            people.Add(newPerson);
            //Clear the text boxes ready for the next input
            txtAge.Text = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
            //Display label confirming record has been created
            lblOutput.Text = "Record created";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear everything
            txtAge.Text = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
            lblOutput.Text = null;
            listBox1.Items.Clear();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //User feedback
            lblOutput.Text = "Displaying all records";
            //Display the ojects info in an easy to read format.
            foreach (var x in people)
            {
                listBox1.Items.Add(x.DisplayName());
                listBox1.Items.Add("Age: " + x.Age);
                listBox1.Items.Add("*----------------------*");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblOutput.Text = null;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            lblOutput.Text = null;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            lblOutput.Text = null;
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            lblOutput.Text = null;
        }
    }
}
