using System;

namespace FileManager.errors
{
    class FileManagerException : Exception
    {
        public FileManagerException(string message)
            : base(message)
        { }
    }
}
