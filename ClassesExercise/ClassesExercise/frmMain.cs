using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ClassesExercise
{
    public partial class frmMain : Form
    {
        List<Employee> employees = new List<Employee>();
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
            Employee newEmployee = new Employee();
            newEmployee.Fname = txtFirstName.Text;
            newEmployee.Lname = txtLastName.Text;
            newEmployee.Age = int.Parse(txtAge.Text);
            employees.Add(newEmployee);
            txtAge.Text = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAge.Text = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            foreach(var x in employees)
            {
                listBox1.Items.Add(x.Display());
            }
        }
    }
    class Employee
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }

        public string Display()
        {
            return $"Name: {Fname} {Lname} Age: {Age}";
        }
    }
}
