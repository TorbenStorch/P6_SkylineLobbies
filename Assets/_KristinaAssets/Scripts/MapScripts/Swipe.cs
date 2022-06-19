using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{

    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;

   


    public void OnDrag(Vector2 mousePos)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + mousePos.x, transform.localPosition.y);
        
        //check if current pos is on the left or on the right of the initial pos   
        if(transform.localPosition.x - _initialPosition.x > 0) //if right from center
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, 
                (_initialPosition.x + transform.localPosition.x)/(Screen.width/2))  );
        }
        else  //if left from center
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, 
                    (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
           
        }

    }




    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;

        
    }





    public void OnEndDrag(PointerEventData eventData)
    {

        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        

        if (_distanceMoved < 0.3 * Screen.width)
        {
            
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero; //if this line isnt here, the card rotation gets stuck if you leave it midway

        }
        else
        {
            if(transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
            }
            else
            {
                _swipeLeft = true;
            }

            StartCoroutine(MovedCard());
        }


    }


    private IEnumerator MovedCard()
    {
        float time = 0;

        while(GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            
            if (_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, 
                                          transform.localPosition.x - Screen.width, 2*time), transform.localPosition.y, 0);
            
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                                          transform.localPosition.x + Screen.width, 2 * time), transform.localPosition.y, 0);
            }

            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 2 * time));
            yield return null;

        }

        gameObject.SetActive(false); 
        

    }

  


}
