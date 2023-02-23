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

            FileHelper.DeserializeFromFileJson();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var employees = FileHelper.DeserializeFromFileJson();

            var employeeWithHighestId = employees
                .OrderByDescending(x => x.EmployeeId).FirstOrDefault();

            var employeeId = employeeWithHighestId == null ? 
                1 : employeeWithHighestId.EmployeeId + 1;

            employees.Add(AddTextFromControls(employeeId));
            FileHelper.SerializeToFileJson(employees);

            Close();
        }

        private Employee AddTextFromControls(int employeeId)
        {
            var employee = new Employee
            {
                EmployeeId = employeeId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                HireDate = tbHireDate.Text,
                FireDate = Convert.ToDateTime(tbFireDate.Text),
                Wage = Convert.ToDecimal(tbWages.Text),
                Comments = rtbComments.Text,
            };
            return employee;
        }
    }
}
