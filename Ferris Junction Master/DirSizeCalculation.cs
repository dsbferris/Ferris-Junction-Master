using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ferris_Junction_Master
{
    public static class DirSizeCalculation
    {
        public static long GetDirSize(string directory)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(directory);
            long size = 0;
            while (queue.Count > 0)
            {
                string dir = queue.Dequeue();

                foreach (string subDir in GetTopDirectories(dir))
                {
                    queue.Enqueue(subDir);
                }


                foreach (var file in GetTopFiles(dir))
                {
                    size += new FileInfo(file).Length;
                }
            }
            return size;
        }


        private static IEnumerable<string> GetTopDirectories(string path)
        {
            try
            {
                return Directory.EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        private static IEnumerable<string> GetTopFiles(string path)
        {
            try
            {
                return Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }

        public static long SizeScaleFactor(long[] sizes)
        {
            long min = sizes.Min();
            long factor = 1;
            while (min > 1024 * 10)
            {
                min /= 1024;
                factor *= 1024;
            }
            return factor;
        }

        public static string ToReadableBytes(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            //return String.Format("{0:0.##} {1}", len, sizes[order]);
            return String.Format("{0:0.#}{1}", len, sizes[order]);
        }
    }

}
