/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Sphere - Prototyping area
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class SphereInstantiation : MonoBehaviour
{
    [SerializeField] GameObject mySphere;

    [SerializeField] bool sphereHasSpawned;

    public PhotonView photonView;

    public void SphereCloning()
    {
        if (sphereHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
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
}
