using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PL.Helper
{
    public  static class DecoumentSeting
    {
        public static string UploadFiles(IFormFile file , string FolderName)
        {
            //Get Loceted FolderPass +> 
            //string FolderFiles = "E:\\route\\MVC\\3teir arct\\PL\\wwwroot\\Files\\Imges\\";
            //Dynamic
            //string FolderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + FolderName;
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //Get file name 
            //use Guid to make it uniq=>

            string FileNaem = $"{Guid.NewGuid()} {file.FileName}";
            //Get file path
            string Filepath = Path.Combine(FolderPath, FileNaem);
            //Seave Data as Stream=> DAta pear Time
            using var Fs = new FileStream(Filepath, FileMode.CreateNew);
            file.CopyTo(Fs);
            return FileNaem;

        }
        public static void DeleFile(string FileNaem, string FolderName)
        {
            string filepath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName,FileNaem);
              if(File.Exists(filepath))
                  File.Delete(filepath);
        }
    }
}
