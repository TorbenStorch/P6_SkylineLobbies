using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBubbles : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Ball2;
    public GameObject Ball3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetBubbles()
    {
        Ball.transform.position = new Vector3(0.307f, 1.114f, -0.84f);
        Ball.transform.rotation = Quaternion.identity;
        Ball2.transform.position = new Vector3(-0.08f, 1.114f, -0.5f);
        Ball2.transform.rotation = Quaternion.identity;
        Ball3.transform.position = new Vector3(-0.276f, 1.114f, 0.043f);
        Ball3.transform.rotation = Quaternion.identity;
    }
}
