using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Face
{
    public List<Vector3> vertices { get; private set; }
    public List<int> triangles { get; private set; }
    public List<Vector2> uvs { get; private set; }

    public Face(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs)
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.uvs = uvs;
    }

}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HexScript : MonoBehaviour
{
    private Mesh m_mesh;
    private MeshFilter m_meshFilter;
    private MeshRenderer m_meshRenderer;

    private List<Face> m_faces;

    public Material material;
    public float innerSize;
    public float outerSize;
    public float height;
    public int point;

    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_meshRenderer = GetComponent<MeshRenderer>();

        m_mesh = new Mesh();
        m_mesh.name = "Hex";

        m_meshFilter.mesh = m_mesh;
        m_meshRenderer.material = material;
    }

    private void OnEnable()
    {
        DrawMesh();
    }

    public void OnValidate()
    {
        if (Application.isPlaying && m_mesh)
        {
            DrawMesh();
        }
    }

    public void DrawMesh()
    {
        DrawFaces();
        CombineFaces();

    }

    private Face CreateFace(float innerRad, float outerRad, float heightA, float heightB, int point, bool reverse = false)
    {
        Vector3 pointA = GetPoint(innerRad, heightB, point);                    
        Vector3 pointB = GetPoint(innerRad, heightB, (point < 5) ? point + 1 : 0); 
        Vector3 pointC = GetPoint(outerRad, heightA, (point < 5) ? point + 1 : 0); 
        Vector3 pointD = GetPoint(outerRad, heightA, point);

        List<Vector3> vertices = new List<Vector3>() {pointA , pointB , pointC , pointD }; // 存储顶点坐标
        List<int> triangles = new List<int>() {0,1,2,2,3,0};        // 存储三角形索引
        List<Vector2> uvs = new List<Vector2>()
        { 
            new Vector2(0,0),new Vector2(1,0),new Vector2(1,1), new Vector2(0,1),
        };      // 存储 UV 贴图坐标

        if (reverse)
        {
            vertices.Reverse();
        }

        return new Face();
    }
    protected Vector3 GetPoint(float size, float height, int index)
    {
        float angle_deg = 60 * index;          // 计算角度（60° × index）
        float angle_rad = Mathf.PI / 180f * angle_deg;  // 角度转弧度
        return new Vector3(
            (size * Mathf.Cos(angle_rad)),     // X 坐标 = size × cos(角度)
            height,                            // Y 坐标 = 高度（固定值）
            size * Mathf.Sin(angle_rad)        // Z 坐标 = size × sin(角度)
        );
    }

    private void DrawFaces()
    {
        m_faces = new List<Face>();

        for(int i = 0; i < 6; i++)
        {
            m_faces.Add(CreateFace(innerSize , outerSize , height/2f , height/2f , point ));
        }

    }
    private void CombineFaces()
    {
        List<Vector3> vertices = new List<Vector3>(); 
        List<int> tris = new List<int>();           
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < m_faces.Count; i++)
        {
            
            vertices.AddRange(m_faces[i].vertices);
            uvs.AddRange(m_faces[i].uvs);

            int offset = (4 * i); 
            foreach (int triangle in m_faces[i].triangles)
            {
                tris.Add(triangle + offset);
            }
        }

        m_mesh.vertices = vertices.ToArray();
        m_mesh.triangles = tris.ToArray();
        m_mesh.uv = uvs.ToArray();
        m_mesh.RecalculateNormals();
    }

    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
