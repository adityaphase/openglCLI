using System;
using System.IO;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;


namespace OpenGL_2D
{
    public class Renderer
    {
        public static void RendererWindow(int width, int height)
        {
            using (RenderWindow renderWindow = new RenderWindow(width, height, "RenderOutput"))
            {
                renderWindow.Run();
            }
        }
    }
}