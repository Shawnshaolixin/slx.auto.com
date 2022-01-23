using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using MathNet.Numerics.LinearAlgebra;
using OpenCvSharp;
using OpenCvSharp.Aruco;


namespace HM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Runtime Version = {0}", Environment.Version);
            // RunTest();
            // HM0();
            HM1();
            #region Test


            //Mat targermat = new Mat(700, 700, MatType.CV_8UC3, Scalar.Black);

            //targermat.Set<Vec3b>(100, 100, new Vec3b(0, 0, 255));


            //var color = new Scalar(0, 255, 0);
            //Cv2.Line(targermat,
            //    (Point)new Point2f(1, 1),
            //    (Point)new Point2f(100, 100),
            //    color);
            //Cv2.ImShow("123", targermat);
            //Cv2.WaitKey(0);
            //float a = 1.0f, b = 2.0f;
            //Console.WriteLine(a);
            //Console.WriteLine(a / b);
            //Console.WriteLine(MathF.Sqrt(a));
            //Console.WriteLine(MathF.Acos(-1));
            //Console.WriteLine(MathF.Sin(30.0f / 180.0f * MathF.Acos(-1)));
            //Console.WriteLine("Hello World!");

            //Console.WriteLine("Example of vector");
            //Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            //Vector3 w = new Vector3(1.0f, 0.0f, 0.0f);
            //Console.WriteLine("输出向量：");
            //Console.WriteLine(v);
            //// vector add
            //Console.WriteLine(v + w);
            //Console.WriteLine(v * 3.0f);
            //Console.WriteLine(2.0f * v);
            //Console.WriteLine(Vector3.Cross(v, w));

            //// Example of matrix
            //Console.WriteLine("Example of matrix");

            //Matrix i = new DenseMatrix(3);
            //i[0, 0] = 1;
            //i[0, 1] = 2;
            //i[0, 2] = 3;

            //i[1, 0] = 4;
            //i[1, 1] = 5;
            //i[1, 2] = 6;

            //i[2, 0] = 7;
            //i[2, 1] = 8;
            //i[2, 2] = 9;

            //Matrix j = new DenseMatrix(3);

            //j[0, 0] = 2;
            //j[0, 1] = 3;
            //j[0, 2] = 1;

            //j[1, 0] = 4;
            //j[1, 1] = 6;
            //j[1, 2] = 5;

            //j[2, 0] = 9;
            //j[2, 1] = 7;
            //j[2, 2] = 8;

            //Console.WriteLine(i);
            //Console.WriteLine(3 * i + j);
            #endregion
            Console.ReadKey();
        }


        /// <summary>
        /// 首先作业0的问题是：给定一个点 P =(2,1), 将该点绕原点先逆时针旋转 45◦，再平移 (1,2), 计算出 变换后点的坐标(要求用齐次坐标进行计算)。
        /// </summary>
        private static void HM0()
        {
            var p = new DenseVector(new[] { 2.0, 1, 1 }); //定义点p,写成齐次坐标形式

            //  DenseMatrix rotation; // 定义旋转矩阵
            //   var transform; // 定义平移矩阵

            float theta = 45.0f / 180.0f * MathF.PI;// 转换成弧度数
            var rotation = DenseMatrix.OfArray(new[,]
            {
                { MathF.Cos(theta), -MathF.Sin(theta), 0.0 },
                { MathF.Sin(theta),MathF.Cos(theta), 0 },
                { 0,0, 1 },
            });
            var transform = DenseMatrix.OfArray(new[,] {
                {1.0, 0,1},
                {0, 1, 2},
                {0, 0, 1},
            });
            Vector3 v = new Vector3();
            p = transform * rotation * p;
            Console.WriteLine("作业结果");
            Console.WriteLine(p);

        }

        private static void HM1()
        {
            float angle = 0;
            float scal = 1;

            bool command_line = false;
            string fileName = "output.png";

            Rasterizer r = new Rasterizer(700, 700);

            var eye_pos = new DenseVector(new[] { 0, 0, 5.0 }); //眼睛位置，摄像机位置？

            //Mat image = new Mat(700, 700, MatType.CV_32FC3,);

            List<Vector3> pos = new List<Vector3>();
            pos.Add(new Vector3(2, 0, -2));
            pos.Add(new Vector3(0, 2, -2));
            pos.Add(new Vector3(-2, 0, -2));

            List<Vector3> ind = new List<Vector3>();
            ind.Add(new Vector3(0, 1, 2));
            var pos_id = r.load_positions(pos);
            var ind_id = r.load_indices(ind);

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
                r.draw(pos_id, ind_id, Primitive.Triangle);
                var data = r.frame_buffer().ToArray();

                Mat image = new Mat(700, 700, MatType.CV_32FC3, data);
                image.ConvertTo(image, MatType.CV_8UC3, 1.0f);
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
            DenseMatrix rotate = DenseMatrix.OfArray(new[,] {
                { MathF.Cos(radian), -MathF.Sin(radian), 0.0,0 },
                { MathF.Sin(radian),MathF.Cos(radian), 0,0 },
                {0, 0, 1,0},
                {0, 0, 0,1}
            });
            DenseMatrix scale = DenseMatrix.OfArray(new[,] {
                {1.0*scal, 0,0,0},
                {0, 1*scal, 0,0},
                {0, 0, 1*scal,0},
                {0, 0, 0,1}
            });
            DenseMatrix move = DenseMatrix.OfArray(new[,] {
                {1.0, 0,0,1},
                {0, 1, 0,1},
                {0, 0, 1,1},
                {0, 0, 0,1}
            });
            model = rotate * model;
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
            DenseMatrix projection = DenseMatrix.OfArray(new[,] {
                {1.0, 0,0,0},
                {0, 1, 0,0},
                {0, 0, 1,0},
                {0, 0, 0,1}
            });

            DenseMatrix P2O = DenseMatrix.OfArray(new[,] {
                {zNear, 0,0,0.0},
                {0, zNear, 0,0},
                {0, 0, zNear+zFar,(-1)*zFar*zNear},
                {0, 0, 1,0}
            });
            float halfEyeAngleRadian = (float)(eye_fov / 2.0 / 180.0 * MathF.PI);
            float t = zNear * MathF.Tan(halfEyeAngleRadian);
            float r = t * aspect_ratio;
            float l = (-1) * r;//left x轴最小值
            float b = (-1) * t;//bottom y轴的最大值

            DenseMatrix ortho1 = DenseMatrix.OfArray(new[,] {
                {2/(r-l), 0,0,0.0},
                {0, 2/(t-b), 0,0},
                {0, 0, 2/(zNear-zFar),0},
                {0, 0, 0,1}
            });
            DenseMatrix ortho2 = DenseMatrix.OfArray(new[,] {
                {1, 0,0.0,(-1)*(r+l)/2},
                { 0,1,0,(-1)*(t+b)/2},
                {0,0,1,(-1)*(zNear+zFar)/2},
                {0, 0, 0,1}
            });
            DenseMatrix matrix_ortho = ortho1 * ortho2;
            projection = matrix_ortho * P2O;
            return projection;
        }
    }
}
