using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followdirectionsaudio : MonoBehaviour
{
    public AudioSource AS_empty;
    public AudioClip AC_clip;
   
    void Start()
    {
        AS_empty.clip = AC_clip;
    }

    public void PlayAudio()
    {
        AS_empty.Play();
    }

   
}
