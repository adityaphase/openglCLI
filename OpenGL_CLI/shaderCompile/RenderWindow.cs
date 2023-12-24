using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;
using System.Threading;

#pragma warning disable 8618

namespace OpenGL_2D
{
    public class RenderWindow(int width, int height, string title)
    : GameWindow(GameWindowSettings.Default, new NativeWindowSettings()
    { ClientSize = new Vector2i(width, height), Title = title })
    {
        private float Height = (float)height;
        private float Width = (float)width;

        private VBuffer VertexStorageBuffer;
        private VertexArrayObj VertexArrayObject;
        private InBuffer ElementBufferObject;
        private Shader shader;

        private readonly uint[] indices = new uint[]
        {
            0, 1, 3,
            1, 2, 3
        };

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.4f, 0.0f, 0.7f, 0.5f);

            VertexPositionColor[] vertices = new VertexPositionColor[]
            {
            new VertexPositionColor(new Vector2(1.0f, 1.0f), new Color4(0.0f, 0.0f, 0.0f, 0.0f)),
            new VertexPositionColor(new Vector2(-1.0f, 1.0f), new Color4(0.0f, 0.0f, 0.0f, 0.0f)),
            new VertexPositionColor(new Vector2(-1.0f, -1.0f), new Color4(0.0f, 0.0f, 0.0f, 0.0f)),
            new VertexPositionColor(new Vector2(1.0f, -1.0f), new Color4(0.0f, 0.0f, 0.0f, 0.0f))
            };

            VertexStorageBuffer = new VBuffer(VertexPositionColor.vertexInfo, vertices.Length);
            VertexStorageBuffer.FetchData(vertices, vertices.Length);

            VertexArrayObject = new VertexArrayObj(VertexStorageBuffer);

            ElementBufferObject = new InBuffer(indices.Length);
            ElementBufferObject.FetchData(indices, indices.Length);

            //shader = new Shader("shader.vert", "shader.frag");
            shader = new Shader("shader.vert", FileManage.FragFileNameReturn());

            shader.Use();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            shader.Use();

            double someTime = GLFW.GetTime();

            int sendResolution = GL.GetUniformLocation(shader.Handle, "u_resolution");
            GL.Uniform2(sendResolution, this.Width, this.Height);
            int sendTime = GL.GetUniformLocation(shader.Handle, "u_time");
            GL.Uniform1(sendTime, (float)someTime);

            GL.BindVertexArray(VertexArrayObject.VertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyPress = KeyboardState;

            if (keyPress.IsKeyDown(Keys.Up)) Close();

        }

        protected override void OnUnload()
        {
            base.OnUnload();

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            VertexStorageBuffer?.Dispose();
            ElementBufferObject?.Dispose();
            VertexArrayObject?.Dispose();
            GL.DeleteProgram(shader.Handle);
        }
    }
}
