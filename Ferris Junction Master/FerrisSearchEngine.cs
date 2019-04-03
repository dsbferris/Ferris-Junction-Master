using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ferris_Directory_Scanner
{
    public static class FerrisSearchEngine
    {

        public static string[] ScanDirectories(string[] directories, string[] extensions, CancellationTokenSource cts)
        {
            List<string> MatchFiles = new List<string>();
            foreach(var dir in directories)
            {
                MatchFiles.AddRange(GetAllFiles(dir, extensions, cts));
            }
            return MatchFiles.ToArray();
        }
        
        private static IEnumerable<string> GetAllFiles(string path, string[] extensions, CancellationTokenSource cts)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                //ct.ThrowIfCancellationRequested();
                if (cts != null && cts.Token.IsCancellationRequested)
                {
                    break;
                }

                path = queue.Dequeue();

                foreach (string subDir in GetTopDirectories(path))
                {
                    queue.Enqueue(subDir);
                }

                string[] files = null;

                files = GetTopFiles(path).ToArray();

                if (files != null && files.Length != 0)
                {
                    foreach(var file in files)
                    {
                        if(extensions == null) yield return file;
                        else
                        {
                            foreach (var extension in extensions)
                            {

                                if (file.ToLower().EndsWith(extension))
                                {
                                    yield return file;
                                    break;
                                }
                                //if(file.ToLower().Contains(extension.ToLower()))
                            }
                        }
                    }
                }
            }
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

    }
}
