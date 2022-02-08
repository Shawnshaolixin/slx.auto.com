using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM5
{
    public class Scene
    {
        public int width = 1280;
        public int height = 720;
        private double fov = 90;
        private Vector3 backgroundColor = new Vector3(0.235294f, 0.67451f, 0.843137f);

        private int maxDepth = 5;
        private float epsilon = 0.00001f;

        private List<MyObject> objects = new List<MyObject>();
        private List<Light> lights = new List<Light>();

        public Scene(int w, int h)
        {
            width = w;
            height = h;
        }
        public void Add(MyObject obj)
        {
            objects.Add(obj);
        }

        public void Add(Light light)
        {
            lights.Add(light);
        }

    }
}
