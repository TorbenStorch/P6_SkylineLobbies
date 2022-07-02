/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 02-07-2022
Topic: Mapping the Marker to the controller if its inside the trigger
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDrawing : MonoBehaviour
{
	[SerializeField] GameObject targetHand;
	[SerializeField] GameObject marker;
	[SerializeField] GameObject markerPos;


	private void Start()
	{
		if (!targetHand) Debug.LogError("No Target Hand!");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == targetHand)
		{
			marker.transform.position = new Vector3(marker.transform.position.x, markerPos.transform.position.y, marker.transform.position.z);
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == targetHand)
		{
			marker.transform.position = new Vector3(targetHand.transform.position.x, markerPos.transform.position.y, targetHand.transform.position.z);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == targetHand)
		{
			marker.transform.position = new Vector3(marker.transform.position.x, 100f, marker.transform.position.z);
		}
	}

}
