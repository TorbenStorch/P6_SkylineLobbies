using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class MenuManager : MonoBehaviour
{
	public TMP_InputField createInput;
	public TMP_InputField joinInput;

	public TMP_Text connectButton;
	public GameObject[] activateButtons;

	
	private void Start()
	{
		foreach (var item in activateButtons)
		{
			item.SetActive(false);
		}
		FindObjectOfType<MyNetworkManager>().connectedToLobbyEvent += ConnectedToServerAndLobby; //connect to the event (listener)
	}
	public void ConnectToServer()
	{
		connectButton.text = "connecting...";
		MyNetworkManager.Instance.StartConnectServer();
	}
	void ConnectedToServerAndLobby()
	{
		connectButton.text = "Connected!";
		foreach (var item in activateButtons)
		{
			item.SetActive(true);
		}
	}

	public void JoinOrCreateRandomRoom()
	{
		MyNetworkManager.Instance.JoinOrCreateRandomRoom();
	}
	public void CreateSpecificRoom()
	{
		if (createInput != null)
		{
			MyNetworkManager.Instance.CreateSpecificRoom(createInput.text);
		}
	}
	public void JoinSpecificRoom()
	{
		if (joinInput != null)
		{
			MyNetworkManager.Instance.JoinSpecificRoom(joinInput.text);
		}
	}
	






	public void ExitGame()
	{
		Application.Quit();
	}
}
