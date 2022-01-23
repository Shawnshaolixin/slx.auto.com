using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using OpenCvSharp;

using Vector = MathNet.Numerics.LinearAlgebra.Complex.Vector;

namespace HM1
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
    public class Rasterizer : IReasterizer
    {
        DenseMatrix model;
        DenseMatrix view;
        DenseMatrix projection;
        int width;
        int height;
        int next_id = 0;
        Vector3[] frame_buf;
        float[] depth_buf;

        Dictionary<int, List<Vector3>> pos_buf = new Dictionary<int, List<Vector3>>();
        Dictionary<int, List<Vector3>> ind_buf = new Dictionary<int, List<Vector3>>();

        public Rasterizer(int w, int h)
        {
            width = w;
            height = h;
            frame_buf = new Vector3[w * h]; //new List<Vector3>(w * h);
            depth_buf = new float[w * h]; // new List<float>(w * h);
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
        public void draw(Pos_Buf_Id pos_buffer, Ind_Buf_Id ind_buffer, Primitive type)
        {
            if (type != Primitive.Triangle)
            {
                throw new Exception("Drawing primitives others than triangle is not implemented yet!");
            }

            var buf = pos_buf[pos_buffer.pos_id];
            var ind = ind_buf[ind_buffer.ind_id];

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
                t.setColor(0, 255.0f, 0.0f, 0.0f);
                t.setColor(1, 0.0f, 255.0f, 0.0f);
                t.setColor(2, 0.0f, 0.0f, 255.0f);

                rasterize_wireframe(t);
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

        public int get_index(int x, int y)
        {
            return (height - y) * width + x;
        }
    }
}
