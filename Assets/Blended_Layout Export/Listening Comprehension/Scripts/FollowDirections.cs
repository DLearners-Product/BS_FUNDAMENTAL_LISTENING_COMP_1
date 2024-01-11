using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FollowDirections : MonoBehaviour
{ /// Start is called before the first frame update
    public AudioSource AS_empty;
    public AudioClip[] AC_clips;
    public int Q_count;
 //   public TextMeshProUGUI TXT_Max, TXT_Current;
    public Button nextButton;
    public Button backButton;
    public GameObject ActivityCompleted;
    public GameObject activityButton;
    public GameObject[] dots;
    private int currentDotIndex = 0; // Keep track of the current active dot


    void Start()
    {
        Q_count = 0;
        AS_empty.clip = AC_clips[Q_count];
        backButton.gameObject.SetActive(false);
         SetDotActive(currentDotIndex);
     //   TXT_Max.text = AC_clips.Length.ToString();
        int i = Q_count + 1;
       // TXT_Current.text = i.ToString();

    }

    // Update is called once per frame
    public void But_Nextbutton()
    {
         SetDotActive(currentDotIndex, false);
    
    // Increment the index, and ensure it stays within bounds
    currentDotIndex++;
    if (currentDotIndex >= dots.Length)
    {
        currentDotIndex = 0; // Wrap around to the first dot if needed
    }
    
    // Activate the next dot
    SetDotActive(currentDotIndex);
        Q_count++;
        if (Q_count < AC_clips.Length)
        {
            AS_empty.Stop();
            AS_empty.clip = AC_clips[Q_count];
            int i = Q_count + 1;
       //     TXT_Current.text = i.ToString();
            BUT_Enabler();
        }

    }

    public void But_Backbutton()
    {
         // Deactivate the current dot
    SetDotActive(currentDotIndex, false);
    
    // Decrement the index, and ensure it stays within bounds
    currentDotIndex--;
    if (currentDotIndex < 0)
    {
        currentDotIndex = dots.Length - 1; // Wrap around to the last dot if needed
    }
    
    // Activate the previous dot
    SetDotActive(currentDotIndex);
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
    private void SetDotActive(int index, bool isActive = true)
{
    if (index >= 0 && index < dots.Length)
    {
        dots[index].SetActive(isActive);
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
           
        }
        if (Q_count == 6)
        {
           
            nextButton.gameObject.SetActive(false);
           
        }
        else if (Q_count == AC_clips.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
             activityButton.SetActive(true);
        }
        else
        {
            // backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
             activityButton.SetActive(false);

        }
    }

    public void activityCompleted()
    {
        AS_empty.Stop();
        ActivityCompleted.SetActive(true);
    }
}
