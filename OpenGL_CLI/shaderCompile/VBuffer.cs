using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGL_2D
{
    public sealed class VBuffer : IDisposable
    {
        private bool isDisposed;

        public const int MinVertexCount = 1;
        public const int MaxVertexCount = 100;
        public readonly int VertexStorageBuffer;
        public readonly VertexInfo VertexInfo;
        public readonly int VertexCount;

        public VBuffer(VertexInfo vertexInfo, int vertexCount)
        {
            this.isDisposed = false;

            if (vertexCount < MinVertexCount || vertexCount > MaxVertexCount) 
                throw new Exception("Vertex Count out of range");

            this.VertexInfo = vertexInfo;
            this.VertexCount = vertexCount;

            int vertexByteSize = VertexPositionColor.vertexInfo.SizeInBytes;

            this.VertexStorageBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.VertexStorageBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, this.VertexCount * vertexByteSize,
                IntPtr.Zero, BufferUsageHint.DynamicDraw);
        }

        public void FetchData<T>(T[] data, int count) where T : struct
        {
            if(typeof(T) != this.VertexInfo.Type)
            {
                throw new Exception("data type mismatch");
            }
            else if (data is null || data.Length <= 0)
            {
                throw new ArgumentNullException(nameof(data));
            }
            else if (count <= 0 || count > this.VertexCount || count > data.Length)
            {
                throw new Exception("out of range");
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.VertexStorageBuffer);
            GL.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, count * this.VertexInfo.SizeInBytes, data);
            
        }

        ~VBuffer()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }

            GL.DeleteBuffer(this.VertexStorageBuffer);

            this.isDisposed = true;
            GC.SuppressFinalize(this);
        }

    }
}
