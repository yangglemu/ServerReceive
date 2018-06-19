using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace ServerReceive
{
    public partial class MdiForm : Form
    {
        public int comboxindex;
        MySqlCommand command;
        public DataTable m_dt;
        public MdiForm()
        {
            InitializeComponent();
            command = MainForm.command;
        }

        private void MdiForm_Shown(object sender, System.EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                m_dt = dataGridView.DataSource as DataTable;
                Sum();
                SetRowHeaderText();
            }
            var mainForm = this.ParentForm as MainForm;
            this.comboxindex = 0;
            mainForm.SetComboxSelectedIndex(0);
        }

        private void dataGridView_DataSourceChanged(object sender, System.EventArgs e)
        {
            Sum();
            SetRowHeaderText();
        }

        private void SetRowHeaderText()
        {
            for (int count = 0; count < dataGridView.Rows.Count; count++)
            {
                dataGridView.Rows[count].HeaderCell.Value = (count + 1).ToString();
            }
        }

        private void Sum()
        {
            this.toolStripStatusLabel.Text = "";
            if (this.dataGridView.Columns.Contains("数量") && this.dataGridView.Columns.Contains("金额"))
            {
                var sl = 0;
                var je = 0;
                var dt = dataGridView.DataSource as DataTable;
                foreach (DataRow row in dt.Rows)
                {
                    sl += Convert.ToInt32(row["数量"]);
                    je += Convert.ToInt32(row["金额"]);
                }
                var s = string.Format("统计--> 数量：{0}, 金额：{1}", sl, je.ToString("0.00"));
                toolStripStatusLabel.Text = s;
                dataGridView.Columns["金额"].DefaultCellStyle.Format = "0.00";
                if (this.dataGridView.Columns.Contains("实收"))
                {
                    dataGridView.Columns["实收"].DefaultCellStyle.Format = "0.00";
                    dataGridView.Columns["找零"].DefaultCellStyle.Format = "0.00";
                }
            }
        }

        private void MdiForm_Enter(object sender, EventArgs e)
        {
            (this.ParentForm as MainForm).SetComboxSelectedIndex(comboxindex);
        }

        private void MdiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mf = this.MdiParent as MainForm;
            if (mf.MdiChildren.Length == 1)
            {
                mf.SetComboxSelectedIndex(0);
            }
        }
    }
}
