using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HRBase
{
    public partial class Main : Form
    {
        private string _filePath = 
            Path.Combine(Environment.CurrentDirectory,"EmployeeDataBase.txt");
        public Main()
        {
            InitializeComponent();
        }

        private void btnHire_Click(object sender, EventArgs e)
        {
            var newEmployeeForm = new AddEditEmployee();
            newEmployeeForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}
