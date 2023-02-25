using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRBase
{
    public partial class AddEditEmployee : Form
    {
        public AddEditEmployee()
        {
            InitializeComponent();

            FileHelper.DeserializeFromFile();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var employees = FileHelper.DeserializeFromFile();

            var employeeWithHighestId = employees
                .OrderByDescending(x => x.EmployeeId).FirstOrDefault();

            var employeeId = employeeWithHighestId == null ?
                1 : employeeWithHighestId.EmployeeId + 1;

            employees.Add(AddTextFromControls(employeeId));
            FileHelper.SerializeToFile(employees);

            Close();
        }

        private Employee AddTextFromControls(int employeeId)
        {
            DateTime fireDate = DateTime.Now;

            var employee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                HireDate = tbHireDate.Text,
                FireDate = tbFireDate.Text == null ?
                    fireDate : DateTime.Parse(tbFireDate.Text),
                Wage = Convert.ToDecimal(tbWages.Text),
                Comments = rtbComments.Text
            };
            return employee;
        }
    }
}
