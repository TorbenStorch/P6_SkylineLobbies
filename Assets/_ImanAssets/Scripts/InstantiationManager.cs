using UnityEngine;
using Photon.Pun;

public class InstantiationManager : MonoBehaviour
{
    [SerializeField]
    Transform myCube;
    [SerializeField]
    Transform mySphere;
    [SerializeField]
    Transform myCylinder;
    [SerializeField]
    Transform myCapsule;

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
        Instantiate(Resources.Load("Cube"), myCube.position, myCube.rotation);
    }

    public void SphereInstantiation()
    {
        Instantiate(Resources.Load("Sphere"), mySphere.position, mySphere.rotation);
    }

    public void CapsuleInstantiation()
    {
        Instantiate(Resources.Load("Capsule"), myCapsule.position, myCapsule.rotation);
    }

    public void CylinderInstantiation()
    {
        Instantiate(Resources.Load("Cylinder"), myCylinder.position, myCylinder.rotation);
    }
}
