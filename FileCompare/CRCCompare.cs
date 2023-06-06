using Force.Crc32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    public class CRCCompare : AFileCompare
    {
        public CRCCompare() : base("CRC")
        {
        }
        public override bool CompareCore(string file1, string file2)
        {
            Crc32Algorithm crc32 = new Crc32Algorithm();
            byte[] one, two;
            using (var fs1 = File.Open(file1, FileMode.Open))
            {
                one = crc32.ComputeHash(fs1);
            }
            using (var fs2 = File.Open(file2, FileMode.Open))
            {
                two = crc32.ComputeHash(fs2);
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
