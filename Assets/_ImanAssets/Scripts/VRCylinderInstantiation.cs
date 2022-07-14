/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Cylinder - Prototyping area - VR side
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class VRCylinderInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCylinder;

    [SerializeField] bool cylinderHasSpawned;

    public PhotonView photonView;

    public void VRCylinderCloning()
    {
        if (cylinderHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
        {
            PhotonNetwork.Instantiate("VRCylinder", myCylinder.transform.position, myCylinder.transform.rotation);
            cylinderHasSpawned = true;
            Debug.Log("VR Cylinder in multiplayer scene has instantiated");
        }
        else if (!PhotonNetwork.InRoom)
        {
            Instantiate(Resources.Load(("VRCylinder")), myCylinder.transform.position, myCylinder.transform.rotation);
            cylinderHasSpawned = true;
            Debug.Log("VR Cylinder in singleplayer scene has instantiated");
        }
    }
}
