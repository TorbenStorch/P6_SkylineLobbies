/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 26-06-2022
Topic: Script for instantiate the gameobjects - Prototyping area - CAVE side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;


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
            PhotonNetwork.Instantiate("Cube", myCube.position, myCube.rotation);
        }
        else
        {
            Instantiate(Resources.Load("Cube"), myCube.position, myCube.rotation);
        }
    }

    public void SphereInstantiation()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("Sphere", mySphere.position, mySphere.rotation);
        }
        else
        {
            Instantiate(Resources.Load("Sphere"), mySphere.position, mySphere.rotation);
        }
    }

    public void CapsuleInstantiation()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("Capsule", myCapsule.position, myCapsule.rotation);
        }
        else
        {
            Instantiate(Resources.Load("Capsule"), myCapsule.position, myCapsule.rotation);
        }
    }

    public void CylinderInstantiation()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("Cylinder", myCylinder.position, myCylinder.rotation);
        }
        else
        {
            Instantiate(Resources.Load("Cylinder"), myCylinder.position, myCylinder.rotation);
        }
    }
}
