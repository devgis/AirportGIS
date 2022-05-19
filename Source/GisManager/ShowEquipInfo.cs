using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GisManager
{
    public partial class ShowEquipInfo : Form
    {
        String _EquipID;
        public ShowEquipInfo(String EquipID)
        {
            InitializeComponent();
            _EquipID = EquipID;
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            AddPerson frmAddPerson = new AddPerson();
            if (frmAddPerson.ShowDialog() == DialogResult.OK)
            {
                string sql = String.Format("insert into Person(ID,Name,Remarks,EID)values('{0}','{1}','{2}','{3}')", Guid.NewGuid().ToString(), frmAddPerson.Name, frmAddPerson.Remarks, _EquipID);
                if (DBHelper.Instance.ExcuteSql(sql))
                {
                    MessageBox.Show("保存成功！");
                    LoadData();
                }
            }
        }

        private void tsBtnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvList.SelectedRows)
                {
                    string id = dgvr.Cells["ID"].Value.ToString();
                    string sql = string.Format("delete from person where id='{0}'", id);
                    DBHelper.Instance.ExcuteSql(sql);
                }
                LoadData();
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("请选择！");
            }
            
        }
        private void LoadData()
        {
            //dgvList.Rows.Clear();
            for (int i = dgvList.Rows.Count-1; i>=0; i--)
            {
                dgvList.Rows.RemoveAt(i);
            }

            string sql = String.Format("select ID,Name,Remarks from Person where EID='{0}'", _EquipID);
            DataTable dt = DBHelper.Instance.GetDataTable(sql);
            dgvList.DataSource = dt;
        }

        private void ShowEquipInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}