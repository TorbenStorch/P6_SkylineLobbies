using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSetup : MonoBehaviour //currently only for one tracker - needs more later on
{
	//Position
	Vector3 centerPosition;
	Vector3 leftBorder, frontBorder, rightBorder, bufferBorder;
	int state = 0;
	public int secondsToWaitForCalibration;
	bool guardianSet;
	//float guardianShowStartProcentage = 0.7f; //needs change maybe - depending on number the distanbce can be bigger/smaller tzhen the other borderstartpoints
	float bufferBorderDifference;
	float frontBorderStart, leftBorderStart, rightBorderStart;
	bool buttonPressedFlag = false;





	//Color
	Color near = new Color(1, 0, 0, 1);
	Color far = new Color(0, 0, 0, 0);
	//float maxDistance = 99900;
	Color borderColorLeft, borderColorFront, borderColorRight;
	public GameObject borderObjLeft, borderObjFront, borderObjRight;

	private void Start()
	{
		defaultBorders();
	}
	private void Update()
	{
		setGuardian();
		//setColor();
		if (guardianSet)
		{
			bufferBorderDifference = rightBorder.x - bufferBorder.x;

			frontBorderStart = frontBorder.z - bufferBorderDifference;
			leftBorderStart = leftBorder.x + bufferBorderDifference;
			rightBorderStart = rightBorder.x - bufferBorderDifference;
		}
		calculateAlpha();
		setColorForBorder();
	}

	void defaultBorders()
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

	#region SetGuardian
	void setGuardian()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !guardianSet && !buttonPressedFlag)
		{
			buttonPressedFlag = true;
			StartCoroutine(setPostitons(state));
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
			defaultBorders();
		}
	}
	IEnumerator setPostitons(int currentState)
	{
		yield return new WaitForSeconds(secondsToWaitForCalibration);
		buttonPressedFlag = false;
		switch (currentState)
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
				break;


			default:
				break;
		}
		state += 1;
	}
	#endregion


	#region CheckDistance
	//void setColor()
	//{
	//	maxDistance = ((Vector3.Distance(centerPosition, frontBorder) + Vector3.Distance(centerPosition, leftBorder) + Vector3.Distance(centerPosition, rightBorder)) / 3) * 100;
	//	calculateColor(leftBorder);
	//	calculateColor(frontBorder);
	//	calculateColor(rightBorder);
	//
	//
	//}
	//void calculateColor(Vector3 objectForDistance)
	//{
	//	float distanceApart = getSqrDistance(transform.position, objectForDistance);
	//	//Debug.Log(getSqrDistance(transform.position, objectForDistance));
	//	float lerp = mapValue(distanceApart, 0, maxDistance, 0f, 1f);
	//	Color lerpColor = Color.Lerp(near, far, lerp);
	//	if (objectForDistance == leftBorder)
	//	{
	//		borderColorLeft = lerpColor;
	//		if (lerpColor.r != 0)
	//		{
	//			//Debug.LogWarning("CLOSE LEFT");
	//		}
	//	}
	//	else if (objectForDistance == frontBorder)
	//	{
	//		borderColorFront = lerpColor;
	//	}
	//	else if (objectForDistance == rightBorder)
	//	{
	//		borderColorRight = lerpColor;
	//	}
	//	//borderColorRight = objectForDistance == rightBorder ? lerpColor : Color.red;
	//	Debug.Log(lerpColor);
	//
	//	//GetComponent<Renderer>().material.color = lerpColor;
	//}
	//public float getSqrDistance(Vector3 v1, Vector3 v2)
	//{
	//	return (v1 - v2).sqrMagnitude;
	//}

	void calculateAlpha()
	{
		if (transform.position.x <= leftBorderStart)
		{
			float lerp = mapValue(transform.position.x, leftBorder.x, leftBorderStart, 0f, 1f);
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
			float lerp = mapValue(transform.position.x, rightBorder.x, rightBorderStart, 0f, 1f);
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
			float lerp = mapValue(transform.position.z, frontBorder.z, frontBorderStart, 0f, 1f);
			Color lerpColor = Color.Lerp(near, far, lerp);
			Debug.LogWarning("FRONT");
			borderColorFront = lerpColor;
		}
		else
		{
			borderColorFront = far;
		}
	}

	void setColorForBorder()
	{
		if (guardianSet)
		{
			borderObjLeft.GetComponent<Renderer>().material.color = borderColorLeft;
			borderObjFront.GetComponent<Renderer>().material.color = borderColorFront;
			borderObjRight.GetComponent<Renderer>().material.color = borderColorRight;
		}
	}



	float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
	{
		return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
	}

	void OnDrawGizmos()
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
