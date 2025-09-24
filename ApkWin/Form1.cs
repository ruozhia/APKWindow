using ApkReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ApkWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            btn_test.AllowDrop = true;
            btn_test.DragEnter += Form1_DragEnter;
            btn_test.DragDrop += Form1_DragDrop;

            //var path = System.Windows.Forms.Application.StartupPath;
            //for (int i = 0; i < 3; i++)
            //{
            //    path = Path.GetDirectoryName(path);
            //}
            //Console.WriteLine("路径:::::"+ path+@"\tool\ppat2.exe");

        }

        public Form1(string apkPath) : this()
        {

            //MessageBox.Show("传入的参数:::::" + apkPath);

            showAppInfo(apkPath);
            ApkIconLocator.GetIconPath(apkPath);
            showApkIconAndName(ApkIconLocator.iconPath, apkPath);
        }



        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // 判断拖入的数据是否为文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖入的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];  // 第一个文件路径
                //MessageBox.Show("拖入的文件路径：" + filePath);
                // 你可以在这里做其他处理，例如显示到 TextBox
                showAppInfo(filePath);
                ApkIconLocator.GetIconPath(filePath);
                showApkIconAndName(ApkIconLocator.iconPath, filePath);
          }
        }

        /**
         * 显示APK信息
         */
        private void showAppInfo(string apkPath)
        {
            //string apkPath = "C:\\Users\\admin\\Desktop\\catlog\\lazy312_003_nosn_V1.2.1.apk";

            FileStream apkStream = File.OpenRead(apkPath);

            //var reader = new ApkReader.ApkReader();
            //var apkInfo = reader.Read(apkStream);

            var apkInfo = ApkHelper.GetManifestInfo(apkStream);

            string permission = "";
            string apkPackageName = "";
            string apkVersionName = "";
            string apkVersionCode = "";
            string apkTargetSdkVersion = "";
            string apkMinSdkVersion = "";
            for (int i = 0; i < apkInfo.Count; i++)
            {
                for (int j = 0; j < apkInfo[i].Settings.Count; j++)
                {
                    if (apkInfo[i].Settings[j].Name.Equals("package"))
                    {
                        apkPackageName = apkInfo[i].Settings[j].Value;
                    }
                    else if (apkInfo[i].Settings[j].Name.Equals("android:versionCode"))
                    {
                        apkVersionCode = apkInfo[i].Settings[j].Value;
                    }
                    else if (apkInfo[i].Settings[j].Name.Equals("android:versionName"))
                    {
                        apkVersionName = apkInfo[i].Settings[j].Value;
                    }
                    else if (apkInfo[i].Settings[j].Name.Equals("android:targetSdkVersion"))
                    {
                        apkTargetSdkVersion = apkInfo[i].Settings[j].Value;
                    }
                    else if (apkInfo[i].Settings[j].Name.Equals("android:minSdkVersion"))
                    {
                        apkMinSdkVersion = apkInfo[i].Settings[j].Value;
                    }
                    else if (apkInfo[i].Settings[j].Value.Contains("android.permission"))
                    {
                        permission += apkInfo[i].Settings[j].Value + "\n";
                    }

                }
            }

            tb_package_name.Text = apkPackageName;
            tb_version_code.Text = apkVersionCode;
            tb_version_name.Text = apkVersionName;
            tb_target_sdk_version.Text = apkTargetSdkVersion;
            tb_min_sdk_version.Text = apkMinSdkVersion;
            rtb_permission.Text = permission;
            tb_md5.Text = ApkHelper.GetLargeFileMD5(apkPath);
        }

        /**
        * 显示APK图标
        */
        private void showApkIconAndName(string iconPath, string apkPath)
        {

            if (iconPath.Equals(""))
            {
                return;
            }
            using (ZipArchive zip = ZipFile.OpenRead(apkPath))
            {
                var iconEntry = zip.GetEntry(iconPath);
                if (iconEntry != null)
                {
                    using (var iconStream = iconEntry.Open())
                    {
                        // 用 Image.FromStream 读取图标文件流
                        try
                        {
                            imv_icon.Image = Image.FromStream(iconStream);
                        }
                        catch (Exception e)
                        {

                        }

                    }
                }
                else
                {
                    MessageBox.Show("未找到图标文件：" + iconPath);
                }
            }

            if (ApkIconLocator.mApkLabel != null || !"".Equals("ApkIconLocator.mApkLabel"))
            {
                tb_label.Text = ApkIconLocator.mApkLabel;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void 保存图标至桌面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApkIconLocator.SaveIconToDeskTop();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new RegisterAssociation();
        }
    }
}
