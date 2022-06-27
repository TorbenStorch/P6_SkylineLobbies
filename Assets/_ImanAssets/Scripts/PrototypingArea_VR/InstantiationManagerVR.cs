/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 27-06-2022
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

    public void CubeInstantiation()
    {
        if (hasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("VR Cube", myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in multiplayer scene instantiated");
        }
        else
        {
            Instantiate(Resources.Load("VR Cube"), myCube.transform.position, myCube.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cube in singleplayer scene instantiated");
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
            PhotonNetwork.Instantiate("VR Sphere", mySphere.transform.position, mySphere.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Sphere in multiplayer scene instantiated");
        }
        else
        {
            Instantiate(Resources.Load("VR Sphere"), mySphere.transform.position, mySphere.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Sphere in singleplayer scene instantiated");
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
            PhotonNetwork.Instantiate("VR Capsule", myCapsule.transform.position, myCapsule.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Capsule in multiplayer scene instantiated");
        }
        else
        {
            Instantiate(Resources.Load("VR Capsule"), myCapsule.transform.position, myCapsule.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Capsule in singleplayer scene instantiated");
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
            PhotonNetwork.Instantiate("VR Cylinder", myCylinder.transform.position, myCylinder.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cylinder in multiplayer scene instantiated");
        }
        else
        {
            Instantiate(Resources.Load("VR Cylinder"), myCylinder.transform.position, myCylinder.transform.rotation);
            hasSpawned = true;
            Debug.Log("VR Cylinder in singleplayer scene instantiated");
        }
    }
}
