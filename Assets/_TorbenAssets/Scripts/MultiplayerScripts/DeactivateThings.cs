/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 25-06-2022
Topic: Script to deactivate different Components/GameObjects to ensure Photon will not try to use both
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(PhotonView))]
public class DeactivateThings : MonoBehaviour
{
	[SerializeField] PhotonView photonView;

	[Header("Objects to deactivate:")]
	[Space(10)]
	[SerializeField] GameObject[] deactivateObjects;
	[SerializeField] Camera cameraToTurnOff;
	[SerializeField] AudioListener audioListenerToTurnOff;

	[SerializeField] bool deactavateXROrigin;

	[SerializeField] TrackedPoseDriver trackedPoseDriver;

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
			if (trackedPoseDriver != null)
				trackedPoseDriver.enabled = false;
			if (deactavateXROrigin)
			{
				origin = GetComponent<XROrigin>();
				if (origin != null)
					origin.enabled = false;
			}
		}
	}
}
