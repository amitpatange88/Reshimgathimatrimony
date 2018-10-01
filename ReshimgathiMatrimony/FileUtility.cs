using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ReshimgathiMatrimony
{
    public class FileUtility
    {
        public string Path = @"C:\E\VS-Programs\ReshimgathiMatrimony\ReshimgathiMatrimony\Log\";
        public string Name = "ReshimgathiMatrimony-DailyLog-{0}.txt";

        public void CreateFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(content);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine(content);
                }
            }
        }
    }
}