using LumiSoft.Net.Mail;
using LumiSoft.Net.POP3.Client;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ServerReceive
{
    public partial class MainForm : Form
    {
        string pop3Host, user, password;
        const string cs = "data source=localhost;user id=root;password=yuanbo960502;database=mail";
        public static MySqlConnection connection;
        public static MySqlCommand command;
        private Dictionary<string, string> shops;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.InitEventHandler();
        }

        public void InitConfig()
        {
            var xml = new XmlDocument();
            xml.Load("ServerReceive.xml");
            this.pop3Host = xml.SelectSingleNode("/config/pop3Host").InnerText;
            this.user = xml.SelectSingleNode("/config/user").InnerText;
            this.password = xml.SelectSingleNode("/config/password").InnerText;
        }

        public void InitData()
        {
            connection = new MySqlConnection(cs);
            command = connection.CreateCommand();
            connection.Open();
        }

        public void InitShops()
        {
            shops = new Dictionary<string, string>();
            command.CommandText = "select pname,name from shop";
            var read = command.ExecuteReader();
            while (read.Read())
            {
                shops.Add(read.GetString(0), read.GetString(1));
            }
            read.Close();
        }

        public void InitEventHandler()
        {
            //新增备注
            this.toolStripButton_add_note.Click += (o, e) =>
            {
                var input = new Form_Input();
                if (input.ShowDialog() == DialogResult.OK)
                {
                    //command.Parameters.Clear();
                    //command.Parameters.Add(@"rq", MySqlDbType.DateTime).Value = DateTime.Now;
                    //command.Parameters.Add(@"text", MySqlDbType.VarChar).Value = input.Input;
                    command.CommandText = string.Format(@"insert into note(rq,text) 
                        values('{0}','{1}')", DateTime.Now.ToString(), input.Input);
                    command.ExecuteNonQuery();
                    MessageBox.Show("新增备注成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            //查看备注
            this.toolStripButton_view_note.Click += (o, e) =>
            {
                var select = new Form_SelectDate();
                if (select.ShowDialog() == DialogResult.OK)
                {
                    //command.Parameters.Clear();
                    //command.Parameters.Add("start", MySqlDbType.DateTime).Value = select.dateTimePicker1.Value;
                    //command.Parameters.Add("end", MySqlDbType.DateTime).Value = select.dateTimePicker2.Value;
                    //command.CommandText = "select rq as 日期,text as 备注 from note where date(rq)>=date(?start) and date(rq)<date(?end) order by rq desc";
                    command.CommandText = string.Format(@"select rq as 日期,text as 备注 from note where 
                        date(rq)>='{0}' and date(rq)<='{1}'",
                        select.dateTimePicker1.Value.ToShortDateString(),
                        select.dateTimePicker2.Value.ToShortDateString());
                    var dt = new DataTable();
                    var adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);
                    var mdi = new MdiForm();
                    mdi.MdiParent = this;
                    mdi.dataGridView.DataSource = dt;
                    mdi.dataGridView.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss dddd";
                    mdi.Text = "查看备注";
                    mdi.Show();
                }
            };
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            toolStripComboBox门店.Items.Add(new Shop("全部", "qb"));
            foreach (KeyValuePair<string, string> pair in shops)
            {
                var shop = new Shop(pair.Value, pair.Key);
                toolStripComboBox门店.Items.Add(shop);
            }
            toolStripComboBox门店.SelectedIndex = 0;
            this.toolStripComboBox门店.SelectedIndexChanged += this.toolStripComboBox门店_SelectedIndexChanged;
        }

        private void UpdateData()
        {
            using (var pop3 = new POP3_Client())
            {
                pop3.Connect(this.pop3Host, 995, true);
                pop3.Login(this.user, this.password);
                int delete = 0;
                int insert = 0;
                int old = 0;
                int sum = pop3.Messages.Count;
                int newShop = 0;
                foreach (POP3_ClientMessage m in pop3.Messages)
                {
                    var header = Mail_Message.ParseFromByte(m.HeaderToByte());
                    var subject = header.Subject;
                    var ss = subject.Split('@'); // "wkl@2017-01-01"
                    if (ss.Length != 2)
                    {
                        m.MarkForDeletion();
                        delete++;
                        continue;
                    }
                    if (!shops.Keys.Contains<string>(ss[0]))
                    {
                        newShop++;
                        continue;
                    }
                    DateTime dt;
                    if (!DateTime.TryParse(ss[1], out dt))
                    {
                        m.MarkForDeletion();
                        delete++;
                        continue;
                    }
                    if (this.IsOldUid(m.UID)) //如果已读取过的邮件跳过
                    {
                        if (this.IsOldDate(dt))
                        {
                            m.MarkForDeletion(); //过期删除
                            delete++;
                        }
                        old++;
                        continue;
                    }
                    var mail = Mail_Message.ParseFromByte(m.MessageToByte());
                    var xml = new XmlDocument();
                    xml.LoadXml(mail.BodyText);
                    this.InsertData(xml, dt);
                    this.InsertOldMail(m.UID, dt);
                    insert++;
                }

                MessageBox.Show(string.Format("共 {0} 条邮件,删除过期邮件 {1}, 略过已读邮件 {2}, 读取新邮件 {3}.\r\n未识别门店邮件 {4}, (如此值大于零, 请添加新门店!)",
                    sum, delete, old, insert, newShop), "数据处理报告：", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pop3.Disconnect();
                pop3.Dispose();
            }
        }

        private bool IsOldUid(string uid)
        {
            var sql = string.Format("select count(*) from mail where uid='{0}'", uid);
            command.CommandText = sql;
            int count = int.Parse(command.ExecuteScalar().ToString());
            if (count == 1) return true;
            return false;
        }

        private bool IsOldDate(DateTime datetime)
        {
            var now = DateTime.Today;
            var span = now.Subtract(datetime.Date);
            if (span.Days > 10) return true;
            return false;
        }

        private void InsertOldMail(string uid, DateTime date)
        {
            var sql = string.Format("insert into mail(uid,rq) values('{0}','{1}')", uid, date.Date);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        private void InsertData(XmlDocument xml, DateTime dt)
        {
            var root = xml.DocumentElement;
            var goods = root.SelectSingleNode("goods");
            var sale_dbs = root.SelectSingleNode("sale_dbs");
            var sale_mxs = root.SelectSingleNode("sale_mxs");
            string sql_delete, sql_insert;
            #region replace into table `goods`
            sql_delete = string.Format("delete from goods where shop='{0}'", root.Name);
            command.CommandText = sql_delete;
            command.ExecuteNonQuery();
            foreach (XmlNode node in goods.ChildNodes)
            {
                var tm = node.Attributes["tm"].Value;
                var sl = node.Attributes["sl"].Value;
                sql_insert = string.Format("insert into goods (tm,sl,shop) values('{0}',{1},'{2}')", tm, sl, root.Name);
                command.CommandText = sql_insert;
                command.ExecuteNonQuery();
            }
            #endregion

            #region replace into table `sale_db`
            sql_delete = string.Format("delete from sale_db where shop='{0}' and date(rq)='{1}'", root.Name, dt.ToString("yyyy-MM-dd"));
            command.CommandText = sql_delete;
            command.ExecuteNonQuery();
            foreach (XmlNode node in sale_dbs.ChildNodes)
            {
                var djh = node.Attributes["djh"].Value;
                var sl = node.Attributes["sl"].Value;
                var je = node.Attributes["je"].Value;
                var ss = node.Attributes["ss"].Value;
                var zl = node.Attributes["zl"].Value;
                var rq = djh.Substring(0, 4) + "-" + djh.Substring(4, 2) + "-" + djh.Substring(6, 2) + " "
                    + djh.Substring(8, 2) + ":" + djh.Substring(10, 2) + ":" + djh.Substring(12, 2);
                var syy = node.Attributes["syy"].Value;
                sql_insert = string.Format("insert into sale_db(djh,sl,je,ss,zl,rq,syy,shop) values('{0}',{1},{2},{3},{4},'{5}','{6}','{7}')",
                     djh, sl, je, ss, zl, rq, syy, root.Name);
                command.CommandText = sql_insert;
                command.ExecuteNonQuery();
            }
            #endregion

            #region replace into table `sale_mx`
            sql_delete = string.Format("delete from sale_mx where shop='{0}' and date(rq)='{1}'", root.Name, dt.ToString("yyyy-MM-dd"));
            command.CommandText = sql_delete;
            command.ExecuteNonQuery();
            foreach (XmlNode node in sale_mxs.ChildNodes)
            {
                var djh = node.Attributes["djh"].Value;
                var tm = node.Attributes["tm"].Value;
                var sl = node.Attributes["sl"].Value;
                var zq = node.Attributes["zq"].Value;
                var je = node.Attributes["je"].Value;
                var rq = djh.Substring(0, 4) + "-" + djh.Substring(4, 2) + "-" + djh.Substring(6, 2) + " "
                    + djh.Substring(8, 2) + ":" + djh.Substring(10, 2) + ":" + djh.Substring(12, 2);
                sql_insert = string.Format("insert into sale_mx(djh,tm,sl,zq,je,shop,rq) values('{0}','{1}',{2},{3},{4},'{5}','{6}')",
                    djh, tm, sl, zq, je, root.Name, rq);
                command.CommandText = sql_insert;
                command.ExecuteNonQuery();
            }
            #endregion
        }

        private void menuStripMain_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0) e.Item.Visible = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var now = DateTime.Today;
            now = now.Subtract(new TimeSpan(10, 0, 0, 0, 0));
            command.CommandText = string.Format("delete from mail where rq<'{0}'", now.ToString("yyyy-MM-dd"));
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void 新增门店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new NewShop();
            f.ShowDialog(this);
        }

        private void 查看门店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sql = "select name as 名称,pname as 代码,worker as 店长,address as 地址,tel as 电话,rq as 日期 from shop";
            MainForm.command.CommandText = sql;
            var adapter = new MySqlDataAdapter(MainForm.command);
            var dt = new DataTable();
            adapter.Fill(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = "查看门店";
            mdi.dataGridView.DataSource = dt;
            mdi.dataGridView.Columns["日期"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss dddd";
            mdi.dataGridView.Columns["日期"].FillWeight = 130;
            mdi.Show();
        }
        /// <summary>
        /// 从邮箱读取邮件更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.UpdateData();
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "Get Mails Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 全部关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in MdiChildren) f.Close();
        }

        private void 排列窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void toolStripMenuItem单笔明细_Click(object sender, EventArgs e)
        {
            var sf = new Form_SelectDate();
            if (DialogResult.OK == sf.ShowDialog(this))
            {
                Show_DB(sf.dateTimePicker1.Value, sf.dateTimePicker2.Value);
            }
        }

        private void Show_DB(DateTime start, DateTime end)
        {
            var _s = start.ToString("yyyy-MM-dd");
            var _e = end.ToString("yyyy-MM-dd");
            var sql = string.Format("select djh as 单据号,sl as 数量,je as 金额,ss as 实收,zl as 找零,syy as 收银员,shop as 门店,rq as 日期 from sale_db where date(rq)>='{0}' and date(rq)<='{1}'",
                _s, _e);
            command.CommandText = sql;
            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            SetName(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = string.Format("单笔明细：[{0}-->{1}]", _s, _e);
            mdi.dataGridView.DataSource = dt;
            mdi.dataGridView.Columns["日期"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss dddd";
            mdi.dataGridView.Columns["日期"].FillWeight = 130;
            mdi.dataGridView.Columns["金额"].FillWeight = mdi.dataGridView.Columns["数量"].FillWeight = 50;
            mdi.dataGridView.Columns["实收"].FillWeight = mdi.dataGridView.Columns["找零"].FillWeight = 50;
            mdi.dataGridView.Columns["收银员"].FillWeight = mdi.dataGridView.Columns["门店"].FillWeight = 60;
            mdi.Show();
        }

        private void toolStripMenuItem商品明细_Click(object sender, EventArgs e)
        {
            var sf = new Form_SelectDate();
            if (DialogResult.OK == sf.ShowDialog(this))
            {
                Show_MX(sf.dateTimePicker1.Value, sf.dateTimePicker2.Value);
            }
        }

        private void Show_MX(DateTime start, DateTime end)
        {
            var _s = start.ToString("yyyy-MM-dd");
            var _e = end.ToString("yyyy-MM-dd");
            var sql = string.Format("select djh as 单据号,tm as 条码,sl as 数量,zq as 折扣,je as 金额,shop as 门店,rq as 日期 from sale_mx where date(rq)>='{0}' and date(rq)<='{1}'",
                _s, _e);
            command.CommandText = sql;
            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            SetName(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = string.Format("商品明细：[{0}-->{1}]", _s, _e);
            mdi.dataGridView.DataSource = dt;
            mdi.dataGridView.Columns["日期"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss dddd";
            mdi.dataGridView.Columns["日期"].FillWeight = 130;
            mdi.dataGridView.Columns["折扣"].FillWeight = mdi.dataGridView.Columns["数量"].FillWeight = 50;
            mdi.dataGridView.Columns["金额"].FillWeight = mdi.dataGridView.Columns["条码"].FillWeight = 50;
            mdi.dataGridView.Columns["门店"].FillWeight = 60;
            mdi.Show();
        }

        private void SetName(DataTable dt)
        {
            if (dt.Columns.Contains("门店"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["门店"] = shops[row["门店"].ToString()];
                }
            }
        }

        private void 查看库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripComboBox门店.SelectedIndex = 0;
            var sql = "select tm as 条码,sl as 数量,tm*sl as 金额,shop as 门店 from goods";
            command.CommandText = sql;
            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            SetName(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = "查看库存";
            mdi.dataGridView.DataSource = dt;
            mdi.Show();
        }

        private void toolStripComboBox门店_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mdi = this.ActiveMdiChild as MdiForm;
            if (mdi == null) return;
            if (mdi.dataGridView.Columns.Contains("数量") && mdi.dataGridView.Columns.Contains("金额"))
            {
                mdi.comboxindex = this.toolStripComboBox门店.SelectedIndex;
                //when combox index is 0,shop.pname=='qb'
                if (mdi.comboxindex == 0)
                {
                    mdi.dataGridView.DataSource = mdi.m_dt;
                }
                else
                {
                    var shop = toolStripComboBox门店.Items[mdi.comboxindex] as Shop;
                    var drs = mdi.m_dt.Select("门店='" + shop.name + "'");
                    var dt = mdi.m_dt.Clone();
                    foreach (DataRow dr in drs)
                    {
                        dt.Rows.Add(dr.ItemArray);
                    }
                    mdi.dataGridView.DataSource = dt;
                }
            }
        }

        private void toolStripMenuItem价格汇总_Click(object sender, EventArgs e)
        {
            var sf = new Form_SelectDate();
            if (DialogResult.OK == sf.ShowDialog(this))
            {
                Show_JG(sf.dateTimePicker1.Value, sf.dateTimePicker2.Value);
            }
        }

        private void Show_JG(DateTime start, DateTime end)
        {
            var _s = start.ToString("yyyy-MM-dd");
            var _e = end.ToString("yyyy-MM-dd");
            var sql = string.Format("select tm as 条码,sum(sl) as 数量,sum(je) as 金额,shop as 门店 from sale_mx where date(rq)>='{0}' and date(rq)<='{1}' group by shop,tm",
                _s, _e);
            command.CommandText = sql;
            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            SetName(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = string.Format("价格汇总：[{0}-->{1}]", _s, _e);
            mdi.dataGridView.DataSource = dt;
            mdi.Show();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            var mdi = this.ActiveMdiChild as MdiForm;
            if (mdi == null) return;
            if (mdi.Text == "查看门店")
            {
                this.toolStripComboBox门店.Enabled = false;
            }
            else
            {
                this.toolStripComboBox门店.Enabled = true;
            }
        }

        private void toolStripButton_本日价格汇总_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            this.Show_JG(now, now);
        }

        private void toolStripMenuItem按天统计_Click(object sender, EventArgs e)
        {
            var sf = new Form_SelectDate();
            if (sf.ShowDialog(this) != DialogResult.OK) return;
            Show_Day(sf.dateTimePicker1.Value, sf.dateTimePicker2.Value);
        }

        private void Show_Day(DateTime start, DateTime end)
        {
            var _s = start.ToString("yyyy-MM-dd");
            var _e = end.ToString("yyyy-MM-dd");
            var sql = string.Format("select date(rq) as 日期,sum(sl) as 数量,sum(je) as 金额,shop as 门店 from sale_db where date(rq)>='{0}' and date(rq)<='{1}' group by shop,date(rq) order by rq desc",
                _s, _e);
            command.CommandText = sql;
            var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            SetName(dt);
            var mdi = new MdiForm();
            mdi.MdiParent = this;
            mdi.Text = string.Format("按天统计：[{0}-->{1}]", _s, _e);
            mdi.dataGridView.DataSource = dt;
            mdi.dataGridView.Columns["日期"].DefaultCellStyle.Format = "yyyy-MM-dd dddd";
            mdi.Show();
        }

        private void toolStripButton今天统计_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            //var start = now.Subtract(new TimeSpan(30, 0, 0, 0));
            Show_Day(now, now);
        }

        public void SetComboxSelectedIndex(int index)
        {
            this.toolStripComboBox门店.SelectedIndexChanged -= this.toolStripComboBox门店_SelectedIndexChanged;
            this.toolStripComboBox门店.SelectedIndex = index;
            this.toolStripComboBox门店.SelectedIndexChanged += this.toolStripComboBox门店_SelectedIndexChanged;
        }
    }
}
