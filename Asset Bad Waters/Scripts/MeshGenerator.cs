using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{

    [SerializeField] Vector3[] changes;
    [SerializeField] Vector3[] _vertices;
    int[] _triangle;

    Mesh _mesh;
    
    void Awake()
    {

        _mesh = new Mesh();

       // _vertices = new Vector3[6];

        CreateMesh();
        

        //_vertices = GetComponent<MeshFilter>().sharedMesh.isReadable = true;
        //_vertices = GetComponent<MeshFilter>().sharedMesh.normals;

    }

    void CreateMesh()
    {
        //  _vertices = new Vector3[6];
        //_vertices[0] = new Vector3(0, 0, 0);
        //_vertices[1] = new Vector3(1, 0, 0);
        //_vertices[2] = new Vector3(0, 0, 1);
        //_vertices[3] = new Vector3(0, -0.5f, 0);
        //_vertices[4] = new Vector3(1, -0.4f, 0);
        //_vertices[5] = new Vector3(0, -0.4f, 1.1f);

        _triangle = new int[24]
        {
            0,2,1,
            4,5,3,
            4,3,0,
            4,1,2,
            5,4,2,
            1,4,0,
            0,3,2,
            2,3,5
        };

        Vector3[] _normals;
        _normals = new Vector3[6]
        {
        
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up,
            Vector3.up

        };

        var uv = new Vector2[6]
       {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
       };
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangle;
        _mesh.normals = _normals;
        _mesh.uv = uv;
        //_mesh.RecalculateNormals();
        _mesh.name = "Tricu";
        GetComponent<MeshFilter>().mesh = _mesh;
      //  GetComponent<MeshCollider>().sharedMesh.Clear();
        GetComponent<MeshCollider>().sharedMesh = _mesh;


    }

    void UpdateMesh()
    {


       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("Letra");
            

        }

        CreateMesh();

    }
}
