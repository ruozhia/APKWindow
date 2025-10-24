using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ApkWin
{

    public class ApkIconLocator
    {

        public static string iconPath = ""; // 图片路径
        public static string mApkPath = ""; // APK路径
        public static string mApkLabel = ""; // APK名称


        public static void GetIconPath(string apkPath, int plan)
        {

            string aaptPath = GetPath(plan); // 修改为你自己的aapt路径

            Console.WriteLine("aapt路径: " + aaptPath);
            //MessageBox.Show("aapt路径: " + aaptPath);
            mApkPath = apkPath;

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = aaptPath,
                Arguments = $"dump badging \"{apkPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8
            };

            using (Process proc = Process.Start(psi))
            {
                string output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                // 查找 icon 路径（有可能是 icon 或 application-icon-<density>）
                var match = Regex.Match(output, @"application-icon(?:-\d+)?:\'([^\']+)\'");
                var apkLabel = Regex.Match(output, @"application-label(?:-\d+)?:\'([^\']+)\'");
                if (match.Success)
                {
                    Console.WriteLine("图标路径: " + match.Groups[1].Value);
                    Console.WriteLine("apk名称: " + apkLabel.Groups[1].Value);
                    try
                    {
                        iconPath = match.Groups[1].Value;
                        mApkLabel = apkLabel.Groups[1].Value;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("获取apk图标和名称的地方报错了: " + ex.Message);
                        MessageBox.Show("获取apk图标和名称的地方报错了: " + ex.Message);
                    }

                }
                else
                {
                    // 有些apk只输出 icon 字段
                    match = Regex.Match(output, @"icon:\'([^\']+)\'");
                    if (match.Success)
                    {
                        Console.WriteLine("图标路径: " + match.Groups[1].Value);
                        iconPath = match.Groups[1].Value;
                    }

                    else
                    {
                        if (plan == 1)
                        {
                            // 备用方案，使用aapt2再试一次
                            GetIconPath(apkPath, 2);
                            return;
                        }
                        Console.WriteLine("未找到图标路径");
                    }

                }
            }
            //SaveIconToDeskTop();

        }

        public static String SaveIconToDeskTop(bool isShowMessageBox)
        {
            // 获取桌面路径
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string savePath = "";
            if (isShowMessageBox)
            {
                savePath = Path.Combine(desktop, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ".png"); // 可自定义文件名
            }
            else
            {
                //savePath = GetPath().Replace(@"\tool\aapt2.exe", @"\webp\" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ".png");
                savePath = (@"C:\Users\admin\Downloads\" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ".png");
                Console.WriteLine("保存图标路径: " + savePath);
            }
            if (iconPath.Equals("") || "".Equals(mApkPath))
            {
                return null;
            }

            using (ZipArchive zip = ZipFile.OpenRead(mApkPath))
            {
                var iconEntry = zip.GetEntry(iconPath);
                if (iconEntry != null)
                {
                    using (var iconStream = iconEntry.Open())
                    using (var fileStream = File.Create(savePath))
                    {
                        iconStream.CopyTo(fileStream);
                    }
                    if (isShowMessageBox)
                    {
                        MessageBox.Show("图标已保存到桌面: " + savePath);
                    }
                    else
                    {
                        return savePath;
                    }
                }
                else
                {
                    MessageBox.Show("未找到图标文件：" + iconPath);
                }
            }
            return null;
        }

        /**
         * 获取aapt2路径
         * 我这里的位置是D:\VisualStudio\project\ApkWin\ApkWin\tool\aapt2.exe
         * 可以直接写死
         */
        private static string GetPath(int aaptVersion)
        {
            //var path = System.Windows.Forms.Application.StartupPath;
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            //Debug运行的路径需要回退两格，打包后的路径不需要，没什么好的判断条件，随便弄了一个
            if (path.Contains("D:\\VisualStudio\\project\\ApkWin"))
            {
                for (int i = 0; i < 2; i++)
                {
                    path = Path.GetDirectoryName(path);
                }
            }

            /**
             * 因为使用aapt2去取微信apk的信息时，会有很多warning信息导致应用“无响应了”，所以改用aapt去获取
             * 但是使用aapt去获取部分apk会提示“该APK没有Androidmanifest”获取失败，其实那个APK是有的，而aapt2正常
             * 
             * 所以，交替使用吧，默认aapt，aapt2备用方案
             */
            if (aaptVersion == 2)
            {
                return path + @"\tool\aapt2.exe";
            }
            return path + @"\tool\aapt.exe";
        }
    }
}
