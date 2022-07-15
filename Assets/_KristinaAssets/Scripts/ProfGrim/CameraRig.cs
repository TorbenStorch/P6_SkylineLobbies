using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    //public int numCameras = 4;
    //public bool renderInTexture = true;

    // Start is called before the first frame update
    void Start() 
    {
        createMultiDisplay();
        //createDemoScene(5, 5.0f); //fills the screen with rotating cubes
        //createCameras();
    }

    // rotY, rotX, lensshift

    float[,] cameraData = { { 0.0f, 0.0f, -0.5f }, { 0.0f, -90.0f, -0.5f }, { 0.0f, 90.0f, -0.5f }, { 90.0f, 0.0f, -0.5f },
                            { 0.0f, 0.0f, +0.5f }, { 0.0f, -90.0f, +0.5f }, { 0.0f, 90.0f, +0.5f }, { 90.0f, 0.0f, +0.5f }};

    /*void createCameras()
	{
        for (int i=0; i<numCameras; i++)
		{
            Camera camera = new Camera();
            //camera.transform.parent = transform;

            camera.transform.Rotate(new Vector3( cameraData[i,0], cameraData[i, 1], 0.0f ));
            camera.usePhysicalProperties = true;
            camera.fieldOfView = 90;
            camera.lensShift = new Vector2(0.0f, cameraData[i, 3]);
        }
    }*/

    void createMultiDisplay()
	{
        Debug.Log(Display.displays.Length);
        for (int i=1; i< Display.displays.Length; i++)
            Display.displays[i].Activate();
    }
}
