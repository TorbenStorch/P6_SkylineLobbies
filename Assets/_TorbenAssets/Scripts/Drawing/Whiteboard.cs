/*-------------------------------------------------------
Creator: Torben Storch
Expanded Realities P6
last change: 25-06-2022
Topic: Script to setup the whiteboard
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
	public Texture2D texture;
	public Vector2 textureSize = new Vector2(2048, 2048);

	private void Start()
	{
		var r = GetComponent<Renderer>();
		texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
		r.material.mainTexture = texture;
	}
}
