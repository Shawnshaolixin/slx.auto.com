using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class MyObject
    {   // material properties
      public  MaterialType materialType;
      public float ior;
      public float Kd, Ks;
      public Vector3 diffuseColor;
      public float specularExponent;
        public MyObject()
        {
            materialType = MaterialType.DIFFUSE_AND_GLOSSY;
            ior = 1.3f;
            Kd = 0.8f;
            Ks = 0.2f;
            diffuseColor = new Vector3(0.2f, 0.2f, 0.2f);
            specularExponent = 25;
        }
        public virtual bool intersect(Vector3 a, Vector3 b,out float c, int d, Vector2 e)
        {
            c = 0;
            return false;
        }
        public virtual void getSurfaceProperties(Vector3 a, Vector3 b, int c, Vector2 d,out Vector3 e, Vector2 f)
        {
            e= Vector3.One;
            return;
        }
        public virtual Vector3 evalDiffuseColor(Vector2 a)
        {
            return diffuseColor;
        }
    }
}
