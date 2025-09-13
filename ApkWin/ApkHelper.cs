using AndroidXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
 

