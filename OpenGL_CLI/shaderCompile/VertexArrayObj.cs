using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace OpenGL_2D
{
    public sealed class VertexArrayObj : IDisposable
    {
        private bool _disposed;
        public readonly int VertexArrayObject;
        private readonly VBuffer _buffer;
        public VertexArrayObj(VBuffer vBuffer) 
        {
            _disposed = false;

            if(vBuffer is null)
                throw new ArgumentNullException(nameof(vBuffer));

            this._buffer = vBuffer;

            int vertexByteSize = VertexPositionColor.vertexInfo.SizeInBytes;

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexAttri[] vertexAttri = this._buffer.VertexInfo.Attributes;

            for(int i  = 0; i < vertexAttri.Length;  i++)
            {
                VertexAttri attribute = vertexAttri[i];
                GL.VertexAttribPointer(attribute.Index, attribute.Component, VertexAttribPointerType.Float, false, 
                    vertexByteSize, attribute.Offset);
                GL.EnableVertexAttribArray(attribute.Index);
            }
        }

        ~VertexArrayObj() 
        {
            this.Dispose();
        }
        public void Dispose()
        {
            if( _disposed )
            {
                return;
            }

            GL.DeleteVertexArray(VertexArrayObject);
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
