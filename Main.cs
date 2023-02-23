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
using System.Xml.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

namespace HRBase
{
    public partial class Main : Form
    {


        public Main()
        {
            InitializeComponent();

            var employees = FileHelper.DeserializeFromFileJson();

            dgvList.DataSource = employees;
        }



        private void btnHire_Click(object sender, EventArgs e)
        {
            var addEditEmployee = new AddEditEmployee();
            addEditEmployee.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void btnFire_Click(object sender, EventArgs e)
        {

        }
    }
}
