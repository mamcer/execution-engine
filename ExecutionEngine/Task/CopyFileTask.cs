using System;
using System.IO;

namespace ExecutionEngine.Task
{
    public class CopyFileTask : ITask
    {
        private readonly string _fromFilePath;
        private readonly string _toFolderPath;

        public CopyFileTask(string fromFilePath, string toFolderPath)
        {
            _fromFilePath = fromFilePath;
            _toFolderPath = toFolderPath;
        }

        public void Run()
        {
            try
            {
                if (!File.Exists(_fromFilePath))
                {
                    throw new ArgumentException("fromFilePath: File doesn't exists or don't have access.", "fromFilePath");
                }

                if (!Directory.Exists(_toFolderPath))
                {
                    throw new ArgumentException("toFolderPath: Folder doesn't exists or don't have access.", "toFolderPath");
                }

                var fileNameWithExtension = Path.GetFileName(_fromFilePath);

                if (fileNameWithExtension == null)
                {
                    throw new TaskException("Cannot extract file name from path: " + _fromFilePath);
                }

                var destinationFileName = Path.Combine(_toFolderPath, fileNameWithExtension);
                File.Copy(_fromFilePath, destinationFileName, true);
                File.SetAttributes(destinationFileName, FileAttributes.Normal);
            }
            catch (Exception ex)
            {
                throw new TaskException(ex.Message);
            }
        }
    }
}