using OpenGL_2D;

namespace OpenGL_CLI
{
    public class FileArguments : Program
    {
        private static string finalFilePath = string.Empty;
        public static string FinalFilePath
        {
            get
            {
                return finalFilePath;
            }
            set
            {
                finalFilePath = value;
            }
        }
        public static void FileArgs(string arg, string? data = null)
        {
            try
            {
                if (arg[1] == 'h')
                {
                    Console.WriteLine("Help:\n -h: help\n -f path to file\n");
                }
                else if (arg[1] == 'f')
                {
                    if (data == null)
                    {
                        Console.WriteLine("Invalid File Path Specified.");
                    }
                    else
                    {
                        if (File.Exists(data))
                        {
                            if(CheckFileExtension.CheckFileExt(data))
                            {
                                FinalFilePath = data;
                            }
                            else
                            {
                                Console.WriteLine("Invalid File Extension.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("File Not Found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Arguments.");
                }
            }
            catch
            {
                checkArgException = true;
            }
        }
    }
}