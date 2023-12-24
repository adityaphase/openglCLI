using System.Runtime.CompilerServices;

namespace OpenGL_CLI
{
    public class CheckFileExtension
    {
        public static bool CheckFileExt(string filePath)
        {
            try
            {
                string getExt = Path.GetExtension(filePath);
                if (string.Equals(getExt, ".frag", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("No frag File Specified.");
                }
            }
            catch (ArgumentException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return false;
        }
    }
}