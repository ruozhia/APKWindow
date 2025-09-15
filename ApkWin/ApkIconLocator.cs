using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApkWin
{

    public class ApkIconLocator
    {
        static string AAPT_PATH = GetPath();
        public static string iconPath = ""; // 图片路径
        public static string mApkPath = ""; // 图片路径

        public static void GetIconPath(string apkPath)
        {
            string aaptPath = GetPath(); // 修改为你自己的aapt路径

            Console.WriteLine("aapt路径: " + aaptPath);
            MessageBox.Show("aapt路径: " + aaptPath);
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
                if (match.Success)
                {
                    Console.WriteLine("图标路径: " + match.Groups[1].Value);
                    iconPath = match.Groups[1].Value;
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
                        Console.WriteLine("未找到图标路径");
                }
            }
            //SaveIconToDeskTop();

        }

        public static void SaveIconToDeskTop()
        {
            // 获取桌面路径
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string savePath = Path.Combine(desktop, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ".png"); // 可自定义文件名

            if (iconPath.Equals("") || "".Equals(mApkPath))
            {
                return;
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
                    MessageBox.Show("图标已保存到桌面: " + savePath);
                }
                else
                {
                    MessageBox.Show("未找到图标文件：" + iconPath);
                }
            }
        }


        private static string GetPath()
        {
            //var path = System.Windows.Forms.Application.StartupPath;
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            if (path.Contains("D:\\VisualStudio\\project\\ApkWin"))
            {
                for (int i = 0; i < 2; i++)
                {
                    path = Path.GetDirectoryName(path);
                }
            }

            return path + @"\tool\aapt2.exe";
        }
    }
}
