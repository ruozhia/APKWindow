using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkWin
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 检查命令行参数
            if (args.Length > 0)
            {
                string apkPath = args[0];
                Application.Run(new Form1(apkPath));
            }
            else
            {
                Application.Run(new Form1());
            }


        }
    }
}
