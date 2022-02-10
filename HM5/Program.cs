using System;
using System.Numerics;

namespace HM5
{
    class Program
    {
        static void Main(string[] args)
        {

            Scene scene = new Scene(1280, 960);
            var sph1 = new Sphere(new Vector3(-1f, 0f, -12f), 2);

            sph1.materialType = MaterialType.DIFFUSE_AND_GLOSSY;
            sph1.diffuseColor = new Vector3(0.6f, 0.7f, 0.8f);

            var sph2 = new Sphere(new Vector3(0.5f, -0.5f, -8f), 1.5f);

            sph2.ior = 1.5f;
            sph2.materialType = MaterialType.REFLECTION_AND_REFRACTION;

            scene.Add(sph1);
            scene.Add(sph2);


            Vector3[] vects = new[]
                { new Vector3(-5, -3, -6), new Vector3(5, -3, -6), new Vector3(5,-3,-16), new Vector3(-5,-3,-16) };


            int[] vertIndex = { 0, 1, 3, 1, 2, 3 };
            Vector2[] st = new[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };




            Console.WriteLine("Hello World!");

        }
    }
}

