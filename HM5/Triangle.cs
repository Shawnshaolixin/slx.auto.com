using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class Triangle
    {

    }

    public class MeshTriangle : MyObject
    {
        private Vector3[] vertices;
        private int numTriangles;
        private int[] vertexIndex;
        private Vector2[] stCoordinates;
        public MeshTriangle(Vector3 verts, int[] vertsIndex, int numTris, Vector2 st)
        {
            int maxIndex = 0;
            for (int i = 0; i < numTris * 3; ++i)
            {
                if (vertsIndex[i] > maxIndex)
                {
                    maxIndex = vertsIndex[i];
                }

                maxIndex += 1;
                vertices= new []{new Vector3()}
            }
        }
    }
}
