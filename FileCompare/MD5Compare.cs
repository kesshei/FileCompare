using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    public class MD5Compare : AFileCompare
    {
        public MD5Compare() : base("MD5")
        {
        }

        public override bool CompareCore(string file1, string file2)
        {
            using (var md5 = MD5.Create())
            {
                byte[] one, two;
                using (var fs1 = File.Open(file1, FileMode.Open))
                {
                    // 以FileStream读取文件内容,计算HASH值
                    one = md5.ComputeHash(fs1);
                }
                using (var fs2 = File.Open(file2, FileMode.Open))
                {
                    // 以FileStream读取文件内容,计算HASH值
                    two = md5.ComputeHash(fs2);
                }
                for (int i = 0; i < one.Length; i++)
                {
                    if (one[i] != two[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
