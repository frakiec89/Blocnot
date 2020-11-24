using System;
using System.Collections.Generic;
using System.IO; // это надо  подключить
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.BL
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExistFile(string filePath);
        void SaveContent(string filePath, string content);
        void SaveContent(string filePath, string content, Encoding encoding);
    }

    public class FileManager : IFileManager
    {
        private readonly Encoding _encoding = Encoding.UTF8;

        public string GetContent(string filePath, Encoding encoding)
        {
            return File.ReadAllText(filePath, encoding); // он  будет  работать 
        }

        public string GetContent(string filePath) // обертака 
        {
            return GetContent(filePath, _encoding); // он  будет вызываться 
        }

        public void SaveContent(string filePath, string content, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public void SaveContent(string filePath, string content)
        {
            SaveContent(filePath, content, _encoding);
        }

        public bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;
        }
    }
}
