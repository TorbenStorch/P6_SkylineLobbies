using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CubeInstantiation()
    {
        /*GameObject != gameObject*/
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        /*if you need add position, scale and color to the cube*/
        cubeObject.transform.localPosition = new Vector3(0, 1, 0);
        cubeObject.transform.localScale = new Vector3(1, 1, 1);
        cubeObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void SphereInstantiation()
    {
        /*GameObject != gameObject*/
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        /*if you need add position, scale and color to the cube*/
        cubeObject.transform.localPosition = new Vector3(-2, 1, 0);
        cubeObject.transform.localScale = new Vector3(1, 1, 1);
        cubeObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public void CapsuleInstantiation()
    {
        /*GameObject != gameObject*/
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        /*if you need add position, scale and color to the cube*/
        cubeObject.transform.localPosition = new Vector3(2, 1, 0);
        cubeObject.transform.localScale = new Vector3(1, 1, 1);
        cubeObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    public void CylinderInstantiation()
    {
        /*GameObject != gameObject*/
        GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        /*if you need add position, scale and color to the cube*/
        cubeObject.transform.localPosition = new Vector3(0, 1, 0);
        cubeObject.transform.localScale = new Vector3(1, 1, 1);
        cubeObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
