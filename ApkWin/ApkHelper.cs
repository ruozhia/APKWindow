using AndroidXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ApkWin
{
    public static class ApkHelper
    {


        public static List<AndroidInfo> GetManifestInfo(Stream filestream)
        {
            List<AndroidInfo> androidInfos = new List<AndroidInfo>();
            byte[] manifestData = null;

            ICSharpCode.SharpZipLib.Zip.ZipFile zipfile = new ICSharpCode.SharpZipLib.Zip.ZipFile(filestream);
            foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry item in zipfile)
            {
                if (item.Name.ToLower() == "androidmanifest.xml")
                {
                    using (Stream strm = zipfile.GetInputStream(item))
                    {
                        using (BinaryReader s = new BinaryReader(strm))
                        {
                            manifestData = s.ReadBytes((int)item.Size);
                        }
                    }
                    break;
                }
            }


            #region 读取文件内容
            using (var stream = new MemoryStream(manifestData))
            {
                var reader = new AndroidXmlReader(stream);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                AndroidInfo info = new AndroidInfo();
                                androidInfos.Add(info);
                                info.Name = reader.Name;
                                info.Settings = new List<AndroidSetting>();
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);

                                    AndroidSetting setting = new AndroidSetting() { Name = reader.Name, Value = reader.Value };
                                    info.Settings.Add(setting);
                                }
                                reader.MoveToElement();
                                break;
                            }
                    }
                }
            }
            #endregion
            return androidInfos;
        }

        public static string GetLargeFileMD5(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("文件未找到", filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = new byte[4096]; // 4KB 缓冲区（可根据需求调整）
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    md5.TransformBlock(buffer, 0, bytesRead, null, 0);
                }

                md5.TransformFinalBlock(buffer, 0, 0); // 完成哈希计算

                // 转换结果（同基础版）
                StringBuilder sb = new StringBuilder();
                foreach (byte b in md5.Hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString().ToUpper();
            }
        }
    }


    /// <summary>
    /// android应用程序信息
    /// </summary>
    public class AndroidInfo
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 节点属性集合
        /// </summary>
        public List<AndroidSetting> Settings { get; set; }
    }

    /// <summary>
    /// 节点属性
    /// </summary>
    public class AndroidSetting
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }



}



