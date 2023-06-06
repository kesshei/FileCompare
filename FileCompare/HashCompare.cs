using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    public class HashCompare : AFileCompare
    {
        public HashCompare() : base("Hash256")
        {
        }

        public override bool CompareCore(string file1, string file2)
        {
            byte[] one, two;
            using (SHA1 mySHA1 = SHA1.Create())
            {
                using (FileStream stream = File.OpenRead(file1))
                {
                    one = mySHA1.ComputeHash(stream);
                }
            }
            using (SHA1 mySHA1 = SHA1.Create())
            {
                using (FileStream stream = File.OpenRead(file2))
                {
                    two = mySHA1.ComputeHash(stream);
                }
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
