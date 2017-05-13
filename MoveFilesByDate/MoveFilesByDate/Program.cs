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
        /// <summary>
        /// First argument is the source directory
        /// Second argument it the target directory
        /// Third argument - if present, just create directory structure
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var foo = GetDirPath(@"C:\Tmp", @"y:\Amazon Drive\Pictures\20160811\DSC08052.JPG");
            Directory.CreateDirectory(foo);
            // Check for 2 or 3 arguments
            // Verify source directory exists
            // Check or create target as needed
            // Process each file/directory
        }
        /// <summary>
        /// Process a file or directory
        /// </summary>
        /// <param name="fileName"> the file to process</param>
        /// <param name="targetDir">The root target directory</param>
        static void ProcessFile(string fileName, string targetDir)
        {
            // If File
            //  get target directory
            //  get dirtectory to send it too
            //  see if directory exists
            //  if not, create it
            //  copy the files
            // else
            //  call ProcessFile
        }

        static string GetDirPath(string target, string fileName)
        {
            var fi = new FileInfo(fileName);
            var ct = fi.CreationTime;
            var year = ct.Year.ToString();
            var month = string.Format("{0}-{1}", ct.Month.ToString("D2"), ct.ToString("MMM"));
            var day = string.Format("{0}-{1}", ct.Day.ToString("D2"), ct.ToString("ddd"));

            var fPath = Path.Combine(target, year);
            fPath = Path.Combine(fPath, month);
            fPath = Path.Combine(fPath, day);

            return fPath;
        }
    }
}
