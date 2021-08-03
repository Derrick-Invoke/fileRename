using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoE_Rename_files.Common
{
    public static class Folders
    {

        public static List<string>  GetSubFolders(string folderpath)
        {
            string rootFolder =  folderpath;
            List<string> owner = new List<string>();
            List<string> root = Directory.EnumerateDirectories(rootFolder).ToList();

            foreach (var sub in root)
            {
                owner.Add(sub);
                foreach (var subsub in Directory.EnumerateDirectories(sub).ToList())
                {
                    owner.Add(subsub);
                    foreach (var subsubsub in Directory.EnumerateDirectories(subsub).ToList())
                    {
                        owner.Add(subsubsub);
                        foreach (var subsubsubsub in Directory.EnumerateDirectories(subsubsub).ToList())
                        {
                            owner.Add(subsubsubsub);

                            foreach (var subsubsubsubsub in Directory.EnumerateDirectories(subsubsubsub).ToList())
                            {
                                owner.Add(subsubsubsubsub);

                                foreach (var subsubsubsubsubsub in Directory.EnumerateDirectories(subsubsubsubsub).ToList())
                                {
                                    owner.Add(subsubsubsubsubsub);
                                    foreach (var subsubsubsubsubsubsub in Directory.EnumerateDirectories(subsubsubsubsubsub).ToList())
                                    {
                                        owner.Add(subsubsubsubsubsubsub);

                                        foreach (var subsubsubsubsubsubsubsub in Directory.EnumerateDirectories(subsubsubsubsubsubsub).ToList())
                                        {
                                            owner.Add(subsubsubsubsubsubsubsub);
                                            foreach (var subsubsubsubsubsubsubsubsub in Directory.EnumerateDirectories(subsubsubsubsubsubsubsub).ToList())
                                            {
                                                owner.Add(subsubsubsubsubsubsubsubsub);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<string> extensions = new List<string>();

            extensions.Add(Path.GetExtension(root.ToString()));

            return owner;
        }

        static List<string> directories = new List<string>();

        public static List<string> LoadSubDirs(string dir)
        {
            directories.Add(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
            return directories;
        }

        public static void GetSubDirectories(string root)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(root);

            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
        }
        public static void GetPdfFiles(List<string> paths, string MoveTo)
        {
            int count = 1;
            List<string> files = new List<string>();
            foreach (var path in paths)
            {
                List<string> fileNames = Directory.GetFiles(path, "*.pdf").Select(Path.GetFileName).ToList();
                foreach (var fileName in fileNames)
                {
                    int i = fileNames.IndexOf(fileName);
                    System.IO.File.Copy(path + "\\" + fileName, MoveTo + "\\" + count.ToString() + ".pdf");
                    count++;
                }
            }
        }
    }
}
