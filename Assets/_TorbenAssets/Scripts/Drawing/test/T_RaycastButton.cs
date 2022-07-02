using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class T_RaycastButton : MonoBehaviour
{
    public UnityEvent buttonClicked;

    public void OnButtonClick()
	{
		buttonClicked.Invoke();
		Debug.Log(this.gameObject.name + " was clicked!");
	}
}
