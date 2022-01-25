using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading;
using MathNet.Numerics.LinearAlgebra;
using OpenCvSharp;
using OpenCvSharp.Aruco;
namespace HM3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HM1();

        }

        private static void HM1()
        {

            List<Triangle> TriangleList = new List<Triangle>();

            float angle = 140;
            float scal = 1;

            bool command_line = false;
            string fileName = "output.png";
            Loader loader = new Loader();
            string obj_path = "../models/spot/";
            var fullPath = Path.GetFullPath("../../..");
            bool loadout = loader.LoadFile("models/spot/spot_triangulated_good.obj");
            foreach (Mesh mesh in loader.LoadedMeshes)
            {
                for (int i = 0; i < mesh.Vertices.Count; i += 3)
                {
                    Triangle t = new Triangle();
                    for (int j = 0; j < 3; j++)
                    {
                        var x = mesh.Vertices[i + j].Position.X * 1.0d;
                        var y = mesh.Vertices[i + j].Position.Y;
                        var z = mesh.Vertices[i + j].Position.Z;
                        t.setVertex(j, new DenseVector(new[] { x, y, z, 1.0f }));//todo 这里是 Vector4
                        t.setNormal(j, mesh.Vertices[j + i].Normal);
                        t.setTexCoord(j, mesh.Vertices[i + j].TextureCoordinate.X, mesh.Vertices[i + j].TextureCoordinate.Y);
                    }
                    TriangleList.Add(t);
                }
            }
            Rasterizer r = new Rasterizer(700, 700);

            var eye_pos = new DenseVector(new[] { 0, 0, 10.0 }); //眼睛位置，摄像机位置？

            //Mat image = new Mat(700, 700, MatType.CV_32FC3,);







            int key = 0;
            int frame_count = 0;

            //if (command_line)
            //{
            //    r.clear(Buffers.Color | Buffers.Depth);
            //    r.set_model(get_model_matrix(angle));
            //    r.set_view(get_view_matrix(eye_pos));
            //    r.set_projection(get_projection_matrix(45, 1, 0.1f, 50));
            //    r.draw(pos_id, ind_id, Primitive.Triangle);
            //    var data = r.frame_buffer().ToArray();

            //    Mat image = new Mat(700, 700, MatType.CV_32FC3, data);
            //    image.ConvertTo(image, MatType.CV_8UC3, 1.0f);
            //    Cv2.ImWrite(fileName, image);
            //    return;

            //}

            while (key != 27)
            {
                //key = Console.ReadKey(false).KeyChar;
                r.clear(Buffers.Color | Buffers.Depth);
                r.set_model(get_model_matrix(angle, scal));
                r.set_view(get_view_matrix(eye_pos));
                r.set_projection(get_projection_matrix(45, 1, 0.1f, 50));

                r.draw(TriangleList);
                var data = r.frame_buffer().ToArray();

                Mat image = new Mat(700, 700, MatType.CV_32FC3, data);
                image.ConvertTo(image, MatType.CV_8UC3, 1.0f);
                Cv2.CvtColor(image, image, ColorConversionCodes.RGB2BGR);
                Cv2.ImShow("image", image);
                key = Cv2.WaitKey(10);
                Console.WriteLine("frame_count=" + frame_count++);
                Thread.Sleep(100);
                if (key == 'a')
                {
                    angle += 10;
                }
                else if (key == 'd')
                {
                    angle -= 10;
                }
                else if (key == 'u')
                {
                    scal += 0.1f;
                }
                else if (key == 'o')
                {
                    scal -= 0.1f;
                }
            }

        }

        static DenseMatrix get_model_matrix(float rotation_angle, float scal = 1)
        {

            DenseMatrix model = DenseMatrix.OfArray(new[,] {
                {1.0, 0,0,0},
                {0, 1, 0,0},
                {0, 0, 1,0},
                {0, 0, 0,1}
            });
            float radian = (float)(rotation_angle / 180.0 * MathF.PI);
            //DenseMatrix rotate = DenseMatrix.OfArray(new[,] {
            //    { MathF.Cos(radian), -MathF.Sin(radian), 0.0,0 },
            //    { MathF.Sin(radian),MathF.Cos(radian), 0,0 },
            //    {0, 0, 1,0},
            //    {0, 0, 0,1}
            //});
            DenseMatrix rotate = DenseMatrix.OfArray(new[,] {
                { MathF.Cos(radian), 0, MathF.Sin(radian),0.0 },
                { 0,1, 0,0 },
                {-MathF.Sin(radian), 0, MathF.Cos(radian),0},
                {0, 0, 0,1}
            });
            DenseMatrix scale = DenseMatrix.OfArray(new[,] {
                {2.5, 0,0,0},
                {0, 2.5, 0,0},
                {0, 0, 2.5,0},
                {0, 0, 0,1}
            });
            //DenseMatrix move = DenseMatrix.OfArray(new[,] {
            //    {1.0, 0,0,1},
            //    {0, 1, 0,1},
            //    {0, 0, 1,1},
            //    {0, 0, 0,1}
            //});
            model = rotate * model * scale;
            return model;
        }

        static DenseMatrix get_view_matrix(DenseVector eye_pos)
        {
            DenseMatrix view = DenseMatrix.OfArray(new[,] {
                {1.0, 0,0,0},
                {0, 1, 0,0},
                {0, 0, 1,0},
                {0, 0, 0,1}
            });
            // 将摄像机位置转换成远点位置 往-z 方向看
            DenseMatrix translate = DenseMatrix.OfArray(new[,] {
                {1.0, 0,0,-eye_pos[0]},
                {0, 1, 0,-eye_pos[1]},
                {0, 0, 1,-eye_pos[2]},
                {0, 0, 0,1}
            });
            view = translate * view;
            return view;
        }

        static DenseMatrix get_projection_matrix(float eye_fov, float aspect_ratio, float zNear, float zFar)
        {
            zNear = -zNear;
            zFar = -zFar;
            float halfEyeAngelRadian = eye_fov / 2.0f / 180.0f * MathF.PI;
            float t = MathF.Tan(halfEyeAngelRadian);
            float top = zNear * (-t);
            float bottom = -top;
            float right = top * aspect_ratio;
            float left = -right;


            DenseMatrix projection = DenseMatrix.OfArray(new[,] {
                {zNear, 0,0,0.0},
                {0, zNear, 0,0},
                {0, 0, zNear+zFar,-zFar*zNear},
                {0, 0, 1,0}
            });
            //float halfEyeAngleRadian = (float)(eye_fov / 2.0 * MathF.PI / 180.0);
            //float top = zNear * (-1) * MathF.Tan(halfEyeAngleRadian);
            //float right = top * aspect_ratio;
            //float left = (-1) * right;//left x轴最小值
            //float bottom = (-1) * top;//bottom y轴的最大值

            DenseMatrix re = DenseMatrix.OfArray(new[,] {
                {2/(right-left), 0,0,0.0},
                {0, 2/(top -bottom), 0,0},
                {0, 0, 2/(zFar -zNear),0},
                {0, 0, 0,1}
            });
            DenseMatrix move = DenseMatrix.OfArray(new[,] {
                {1, 0,0,0.0},
                {0, 1, 0,0},
                {0, 0, 1,-(zNear-+zFar)/2},
                {0, 0, 0,1}
            });
            //DenseMatrix p = DenseMatrix.OfArray(new[,] {
            //    {1, 0,0.0,(-1)*(right+left)/2},
            //    { 0,1,0,(-1)*(top +bottom)/2},
            //    {0,0,1,(-1)*(zNear+zFar)/2},
            //    {0, 0, 0,1}
            //});

            projection = re * move * projection;
            return projection;
        }

    }
}
