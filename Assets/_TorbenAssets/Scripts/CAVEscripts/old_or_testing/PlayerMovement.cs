using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
	public float rotationSpeed = 5.0f;
	public float verticalSpeed = 0.1f;
	public float runSpeed = 4.5f;

	[SerializeField] PhotonView photonView;
	[SerializeField] Camera camera;

	Animator animator;


	private void Start()
	{
		if (animator != null) animator = GetComponent<Animator>();

		//rb = GetComponent<Rigidbody>();
		//
		if (PhotonNetwork.InRoom && !photonView.IsMine)
		{
			if (camera != null) camera.enabled = false;
		}
	}
	void Update()
	{
		// check if in room and if this is on my side (local) or on the other side (remote)
		// allow control only if on it's my view
		if (PhotonNetwork.InRoom && !photonView.IsMine)
		{
			return;
		}

		float z = Input.GetAxis("Vertical");

		float h = rotationSpeed * Input.GetAxis("Mouse X");

		z = z * Time.deltaTime * runSpeed;
		transform.Rotate(0, h, 0);


		transform.Translate(0, 0, z); // transform the z-postion controlled by keyboard
									  //Debug.Log(z);
		if (animator != null) animator.SetFloat("isMoving", z);
	}
}

