using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GisManager
{
    public partial class AddPerson : Form
    {
        public string Name;
        public string Remarks;
        public AddPerson()
        {
            InitializeComponent();
        }


        private void btOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text.Trim()))
            {
                MessageBox.Show("名称不能为空！");
                tbName.Focus();
            }
            else
            {
                Name = tbName.Text;
                Remarks = tbRemarks.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}