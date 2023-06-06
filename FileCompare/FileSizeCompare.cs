﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    public class FileSizeCompare : AFileCompare
    {
        public FileSizeCompare() : base("FileSize_4096")
        {
        }

        public override bool CompareCore(string file1, string file2)
        {
            using (FileStream fs1 = new FileStream(file1, FileMode.Open))
            using (FileStream fs2 = new FileStream(file2, FileMode.Open))
            {
                byte[] buffer1 = new byte[4096];
                byte[] buffer2 = new byte[4096];

                int bytesRead1;
                int bytesRead2;

                do
                {
                    bytesRead1 = fs1.Read(buffer1, 0, buffer1.Length);
                    bytesRead2 = fs2.Read(buffer2, 0, buffer2.Length);

                    if (bytesRead1 != bytesRead2)
                    {
                        return false;
                    }

                    for (int i = 0; i < bytesRead1; i++)
                    {
                        if (buffer1[i] != buffer2[i])
                        {
                            return false;
                        }
                    }
                } while (bytesRead1 > 0);

                return true;
            }
        }
    }
}
