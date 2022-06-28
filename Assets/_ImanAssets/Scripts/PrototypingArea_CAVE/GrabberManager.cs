/*-------------------------------------------------------
Creator: YouTube channel: https://www.youtube.com/watch?v=uNCCS6DjebA
Modified and adjusted by Iman Nikkhahazad
Expanded Realities P6
last change: 28-06-2022
Topic: Script for grabbing the gameobjects - Prototyping area - CAVE side
---------------------------------------------------------*/


using UnityEngine;
using Photon.Pun;

public class GrabberManager : MonoBehaviour
{
    GameObject interactable;
    GameObject player;
    
    private GameObject selectedObject;
    public PhotonView photonView;

    private bool firstHit;

    void Awake()
    {
        interactable = GameObject.FindGameObjectWithTag("Interactable");
    }

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Interactable"))
                    {
                        return;
                    }
                    else
                    {
                        if (firstHit == true)
                        {
                            selectedObject = hit.collider.gameObject;
                            Debug.Log("Second hit");
                            Cursor.visible = false;
                            if (Input.GetKeyDown(KeyCode.Space))
                            {
                                Debug.Log("set childeren");
                            }
                        }
                        else
                        {
                            selectedObject = hit.collider.gameObject;
                            firstHit = true;
                            SetParent(interactable);
                            Debug.Log("First hit");
                            Cursor.visible = false;
                        }
                    }
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 45f,
                    selectedObject.transform.rotation.eulerAngles.z));
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    //Invoked when a button is pressed.
    public void SetParent(GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        player.transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Player's Parent: " + player.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + player.transform.parent.parent.name);
        }
    }
}
