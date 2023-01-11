using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstlastsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AS_empty;
    public AudioClip[] AC_clips;
    public int Q_count;

    void Start()
    {
        Q_count=0;
        AS_empty.clip = AC_clips[Q_count];
       // AS_empty.Play();
    }

    // Update is called once per frame
    public void But_Nextbutton()
    {
        if(Q_count<AC_clips.Length)
        {
            Q_count++;
            AS_empty.clip = AC_clips[Q_count];
           // AS_empty.Play();
        }
      
    }
    public void But_speaker()
    {
        AS_empty.Play();
    }
}
