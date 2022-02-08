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

            Console.WriteLine("Hello World!");
        }
    }
}
