using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerReceive
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mf = new MainForm();
            mf.InitConfig();// 配置文件
            mf.InitData(); //  数据库连接
            mf.InitShops();//  门店配置
            Application.Run(mf);
        }
    }
}
