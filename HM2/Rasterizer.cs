using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using OpenCvSharp;

using Vector = MathNet.Numerics.LinearAlgebra.Complex.Vector;

namespace HM2
{
    public enum Buffers
    {
        Color = 1,
        Depth = 2
    }

    public enum Primitive
    {
        Line,
        Triangle
    }
    public class Pos_Buf_Id
    {
        public int pos_id { get; set; }

        public Pos_Buf_Id(int id)
        {
            pos_id = id;
        }
    }

    public class Col_Buf_Id
    {
        public int col_id { get; set; }

        public Col_Buf_Id(int id)
        {
            col_id = id;
        }
    }
    public class Ind_Buf_Id
    {
        public int ind_id { get; set; }

        public Ind_Buf_Id(int id)
        {
            ind_id = id;
        }
    }
    public interface IReasterizer
    {




        Pos_Buf_Id load_positions(List<Vector3> positions);
        Ind_Buf_Id load_indices(List<Vector3> indices);

        void set_model(DenseMatrix m);
        void set_view(DenseMatrix v);
        void set_projection(DenseMatrix p);

        void set_pixel(Vector3 point, Vector3 color);
        void clear(Buffers buff);
        void draw(Pos_Buf_Id pos_buffer, Ind_Buf_Id ind_buffer, Primitive type);


        void draw_line(Vector3 begin, Vector3 end);
        void rasterize_wireframe(Triangle t);
    }
    public class Rasterizer //: IReasterizer
    {
        DenseMatrix model;
        DenseMatrix view;
        DenseMatrix projection;
        int width;
        int height;
        int next_id = 0;
        Vector3[] frame_buf;
        float[] depth_buf;
        private List<Vector2> pos;//抗锯齿的点
        Dictionary<int, List<Vector3>> pos_buf = new Dictionary<int, List<Vector3>>();
        Dictionary<int, List<Vector3>> ind_buf = new Dictionary<int, List<Vector3>>();
        Dictionary<int, List<Vector3>> col_buf = new Dictionary<int, List<Vector3>>();

        public Rasterizer(int w, int h)
        {
            width = w;
            height = h;
            frame_buf = new Vector3[w * h]; //new List<Vector3>(w * h);
            depth_buf = new float[w * h]; // new List<float>(w * h);
            pos = new List<Vector2>(4);
            pos.Add(new Vector2(0.25f, 0.25f));
            pos.Add(new Vector2(0.75f, 0.25f));
            pos.Add(new Vector2(0.25f, 0.75f));
            pos.Add(new Vector2(0.75f, 0.75f));
        }
        int Get_Next_Id()
        {
            return next_id++;
        }
        public List<Vector3> frame_buffer()
        {
            return frame_buf.ToList();
        }
        public void clear(Buffers buff)
        {
            if ((buff & Buffers.Color) == Buffers.Color)
            {
                for (int i = 0; i < frame_buf.Length; i++)
                {
                    frame_buf[i] = new Vector3(0, 0, 0);
                }
            }
            if ((buff & Buffers.Color) == Buffers.Color)
            {
                for (int i = 0; i < depth_buf.Length; i++)
                {
                    depth_buf[i] = float.MaxValue;
                }
            }

        }

        DenseVector to_vec4(Vector3 v3, float w = 1.0f)
        {
            return new DenseVector(new[] { v3.X * 1.0, v3.Y, v3.Z, w });
        }
        public void draw(Pos_Buf_Id pos_buffer, Ind_Buf_Id ind_buffer, Col_Buf_Id col_buffer, Primitive type)
        {
            if (type != Primitive.Triangle)
            {
                throw new Exception("Drawing primitives others than triangle is not implemented yet!");
            }

            var buf = pos_buf[pos_buffer.pos_id];
            var ind = ind_buf[ind_buffer.ind_id];
            var col = col_buf[col_buffer.col_id];
            float f1 = (100 - 0.1f) / 2.0f;
            float f2 = (100.0f + 0.1f) / 2.0f;

            DenseMatrix mvp = projection * view * model;
            //  DenseVector
            foreach (var i in ind)
            {
                Triangle t = new Triangle();
                DenseVector[] v = new DenseVector[3];
                v[0] = mvp * to_vec4(buf[(int)i.X], 1.0f);
                v[1] = mvp * to_vec4(buf[(int)i.Y], 1.0f);
                v[2] = mvp * to_vec4(buf[(int)i.Z], 1.0f);


                for (int j = 0; j < v.Length; j++)
                {
                    var vec = v[j];
                    // v[j][]  vec vec[4]
                    for (int k = 0; k < v[j].Count; k++)
                    {
                        v[j][k] /= v[j][3];
                    }
                }

                for (int j = 0; j < v.Length; j++)
                {
                    v[j][0] = 0.5 * width * (v[j][0] + 1.0);
                    v[j][1] = 0.5 * height * (v[j][1] + 1.0);
                    v[j][2] = v[j][2] * f1 + f2;
                }
                for (int n = 0; n < 3; ++n)
                {
                    t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
                    t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
                    t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
                }

                var col_x = col[(int)i.X];
                var col_y = col[(int)i.Y];
                var col_z = col[(int)i.Z];

                t.setColor(0, col_x.X, col_x.Y, col_x.Z);
                t.setColor(1, col_y.X, col_y.Y, col_y.Z);
                t.setColor(2, col_z.X, col_z.Y, col_z.Z);

                //rasterize_wireframe(t);
                rasterize_triangle(t);
            }
        }

