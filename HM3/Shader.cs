using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HM3
{
    public class Shader
    {
    }

    public class fragment_shader_payload
    {
        fragment_shader_payload(Vector3 col, Vector3 nor, Vector2 tc, Texture tex)
        {
            color = col;
            normal = nor;
            texture = tex;
            tex_coords = tc;

        }

        public fragment_shader_payload()
        {

        }
        private Vector3 view_pos;
        private Vector3 color;
        private Vector3 normal;
        private Vector2 tex_coords;
        private Texture texture;
    }

    public class vertex_shader_payload
    {
        Vector3 position;
    }
}
