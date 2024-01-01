using OpenGL_2D;

namespace OpenGL_CLI
{
    public class OpenglCLI //lol
    {
        public static bool checkArgException = false;
        public static bool checkIfExceptionRaised = false;
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No Arguments Provided. Use -h for help.");
            }
            else if (args.Length == 1)
            {
                string userArgs = args[0];
                if (string.IsNullOrEmpty(userArgs))
                {
                    Console.WriteLine("No Arguments Provided.");
                }
                else
                {
                    FileArguments.FileArgs(userArgs);
                }
            }
            else if (args.Length == 2)
            {
                string userArgSelect = args[0];
                string userArgData = args[1];

                if (!string.IsNullOrEmpty(userArgSelect))
                {
                    try
                    {
                        FileArguments.FileArgs(userArgSelect, userArgData);
                        Renderer.RendererWindow();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                }
            }
            else if (checkArgException)
            {
                Console.WriteLine("Invalid Arguments Provided. Use -h for help.");
            }

        }
    }
}
