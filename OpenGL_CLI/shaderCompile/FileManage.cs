using OpenGL_CLI;

namespace OpenGL_2D
{
    public class FileManage : FileArguments
    {
        public static string FragFileNameReturn()
        {
            return FinalFilePath;
        }

        public static string VertFileNameReturn()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shader.vert");
        }
    }
}