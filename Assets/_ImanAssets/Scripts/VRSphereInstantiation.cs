/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Sphere - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class VRSphereInstantiation : MonoBehaviour
{
    [SerializeField] GameObject mySphere;

    [SerializeField] bool sphereHasSpawned;

    public PhotonView photonView;

    public void VRSphereCloning()
    {
        if (sphereHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("VRSphere", mySphere.transform.position, mySphere.transform.rotation);
            sphereHasSpawned = true;
            Debug.Log("VR Sphere in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("VRSphere")), mySphere.transform.position, mySphere.transform.rotation);
            sphereHasSpawned = true;
            Debug.Log("VR Sphere in singleplayer scene has instantiated");
        }
    }
}
