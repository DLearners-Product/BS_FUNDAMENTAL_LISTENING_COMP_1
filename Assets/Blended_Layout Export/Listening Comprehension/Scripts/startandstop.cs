using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startandstop : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AS_empty;
    public AudioClip[] AC_clips;
    public int Q_count;
    public Sprite[] SA_Images;
    public GameObject Empty;
    void Start()
    {
        Q_count=0;
        AS_empty.clip = AC_clips[Q_count];
    }

    // Update is called once per frame
    public void But_Nextbutton()
    {
        if(Q_count<AC_clips.Length)
        {
            AS_empty.Stop();
            Q_count++;
            Empty.GetComponent<Image>().sprite = null;
            AS_empty.clip = AC_clips[Q_count];
        }
      
    }
    public void BUT_showimage()
    {
      Empty.GetComponent<Image>().sprite=SA_Images[Q_count];
        Empty.GetComponent<Image>().preserveAspect = true;
    }
    public void But_speaker()
    {
        AS_empty.Play();
    }
}
