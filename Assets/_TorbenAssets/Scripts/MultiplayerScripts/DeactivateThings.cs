using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(PhotonView))]
public class DeactivateThings : MonoBehaviour
{
	[SerializeField] PhotonView photonView;

	[Header("Objects to deactivate:")]
	[SerializeField] GameObject[] deactivateObjects;
	[SerializeField] Camera cameraToTurnOff;
	[SerializeField] AudioListener audioListenerToTurnOff;

	[SerializeField] bool deactavateXROrigin;

	//GameObject hmdObjectToDeactivate;
	XROrigin origin;

	private void Start()
	{
		if (photonView == null)
		{
			Debug.LogError("No PhotonView found!");
			return;
		}
		if (PhotonNetwork.InRoom && !photonView.IsMine)
		{
			foreach (var item in deactivateObjects)
				item.SetActive(false);

			if (cameraToTurnOff != null)
				cameraToTurnOff.enabled = false;

			if (audioListenerToTurnOff != null)
				audioListenerToTurnOff.enabled = false;

			if (deactavateXROrigin)
			{
				origin = GetComponent<XROrigin>();
				if (origin != null)
					origin.enabled = false;
			}
		}
	}
}
