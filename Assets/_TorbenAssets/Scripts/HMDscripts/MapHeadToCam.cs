using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MapHeadToCam : MonoBehaviour
{
	[SerializeField] Transform camera;
	[SerializeField] PhotonView photonView;
	void Update()
	{
		if (photonView.IsMine)
			MapPosition(transform, camera);
	}
	void MapPosition(Transform target, Transform rigTransform)
	{
		target.position = rigTransform.position;
		target.rotation = rigTransform.rotation;
	}
}
