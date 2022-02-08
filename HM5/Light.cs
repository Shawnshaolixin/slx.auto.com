using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class Light
    {
        private Vector3 position;
        private Vector3 intensity;
        public Light(Vector3 p, Vector3 i)
        {
            position = p;
            intensity = i;
        }
    }
}
