/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 06-07-2022
Topic: Instantiate Object and grabing it out (infinite atm)
---------------------------------------------------------*/
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class GrabInstantiate : MonoBehaviour
{
	bool wasCreated;
	[SerializeField] GameObject prefab;
	[SerializeField] LayerMask interactionLayer;
	GameObject createdObject;

	public static event Action<GameObject> createdNewObject; //event that will be called with the created object as parameter when a new object was created
	public UnityEvent onTriggerExit; //unity event so that i can reactivate the collider (not trigger) to use the XR Simple Interactable for long distance spawing

	private void OnTriggerEnter(Collider other)
	{
		if (((interactionLayer.value & (1 << other.gameObject.layer)) > 0)) //trigger works with layer -> object needs to have same layer if it wants to call triggerEnter
		{
			OnHover();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == createdObject)
		{
			createdObject.GetComponent<Renderer>().enabled = true;
			wasCreated = false;
			onTriggerExit.Invoke();
		}
	}

	public void OnHover()
	{
		if (wasCreated)
		{
			return;
		}
		if (PhotonNetwork.InRoom)
		{
			createdObject = PhotonNetwork.Instantiate(prefab.name, transform.position, transform.rotation);
			createdObject.GetComponent<Renderer>().enabled = false;

			if (createdNewObject != null) //safety check - dont call it if there is notghing to call
			{
				createdNewObject(createdObject); //event called with createdObject as parameter
			}

			wasCreated = true;
		}
		else if (!PhotonNetwork.InRoom)
		{
			createdObject = Instantiate(prefab, transform.position, transform.rotation);
			createdObject.GetComponent<Renderer>().enabled = false;

			if (createdNewObject != null) //safety check - dont call it if there is notghing to call
			{
				createdNewObject(createdObject); //event called with createdObject as parameter
			}

			wasCreated = true;
		}
	}

}
