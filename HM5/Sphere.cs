using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class Sphere : MyObject
    {
        Vector3 center;
        float radius, radius2;
        public Sphere(Vector3 c, float r)
        {
            center = c;
            radius = r;
            radius2 = r * r;
        }

        public override bool intersect(Vector3 orig, Vector3 dir, out float tnear, int d, Vector2 e)
        {
            tnear = 0;
            Vector3 L = orig - center;
            float a = Vector3.Dot(dir, dir);
            float b = 2 * Vector3.Dot(dir, L);
            float c = Vector3.Dot(L, L) - radius2;
            if (global.solveQuadratic(a, b, c, out float t0, out var t1))
            {
                return false;
            }
            if (t0 < 0)
            {
                t0 = t1;
            }
            if (t0 < 0)
            {
                return false;
            }
            tnear = t0;

            return true;
        }

        public override void getSurfaceProperties(Vector3 P, Vector3 b, int c, Vector2 d, out Vector3 N, Vector2 f)
        {
            N = Vector3.Normalize(P - center);
            return; ;
        }
    }
}
