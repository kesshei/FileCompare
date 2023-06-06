using System.ComponentModel;
using System.Data;
using System.Net.Http.Headers;

namespace FileCompare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = new List<(string name, string source, string target)>()
            {
                ("ubuntu_4.58 GB",@"E:\重装系统\ubuntu-22.04.2-desktop-amd64.iso",@"E:\重装系统\ubuntu-22.04.2-desktop-amd64 - 副本.iso"),
                ("Docker_523 MB",@"E:\重装系统\Docker Desktop Installer(1).exe",@"E:\重装系统\Docker Desktop Installer(1) - 副本.exe"),
                ("Postman_116 MB",@"E:\重装系统\Postman-win64-8.5.0-Setup.exe",@"E:\重装系统\Postman-win64-8.5.0-Setup - 副本.exe")
            };
            var list = new List<AFileCompare>();
            list.Add(new MD5Compare());
            list.Add(new HashCompare());
            list.Add(new FileSizeCompare());
            list.Add(new FileSizeCompare2());
            list.Add(new CRCCompare());
            foreach ((string name, string source, string target) in files)
            {
                foreach (var item in list)
                {
                    var result = item.Compare(source, target);
                    Console.WriteLine($"{name} - {item.Name} 结果:{result} {item}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("测试完毕");
            Console.ReadLine();
        }
    }
}