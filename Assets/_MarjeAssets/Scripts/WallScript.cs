using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public GameObject Bubble;
    public GameObject Bubble2;
    public GameObject Bubble3;
    public GameObject Ball;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Paper1;
    public GameObject Paper2;
    public GameObject Paper3;
    public float bubblePosition = -0.5f;

    //vectors for the Bubbles to respawn to
    //Blubble2
    private float BubbleX = 0.307f;
    private float Bubble123Y = 1.114f; //the same for all 3
    private float BubbleZ = -0.84f;
    //Blubble2
    private float Bubble23X = -0.08f; //the same for 2 and 3
    private float Bubble2Z = -0.5f;
    //Blubble3
    private float Bubble3Z = -0.84f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("WallCollision");
            Ball.SetActive(false);
            //Ball2.SetActive(false);
            //Ball3.SetActive(false);

            
            
            Bubble.SetActive(true);
            Bubble.transform.position = Ball.transform.position + /*Vector3.forward*/ new Vector3(0,0,bubblePosition);
            Debug.Log("Bubbleactive"); //inactive part when outside doesn't work yet (and also doesn't make sense since its reversed)

            Paper1.transform.position = Ball.transform.position + /*Vector3.forward*/ new Vector3(0, 0, bubblePosition);
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



                Bubble2.SetActive(true);
                Bubble2.transform.position = Ball2.transform.position + /*Vector3.forward*/ new Vector3(0, 0, bubblePosition);
                Debug.Log("Bubbleactive");

                Paper2.transform.position = Ball2.transform.position + /*Vector3.forward*/ new Vector3(0, 0, bubblePosition);
        }

        if (collision.gameObject.tag == "Ball3")
        {
            Debug.Log("WallCollision");
            //Ball.SetActive(false);
            Ball3.SetActive(false);
            //Ball3.SetActive(false);



            Bubble3.SetActive(true);
            Bubble3.transform.position = Ball3.transform.position + /*Vector3.forward*/ new Vector3(0, 0, bubblePosition);
            Debug.Log("Bubbleactive");

            //Paper.SetActive(true);
            Paper3.transform.position = Ball3.transform.position + /*Vector3.forward*/ new Vector3(0, 0, bubblePosition);
        }

        //------------------------------------------------------------------------
        //other balls


    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            
            Bubble.SetActive(false);
            Debug.Log("Bubbleinactive"); //inactive part when outside doesn't work yet (and also doesn't make sense since its reversed)
            Paper1.SetActive(false);
            Ball.SetActive(true);
            Ball.transform.position = new Vector3(BubbleX, Bubble123Y, BubbleZ); //just set it far away from collider (mebi back to table)
            Ball.transform.rotation = Quaternion.identity; //to reset the rotation too cause it was weird b4
            //maybe freeze rotation until collision with hand (since the balls sometimes roll away again after respawning)
            
        }

        if (collision.gameObject.tag == "Bubble2")
        {
            Bubble2.SetActive(false);
            Paper2.SetActive(false);
            Ball2.SetActive(true);
            Ball2.transform.position = new Vector3(Bubble23X, Bubble123Y, Bubble2Z);
            Ball2.transform.rotation = Quaternion.identity;

        }

        if (collision.gameObject.tag == "Bubble3")
        {
            Bubble3.SetActive(false);
            Paper3.SetActive(false);
            Ball3.SetActive(true);
            Ball3.transform.position = new Vector3(Bubble23X, Bubble123Y, Bubble3Z);
            Ball3.transform.rotation = Quaternion.identity;

            
        }
    }
}
