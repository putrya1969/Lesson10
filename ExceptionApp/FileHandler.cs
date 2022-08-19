using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionApp
{
    public class FileHandler
    {
        public string FullFileName { get;}
        public string[] Content { get; set; } = null;

        public FileHandler(string fullFileName)
        {
            FullFileName = fullFileName;
            try
            {
                Content = GetFileContent();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Program.CloseApp("Application was halted");
            }
        }

        private string[] GetFileContent()
        {
            StringBuilder content = null;

            using (StreamReader reader = new StreamReader(FullFileName))
            {
                content = new StringBuilder(reader.ReadToEnd());
            }
            return content.ToString().Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
