/*-------------------------------------------------------
Creator: Iman Nikkhahazad
Expanded Realities P6
last change: 14-07-2022
Topic: Script for instantiate the Cylinder - Prototyping area 
---------------------------------------------------------*/

using UnityEngine;
using Photon.Pun;

public class CylinderInstantiation : MonoBehaviour
{
    [SerializeField] GameObject myCylinder;

    [SerializeField] bool cylinderHasSpawned;

    public PhotonView photonView;

    public void CylinderCloning()
    {
        if (cylinderHasSpawned)
        {
            return;
        }

        if (PhotonNetwork.InRoom && photonView.IsMine)
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
