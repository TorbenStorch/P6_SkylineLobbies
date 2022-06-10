using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StickyNote : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Vector3 _initialPosition;
    private Vector3 _lastPosition;

    private float _distanceMoved;
    private bool _swipeLeft;

    [SerializeField]
    private GameObject StickyNotePanel;

    [SerializeField]
    private GameObject RightDisplayCanvas;
   


    public void OnDrag(PointerEventData eventData)
    {
     
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
     
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
            //transform.localEulerAngles = Vector3.zero; 
            //if this line isnt here, the card rotation gets stuck if you leave it midway

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

            MovedNote();
        }


    }


    private void MovedNote()
    {

        transform.SetParent(RightDisplayCanvas.transform);

        float canvasHeight = RightDisplayCanvas.GetComponent<RectTransform>().rect.height;
        float canvasWidth = RightDisplayCanvas.GetComponent<RectTransform>().rect.width;


        float stickyNoteHeight = this.gameObject.GetComponent<RectTransform>().rect.height;
        float stickyNoteWidth = this.gameObject.GetComponent<RectTransform>().rect.width;

        Vector2 randomCanvasPos = new Vector2(Random.Range(0 + stickyNoteWidth, canvasWidth - stickyNoteWidth), 
                                                Random.Range(0 + stickyNoteHeight, canvasHeight - stickyNoteHeight));

        Debug.LogWarning(transform.rotation + " transformed the rotation BEFORE");

        transform.localPosition = randomCanvasPos;


        transform.localRotation = RightDisplayCanvas.transform.rotation;

        Debug.LogWarning(transform.rotation + " transformed the rotation´AFTER ");




    }

  


}
