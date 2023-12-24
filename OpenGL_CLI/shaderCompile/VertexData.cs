using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_2D
{
    public readonly struct VertexAttri
    {
        public readonly string Name;
        public readonly int Index;
        public readonly int Component;
        public readonly int Offset;

        public VertexAttri(string name,int index, int component, int offset)
        {
            this.Name = name;   
            this.Index = index;
            this.Component = component;
            this.Offset = offset;
        }

    }

    public sealed class VertexInfo
    {
        public Type Type;
        public int SizeInBytes;
        public readonly VertexAttri[] Attributes;

        public VertexInfo(Type type, params VertexAttri[] attri)
        {
            this.Type = type;
            this.SizeInBytes = 0;

            this.Attributes = attri;

            for(int i = 0; i < this.Attributes.Length; i++)
            {
                VertexAttri vertexAttri = this.Attributes[i];
                this.SizeInBytes += vertexAttri.Component * sizeof(float);
            }
            
        }
    }

    public struct VertexPositionColor
    {
        public Vector2 position;
        public Color4 color;

        public static readonly VertexInfo vertexInfo = new VertexInfo(
                typeof(VertexPositionColor),
                new VertexAttri("position", 0, 2, 0),
                new VertexAttri("color", 1, 4, 2 * sizeof(float))

            );

        public VertexPositionColor(Vector2 position, Color4 color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
