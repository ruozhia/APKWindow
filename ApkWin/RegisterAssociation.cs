using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkWin
{

    public class RegisterAssociation
    {

        private const string FileType = "APKFile";
        private const string FileExtension = ".apk";
        private const string FileTypeDescription = "Android Application Package";

        public RegisterAssociation()
        {
            try
            {
                // 获取当前程序路径
                string appPath = Process.GetCurrentProcess().MainModule.FileName;

                // 创建文件扩展名关联
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(FileExtension))
                {
                    key.SetValue("", FileType);
                }

                // 创建文件类型描述
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(FileType))
                {
                    key.SetValue("", FileTypeDescription);

                    // 设置默认图标
                    using (RegistryKey iconKey = key.CreateSubKey("DefaultIcon"))
                    {
                        iconKey.SetValue("", $"\"{appPath}\",0");
                    }

                    // 创建打开命令
                    using (RegistryKey shellKey = key.CreateSubKey("shell\\open\\command"))
                    {
                        shellKey.SetValue("", $"\"{appPath}\" \"%1\"");
                    }
                }

                // 刷新Shell通知
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

                MessageBox.Show(".apk 文件关联已成功注册！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("需要管理员权限才能注册文件关联！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"注册失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