        public void draw_line(Vector3 begin, Vector3 end)
        {

            var x1 = Convert.ToInt32(begin.X);
            var y1 = Convert.ToInt32(begin.Y);
            var x2 = Convert.ToInt32(end.X);
            var y2 = Convert.ToInt32(end.Y);

            Vector3 line_color = new Vector3(0, 255, 0);
            int x, y, dx, dy, dx1, dy1, px, py, xe, ye, i;
            dx = Convert.ToInt32(x2 - x1);
            dy = Convert.ToInt32(y2 - y1);
            dx1 = (int)MathF.Abs(dx);
            dy1 = (int)MathF.Abs(dy);
            px = 2 * dy1 - dx1;
            py = 2 * dx1 - dy1;
            if (dy1 <= dx1)
            {
                if (dx >= 0)
                {
                    x = x1;
                    y = y1;
                    xe = x2;
                }
                else
                {
                    x = x2;
                    y = y2;
                    xe = x1;
                }
                Vector3 point = new Vector3(x, y, 1.0f);
                set_pixel(point, line_color);
                for (i = 0; x < xe; i++)
                {
                    x = x + 1;
                    if (px < 0)
                    {
                        px = px + 2 * dy1;
                    }
                    else
                    {
                        if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0))
                        {
                            y = y + 1;
                        }
                        else
                        {
                            y = y - 1;
                        }
                        px = px + 2 * (dy1 - dx1);
                    }
                    //            delay(0);

                    set_pixel(new Vector3(x, y, 1.0f), line_color);
                }
            }
            else
            {
                if (dy >= 0)
                {
                    x = x1;
                    y = y1;
                    ye = y2;
                }
                else
                {
                    x = x2;
                    y = y2;
                    ye = y1;
                }

                set_pixel(new Vector3(x, y, 1.0f), line_color);
                for (i = 0; y < ye; i++)
                {
                    y = y + 1;
                    if (py <= 0)
                    {
                        py = py + 2 * dx1;
                    }
                    else
                    {
                        if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0))
                        {
                            x = x + 1;
                        }
                        else
                        {
                            x = x - 1;
                        }
                        py = py + 2 * (dx1 - dy1);
                    }
                    //            delay(0);

