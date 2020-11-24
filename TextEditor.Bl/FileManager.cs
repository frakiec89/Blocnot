using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Bl
{

    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetContent(string filePath);
        string GetContent(string filePath , Encoding encoding);

        void SaveContent(string content , string filePath);
        void SaveContent(string content, string filePath ,  Encoding encoding);

        int GetSymbolCount(string content);
    }
    
    public class FileManager : IFileManager
    {
        private readonly Encoding encoding = Encoding.UTF8;

        public string GetContent(string filePath)
        {
            return GetContent(filePath, encoding);
        }

        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;
        }

        public bool IsExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, encoding);
        }

        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }
    }
}
