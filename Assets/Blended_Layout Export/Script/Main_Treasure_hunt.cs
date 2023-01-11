using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_Treasure_hunt : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public GameObject G_Selectedobj;
   // public GameObject G_blur_Screen;
    public GameObject G_Final_Screen;
    public Text score;
    public int count,Q_count;
    public AudioSource AS_Wrong,AS_correct;
    public Material Greyscale;

    void Start()
    {
        // G_blur_Screen.SetActive(false);
        
        Q_count = 0;
        for (int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[Q_count].SetActive(true);
        count = 0;
        score.text = "" + count;
        G_Final_Screen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BUT_Clicking()
    {
        
        G_Selectedobj = EventSystem.current.currentSelectedGameObject;
        if(G_Selectedobj.tag=="answer")
        {
            count++;
            score.text = "" + count;
            G_Selectedobj.GetComponent<Button>().enabled = false;
            G_Selectedobj.GetComponent<Image>().material = Greyscale;
            AS_correct.Play();
            if(count==5)
            {
                Invoke("THI_Bluron", AS_correct.clip.length);
            }
        }
        else
        {
            AS_Wrong.Play();
        }
    }
    public void THI_Bluron()
    {
        Q_count++;
        if (Q_count < 5)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[Q_count].SetActive(true);
            count = 0;
            score.text = "" + count;
        }
        else
        {
            G_Final_Screen.SetActive(true);
        }
    }
    
}
