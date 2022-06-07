using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class HmdPlayer : MonoBehaviour
{
	public Transform head, leftHand, rightHand; //on the prefab
	PhotonView photonView;

	Transform headRig, leftHandRig, rightHandRig; //in the scene(inside the XROrigin)

	public Animator leftHandAnimator, rightHandAnimator;


	private void Start()
	{
		photonView = GetComponent<PhotonView>();

		XROrigin origin = FindObjectOfType<XROrigin>();
		headRig = origin.transform.Find("Camera Offset/Main Camera");
		leftHandRig = origin.transform.Find("Camera Offset/LeftHand Controller");
		rightHandRig = origin.transform.Find("Camera Offset/RightHand Controller");

		//headRig = GameObject.FindGameObjectWithTag("hmd").transform;
		//leftHandRig = GameObject.FindGameObjectWithTag("hmd").transform;
		//rightHandRig = GameObject.FindGameObjectWithTag("hmd").transform;

		if (photonView.IsMine)
		{
			foreach (var item in GetComponentsInChildren<Renderer>())
			{
				item.enabled = false;
			}
		}
	}
	private void Update()
	{
		if (photonView.IsMine)
		{
			//head.gameObject.SetActive(false);
			//leftHand.gameObject.SetActive(false);
			//rightHand.gameObject.SetActive(false);

			MapPosition(head, headRig);				
			MapPosition(leftHand, leftHandRig);		
			MapPosition(rightHand, rightHandRig);	

			UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
			UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
		}
	}
	void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
	{
		if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
		{
			handAnimator.SetFloat("Trigger", triggerValue);
		}
		else
		{
			handAnimator.SetFloat("Trigger", 0);
		}

		if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
		{
			handAnimator.SetFloat("Grip", gripValue);
		}
		else
		{
			handAnimator.SetFloat("Grip", 0);
		}
	}
	void MapPosition(Transform target, Transform rigTransform)
	{
		target.position = rigTransform.position;
		target.rotation = rigTransform.rotation;
		
	}
}
