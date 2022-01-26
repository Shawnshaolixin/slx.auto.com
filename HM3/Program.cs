﻿using MathNet.Numerics.LinearAlgebra.Double;
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
            //Blinn-Phone
            // diffuse 漫反射
            // 漫反射光=Kd 表示表面的能力接受系数三通道 就代表颜色 I/r^2 表示：到达这个点的能量，n*l：表示表面能吸收多少能力
            // 漫反射公式 Ld=Kd*(I/r^2)*Max(0,n*l);

            //specular 高光
            //高光=Ls, Ks= 系数一般是白色 I/r^2 ：到达这个点的光的能量n:法线，
            //h半程向量：I+V/|I+V|=V 是观测方向，I是点和光之间的向量
            //p:表示高光的范围一般100-200之间，和余弦函数公式有关系
            //高光公式 Ls=Ks*(I/r^2)*Max(0,n*h)^p

            //ambient 环境光
            //
            // La= Ka * Ia 
            Console.WriteLine("Hello World!");
            HM1();

        }

        public class light
        {
            public light(Vector3 _pos, Vector3 _intensity)
            {
                position = _pos;
                intensity = _intensity;
            }
            /// <summary>
            /// 光的位置
            /// </summary>
            public Vector3 position;
            /// <summary>
            /// 光的强度
            /// </summary>
            public Vector3 intensity;
        }
        public static Vector3 phone_fragment_shader(fragment_shader_payload payload)
        {
            // 环境光
            Vector3 ka = new Vector3(0.005f, 0.005f, 0.005f);
            // 漫反射系数
            Vector3 kd = payload.color;
            // 高光系数
            Vector3 ks = new Vector3(0.7937f, 0.7937f, 0.7937f);

            var l1 = new light(new Vector3(20, 20, 20), new Vector3(500, 500, 500));
            var l2 = new light(new Vector3(-20, 20, 0), new Vector3(500, 500, 500));
            List<light> lights = new List<light>() { l1, l2 };
            Vector3 amb_light_intensity = new Vector3(10, 10, 10);
            Vector3 eye_pos = new Vector3(0, 0, 10);

            float p = 150;

            Vector3 color = payload.color;
            Vector3 point = payload.view_pos;
            Vector3 normal = payload.normal;

            Vector3 result_color = new Vector3(0, 0, 0);
            Vector3 v = Vector3.Normalize(eye_pos - point);// 视线向量

            foreach (var light in lights)
            {
                Vector3 l = Vector3.Normalize(light.position - point);
                Vector3 h = Vector3.Normalize(v + l);// 半程向量
                var r2 = MathF.Pow(Vector3.Distance(light.position, point), 2);
                // var r2=(light.position-point).squaredNorm
                var ambient = ka * (amb_light_intensity);

                var diffuse = kd * (light.intensity / r2 * MathF.Max(0.0f, Vector3.Dot(normal, l)));

                var specular = ks * (light.intensity / r2 * MathF.Pow(MathF.Max(0.0f, Vector3.Dot(normal, h)), p));

                result_color += ambient + diffuse + specular;
            }

            return result_color * 255.0f;
        }

        public static Vector3 normal_fragment_shader(fragment_shader_payload payload)
        {
            Vector3 return_color = (Vector3.Normalize(payload.normal) + new Vector3(1.0f, 1.0f, 1.0f)) / 2.0f;
            Vector3 result = return_color * 255;
            return result;
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


            List<string> paths = new List<string>();
            paths.Add("models/download/FinalBaseMesh.obj");
            paths.Add("models/spot/spot_triangulated_good.obj");
            paths.Add("models/cube/cube.obj");
            paths.Add("models/bunny/bunny.obj");
            paths.Add("models/43-obj/obj/Wolf_One_obj.obj");

            bool loadout = loader.LoadFile(paths[1]);
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
            r.set_fragment_shader(phone_fragment_shader);
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
