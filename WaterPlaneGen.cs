using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGen : MonoBehaviour
{

    //set size of mesh
    public float size = 1;

    public int gridSize = 16;

    // assign filter to MeshFilter
    private MeshFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        //calling GenerateMesh to start whenever we press play
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    //Generates the mesh(Plane) 
    private Mesh GenerateMesh()
    {
        Mesh m = new Mesh();
        
        //storing norms verts and uvs
        var verticies = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        //loops x until it is the gridsize + 1 it will then stop generating
        for(int x = 0; x < gridSize +1; x++)
        {
            //loops y until it is the gridsize + 1 it will then stop generating
            for (int y = 0; y < gridSize +1; y++)
            {
                //divides the x and y by the grid size to generate uvs and verticies
                verticies.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);  //To make sure the mesh is pointing up
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        //Generates the trianges from the verticies calculated .
        var triangles = new List<int>();
        var vertCount = gridSize + 1;
        for(int i =  0; i < vertCount * vertCount - vertCount; i++)
        {
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
            {
                i+1+vertCount, i+vertCount, i,
                i, i+1, i+vertCount+1
            });
        }

        //Takes the calculations from above and sets them as current 
        m.SetVertices(verticies);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);

        //Makes the mesh with the current calculations
        return m;

    }

}
