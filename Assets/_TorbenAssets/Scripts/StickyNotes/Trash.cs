/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 06-07-2022
Topic: TriggerArea that deletes objects (out of List) placed inside 
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
	[HideInInspector] public List<GameObject> trashList;
	private void Start()
	{
		GrabInstantiate.createdNewObject += AddToList; //subscripe to the event by GrabInstatiate (it calls the event everytime a new object gets created & has it in its overrride)
	}
	void AddToList(GameObject gameObject) //we add the gameObject from GrabInstatiate into our list of trashable items
	{
		trashList.Add(gameObject);

	}
	private void OnTriggerEnter(Collider other)
	{
		if (trashList.Contains(other.gameObject))
		{
			Destroy(other.gameObject); //delete the item
		}
	}
	private void OnDisable()
	{
		//GrabInstantiate.createdNewObject -= AddToList;
	}
}
