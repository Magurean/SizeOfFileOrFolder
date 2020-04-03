using System;
using System.IO;
using System.Collections;

namespace SizeOfFileOrFolder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Path to a file/folder:");
            string path;
            path =Console.ReadLine();
           
            try
            {
                long length = new System.IO.FileInfo(path).Length;
                Console.WriteLine("The size of this file is: {0} bytes.", length);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The size is: {0} bytes.", DirSize(new DirectoryInfo(path)));
            }

        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }

            return size;
        }
    }
}
