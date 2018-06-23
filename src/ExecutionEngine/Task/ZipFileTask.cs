using System;
using System.IO;
using System.IO.Compression;

namespace ExecutionEngine.Task
{
    public class ZipFileTask : ITask
    {
        private readonly string _fromFilePath;
        private readonly string _toFolderPath;

        public ZipFileTask(string fromFilePath, string toFolderPath)
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
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_fromFilePath);

                if (fileNameWithoutExtension == null || fileNameWithExtension == null)
                {
                    return;
                }

                var tempPath = Path.GetTempPath();

                var tempFolderName = Path.Combine(tempPath, fileNameWithoutExtension);
                Directory.CreateDirectory(tempFolderName);
                var tempFilePath = Path.Combine(tempFolderName, fileNameWithExtension);
                File.Copy(_fromFilePath, tempFilePath, true);
                File.SetAttributes(tempFilePath, FileAttributes.Normal);
                var zipFilePath = Path.Combine(_toFolderPath, fileNameWithExtension + ".zip");
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                }

                ZipFile.CreateFromDirectory(tempFolderName, zipFilePath);
                File.SetAttributes(zipFilePath, FileAttributes.Normal);
                Directory.Delete(tempFolderName, true);
            }
            catch (Exception ex)
            {
                throw new TaskException(ex.Message);
            }
        }
    }
}