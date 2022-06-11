using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour
{
	[SerializeField] Transform transfromTarget;
	
	void Update()
	{
		
			MapPosition(transform, transfromTarget);
	}
	void MapPosition(Transform target, Transform rigTransform)
	{
		target.position = rigTransform.position;
		target.rotation = rigTransform.rotation;
	}
}
