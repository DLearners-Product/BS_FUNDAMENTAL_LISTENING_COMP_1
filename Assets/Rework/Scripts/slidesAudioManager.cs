using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slidesAudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
   


    public void PlayVO(AudioClip clip)
    {
        Debug.Log("AudioPlayed");
        source.clip = clip;
        source.Play();
     
    }

}
