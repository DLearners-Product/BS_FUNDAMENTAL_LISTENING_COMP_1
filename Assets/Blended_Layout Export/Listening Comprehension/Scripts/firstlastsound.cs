using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class firstlastsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AS_empty;
    public AudioClip[] AC_clips;
    public int Q_count;
  //  public TextMeshProUGUI TXT_Max, TXT_Current;
    public Button nextButton;
    public Button backButton;
    public GameObject ActivityCompleted;

    void Start()
    {
        Q_count=0;
        AS_empty.clip = AC_clips[Q_count];
        backButton.gameObject.SetActive(false);
     //   TXT_Max.text = AC_clips.Length.ToString();
        int i = Q_count + 1;
     //   TXT_Current.text = i.ToString();

    }

    // Update is called once per frame
    public void But_Nextbutton()
    {
        Q_count++;
        if (Q_count<AC_clips.Length)
        {
            AS_empty.Stop();
            AS_empty.clip = AC_clips[Q_count];
            int i = Q_count + 1;
         //   TXT_Current.text = i.ToString();
            BUT_Enabler();
        }
      
    }

    public void But_Backbutton()
    {
        Q_count--;
        if (Q_count >= 0)
        {
            AS_empty.Stop();
            //Empty.GetComponent<Image>().sprite = null;
            AS_empty.clip = AC_clips[Q_count];
            int i = Q_count + 1;
         //   TXT_Current.text = i.ToString();
            BUT_Enabler();
        }
    }
    public void But_speaker()
    {
        AS_empty.Play();
    }


   // Button Enabler for back and next button
    public void BUT_Enabler()
    {
        if (Q_count == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        if (Q_count == 1)
        {
            backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
        else if (Q_count == AC_clips.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
           // backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
          
        }
    }

    public void activityCompleted()
    {
        AS_empty.Stop();
        ActivityCompleted.SetActive(true);
    }
}
