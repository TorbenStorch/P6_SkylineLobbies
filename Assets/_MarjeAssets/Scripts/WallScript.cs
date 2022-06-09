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
    public float bubblePosition = -0.5f;
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
            Ball.SetActive(true);
            Ball.transform.position = /*Bubble.transform.position +  Vector3.back*/ new Vector3(0.307f, 1.114f, -0.84f); //just set it far away from collider (mebi back to table)
            Ball.transform.rotation = Quaternion.identity; //to reset the rotation too cause it was weird b4
            //maybe freeze rotation until collision with hand (since the balls sometimes roll away again after respawning)
            
        }

        if (collision.gameObject.tag == "Bubble2")
        {
            Bubble2.SetActive(false);
            Ball2.SetActive(true);
            Ball2.transform.position = new Vector3(-0.08f, 1.114f, -0.5f);
            Ball2.transform.rotation = Quaternion.identity;

        }

        if (collision.gameObject.tag == "Bubble3")
        {
            Bubble3.SetActive(false);
            Ball3.SetActive(true);
            Ball3.transform.position = new Vector3(-0.08f, 1.114f, -0.84f);
            Ball3.transform.rotation = Quaternion.identity;
        }
    }
}
