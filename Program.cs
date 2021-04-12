using System;
using FileManager.service;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(@"C:\Go");
            string[] commands = {""};

            while (commands[0] != Command.stop.ToString())
            {
                manager.showCurrentDir();
                Console.WriteLine("-----------------");
                Console.Write("Enter commands, splited by space: ");

                commands = Console.ReadLine().Split(' ');

                if (commands[0] == Command.dir.ToString())
                {
                    if (commands[1] == Command.up.ToString())
                    {
                        manager.toUpperDir();
                    }
                    else if (commands[1] == Command.to.ToString())
                    {
                        manager.setPath(manager.getPath() + '\\' + commands[2]);
                    }
                    else if (commands[1] == Command.remove.ToString())
                    {
                        manager.removeDir(commands[2]);
                    }
                    else if (commands[1] == Command.attrib.ToString())
                        manager.getFileAttributes(commands[2]);
                    Console.WriteLine("-----------------");
                }
            }
        }
    }
}
