using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare
{
    public abstract class AFileCompare
    {
        public AFileCompare(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public bool Compare(string file1, string file2)
        {
            var result = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            if (Check(file1, file2))
            {
                result = CompareCore(file1, file2);
            }
            stopwatch.Stop();
            TimeSpan = stopwatch.Elapsed;
            return result;
        }
        public abstract bool CompareCore(string file1, string file2);
        public TimeSpan TimeSpan { get; set; }
        public bool Check(string file1, string file2)
        {
            if (file1 == file2)
            {
                return true;
            }
            if (new FileInfo(file1).Length == new FileInfo(file2).Length)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Name}耗时:{TimeSpan.TotalSeconds}秒";
        }
    }
}
