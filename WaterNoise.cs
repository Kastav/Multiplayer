//This script is used to make noise for the mesh of the water plane to use to generate wave like shapes.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoise : MonoBehaviour
{
    //To change the appearance of the noise
    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;

    // Start is called before the first frame update
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        makenoise();
    }

    // Update is called once per frame
    void Update()
    {

        //updates the noise every frame so it is constantly moving and appearing like waves.
        makenoise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;
    }

    void makenoise()
    {

        //Gathers the verticies from the mesh loops through all of them and sets their Y coordinate then * the power 
        Vector3[] verticies = mf.mesh.vertices;
        
        for(int i=0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        mf.mesh.vertices = verticies;

    }

    //calculation to make the height through the noise to then call it in the makenoise function
    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + offsetX;
        float yCord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }

}
