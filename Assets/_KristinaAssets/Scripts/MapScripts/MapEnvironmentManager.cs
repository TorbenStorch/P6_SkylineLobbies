using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnvironmentManager : MonoBehaviour
{
    [SerializeField] private GameObject doorToMove;

    public float speed = 3f;
    public float height = -24f;


    public void MoveDoorDown()
    {

        StartCoroutine(AnimateMove(doorToMove,doorToMove.transform.position, doorToMove.transform.position-new Vector3(0,height,0),speed));

    }

    IEnumerator AnimateMove(GameObject gameObject,Vector3 origin, Vector3 target, float duration)
    {
        float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

            gameObject.transform.position = Vector3.Lerp(origin, target, percent);

            yield return null;
        }
    }
}
