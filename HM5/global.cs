using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class global
    {
        public static bool solveQuadratic(float a, float b, float c, out float x0, out float x1)
        {
            float temp;
            float discr = b * b - 4 * a * c;
            if (discr < 0)
            {
                x0 = 0;
                x1 = 0;
                return false;
            }

            else if (discr == 0)
                x0 = x1 = -0.5f * b / a;
            else
            {
                var q = (float)((b > 0) ? -0.5 * (b + MathF.Sqrt(discr)) : -0.5 * (b - MathF.Sqrt(discr)));
                x0 = q / a;
                x1 = c / q;
            }

            if (x0 > x1)
            {
                temp = x0;
                x0 = x1;
                x1 = temp;
                //  std::swap(x0, x1); // 交换 
            }

            return true;
        }
    }
   public enum MaterialType
    {
        DIFFUSE_AND_GLOSSY,
        REFLECTION_AND_REFRACTION,
        REFLECTION
    };
}
