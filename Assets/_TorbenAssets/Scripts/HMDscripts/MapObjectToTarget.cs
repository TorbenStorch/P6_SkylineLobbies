/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 09-06-2022
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
	void Update()
	{
		if (photonView.IsMine)
			MapPosition(transform, targetTransform);
	}
	void MapPosition(Transform target, Transform rigTransform)
	{
		target.position = rigTransform.position;
		target.rotation = rigTransform.rotation;
	}
}
