/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
Last change: 03-07-2022
Topic: Custom Button
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
	[Tooltip("If the slot is empty, we will look for an GameObject with tag 'HmdHand'!")]
	//[SerializeField] private GameObject handCollider;
	[SerializeField] LayerMask buttonLayer;
	[SerializeField] private GameObject frame;

	[Range(0.1f, 10f)]
	[SerializeField] private float timeToGoDown = 0.1f;
	[Range(0.1f, 10f)]
	[SerializeField] private float timeToGoUp = 0.1f;

	public UnityEvent onPress;
	public UnityEvent onDown;

	bool buttonDown;
	Vector3 startPos;

	private void Start() => startPos = gameObject.transform.localPosition;

	private void Update()
	{
		//if (handCollider == null) handCollider = GameObject.FindGameObjectWithTag("HmdHand");
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (/*other.gameObject == handCollider*/ other.gameObject.layer == LayerMask.NameToLayer("HandForOwnership") && !buttonDown)
		//{

		if (  ((buttonLayer.value & (1 << other.gameObject.layer)) > 0)   && !buttonDown)
		{
			onPress.Invoke();
			StartCoroutine(ButtonGoesDown());
		}
		if (other.gameObject == frame)
		{
			buttonDown = true;
			onDown.Invoke();
		}
	}

	public void ButtonGoesUpCall() => StartCoroutine(ButtonGoesUp());

	IEnumerator ButtonGoesDown()
	{
		while (!buttonDown)
		{
			gameObject.transform.localPosition -= new Vector3(0, timeToGoDown * Time.deltaTime, 0);
			yield return null;
		}
		yield return null;
	}

	IEnumerator ButtonGoesUp()
	{
		while (gameObject.transform.localPosition.y < startPos.y)
		{
			gameObject.transform.localPosition += new Vector3(0, timeToGoUp * Time.deltaTime, 0);
			yield return null;
		}
		buttonDown = false;
		yield return null;
	}
}
