using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp.Internal.Vectors;

namespace HM3
{
    public class OBJ_Loader
    {

    }
    /// <summary>
    /// 顶点类
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// 位置
        /// </summary>
        public Vector3 Position { get; set; }
        /// <summary>
        /// 法线
        /// </summary>
        public Vector3 Normal { get; set; }
        /// <summary>
        /// 纹理坐标
        /// </summary>
        public Vector2 TextureCoordinate { get; set; }
    }

    /// <summary>
    /// 材质类
    /// </summary>
    public class Material
    {
        public string Name { get; set; }
        /// <summary>
        /// Ambient环境光颜色
        /// </summary>
        public Vector3 Ka { get; set; }
        /// <summary>
        /// Diffuse散射
        /// </summary>
        public Vector3 Kd { get; set; }

        /// <summary>
        /// 高光颜色
        /// </summary>
        public Vector3 Ks { get; set; }
        /// <summary>
        /// 高光指数
        /// </summary>
        public float Ns { get; set; }
        /// <summary>
        /// 光密度
        /// </summary>
        public float Ni { get; set; }
        /// <summary>
        /// Dissolve
        /// </summary>
        public float d { get; set; }
        /// <summary>
        /// Illumination
        /// </summary>
        public int illum { get; set; }

        /// <summary>
        /// 环境光纹理映射
        /// </summary>
        public string map_Ka { get; set; }
        /// <summary>
        /// 散射纹理映射
        /// </summary>
        public string map_Kd { get; set; }

        /// <summary>
        /// 镜面反射纹理映射
        /// </summary>
        public string map_Ks { get; set; }
        /// <summary>
        /// 高光镜面高亮纹理映射
        /// </summary>
        public string map_Ns { get; set; }
        /// <summary>
        /// Alpha Texture Map
        /// </summary>
        public string map_d { get; set; }
        /// <summary>
        /// 凹凸映射
        /// </summary>
        public string map_bump { get; set; }
    }

    /// <summary>
    /// 网格
    /// </summary>
    public class Mesh
    {
        public Mesh()
        {

        }

        public Mesh(List<Vertex> _vertices, List<int> _indices)
        {
            Vertices = _vertices;
            Indices = _indices;
        }
        public string MeshName { get; set; }
        /// <summary>
        /// 顶点列表
        /// </summary>
        public List<Vertex> Vertices { get; set; }

        /// <summary>
        /// 索引列表
        /// </summary>
        public List<int> Indices { get; set; }
        /// <summary>
        /// 材质信息
        /// </summary>
        public Material MeshMaterial { get; set; }
    }

    public class Algorithm
    {
        // A test to see if P1 is on the same side as P2 of a line segment ab
        public static bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
        {
            Vector3 cp1 = Vector3.Cross(b - a, p1 - a);
            Vector3 cp2 = MathHelper.CrossV3(b - a, p2 - a);

            if (MathHelper.DotV3(cp1, cp2) >= 0)
                return true;
            else
                return false;
        }
        // Generate a cross produect normal for a triangle
        public static Vector3 GenTriNormal(Vector3 t1, Vector3 t2, Vector3 t3)
        {
            Vector3 u = t2 - t1;
            Vector3 v = t3 - t1;

            Vector3 normal = MathHelper.CrossV3(u, v);

            return normal;
        }
        // Check to see if a Vector3 Point is within a 3 Vector3 Triangle
        public static bool inTriangle(Vector3 point, Vector3 tri1, Vector3 tri2, Vector3 tri3)
        {
            // Test to see if it is within an infinite prism that the triangle outlines.
            bool within_tri_prisim = SameSide(point, tri1, tri2, tri3) && SameSide(point, tri2, tri1, tri3)
                                                                       && SameSide(point, tri3, tri1, tri2);

            // If it isn't it will never be on the triangle
            if (!within_tri_prisim)
                return false;

            // Calulate Triangle's Normal
            Vector3 n = GenTriNormal(tri1, tri2, tri3);

            // Project the point onto this normal
            Vector3 proj = MathHelper.ProjV3(point, n);

            // If the distance from the triangle to the point is 0
            //	it lies on the triangle
            if (MathHelper.MagnitudeV3(proj) == 0)
                return true;
            else
                return false;
        }
        public static Vector3 getElement(List<Vector3> elements, string index)
        {
            if (index=="")
            {
                
            }
            int idx = Convert.ToInt32(index);
            if (idx < 0)
                idx = (elements.Count) + idx;
            else
                idx--;
            return elements[idx];
        }
        public static Vector2 getElementV2(List<Vector2> elements, string index)
        {
            int idx = Convert.ToInt32(index);
            if (idx < 0)
                idx = (elements.Count) + idx;
            else
                idx--;
            return elements[idx];
        }
    }
    public class MathHelper
    {
        // Vector3 Cross Product
        public static Vector3 CrossV3(Vector3 a, Vector3 b)
        {
            return new Vector3(a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
        }
        public static float DotV3(Vector3 a, Vector3 b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }
        public static float AngleBetweenV3(Vector3 a, Vector3 b)
        {
            float angle = DotV3(a, b);
            angle /= (MagnitudeV3(a) * MagnitudeV3(b));
            return angle = MathF.Acos(angle);
        }
        // Vector3 Magnitude Calculation
        public static float MagnitudeV3(Vector3 i)
        {
            return (MathF.Sqrt(MathF.Pow(i.X, 2) + MathF.Pow(i.Y, 2) + MathF.Pow(i.Z, 2)));
        }
        // Projection Calculation of a onto b
        public static Vector3 ProjV3(Vector3 a, Vector3 b)
        {
            Vector3 bn = b / MagnitudeV3(b);
            return bn * DotV3(a, bn);
        }
    }

    public class Loader
    {


        public List<Mesh> LoadedMeshes { get; set; } = new List<Mesh>();
        public List<Vertex> LoadedVertices { get; set; } = new List<Vertex>();
        public List<int> LoadedIndices { get; set; } = new List<int>();
        public List<Material> LoadedMaterials { get; set; } = new List<Material>();


        public bool LoadFile(string path)
        {
            if (!path.Contains(".obj"))
            {
                return false;
            }
            //加载到所有模型数据 
            string[] files = File.ReadAllLines(Path.GetFullPath("../../..") + "/" + path);
            List<Vector3> Positions = new List<Vector3>();
            List<Vector2> TCoords = new List<Vector2>();
            List<Vector3> Normals = new List<Vector3>();

            List<Vertex> Vertices = new List<Vertex>();
            List<int> Indices = new List<int>();
            List<string> MeshMatNames = new List<string>();

            bool listening = false;
            string meshname="def_meshname";

            Mesh tempMesh;
            for (int i = 0; i < files.Length; i++)
            {
                var curline = files[i];
                // 顶点
                var datas = curline.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                var key = curline.Split(" ")[0];
                if (key == ("v"))
                {
                    var x = float.Parse(datas[1].Trim());
                    var y = float.Parse(datas[2].Trim());
                    var z = float.Parse(datas[3].Trim());
                    Vector3 vpos = new Vector3(x, y, z);
                    Positions.Add(vpos);


                }
                // 贴图
                if (key == ("vt"))
                {
                    var x = float.Parse(datas[1].Trim());
                    var y = float.Parse(datas[2].Trim());

                    Vector2 vtex = new Vector2(x, y);
                    TCoords.Add(vtex);

                }
                // 法线
                if (curline.StartsWith("vn"))
                {
                    var x = float.Parse(datas[1].Trim());
                    var y = float.Parse(datas[2].Trim());
                    var z = float.Parse(datas[3].Trim());
                    Vector3 vnor = new Vector3(x, y, z);
                    Normals.Add(vnor);
                }
                // 面 face
                if (curline.StartsWith("f"))
                {
                    List<Vertex> vVerts = GenVerticesFromRawOBJ(Positions, TCoords, Normals, curline);
                    for (int j = 0; j < vVerts.Count; j++)
                    {
                        Vertices.Add(vVerts[j]);
                        LoadedVertices.Add(vVerts[j]);

                    }

                    List<int> iIndices = VertexTriangluation(vVerts);
                    for (int j = 0; j < iIndices.Count; j++)
                    {
                        int indnum = (Vertices.Count - vVerts.Count) + iIndices[j];

                        Indices.Add(indnum);
                        indnum = (LoadedVertices.Count - vVerts.Count) + iIndices[j];
                        LoadedIndices.Add(indnum);
                    }

                }
            }
            if (Indices.Count>0 && Vertices.Count>0)
            {
                // Create Mesh
                tempMesh =new Mesh(Vertices, Indices);
                tempMesh.MeshName = meshname;

                // Insert Mesh
                LoadedMeshes.Add(tempMesh);
            }

            return true;
        }
        // Triangulate a list of vertices into a face by printing
        //	inducies corresponding with triangles within it
        private List<int> VertexTriangluation(List<Vertex> vVerts)
        {
            List<int> oIndices = new List<int>();
            if (vVerts.Count < 3)
            {
                return oIndices;
            }

            if (vVerts.Count == 3)
            {
                oIndices.Add(0);
                oIndices.Add(1);
                oIndices.Add(2);
                return oIndices;
            }

            List<Vertex> tVerts = vVerts;
            while (true)
            {
                for (int i = 0; i < tVerts.Count; i++)
                {
                    Vertex pPrev;
                    if (i == 0)
                    {
                        pPrev = tVerts[tVerts.Count - 1];

                    }
                    else
                    {
                        pPrev = tVerts[i - 1];
                    }

                    Vertex pCur = tVerts[i];
                    Vertex pNext;
                    if (i == tVerts.Count - 1)
                    {
                        pNext = tVerts[0];
                    }
                    else
                    {
                        pNext = tVerts[i + 1];
                    }

                    if (tVerts.Count == 3)
                    {
                        for (int j = 0; j < tVerts.Count; j++)
                        {
                            if (vVerts[j].Position == pCur.Position)
                                oIndices.Add(j);
                            if (vVerts[j].Position == pPrev.Position)
                                oIndices.Add(j);
                            if (vVerts[j].Position == pNext.Position)
                                oIndices.Add(j);
                        }
                        tVerts.Clear();
                        break;
                    }

                    if (tVerts.Count == 4)
                    {
                        for (int j = 0; j < vVerts.Count; j++)
                        {
                            if (vVerts[j].Position == pCur.Position)
                            {
                                oIndices.Add(j);
                            }
                            if (vVerts[j].Position == pPrev.Position)
                                oIndices.Add(j);
                            if (vVerts[j].Position == pNext.Position)
                                oIndices.Add(j);
                        }

                        Vector3 tempVec = Vector3.Zero;
                        for (int j = 0; j < tVerts.Count; j++)
                        {
                            if (tVerts[j].Position != pCur.Position
                                && tVerts[j].Position != pPrev.Position
                                && tVerts[j].Position != pNext.Position)
                            {
                                tempVec = tVerts[j].Position;
                                break;
                            }
                        }
                        // Create a triangle from pCur, pPrev, pNext
                        for (int j = 0; j < (vVerts.Count); j++)
                        {
                            if (vVerts[j].Position == pPrev.Position)
                                oIndices.Add(j);
                            if (vVerts[j].Position == pNext.Position)
                                oIndices.Add(j);
                            if (vVerts[j].Position == tempVec)
                                oIndices.Add(j);
                        }

                        tVerts.Clear();
                        break;
                    }
                    // 如果顶点不是内部顶点
                    var angle = MathHelper.AngleBetweenV3(pPrev.Position - pCur.Position, pNext.Position - pCur.Position) * (180 / 3.14159265359);

                    if (angle <= 0 && angle >= 180)
                    {
                        continue;
                    }
                    //// If any vertices are within this triangle
                    bool inTri = false;
                    for (int j = 0; j < vVerts.Count; j++)
                    {
                        if (Algorithm.inTriangle(vVerts[j].Position, pPrev.Position, pCur.Position, pNext.Position) && vVerts[j].Position != pPrev.Position
                            && vVerts[j].Position != pCur.Position
                            && vVerts[j].Position != pNext.Position)
                        {
                            inTri = true;
                            break;
                        }
                    }

                    if (inTri)
                    {
                        continue;
                    }
                    // Create a triangle from pCur, pPrev, pNext
                    for (int j = 0; j < vVerts.Count; j++)
                    {
                        if (vVerts[j].Position == pCur.Position)
                            oIndices.Add(j);
                        if (vVerts[j].Position == pPrev.Position)
                            oIndices.Add(j);
                        if (vVerts[j].Position == pNext.Position)
                            oIndices.Add(j);
                    }

                    // Delete pCur from the list
                    for (int j = 0; j < tVerts.Count; j++)
                    {
                        if (tVerts[j].Position == pCur.Position)
                        {
                            tVerts.RemoveAt(Convert.ToInt32(tVerts.FirstOrDefault()) + j);
                            break;
                        }
                    }

                    i = -1;
                }
                // if no triangles were created
                if (oIndices.Count == 0)
                    break;

                // if no more vertices
                if (tVerts.Count == 0)
                    break;
            }

            return oIndices;
        }

        private List<Vertex> GenVerticesFromRawOBJ(List<Vector3> positions, List<Vector2> coords, List<Vector3> normals, string curline)
        {
            List<Vertex> oVerts = new List<Vertex>();
            var sface = curline.Split(" ").ToList();
        
            bool noNormal = false;
            for (int i = 1; i < sface.Count; i++)
            {
                Vertex vVert = new Vertex();
                int vtype = 0;
                var svert = sface[i].Split("/");
                if (svert.Length == 1)
                {
                    vtype = 1;
                }

                if (svert.Length == 2)
                {
                    vtype = 2;
                }

                if (svert.Length == 3)
                {
                    if (svert[1] != "")
                    {
                        vtype = 4;
                    }
                    else
                    {
                        vtype = 3;
                    }
                }

                switch (vtype)
                {
                    case 1://P
                        {
                            vVert.Position = Algorithm.getElement(positions, svert[0]);
                            vVert.TextureCoordinate = Vector2.Zero;
                            noNormal = true;
                            oVerts.Add(vVert);
                            break;
                        }
                    case 2://P/T
                        {
                            vVert.Position = Algorithm.getElement(positions, svert[0]);
                            vVert.TextureCoordinate = Algorithm.getElementV2(coords, svert[1]);// coords[Convert.ToInt32(svert[1])];
                            noNormal = true;
                            oVerts.Add(vVert);
                            break;

                        }
                    case 3:// P//N
                        {
                            vVert.Position = Algorithm.getElement(positions, svert[0]);
                            vVert.TextureCoordinate = Vector2.Zero;//coords[Convert.ToInt32(svert[1])];
                            vVert.Normal = Algorithm.getElement(normals, svert[2]);
                            oVerts.Add(vVert);

                            break;
                        }
                    case 4:// P/T/N
                        {
                            vVert.Position = Algorithm.getElement(positions, svert[0]);
                            vVert.TextureCoordinate = Algorithm.getElementV2(coords, svert[1]);
                            vVert.Normal = Algorithm.getElement(normals, svert[2]);
                            oVerts.Add(vVert);

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            if (noNormal)
            {
                Vector3 A = oVerts[0].Position - oVerts[1].Position;
                Vector3 B = oVerts[2].Position - oVerts[1].Position;
                Vector3 normal = Vector3.Cross(A, B);
                for (int i = 0; i < oVerts.Count; i++)
                {
                    oVerts[i].Normal = normal;
                }
            }
            return oVerts;
        }

        public void GenVerticesFromRawOBJ(List<Vertex> oVerts, List<Vector3> iPositions, List<Vector3> iTCoords,
             List<Vector3> iNormals, string icurline)
        {
            List<string> sface, svert;
            Vertex vVert;
            sface = icurline.Split(" ").ToList();
            bool noNormal = false;

            // 遍历每一个面
            for (int i = 0; i < sface.Count; i++)
            {
                int vtype;
                svert = sface[i].Split("/").ToList();
                if (svert.Count == 1)
                {
                    // 只有一个位置信息
                    vtype = 1;
                }

                if (svert.Count == 2)
                {
                    // 位置和纹理
                    vtype = 2;
                }

                if (svert.Count == 3)
                {
                    if (svert[1] != "")
                    {
                        // 位置，纹理 和 法线
                        vtype = 4;
                    }
                    else
                    {
                        // 位置和法线
                        vtype = 3;
                    }
                }


            }
        }

        public void VertexTriangluation(List<int> oIndices, List<Vertex> iVerts)
        {
            if (iVerts.Count < 3)
            {
                return; ;
            }

            if (iVerts.Count == 3)
            {
                oIndices.Add(0);
                oIndices.Add(1);
                oIndices.Add(2);
                return;
            }

            List<Vertex> tVerts = iVerts;
            while (true)
            {
                for (int i = 0; i < tVerts.Count; i++)
                {
                    Vertex pPrev;
                    if (i == 0)
                    {
                        pPrev = tVerts[tVerts.Count - 1];
                    }
                    else
                    {
                        pPrev = tVerts[i - 1];
                    }

                    Vertex pCur = tVerts[i];
                    Vertex pNext;
                    if (i == tVerts.Count - 1)
                    {
                        pNext = tVerts[0];

                    }
                    else
                    {
                        pNext = tVerts[i + 1];
                    }

                    if (tVerts.Count == 3)
                    {
                        for (int j = 0; j < tVerts.Count; j++)
                        {
                            if (iVerts[j].Position == pCur.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == pPrev.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == pNext.Position)
                            {
                                oIndices.Add(j);
                            }
                        }
                        tVerts.Clear();
                        break;
                    }

                    if (tVerts.Count == 4)
                    {
                        for (int j = 0; j < iVerts.Count; j++)
                        {
                            if (iVerts[j].Position == pCur.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == pPrev.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == pNext.Position)
                            {
                                oIndices.Add(j);
                            }
                        }

                        Vector3 tempVec = new Vector3();
                        for (int j = 0; j < tVerts.Count; j++)
                        {
                            if (tVerts[j].Position != pCur.Position
                                && tVerts[j].Position != pPrev.Position
                                && tVerts[j].Position != pNext.Position
                                )
                            {
                                tempVec = tVerts[j].Position;
                                break;
                            }
                        }

                        for (int j = 0; j < iVerts.Count; j++)
                        {
                            if (iVerts[j].Position == pPrev.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == pNext.Position)
                            {
                                oIndices.Add(j);
                            }

                            if (iVerts[j].Position == tempVec)
                            {
                                oIndices.Add(j);
                            }
                        }
                        tVerts.Clear();
                        break;
                    }
                    // 如果顶点不是内部顶点
                    var angle = MathHelper.AngleBetweenV3(pPrev.Position - pCur.Position, pNext.Position - pCur.Position) * (180 / 3.14159265359);

                    if (angle <= 0 && angle >= 180)
                    {
                        continue;
                    }
                    //// If any vertices are within this triangle
                    bool inTri = false;
                    for (int j = 0; j < iVerts.Count; j++)
                    {

                    }
                }
            }
        }

        public bool LoadMaterials(string path)
        {
            return false;
        }
    }
}
