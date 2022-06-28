/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for instantiate the gameobjects - Prototyping area - CAVE side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;
using System.IO;

public class InstantiationManager : MonoBehaviour
{
    [SerializeField] Transform myCube;
    [SerializeField] Transform mySphere;
    [SerializeField] Transform myCylinder;
    [SerializeField] Transform myCapsule;

    public PhotonView photonView;


    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }
    }

    public void CubeInstantiation()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("CAVE", "Cube"), myCube.position, myCube.rotation);
            Debug.Log("Cube in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("CAVE", "Cube")), myCube.position, myCube.rotation);
            Debug.Log("Cube in singleplayer scene has instantiated");
        }
    }

    public void SphereInstantiation()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("CAVE", "Sphere"), mySphere.position, mySphere.rotation);
            Debug.Log("Sphere in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("CAVE", "Sphere")), mySphere.position, mySphere.rotation);
            Debug.Log("Sphere in singleplayer scene has instantiated");
        }
    }

    public void CapsuleInstantiation()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("CAVE", "Capsule"), myCapsule.position, myCapsule.rotation);
            Debug.Log("Capsule in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("CAVE", "Capsule")), myCapsule.position, myCapsule.rotation);
            Debug.Log("Capsule in singleplayer scene has instantiated");
        }
    }

    public void CylinderInstantiation()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate(Path.Combine("CAVE", "Cylinder"), myCylinder.position, myCylinder.rotation);
            Debug.Log("Cylinder in multiplayer scene has instantiated");
        }
        else
        {
            Instantiate(Resources.Load(Path.Combine("CAVE", "Cylinder")), myCylinder.position, myCylinder.rotation);
            Debug.Log("Cylinder in singleplayer scene has instantiated");
        }
    }
}
