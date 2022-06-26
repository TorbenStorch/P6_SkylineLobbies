using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    
    public float speed = 5f;
    
    public float height = 0.5f;


    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 localPos = transform.localPosition;
        
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        
        //set the object's Y to the new calculated Y
        transform.localPosition = new Vector3(localPos.x, newY, localPos.z) * height;
    }



}
