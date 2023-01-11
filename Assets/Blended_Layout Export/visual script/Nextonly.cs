using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextonly : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public AudioClip[] AC_crtsong,AC_wrgsong;
    public AudioSource AS_crt,AS_wrg;
    int count;
    public GameObject G_finalscreen;
    // Start is called before the first frame update
    void Start()
    {
        G_finalscreen.SetActive(false);
        count = 0;
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[count].SetActive(true);
        AS_crt.clip = null;
        AS_wrg.clip = null;
    }
    public void BUT_crtaudio()
    {
        AS_wrg.Stop();
        AS_crt.clip = AC_crtsong[count];
        AS_crt.Play();
    }
    public void BUT_wrgaudio()
    {
        AS_crt.Stop();
        AS_wrg.clip = AC_wrgsong[count];
        AS_wrg.Play();
    }
    public void BUT_stop()
    {
        AS_crt.Stop();
        AS_wrg.Stop();
    }
    // Update is called once per frame
    public void BUT_next()
    {
        //this.GetComponent<Draw>().BUT_erase();
        AS_crt.Stop();
        AS_wrg.Stop();
        if (count < GA_Questions.Length - 1)
        {
            count++;
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[count].SetActive(true);
        }
        else
        {
            G_finalscreen.SetActive(true);
        }
    }

}
