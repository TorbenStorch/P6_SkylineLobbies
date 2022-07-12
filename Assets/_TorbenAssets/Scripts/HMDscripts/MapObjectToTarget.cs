/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 10-07-2022
Topic: Script to map the head-model onto the VR Camera Transform
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MapObjectToTarget : MonoBehaviour
{
	[SerializeField] Transform targetTransform;
	[SerializeField] PhotonView photonView;

	[SerializeField] bool mapRotationAsWell;
	void Update()
	{
		if (photonView.IsMine)
			MapPosition(transform, targetTransform);
	}
	void MapPosition(Transform target, Transform rigTransform)
	{
		target.position = rigTransform.position;
		if (mapRotationAsWell)
			target.rotation = rigTransform.rotation;
	}
}