                    set_pixel(new Vector3(x, y, 1.0f), line_color);
                }
            }
        }



        public void rasterize_wireframe(Triangle t)
        {
            draw_line(t.c(), t.a());
            draw_line(t.c(), t.b());
            draw_line(t.b(), t.a());
        }


        public void rasterize_triangle(Triangle t)
        {
            // todo 光栅化三角形
            var v = t.toVector4();

            // 包围盒
            var min_x = MathF.Min(v[0].X, MathF.Min(v[1].X, v[2].X));
            var max_x = MathF.Max(v[0].X, MathF.Max(v[1].X, v[2].X));

            var min_y = MathF.Min(v[0].Y, MathF.Min(v[1].Y, v[2].Y));
            var max_y = MathF.Max(v[0].Y, MathF.Max(v[1].Y, v[2].Y));
            min_x = (int)MathF.Floor(min_x);
            max_x = (int)MathF.Ceiling(max_x);
            min_y = (int)MathF.Floor(min_y);
            max_y = (int)MathF.Ceiling(max_y);
            bool MSAA = false;
            if (MSAA)
            {
                for (int x = (int)min_x; x <= max_x; x++)
                {
                    for (int y = (int)min_y; y < max_y; y++)
                    {
                        // 记录最小深度
                        float minDepth = float.MaxValue;
                        // 四个小点中落入三角形中的点的数量
                        int count = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (insideTriangle(x + pos[i].X, y + pos[i].Y, t.v))
                            {
                                var tup = computeBarycentric2D(x + pos[i].X, y + pos[i].Y, t.v);
                                float alpha = tup.Item1;
                                float beta = tup.Item2;
                                float gamma = tup.Item3;
                                // 归一化
                                float w_reciprocal = 1.0f / (alpha / v[0].W + beta / v[1].W + gamma / v[2].W);

                                // 深度 插值
                                float z_interpolated = alpha * v[0].Z / v[0].W + beta * v[1].Z / v[1].W +
                                                       gamma * v[2].Z / v[2].W;
                                z_interpolated *= w_reciprocal;
                                minDepth = MathF.Min(minDepth, z_interpolated);
                                count++;

                            }
                        }

                        if (count != 0)
                        {
                            if (depth_buf[get_index(x, y)] > minDepth)
                            {
                                Vector3 color = t.getColor() * count / 4.0f;
                                Vector3 point = new Vector3(x, y, minDepth);
                                depth_buf[get_index(x, y)] = minDepth;
                                set_pixel(point,color);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int x = (int)min_x; x <= max_x; x++)
                {
                    for (int y = (int)min_y; y <= max_y; y++)
                    {
                        if (insideTriangle(x + 0.5f, y + 0.5f, t.v))
                        {

                            if (x == 136)
                            {

                            }
                            // 计算重心坐标
                            var tup = computeBarycentric2D(x + 0.5f, y + 0.5f, t.v);
                            float alpha = tup.Item1;
                            float beta = tup.Item2;
                            float gamma = tup.Item3;
                            float w_reciprocal = 1.0f / (alpha / v[0].W + beta / v[1].W + gamma / v[2].W);
                            float z_interpolated = alpha * v[0].Z / v[0].W + beta * v[1].Z / v[1].W +
                                                   gamma * v[2].Z / v[2].W;

                            z_interpolated *= w_reciprocal;

                            if (depth_buf[get_index(x, y)] > z_interpolated)
                            {
                                Vector3 color = t.getColor();
                                Vector3 point = new Vector3(x, y, z_interpolated);
                                depth_buf[get_index(x, y)] = z_interpolated;

                                set_pixel(point, color);
                            }

                        }
                    }
                }
            }
        }
        static Tuple<float, float, float> computeBarycentric2D(float x, float y, Vector3[] v)
        {
            float c1 = (x * (v[1].Y - v[2].Y) + (v[2].X - v[1].X) * y + v[1].X * v[2].Y - v[2].X * v[1].Y) / (v[0].X * (v[1].Y - v[2].Y) + (v[2].X - v[1].X) * v[0].Y + v[1].Y * v[2].Y - v[2].X * v[1].Y);
            float c2 = (x * (v[2].Y - v[0].Y) + (v[0].X - v[2].X) * y + v[2].X * v[0].Y - v[0].X * v[2].Y) / (v[1].X * (v[2].Y - v[0].Y) + (v[0].X - v[2].X) * v[1].Y + v[2].X * v[0].Y - v[0].X * v[2].Y);
            float c3 = (x * (v[0].Y - v[1].Y) + (v[1].X - v[0].X) * y + v[0].X * v[1].Y - v[1].X * v[0].Y) / (v[2].X * (v[0].Y - v[1].Y) + (v[1].X - v[0].X) * v[2].Y + v[0].X * v[1].Y - v[1].X * v[0].Y);
            return new Tuple<float, float, float>(c1, c2, c3);
        }

        public bool insideTriangle(float x, float y, Vector3[] _v)
        {
            // todo 判断点是不是在三角形里面
            Vector2 p = new Vector2(x, y);

            Vector2 AB = new Vector2(_v[1].X, _v[1].Y) - new Vector2(_v[0].X, _v[0].Y);
            Vector2 BC = new Vector2(_v[2].X, _v[2].Y) - new Vector2(_v[1].X, _v[1].Y);
            Vector2 CA = new Vector2(_v[0].X, _v[0].Y) - new Vector2(_v[2].X, _v[2].Y);


            var AP = p - new Vector2(_v[1].X, _v[1].Y);
            var BP = p - new Vector2(_v[2].X, _v[2].Y);
            var CP = p - new Vector2(_v[0].X, _v[0].Y);
            var reslut = AB.X * AP.Y - AB.Y * AP.X > 0
                 && BC.X * BP.Y - BC.Y * BP.X > 0
                 && CA.X * CP.Y - CA.Y * CP.X > 0;


            return reslut;
        }
        public void set_model(DenseMatrix m)
        {
            model = m;
        }

        public void set_pixel(Vector3 point, Vector3 color)
        {
            //old index: auto ind = point.y() + point.x() * width;
            if (point.X < 0 || point.X >= width ||
                point.Y < 0 || point.Y >= height) return;
            var ind = Convert.ToInt32((height - 1 - point.Y) * width + point.X);
            frame_buf[ind] = color;
        }

        public void set_projection(DenseMatrix p)
        {
            projection = p;
        }

        public void set_view(DenseMatrix v)
        {
            view = v;
        }

        public Pos_Buf_Id load_positions(List<Vector3> positions)
        {
            var id = Get_Next_Id();
            pos_buf.Add(id, positions);
            return new Pos_Buf_Id(id);
        }

        public Ind_Buf_Id load_indices(List<Vector3> indices)
        {
            var id = Get_Next_Id();
            ind_buf.Add(id, indices);
            return new Ind_Buf_Id(id);
        }
        public Col_Buf_Id load_colors(List<Vector3> cols)
        {
            var id = Get_Next_Id();
            col_buf.Add(id, cols);
            return new Col_Buf_Id(id);
        }
        public int get_index(int x, int y)
        {
            var index = (height - 1 - y) * width + x;
            return index;
        }
    }
}
