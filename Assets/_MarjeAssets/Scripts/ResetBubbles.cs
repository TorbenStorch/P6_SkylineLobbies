/*-------------------------------------------------------
Creator: Marje-Alicia Harms
Expanded Realities P6
last change: 13-07-2022
Topic: Script for Bubble (the 3d ones) reset I put on the button next to the wall
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBubbles : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Ball2;
    public GameObject Ball3;

    //vectors for the Bubbles to respawn to
    //Blubble2
    //commented numbers were for my scene
    private float BubbleX = /*0.307f*/ -2.67593f;
    private float Bubble123Y = /*1.114f*/0.718f; //the same for all 3
    private float BubbleZ = /*-0.84f*/0.8809423f;
    //Blubble2
    private float Bubble2X = /*-0.08f*/-2.33593f; //the same for 2 and 3 in the test scene
    private float Bubble2Z = /*-0.5f*/1.267943f;
    //Blubble3
    private float Bubble3X = /*-0.08f*/-2.67593f;
    private float Bubble3Z = /*-0.84f*/1.267943f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBubbles()
    {
        Ball.transform.position = new Vector3(BubbleX, Bubble123Y, BubbleZ);
        Ball.transform.rotation = Quaternion.identity;
        Ball2.transform.position = new Vector3(Bubble2X, Bubble123Y, Bubble2Z);
        Ball2.transform.rotation = Quaternion.identity;
        Ball3.transform.position = new Vector3(Bubble3X, Bubble123Y, Bubble3Z);
        Ball3.transform.rotation = Quaternion.identity;
    }
}
