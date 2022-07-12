/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 10-07-2022
Topic: Script for Cube-Shaped-CAVE-Guardian setup
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianSetup : MonoBehaviour //currently only for one tracker (maybe needs more later on)
{
	#region Data
	//Position
	Vector3 leftBorder, frontBorder, rightBorder, bufferBorder;
	int state = 1;
	[SerializeField] int secondsToWaitForCalibration;
	bool guardianSet;
	float bufferBorderDifference;
	float frontBorderStart, leftBorderStart, rightBorderStart;
	bool buttonPressedFlag = false;
	bool left, front, right;
	//Color
	Color near = new Color(1, 1, 1, 1);
	Color far = new Color(1, 1, 1, 0f);
	Color borderColorLeft, borderColorFront, borderColorRight;
	//public GameObject borderObjLeft, borderObjFront, borderObjRight; //change to canvas!
	public Image leftUp, leftDown, middleUp, middleDown, rightUp, rightDown;

	[Header("The first Item will be used to calibrate the guardian!")]
	[SerializeField] GameObject[] targets;
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
		leftBorder = new Vector3(-10, 0, 0);
		frontBorder = new Vector3(0, 0, 10);
		rightBorder = new Vector3(10, 0, 0);


		leftBorderStart = leftBorder.x;
		frontBorderStart = frontBorder.z;
		rightBorderStart = rightBorder.x;

		//borderObjLeft.GetComponent<Renderer>().material.color = far;
		//borderObjFront.GetComponent<Renderer>().material.color = far;
		//borderObjRight.GetComponent<Renderer>().material.color = far;

		leftUp.color = far;
		leftDown.color = far;
		middleUp.color = far;
		middleDown.color = far;
		rightUp.color = far;
		rightDown.color = far;


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
			state = 1;
			DefaultBorders();
		}
	}
	IEnumerator SetPostitons(int currentState)
	{
		yield return new WaitForSeconds(secondsToWaitForCalibration);
		buttonPressedFlag = false;
		switch (currentState) //set the center & border positions to the point where the tracker is after the delay
		{
			case 1:
				leftBorder = targets[0].transform.position;
				Debug.Log("l_Pos:" + leftBorder);
				break;
			case 2:
				frontBorder = targets[0].transform.position;
				Debug.Log("f_Pos:" + frontBorder);
				break;
			case 3:
				rightBorder = targets[0].transform.position;
				Debug.Log("r_Pos:" + rightBorder);
				break;
			case 4:
				bufferBorder = targets[0].transform.position;
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
		left = false;
		right = false;
		front = false;
		for (int i = 0; i < targets.Length; i++)
		{
			if (targets[i].transform.position.x <= leftBorderStart)
			{
				float lerp = MapValue(targets[i].transform.position.x, leftBorder.x, leftBorderStart, 0f, 1f);
				Color lerpColor = Color.Lerp(near, far, lerp);
				Debug.LogWarning("LEFT");
				left = true;
				borderColorLeft = lerpColor;
			}
			if (targets[i].transform.position.x >= rightBorderStart)
			{
				float lerp = MapValue(targets[i].transform.position.x, rightBorder.x, rightBorderStart, 0f, 1f);
				Color lerpColor = Color.Lerp(near, far, lerp);
				Debug.LogWarning("RIGHT");
				right = true;
				borderColorRight = lerpColor;
			}
			if (targets[i].transform.position.z >= frontBorderStart)
			{
				float lerp = MapValue(targets[i].transform.position.z, frontBorder.z, frontBorderStart, 0f, 1f);
				Color lerpColor = Color.Lerp(near, far, lerp);
				Debug.LogWarning("FRONT");
				front = true;
				borderColorFront = lerpColor;
			}
		}
		if (!left)
			borderColorLeft = far;
		if (!right)
			borderColorRight = far;
		if (!front)
			borderColorFront = far;
	}

	void SetColorForBorder()
	{
		if (guardianSet)
		{
			//borderObjLeft.GetComponent<Renderer>().material.color = borderColorLeft;
			//borderObjFront.GetComponent<Renderer>().material.color = borderColorFront;
			//borderObjRight.GetComponent<Renderer>().material.color = borderColorRight;


			leftUp.color = borderColorLeft;
			leftDown.color = borderColorLeft;
			middleUp.color = borderColorFront;
			middleDown.color = borderColorFront;
			rightUp.color = borderColorRight;
			rightDown.color = borderColorRight;

		}
	}





	// TrackerPos, borderPos, borderPos+buffer, colorIntesity 0, colorIntesity 1 
	float MapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
	{
		return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
	}

	void OnDrawGizmos() //just for Scene debugging
	{
		//Gizmos.color = borderColorLeft;
		//Gizmos.DrawLine(transform.position, leftBorder);
		//Gizmos.color = borderColorFront;
		//Gizmos.DrawLine(transform.position, frontBorder);
		//Gizmos.color = borderColorRight;
		//Gizmos.DrawLine(transform.position, rightBorder);

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

