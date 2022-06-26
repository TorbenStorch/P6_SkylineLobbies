using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{


    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource rejectedSound; //usage example: when dragging the sticky note less than 2/3 of the screen and it snaps back to the middle

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void PlayRejectedSound()
    {
        rejectedSound.Play();
    }


}
