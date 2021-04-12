using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager.service
{
    class Manager
    {
        private string path;

        public Manager(string path)
        {
            this.path = path;
        }

        public void copyFolder()
        {

        }

        public void getFileAttributes(string fileName)
        {
            FileAttributes attributes = File.GetAttributes(path + @"\" + fileName);
            Console.WriteLine(attributes.ToString());
        }

        public void removeDir(string dirName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path + @"\" + dirName);
                dirInfo.Delete(true);
                Console.WriteLine($"Folder {dirName} was removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void toUpperDir()
        {
            {
                for (int i = path.Length - 1; i >= 0; i--)
                {
                    if (path[i].Equals('\\') && !path[i - 1].Equals(':'))
                    {
                        this.path = path.Substring(0, i);
                        break;
                    }
                    else if (path[i].Equals('\\') && path[i - 1].Equals(':'))
                    {
                        path = @"C:\";
                        break;
                    }
                }
            }
        }

        public void showCurrentDir()
        {
            string currentDir = getPath();
            Console.WriteLine($"Content of {path}");
            contentOfDir(currentDir);
        }

        public void contentOfDir(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine($"{path}");
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                List<string> content = new List<string>();

                foreach (string dir in dirs)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    content.Add($"{dirInfo.Name} |{dirInfo.Attributes} | {dirInfo.CreationTime}");
                }
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    content.Add($"{fileInfo.Name} | {fileInfo.Attributes} | {fileInfo.CreationTime} | {fileInfo.Length} bytes");
                }
                content.Sort();

                foreach(string cont in content)
                {
                    Console.WriteLine(cont);
                }
                
            }
        }

        public void setPath(string newPath)
        {
            this.path = newPath;
        }

        public string getPath()
        {
            return path;
        }
    }
}
