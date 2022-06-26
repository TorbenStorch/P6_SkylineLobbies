/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 26-06-2022
Topic: Script for instantiate the gameobjects - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class InstantiationManagerVR : MonoBehaviour
{
    [SerializeField] GameObject myCube;
    [SerializeField] GameObject mySphere;
    [SerializeField] GameObject myCapsule;
    [SerializeField] GameObject myCylinder;

    private bool hasSpawned;

    public PhotonView photonView;

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    //public void InstantiatorManager()
    //{
    //    if(hasSpawned)
    //    {
    //        return;
    //    }

    //    Instantiate(mySphere, mySphere.transform.position, mySphere.transform.rotation);
    //    hasSpawned = true;
    //    Debug.Log("Object created !");
    //}

    public void CubeInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        Instantiate(Resources.Load("VR Cube"), myCube.transform.position, myCube.transform.rotation);
        hasSpawned = true;
        Debug.Log("VR Cube instantiated");
    }

    public void SphereInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        Instantiate(Resources.Load("VR Sphere"), mySphere.transform.position, mySphere.transform.rotation);
        hasSpawned = true;
        Debug.Log("VR Sphere instantiated");
    }

    public void CapsuleInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        Instantiate(Resources.Load("VR Capsule"), myCapsule.transform.position, myCapsule.transform.rotation);
        hasSpawned = true;
        Debug.Log("VR Capsule instantiated");
    }

    public void CylinderInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        Instantiate(Resources.Load("VR Cylinder"), myCylinder.transform.position, myCylinder.transform.rotation);
        hasSpawned = true;
        Debug.Log("VR Cylinder instantiated");
    }
}
