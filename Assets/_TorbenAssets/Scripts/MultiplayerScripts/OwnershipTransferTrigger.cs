/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 03-07-2022
Topic: Script to Transfer Ownership by entering Trigger Area
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnershipTransferTrigger : MonoBehaviour
{
	//[SerializeField] GameObject[] targetArray;
	[SerializeField] PhotonView photonView;
	[SerializeField] LayerMask layer;
	private void OnTriggerEnter(Collider other)
	{
		//foreach (var item in targetArray)
		//{
		//	if (other.gameObject == item)
		//	{
		//		photonView.RequestOwnership();
		//	}
		//}

		//if (other.gameObject.CompareTag("Hand"))
		//{
		//	photonView.RequestOwnership();
		//}

		if (((layer.value & (1 << other.gameObject.layer)) > 0))
		{
			photonView.RequestOwnership();
		}
	}
}
