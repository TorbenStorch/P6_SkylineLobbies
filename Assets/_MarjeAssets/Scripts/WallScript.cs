/*-------------------------------------------------------
Creator: Marje-Alicia Harms
Expanded Realities P6
last change: 13-07-2022
Topic: Wall Collision Script
(When 3d Bubble enters -> turns into Bubble sprite; when exits -> respawns as 3D Bubble on Table)
---------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public GameObject InfoBubble1;
    public GameObject InfoBubble2;
    public GameObject InfoBubble3;
    public GameObject Ball;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Paper1;
    public GameObject Paper2;
    public GameObject Paper3;
    public GameObject BallBowl;
    public float PaperPosition = 0.2f;
    

    ////vectors for the Bubbles to respawn to
    ////Blubble2
    ////commented numbers were for my scene
    //private float BubbleX = /*0.307f*/ 0.6f;
    //private float Bubble123Y = /*1.114f*/0.718f; //the same for all 3
    //private float BubbleZ = /*-0.84f*/6.5f;
    ////Blubble2
    //private float Bubble2X = /*-0.08f*/0.9f; //the same for 2 and 3 in the test scene
    //private float Bubble2Z = /*-0.5f*/6.5f;
    ////Blubble3
    //private float Bubble3X = /*-0.08f*/1.2f;
    //private float Bubble3Z = /*-0.84f*/6.5f;
    //no more magic numbers :D

    private float InfoBubble1XPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        InfoBubble1XPosition = InfoBubble1.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        InfoBubble1.transform.position = new Vector3(InfoBubble1XPosition, InfoBubble1.transform.position.y, InfoBubble1.transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("WallCollision");
            Ball.SetActive(false);
            //Ball2.SetActive(false);
            //Ball3.SetActive(false);

            
            
            Paper1.SetActive(true);
            Paper1.transform.position = Ball.transform.position + /*Vector3.forward*/ new Vector3/*(0,0,bubblePosition)*/ (0, 0, PaperPosition);
            Debug.Log("Bubbleactive"); //inactive part when outside doesn't work yet (and also doesn't make sense since its reversed)

            InfoBubble1.transform.position = Ball.transform.position + /*Vector3.forward*/ new Vector3(0, 0, PaperPosition);
            //else
            //{
            //    //bubble coordinates == ball y&x coordinates
            //    Bubble.SetActive(false);
            //    Debug.Log("Bubbleactive");

            //}




            //Ball.transform.position = new Vector3(0, 2, 0);
        }



        // ------------------------------------------------------------------------
        //for the other balls


        if (collision.gameObject.tag == "Ball2")
            {
                Debug.Log("WallCollision");
                //Ball.SetActive(false);
                Ball2.SetActive(false);
                //Ball3.SetActive(false);



                Paper2.SetActive(true);
                Paper2.transform.position = Ball2.transform.position + /*Vector3.forward*/ new Vector3(0, 0, PaperPosition);
            Debug.Log("Bubbleactive");

            InfoBubble2.transform.position = Ball2.transform.position + /*Vector3.forward*/ new Vector3(0, 0, PaperPosition);
        }

        if (collision.gameObject.tag == "Ball3")
        {
            Debug.Log("WallCollision");
            //Ball.SetActive(false);
            Ball3.SetActive(false);
            //Ball3.SetActive(false);



            Paper3.SetActive(true);
            Paper3.transform.position = Ball3.transform.position + /*Vector3.forward*/ new Vector3(0, 0, PaperPosition); 
            Debug.Log("Bubbleactive");

            //Paper.SetActive(true);
            InfoBubble3.transform.position = Ball3.transform.position + /*Vector3.forward*/ new Vector3(0, 0, PaperPosition);
        }

        


    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {

            Paper1.SetActive(false);
            Debug.Log("Bubbleinactive"); //inactive part when outside doesn't work yet (and also doesn't make sense since its reversed)
            InfoBubble1.SetActive(false);
            Ball.SetActive(true);
            //Ball.transform.position = new Vector3(BubbleX, Bubble123Y, BubbleZ); //just set it far away from collider (mebi back to table)
            Ball.transform.position = BallBowl.transform.position + new Vector3(0, 0.5f, 0); //0.2 because height has to be different if they all respawn at once
            Ball.transform.rotation = Quaternion.identity; //to reset the rotation too cause it was weird b4
            //maybe freeze rotation until collision with hand (since the balls sometimes roll away again after respawning)
            
        }

        if (collision.gameObject.tag == "Bubble2")
        {
            Paper2.SetActive(false);
            InfoBubble2.SetActive(false);
            Ball2.SetActive(true);
            //Ball2.transform.position = new Vector3(Bubble2X, Bubble123Y, Bubble2Z);
            Ball2.transform.position = BallBowl.transform.position + new Vector3(0, 1f, 0);
            Ball2.transform.rotation = Quaternion.identity;

        }

        if (collision.gameObject.tag == "Bubble3")
        {
            Paper3.SetActive(false);
            InfoBubble3.SetActive(false);
            Ball3.SetActive(true);
            //Ball3.transform.position = new Vector3(Bubble3X, Bubble123Y, Bubble3Z);
            Ball3.transform.position = BallBowl.transform.position + new Vector3(0, 1.5f, 0);
            Ball3.transform.rotation = Quaternion.identity;

            
        }
    }
}
