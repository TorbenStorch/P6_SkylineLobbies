using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class HmdHandAnimations : MonoBehaviour
{
	[SerializeField] PhotonView photonView;
	[SerializeField] Animator leftHandAnimator, rightHandAnimator;
	private void Start()
	{
		if (photonView == null) photonView = GetComponent<PhotonView>();
	}
	private void Update()
	{
		if (photonView.IsMine)
		{
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
}
