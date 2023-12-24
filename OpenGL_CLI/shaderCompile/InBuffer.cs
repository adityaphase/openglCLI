using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenGL_2D
{
    public sealed class InBuffer : IDisposable
    {
        private bool _disposed;
        private const int MinCount = 1;
        private const int MaxCount = 25000;

        private readonly int ElementBufferObject;
        private readonly int IndexCount;

        public InBuffer(int indexCount) 
        {
            this._disposed = false;
            if(indexCount < MinCount || indexCount > MaxCount) throw new ArgumentOutOfRangeException("index");
            this.IndexCount = indexCount;

            this.ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexCount * sizeof(uint), IntPtr.Zero,
                BufferUsageHint.DynamicDraw);

        }

        public void FetchData(uint[] indices, int count)
        {
            if (indices is null || indices.Length <= 0)
            {
                throw new ArgumentNullException(nameof(indices));
            }
            else if (count <= 0 || count > this.IndexCount || count > indices.Length)
            {
                throw new Exception("out of range");
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.ElementBufferObject);
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, count * sizeof(uint), indices);
            
        }
        ~InBuffer() 
        {
            this.Dispose();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                return;
            }
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            this._disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
