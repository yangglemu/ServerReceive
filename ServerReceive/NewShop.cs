using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ServerReceive
{
    public partial class NewShop : Form
    {
        public NewShop()
        {
            InitializeComponent();
        }

        private void NewShop_Shown(object sender, EventArgs e)
        {
            this.textBox_name.Select();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBox_name.TextLength < 1 || textBox_pname.TextLength < 1)
                throw new ArgumentNullException("name panme");
            var command = MainForm.command;
            command.CommandText = string.Format("insert into shop(pname,name,address,tel,worker,rq) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                textBox_pname.Text, textBox_name.Text, textBox_address.Text, textBox_tel.Text, textBox_worker.Text, DateTime.Now.ToString());
            command.ExecuteNonQuery();
            foreach (var c in this.Controls)
                if (c is TextBox) (c as TextBox).Clear();
            textBox_name.Select();
            MessageBox.Show("新增门店成功！");
        }
    }
}
