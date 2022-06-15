/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 09-06-2022
Topic: Script for Cube-Shaped-CAVE-Guardian setup
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSetup : MonoBehaviour //currently only for one tracker (maybe needs more later on)
{
	#region Data
	//Position
	Vector3 centerPosition;
	Vector3 leftBorder, frontBorder, rightBorder, bufferBorder;
	int state = 0;
	[SerializeField] int secondsToWaitForCalibration;
	bool guardianSet;
	float bufferBorderDifference;
	float frontBorderStart, leftBorderStart, rightBorderStart;
	bool buttonPressedFlag = false;

	//Color
	Color near = new Color(1, 0, 0, 1);
	Color far = new Color(0, 0, 0, 0);
	Color borderColorLeft, borderColorFront, borderColorRight;
	public GameObject borderObjLeft, borderObjFront, borderObjRight;
	#endregion

	#region Default Border & Update
	void Start()
	{
		DefaultBorders();
	}
	void Update()
	{
		SetGuardian();
		CalculateAlpha();
		SetColorForBorder();
	}

	void DefaultBorders()
	{
		centerPosition = this.transform.position;
		leftBorder = new Vector3(-10, 0, 0);
		frontBorder = new Vector3(0, 0, 10);
		rightBorder = new Vector3(10, 0, 0);


		leftBorderStart = leftBorder.x;
		frontBorderStart = frontBorder.z;
		rightBorderStart = rightBorder.x;

		borderObjLeft.GetComponent<Renderer>().material.color = far;
		borderObjFront.GetComponent<Renderer>().material.color = far;
		borderObjRight.GetComponent<Renderer>().material.color = far;
	}
	#endregion

	#region SetGuardian

	//Press Space and position the Tracker where the border should be set (1. Center | 2. Left | 3. Front | 4. Right | 5. Bufferzone from right side)
	void SetGuardian()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !guardianSet && !buttonPressedFlag) //set the guardian if it was not set & prevent button spamming 
		{
			buttonPressedFlag = true;
			StartCoroutine(SetPostitons(state));
			switch (state)
			{
				case 0:
					Debug.Log("Wait " + secondsToWaitForCalibration + " seconds, Start Position will be set");
					break;
				case 1:
					Debug.Log("Wait " + secondsToWaitForCalibration + " seconds, Left Border will be set");
					break;
				case 2:
					Debug.Log("Wait " + secondsToWaitForCalibration + " seconds, Front Border will be set");
					break;
				case 3:
					Debug.Log("Wait " + secondsToWaitForCalibration + " seconds, Right Border will be set");
					break;
				case 4:
					Debug.Log("Wait " + secondsToWaitForCalibration + " seconds, Buffer Border from Right Border will be set");
					break;

				default:
					break;
			}
		}
		else if ((Input.GetKeyDown(KeyCode.R)))
		{
			Debug.Log("GUARDIAN RESET");
			guardianSet = false;
			state = 0;
			DefaultBorders();
		}
	}
	IEnumerator SetPostitons(int currentState)
	{
		yield return new WaitForSeconds(secondsToWaitForCalibration);
		buttonPressedFlag = false;
		switch (currentState) //set the center & border positions to the point where the tracker is after the delay
		{
			case 0:
				centerPosition = transform.position;
				Debug.Log("StartPos:" + centerPosition);
				break;
			case 1:
				leftBorder = transform.position;
				Debug.Log("l_Pos:" + leftBorder);
				break;
			case 2:
				frontBorder = transform.position;
				Debug.Log("f_Pos:" + frontBorder);
				break;
			case 3:
				rightBorder = transform.position;
				Debug.Log("r_Pos:" + rightBorder);
				break;
			case 4:
				bufferBorder = transform.position;
				Debug.Log("buffer_Pos:" + bufferBorder);
				guardianSet = true;

				//Set Buffer
				bufferBorderDifference = rightBorder.x - bufferBorder.x;
				frontBorderStart = frontBorder.z - bufferBorderDifference;
				leftBorderStart = leftBorder.x + bufferBorderDifference;
				rightBorderStart = rightBorder.x - bufferBorderDifference;
				break;


			default:
				break;
		}
		state += 1;
	}
	#endregion

	#region CheckDistance
	void CalculateAlpha() //set the color of the corresponding border to a lerp from near to far color
	{
		if (transform.position.x <= leftBorderStart)
		{
			float lerp = MapValue(transform.position.x, leftBorder.x, leftBorderStart, 0f, 1f);
			Color lerpColor = Color.Lerp(near, far, lerp);
			Debug.LogWarning("LEFT");
			borderColorLeft = lerpColor;
		}
		else
		{
			borderColorLeft = far;
		}
		if (transform.position.x >= rightBorderStart)
		{
			float lerp = MapValue(transform.position.x, rightBorder.x, rightBorderStart, 0f, 1f);
			Color lerpColor = Color.Lerp(near, far, lerp);
			Debug.LogWarning("RIGHT");
			borderColorRight = lerpColor;
		}
		else
		{
			borderColorRight = far;
		}
		if (transform.position.z >= frontBorderStart)
		{
			float lerp = MapValue(transform.position.z, frontBorder.z, frontBorderStart, 0f, 1f);
			Color lerpColor = Color.Lerp(near, far, lerp);
			Debug.LogWarning("FRONT");
			borderColorFront = lerpColor;
		}
		else
		{
			borderColorFront = far;
		}
	}

	void SetColorForBorder()
	{
		if (guardianSet)
		{
			borderObjLeft.GetComponent<Renderer>().material.color = borderColorLeft;
			borderObjFront.GetComponent<Renderer>().material.color = borderColorFront;
			borderObjRight.GetComponent<Renderer>().material.color = borderColorRight;
		}
	}

	// TrackerPos, borderPos, borderPos+buffer, colorIntesity 0, colorIntesity 1 
	float MapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
	{
		return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
	}

	void OnDrawGizmos() //just for Scene debugging
	{
		Gizmos.color = borderColorLeft;
		Gizmos.DrawLine(transform.position, leftBorder);
		Gizmos.color = borderColorFront;
		Gizmos.DrawLine(transform.position, frontBorder);
		Gizmos.color = borderColorRight;
		Gizmos.DrawLine(transform.position, rightBorder);

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine((new Vector3(leftBorderStart, 0, 10)), (new Vector3(leftBorderStart, 0, -10)));
		Gizmos.DrawLine((new Vector3(rightBorderStart, 0, 10)), (new Vector3(rightBorderStart, 0, -10)));
		Gizmos.DrawLine((new Vector3(10, 0, frontBorderStart)), (new Vector3(-10, 0, frontBorderStart)));

		Gizmos.color = Color.red;
		Gizmos.DrawLine((new Vector3(leftBorder.x, 0, 10)), (new Vector3(leftBorder.x, 0, -10)));
		Gizmos.DrawLine((new Vector3(rightBorder.x, 0, 10)), (new Vector3(rightBorder.x, 0, -10)));
		Gizmos.DrawLine((new Vector3(10, 0, frontBorder.z)), (new Vector3(-10, 0, frontBorder.z)));
	}
	#endregion
}

