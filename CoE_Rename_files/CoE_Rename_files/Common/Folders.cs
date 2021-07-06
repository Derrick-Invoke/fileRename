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

        public static string  SelectFolder()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            var folderpath = folder.SelectedPath;
            return folderpath;
        }
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

        public static void GetPdfFiles(List<string> paths)
        {
            int count = 1;
            List<string> files = new List<string>();
            //foreach (var path in paths)
            //{
                //var pathName = path.Substring(3).Replace("\\", "_");
                List<string> fileNames = Directory.GetFiles(@"C:\\programmin\\Coe Folders\\", "*.pdf").Select(Path.GetFileName).ToList();
                
                foreach (var fileName in fileNames)
                {
                    int i = fileNames.IndexOf(fileName);
                     RenameFiles(@"C:\\programmin\\Coe Folders" + "\\"+fileName, @"C:\\programmin\\Coe Folders" + "\\"+ count.ToString()+".pdf");
                    count++;
                    Console.WriteLine(count);
                }
            //}
        }

        public static void RenameFiles(string oldName ,string newname)
        {
            try
            {
                System.IO.File.Move(oldName, newname);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        public static void MovePdfFiles(List<string> paths)
        {
            //List<string> test = new List<string>()
            int count = 1;
            List<string> files = new List<string>();
            foreach (var path in paths)
            {
                var pathName = path.Substring(3).Replace("\\", "_");
                List<string> fileNames = Directory.GetFiles(path, "*.pdf").Select(Path.GetFileName).ToList();
             //   fileNames.Add(Directory.GetFiles(path, "*.pdf").Select(Path.GetFileName).ToList());
                Console.WriteLine(fileNames.Count);

                Parallel.ForEach(fileNames, fileName =>
                {

                    ///int i = fileNames.IndexOf(fileName);
                    // RenameFiles(path + "\\" + fileName, @"E:\\Final Verified\\" + fileName);
                    //count++;
                });
/*                foreach (var fileName in fileNames)
                {
                    
                    int i = fileNames.IndexOf(fileName);
                    RenameFiles(path + "\\" + fileName, @"E:\\Final Verified\\" + fileName);
                    count++;
                }*/
            }
        }
    }
}
