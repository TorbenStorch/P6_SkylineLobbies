/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 21-06-2022
Topic: Teleportation Locomotion Script
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{

	[SerializeField] private InputActionAsset actionAsset;
	[SerializeField] private XRRayInteractor rayInteractor;
	[SerializeField] private TeleportationProvider provider;
	private InputAction thumpstick;
	private bool isActive;

	private void Start()
	{
		rayInteractor.enabled = false;

		InputAction activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
		activate.Enable();
		activate.performed += _ => OnTeleportActivate(); //if u want to call a function without overload / normally it needs to have same overload as delegate

		InputAction cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
		cancel.Enable();
		cancel.performed += OnTeleportCancel; //this is how u call it if it has same overload as the delegate

		thumpstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
		thumpstick.Enable();
	}
	private void Update()
	{
		if (!isActive)
			return;

		if (thumpstick.triggered)
			return;

		//if(!rayInteractor.GetCurrentRaycastHit(out RaycastHit hit))
		//{
		//	rayInteractor.enabled = false;
		//	isActive = false;
		//	return;
		//}
		if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
		{
			rayInteractor.enabled = false;
			isActive = false;
			return;
		}

		TeleportRequest request = new TeleportRequest()
		{
			destinationPosition = hit.point
		};
		provider.QueueTeleportRequest(request);
		rayInteractor.enabled = false;
		isActive = false;

	}
	void OnTeleportActivate(/*InputAction.CallbackContext context*/) //without overload, it needs to be called different
	{
		rayInteractor.enabled = true;
		isActive = true;
	}
	void OnTeleportCancel(InputAction.CallbackContext context) //if u put in the overload
	{
		rayInteractor.enabled = false;
		isActive = false;
	}
}
