using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using OpenCvSharp;

using Vector = MathNet.Numerics.LinearAlgebra.Complex.Vector;

namespace HM3
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

    public delegate Vector3 fragment_shader(fragment_shader_payload payload);
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
        private fragment_shader fragment_shader;
        public Texture texture;
        public Shader shader;

        public void set_texture(Texture _texture)
        {
            texture = _texture;
        }
        public void set_fragment_shader(fragment_shader _shader)
        {
            fragment_shader = _shader;
        }
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

        public void draw(List<Triangle> triangleList)
        {
            var tList = triangleList;


            float f1 = (50 - 0.1f) / 2.0f;
            float f2 = (50 + 0.1f) / 2.0f;
            DenseMatrix mvp = projection * view * model;
            for (int k = 0; k < triangleList.Count; k++)
            //   foreach (var t in tList)
            {
                var t = triangleList[k];
                // Triangle newtri = DeepCopy<Triangle>(t);
                Triangle newtri = new Triangle();
                newtri.v = t.v.Select(v4 =>
                {
                    return v4;
                }).ToArray();
                newtri.color = t.color.Select(v3 =>
                {
                    return v3;
                }).ToArray();
                newtri.normal = t.normal.Select(v3 =>
                {
                    return v3;
                }).ToArray();
                newtri.tex_coords = t.tex_coords.Select(v2 =>
                {
                    return v2;
                }).ToArray();
                DenseVector[] mm = new DenseVector[3];
                mm[0] = view * model * t.v[0];
                mm[1] = view * model * t.v[1];
                mm[2] = view * model * t.v[2];

                // 观测的点
                Vector3[] viewspace_pos = new Vector3[3];
                viewspace_pos[0] = new Vector3((float)mm[0].Values[0], (float)mm[0].Values[1], (float)mm[0].Values[2]);
                viewspace_pos[1] = new Vector3((float)mm[1].Values[0], (float)mm[1].Values[1], (float)mm[1].Values[2]);
                viewspace_pos[2] = new Vector3((float)mm[2].Values[0], (float)mm[2].Values[1], (float)mm[2].Values[2]);

                //三角形每个顶点 都进行mvp变换
                DenseVector[] v =
                {
                    mvp * newtri.v[0],
                    mvp * newtri.v[1],
                    mvp * newtri.v[2]
                };
                for (int i = 0; i < v.Length; i++)
                {

                    v[i].Values[0] /= v[i].Values[3];
                    v[i].Values[1] /= v[i].Values[3];
                    v[i].Values[2] /= v[i].Values[3];

                }

                DenseMatrix inv_trans = ((view * model).Inverse().Transpose()) as DenseMatrix;

                //变成了 三维空间的 法线
                DenseVector[] n =
                {
                    inv_trans * to_vec4(newtri.normal[0], 0.0f),
                    inv_trans * to_vec4(newtri.normal[1], 0.0f),
                    inv_trans * to_vec4(newtri.normal[2], 0.0f),
                };

                ////Viewport transformation  每个顶点都经过视口变换
                for (int i = 0; i < v.Length; ++i)
                {
                    var vert = v[i];
                    vert.Values[0] = 0.5 * width * (vert.Values[0] + 1.0f);
                    vert.Values[1] = 0.5 * height * (vert.Values[1] + 1.0f);
                    vert.Values[2] = v[i].Values[2] * f1 + f2;

                }

                // 三角形的位置变成了 二位空间的位置
                for (int i = 0; i < 3; ++i)
                {
                    newtri.setVertex(i, v[i]);

                }

                for (int i = 0; i < 3; ++i)
                {
                    newtri.setNormal(i, new Vector3((float)n[i].Values[0], (float)n[i].Values[1], (float)n[i].Values[2]));

                }
                // 每个顶点设置个颜色
                newtri.setColor(0, 148, 121.0f, 92.0f);
                newtri.setColor(1, 148, 121.0f, 92.0f);
                newtri.setColor(2, 148, 121.0f, 92.0f);
                rasterize_triangle(newtri, viewspace_pos);
                //rasterize_wireframe(newtri);

            }


        }
        //public void draw(Pos_Buf_Id pos_buffer, Ind_Buf_Id ind_buffer, Col_Buf_Id col_buffer, Primitive type)
        //{
        //    if (type != Primitive.Triangle)
        //    {
        //        throw new Exception("Drawing primitives others than triangle is not implemented yet!");
        //    }

        //    var buf = pos_buf[pos_buffer.pos_id];
        //    var ind = ind_buf[ind_buffer.ind_id];
        //    var col = col_buf[col_buffer.col_id];
        //    float f1 = (100 - 0.1f) / 2.0f;
        //    float f2 = (100.0f + 0.1f) / 2.0f;

        //    DenseMatrix mvp = projection * view * model;
        //    //  DenseVector
        //    foreach (var i in ind)
        //    {
        //        Triangle t = new Triangle();
        //        DenseVector[] v = new DenseVector[3];
        //        v[0] = mvp * to_vec4(buf[(int)i.X], 1.0f);
        //        v[1] = mvp * to_vec4(buf[(int)i.Y], 1.0f);
        //        v[2] = mvp * to_vec4(buf[(int)i.Z], 1.0f);


        //        for (int j = 0; j < v.Length; j++)
        //        {
        //            var vec = v[j];
        //            // v[j][]  vec vec[4]
        //            for (int k = 0; k < v[j].Count; k++)
        //            {
        //                v[j][k] /= v[j][3];
        //            }
        //        }

        //        for (int j = 0; j < v.Length; j++)
        //        {
        //            v[j][0] = 0.5 * width * (v[j][0] + 1.0);
        //            v[j][1] = 0.5 * height * (v[j][1] + 1.0);
        //            v[j][2] = v[j][2] * f1 + f2;
        //        }
        //        for (int n = 0; n < 3; ++n)
        //        {
        //            //t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
        //            //t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
        //            //t.setVertex(n, new Vector3((float)v[n][0], (float)v[n][1], (float)v[n][2]));
        //        }

        //        var col_x = col[(int)i.X];
        //        var col_y = col[(int)i.Y];
        //        var col_z = col[(int)i.Z];

        //        t.setColor(0, col_x.X, col_x.Y, col_x.Z);
        //        t.setColor(1, col_y.X, col_y.Y, col_y.Z);
        //        t.setColor(2, col_z.X, col_z.Y, col_z.Z);

        //        //rasterize_wireframe(t);
        //        rasterize_triangle(t);
        //    }
        //}

        public void draw_line(Vector3 begin, Vector3 end)
        {

            var x1 = Convert.ToInt32(begin.X);
            var y1 = Convert.ToInt32(begin.Y);
            var x2 = Convert.ToInt32(end.X);
            var y2 = Convert.ToInt32(end.Y);

            Vector3 line_color = new Vector3(255, 255, 255);
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
        static Vector3 interpolate(float alpha, float beta, float gamma, Vector3 vert1, Vector3 vert2, Vector3 vert3, float weight)
        {
            return (alpha * vert1 + beta * vert2 + gamma * vert3) / weight;
        }

        static Vector2 interpolate(float alpha, float beta, float gamma, Vector2 vert1, Vector2 vert2, Vector2 vert3, float weight)
        {
            var u = (alpha * vert1.X + beta * vert2.X + gamma * vert3.X);
            var v = (alpha * vert1.Y + beta * vert2.Y + gamma * vert3.Y);

            u /= weight;
            v /= weight;

            return new Vector2(u, v);
        }

        public void rasterize_triangle(Triangle t, Vector3[] view_pos)
        {
            // todo 光栅化三角形
            var v = t.toVector4();

            // 包围盒
            var min_x = MathF.Min(v[0].X, MathF.Min(v[1].X, v[2].X));
            var max_x = MathF.Max(v[0].X, MathF.Max(v[1].X, v[2].X));

            var min_y = MathF.Min(v[0].Y, MathF.Min(v[1].Y, v[2].Y));
            var max_y = MathF.Max(v[0].Y, MathF.Max(v[1].Y, v[2].Y));
            min_x = (int)MathF.Floor(min_x) - 1;
            max_x = (int)MathF.Ceiling(max_x) + 1;
            min_y = (int)MathF.Floor(min_y) - 1;
            max_y = (int)MathF.Ceiling(max_y) + 1;
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
                            if (insideTriangle(x + pos[i].X, y + pos[i].Y, t.v.Select(v3 =>
                                {
                                    return new Vector3((float)v3.Values[0], (float)v3.Values[1], (float)v3.Values[2]);
                                }).ToArray()))
                            {
                                var tup = computeBarycentric2D(x + pos[i].X, y + pos[i].Y, t.v.Select(v3 =>
                                {
                                    return new Vector3((float)v3.Values[0], (float)v3.Values[1], (float)v3.Values[2]);
                                }).ToArray());
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
                                set_pixel(point, color);
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

                        if (insideTriangle(x + 0.5f, y + 0.5f, t.v.Select(v3 =>
                            {
                                return new Vector3((float)v3.Values[0], (float)v3.Values[1], (float)v3.Values[2]);
                            }).ToArray()))
                        {

                            if (x == 136)
                            {

                            }
                            // 计算重心坐标
                            var tup = computeBarycentric2D(x + 0.5f, y + 0.5f, t.v.Select(v3 =>
                            {
                                return new Vector3((float)v3.Values[0], (float)v3.Values[1], (float)v3.Values[2]);
                            }).ToArray());
                            float alpha = tup.Item1;
                            float beta = tup.Item2;
                            float gamma = tup.Item3;
                            float w_reciprocal = 1.0f / (alpha / v[0].W + beta / v[1].W + gamma / v[2].W);
                            float z_interpolated = alpha * v[0].Z / v[0].W + beta * v[1].Z / v[1].W +
                                                   gamma * v[2].Z / v[2].W;

                            z_interpolated *= w_reciprocal;

                            if (depth_buf[get_index(x, y)] > z_interpolated)
                            {

                                // Vector3 point = new Vector3(x, y, z_interpolated);
                                depth_buf[get_index(x, y)] = z_interpolated;
                               
                                var interpolated_color = interpolate(alpha, beta, gamma, t.color[0], t.color[1], t.color[2], 1);
                                var interpolated_normal = interpolate(alpha, beta, gamma, t.normal[0], t.normal[1], t.normal[2], 1);
                                var interpolated_texcoords = interpolate(alpha, beta, gamma, t.tex_coords[0], t.tex_coords[1], t.tex_coords[2], 1);
                                var interpolated_shadingcoords = interpolate(alpha, beta, gamma, view_pos[0], view_pos[1], view_pos[2], 1);
                                fragment_shader_payload payload = new fragment_shader_payload(interpolated_color, Vector3.Normalize(interpolated_normal), interpolated_texcoords, texture);
                                payload.view_pos = interpolated_shadingcoords; // 看的位置点
                                var pixel_color = fragment_shader(payload);
                                set_pixel(new Vector3(x, y, 0), pixel_color);

                            }

                        }
                    }
                }
            }
        }
        static Tuple<float, float, float> computeBarycentric2D(float x, float y, Vector3[] v)
        {
            float c1 = (x * (v[1].Y - v[2].Y) + (v[2].X - v[1].X) * y + v[1].X * v[2].Y - v[2].X * v[1].Y) / (v[0].X * (v[1].Y - v[2].Y) + (v[2].X - v[1].X) * v[0].Y + v[1].X * v[2].Y - v[2].X * v[1].Y);
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
            var index = (height - y) * width + x;
            //if (index > width * height || index < 0)
            //{
            //    return 0;
            //}

            return index;
        }
    }
}
