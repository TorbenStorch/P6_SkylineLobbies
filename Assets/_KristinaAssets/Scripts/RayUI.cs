/*-------------------------------------------------------
Creator: Kristina Koseva
Expanded Realities P6
last change: 17-07-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class RayUI : MonoBehaviour
{

   // [SerializeField]
   // private PhotonView photonView;


    //private Vector3 _initialPosition;

    [SerializeField]
    private Camera camTable;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) /*&& photonView.IsMine*/)
        {

            Ray ray = camTable.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //instead of infinity, can limit to 10f etc.
            {
                GameObject hitGameObject = hit.collider.gameObject;
                Button hitButton = hitGameObject.GetComponent<Button>();

                if (hitButton != null)
                {
                    Debug.Log("button is hit");
                    //call the event of the hit button
                    hitButton.onClick.Invoke();
                }
                else
                {
                    print("warning! returned gameobject did not have a collider component");
                }

            }
            else
            {
                print("ray returned no results");
            }

        }


        /*
        if (Input.GetMouseButton(0))
        {

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);

            //check if current pos is on the left or on the right of the initial pos   
            if (transform.localPosition.x - _initialPosition.x > 0) //if right from center
            {
                transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30,
                    (_initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));
            }
            else  //if left from center
            {
                transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30,
                        (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));

            }

        }
        */

    }





}















   

