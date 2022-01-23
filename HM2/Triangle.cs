using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector = MathNet.Numerics.LinearAlgebra.Complex.Vector;

namespace HM2
{
    public class Triangle
    {
        public Vector3[] v { get; set; }
        public Vector3[] color { get; set; }

        public Vector2[] tex_coords { get; set; }
        public Vector3[] normal { get; set; }

        public Triangle()
        {
            v = new Vector3[3];
            color = new Vector3[3];
            tex_coords = new Vector2[3];
            normal = new Vector3[3];
        }
        public Vector3 a()
        {
            return v[0];
        }

        public Vector3 b()
        {
            return v[1];
        }

        public Vector3 c()
        {
            return v[2];
        }

        public void setVertex(int ind, Vector3 ver)
        {
            v[ind] = ver;
        }

        public Vector3 getColor()
        {
            return color[0] * 255;
        }
        public void setNormal(int ind, Vector3 n)
        {
            normal[ind] = n;
        }

        public void setColor(int ind, float r, float g, float b)
        {
            color[ind] = new Vector3(r / 255.0f, g / 255.0f, b / 255.0f);
        }

        public void setTexCoord(int ind, float s,
            float t)
        {
            tex_coords[ind] = new Vector2(s, t);
        }

        public Vector4[] toVector4()
        {

            var res = v.Select(z =>
               {
                   return new Vector4(z.X, z.Y, z.Z, 1.0f);
               }).ToArray();
            return res;
        }
    }
}