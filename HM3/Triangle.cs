using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using Vector = MathNet.Numerics.LinearAlgebra.Complex.Vector;

namespace HM3
{
    public class Triangle
    {
        public DenseVector[] v { get; set; }
        public Vector3[] color { get; set; }

        public Vector2[] tex_coords { get; set; }
        public Vector3[] normal { get; set; }

        public Triangle()
        {
            v = new DenseVector[3];
            color = new Vector3[3];
            tex_coords = new Vector2[3];
            normal = new Vector3[3];
        }

        public Triangle(DenseVector[] _v,Vector3[] _color, Vector2[] _tex_coords,Vector3[] _normal)
        {
            v = _v;
            color = _color;
            tex_coords = _tex_coords;
            normal = _normal;
        }
        public Vector3 a()
        {
            return new Vector3((float)v[0].Values[0], (float)v[0].Values[1], (float)v[0].Values[2]);
        }

        public Vector3 b()
        {
            return new Vector3((float)v[1].Values[0], (float)v[1].Values[1], (float)v[1].Values[2]);
        }

        public Vector3 c()
        {
            return new Vector3((float)v[2].Values[0], (float)v[2].Values[1], (float)v[2].Values[2]);
        }

        public void setVertex(int ind, DenseVector ver)
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

                   return new Vector4((float)z.Values[0], (float)z.Values[1], (float)z.Values[2], 1.0f);
               }).ToArray();
            return res;
        }
    }
}