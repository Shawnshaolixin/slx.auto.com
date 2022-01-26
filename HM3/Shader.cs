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

    public class fragment_shader_payload: Shader
    {
        public fragment_shader_payload(Vector3 col, Vector3 nor, Vector2 tc, Texture tex)
        {
            color = col;
            normal = nor;
            texture = tex;
            tex_coords = tc;
            
        }

        public fragment_shader_payload()
        {

        }
        public Vector3 view_pos;
        public Vector3 color;
        public Vector3 normal;
        public Vector2 tex_coords;
        public Texture texture;

    }

    public class vertex_shader_payload: Shader
    {
        Vector3 position;
    }
}
