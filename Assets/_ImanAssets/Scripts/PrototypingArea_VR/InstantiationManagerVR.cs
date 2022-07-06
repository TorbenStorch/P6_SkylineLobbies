/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 06-07-2022
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

    private bool cubeHasSpawned;
    private bool sphereHasSpawned;
    private bool capsuleHasSpawned;
    private bool cylinderHasSpawned;

    public PhotonView photonView;


    public void CubeInstantiation()
    {
        if (cubeHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Cube", myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("Cube in multiplayer scene has instantiated");
        }
        else if(!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("Cube")), myCube.transform.position, myCube.transform.rotation);
            cubeHasSpawned = true;
            Debug.Log("Cube in singleplayer scene has instantiated");
        }
    }

    public void SphereInstantiation()
    {
        if (sphereHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Sphere", mySphere.transform.position, mySphere.transform.rotation);
            sphereHasSpawned = true;
            Debug.Log("Sphere in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("Sphere")), mySphere.transform.position, mySphere.transform.rotation);
            sphereHasSpawned = true;
            Debug.Log("Sphere in singleplayer scene has instantiated");
        }
    }

    public void CapsuleInstantiation()
    {
        if (capsuleHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Capsule", myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("Capsule in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("Capsule")), myCapsule.transform.position, myCapsule.transform.rotation);
            capsuleHasSpawned = true;
            Debug.Log("Capsule in singleplayer scene has instantiated");
        }
    }

    public void CylinderInstantiation()
    {
        if (cylinderHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Cylinder", myCylinder.transform.position, myCylinder.transform.rotation);
            cylinderHasSpawned = true;
            Debug.Log("Cylinder in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("Cylinder")), myCylinder.transform.position, myCylinder.transform.rotation);
            cylinderHasSpawned = true;
            Debug.Log("Cylinder in singleplayer scene has instantiated");
        }
    }
}
