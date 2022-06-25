/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 25-06-2022
Topic: Script to drawn on the whiteboard
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Photon.Pun;


public class WhiteboardMarker : MonoBehaviour
{
	[SerializeField] private Transform tip;
	[SerializeField] private int penSize = 5;

	private Renderer markerTipRenderer;
	private Color[] colors;
	private float tipHeight;
	private RaycastHit touch;
	private Whiteboard whiteboard;
	private Vector2 touchPos;
	private Vector2 lastTouchPos;
	private bool touchedLastFrame;
	private Quaternion lastTouchRotation;

	[SerializeField] PhotonView photonView;


	private void Start()
	{
		markerTipRenderer = tip.GetComponent<Renderer>();
		colors = Enumerable.Repeat(markerTipRenderer.material.color, penSize * penSize).ToArray();
		tipHeight = tip.localScale.y;
	}
	private void Update()
	{
		//Draw();

		photonView.RPC("Draw", RpcTarget.All);
	}

	[PunRPC]private void Draw()
	{
		if (Physics.Raycast(tip.position, transform.up, out touch, tipHeight))
		{
			if (touch.transform.CompareTag("Whiteboard"))
			{
				if (whiteboard == null)
				{
					whiteboard = touch.transform.GetComponent<Whiteboard>();
				}

				touchPos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

				//converting touch pos to specific x&y pixels on whiteboard texture
				var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
				var y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize / 2));

				//if pixels outside of texture (not on whiteborad) -> exit
				if (y < 0 + (penSize) || y > whiteboard.textureSize.y - (penSize) || x < 0 + (penSize) || x > whiteboard.textureSize.x - (penSize))
				{
					return;
				}

				if (touchedLastFrame) //if touchedLastFrame = color the pixels (we only color at the 2nd frame, never the first)
				{
					whiteboard.texture.SetPixels(x, y, penSize, penSize, colors); //original point where we touched (group of pixels)

					for (float f = 0.01f; f < 1.00f; f += 0.01f/*The higher this number, more space inbetween stroke points*/) //loop through 1 in 100 to fill in space/interpoate between last point we touched & current point we touched
					{
						var lerpX = (int)Mathf.Lerp(lastTouchPos.x, x, f);
						var lerpY = (int)Mathf.Lerp(lastTouchPos.y, y, f);
						whiteboard.texture.SetPixels(lerpX, lerpY, penSize, penSize, colors); //set group of pixels to it
					}

					transform.rotation = lastTouchRotation; //lock rotation so that pen does not rotate with physics (prevents flat to the wall)

					whiteboard.texture.Apply();//apply the coloration of pixels to the texture
				}

				//set everything for the next frame
				lastTouchPos = new Vector2(x, y);
				lastTouchRotation = transform.rotation;
				touchedLastFrame = true;
				return;
			}
		}

		//if raycast wasnt hit, reset
		whiteboard = null;
		touchedLastFrame = false;
	}
}
