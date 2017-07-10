using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFilesByDate
{
    class MoveFiles
    {
        private static StreamWriter _sw;
        /// <summary>
        /// First argument is the source directory
        /// Second argument it the target directory
        /// Third argument - if present, just create directory structure
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Check for 2 or 3 arguments
            // Verify source directory exists
            // Check or create target as needed
            // Process each file/directory
            using (_sw = new StreamWriter(@"c:\tmp\MoveLog.csv"))
            {
                ProcessDirectory(@"y:\Amazon Drive\Pictures\cici", @"c:\tmp");
            }
        }
        /// <summary>
        /// Process a file or directory
        /// </summary>
        /// <param name="fileName"> the file to process</param>
        /// <param name="targetDir">The root target directory</param>
        static void ProcessDirectory(string pathName, string targetDir)
        {
            if (pathName.EndsWith("$RECYCLE.BIN"))
            {
                return;
            }
            Console.WriteLine("Processing " + pathName);
            var files = Directory.GetFiles(pathName);
            foreach (var file in files)
            {
                ProcessFile(file, targetDir);
            }
            var folders = Directory.GetDirectories(pathName);
            foreach (var dir in folders)
            {
                ProcessDirectory(dir, targetDir);
            }
        }

        private static void ProcessFile(string file, string targetDir)
        {
            //  get target directory
            var fpath = GetDirPath(targetDir, file);
            //  create it
            Directory.CreateDirectory(fpath);
            _sw.WriteLine(string.Format("\"{0}\",\"{1}\"", file, fpath));
            //  copy the files
            var tofile = Path.GetFileName(file);
            CopyFile(file, Path.Combine(fpath, tofile));
        }

        public static void CopyFile(string copyFromPath, string copyToPath)
        {
            if (File.Exists(copyToPath))
            {
                var target = new FileInfo(copyToPath);
                if (target.IsReadOnly)
                    target.IsReadOnly = false;
            }

            var origin = new FileInfo(copyFromPath);
            origin.CopyTo(copyToPath, true);

            var destination = new FileInfo(copyToPath);
            if (destination.IsReadOnly)
            {
                destination.IsReadOnly = false;
                destination.CreationTime = origin.CreationTime;
                destination.LastWriteTime = origin.LastWriteTime;
                destination.LastAccessTime = origin.LastAccessTime;
                destination.IsReadOnly = true;
            }
            else
            {
                destination.CreationTime = origin.CreationTime;
                destination.LastWriteTime = origin.LastWriteTime;
                destination.LastAccessTime = origin.LastAccessTime;
            }
        }

        static string GetDirPath(string targetDir, string fileName)
        {
            var fi = new FileInfo(fileName);
            var ct = fi.CreationTime;
            var year = ct.Year.ToString();
            var month = string.Format("{0}-{1}", ct.Month.ToString("D2"), ct.ToString("MMM"));
            var day = string.Format("{0}-{1}", ct.Day.ToString("D2"), ct.ToString("ddd"));

            var fPath = Path.Combine(targetDir, year);
            fPath = Path.Combine(fPath, month);
            fPath = Path.Combine(fPath, day);

            return fPath;
        }
    }
}
