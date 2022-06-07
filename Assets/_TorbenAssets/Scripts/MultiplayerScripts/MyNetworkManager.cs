//Torben Storch - Photon Network script (connect to server, join room(specific & random))
//////////////////////////////////////////////////////////////////////////////////////


//using System.Collections;
using System;
//using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
//using UnityEngine.SceneManagement;


public sealed class MyNetworkManager : MonoBehaviourPunCallbacks
{
	public enum avaliableScenes //add the scene names
	{
		SelectDeviceScene, MainMenu, MultiplayerRoom
	}
	public avaliableScenes sceneToLoadWhenJoinedRoom;
	public event Action connectedToLobbyEvent; //event that gets called when we joined the lobby

	#region Singleton

	public static MyNetworkManager Instance { set; get; }

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(Instance);
		}
		else
			Destroy(this.gameObject);
	}
	#endregion

	#region Connect to Server and join Lobby
	//void Start()
	//   {
	//       Debug.Log("Try to Connect to Server");
	//       PhotonNetwork.ConnectUsingSettings(); //Connect to server
	//   }

	public void StartConnectServer() //Connect to server (own function that is called by the MenuManager)
	{
		Debug.Log("Try to Connect to Server");
		PhotonNetwork.ConnectUsingSettings();
	}
	public override void OnConnectedToMaster() //when we are connected to the server
	{
		Debug.Log("Connected to Server");
		PhotonNetwork.JoinLobby(); //join the lobby of server
	}
	public override void OnJoinedLobby()//when we joined the lobby (first connect to server -> then connect to lobby -> then for ex. create/join a room)
	{
		Debug.Log("Ready to join Multiplayer");
		if (connectedToLobbyEvent != null)
		{
			connectedToLobbyEvent();
		}
	}
	#endregion

	#region Create and Join random room
	public void JoinOrCreateRandomRoom()
	{
		Debug.Log("Looking for existing room");
		PhotonNetwork.JoinRandomRoom();
	}
	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		CreateRandomRoom(); //if we could not join a random room (none existant - create one)
	}

	private void CreateRandomRoom()
	{
		int randomRoomName = UnityEngine.Random.Range(0, 9999);
		RoomOptions roomOptions = new RoomOptions()
		{
			IsVisible = true,
			IsOpen = true,
			MaxPlayers = 5,
			PublishUserId = true
		};

		PhotonNetwork.CreateRoom("NewRandomRoom" + randomRoomName, roomOptions);
		Debug.Log("Random Room: 'NewRandomRoom" + randomRoomName + "' was created");
	}
	#endregion

	#region Create and Join specific room
	public void CreateSpecificRoom(string roomName)
	{
		RoomOptions roomOptions = new RoomOptions()
		{
			IsVisible = true,
			IsOpen = true,
			MaxPlayers = 5,
			PublishUserId = true
		};
		Debug.Log("Room: '" + roomName + "' was created");
		PhotonNetwork.CreateRoom(roomName, roomOptions);
	}
	public void JoinSpecificRoom(string roomName)
	{
		PhotonNetwork.JoinRoom(roomName);

	}
	#endregion

	public override void OnJoinedRoom()
	{
		Debug.Log("Room Joined");
		PhotonNetwork.LoadLevel(sceneToLoadWhenJoinedRoom.ToString());
	}
}
