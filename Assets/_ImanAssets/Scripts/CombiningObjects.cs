using UnityEngine;

public class CombiningObjects : MonoBehaviour
{
    private bool hascollided;

    public void OnTriggerEnter(Collider other)
    {
        if(hascollided)
        {
            return;
        }

        if(other.CompareTag("Interactable"))
        {
            Debug.Log("collision happened");
            hascollided = true;
        }
    }
}
