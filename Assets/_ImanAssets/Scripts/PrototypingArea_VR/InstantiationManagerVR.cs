/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for instantiate the gameobjects - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;
using System.IO;

public class InstantiationManagerVR : MonoBehaviour
{
    [SerializeField] GameObject myCube;
    [SerializeField] GameObject mySphere;
    [SerializeField] GameObject myCapsule;
    [SerializeField] GameObject myCylinder;

    private bool hasSpawned;

    public PhotonView photonView;


    public void CubeInstantiationNoSubFolder()
    {
        if (hasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("VRCube", myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in multiplayer scene has instantiated");
        }
        else if(!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("VRCube")), myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in singleplayer scene has instantiated");
        }
    }







    public void CubeInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("VR", "VR Cube"), myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("VR", "VR Cube")), myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in singleplayer scene has instantiated");
        }
    }

    public void SphereInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("VR", "VR Sphere"), mySphere.transform.position, mySphere.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Sphere in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("VR", "VR Sphere")), mySphere.transform.position, mySphere.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Sphere in singleplayer scene has instantiated");
        }
    }

    public void CapsuleInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("VR", "VR Capsule"), myCapsule.transform.position, myCapsule.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Capsule in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("VR", "VR Capsule")), myCapsule.transform.position, myCapsule.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Capsule in singleplayer scene has instantiated");
        }
    }

    public void CylinderInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("VR", "VR Cylinder"), myCylinder.transform.position, myCylinder.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cylinder in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("VR", "VR Cylinder")), myCylinder.transform.position, myCylinder.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cylinder in singleplayer scene has instantiated");
        }
    }
}
