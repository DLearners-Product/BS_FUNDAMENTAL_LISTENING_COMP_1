using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class readandanswer : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public GameObject G_selected, G_finalscreen;
    public int count;
    public AudioSource AS_correct,AS_Wrong;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        G_finalscreen.SetActive(false);
        for(int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[count].SetActive(true);
        GA_Questions[count].transform.GetChild(0).gameObject.SetActive(false);
    }

    public void BUT_clicking()
    {
        G_selected = EventSystem.current.currentSelectedGameObject;
        if(G_selected.tag=="answer")
        {
            AS_correct.Play();
            G_selected.SetActive(false);
            GA_Questions[count].transform.GetChild(0).gameObject.SetActive(true);
            Invoke("ChangeQuestion", 2f);
        }
        else
        {
            AS_Wrong.Play();
        }
    }
    public void ChangeQuestion()
    {
        count ++;
        if(count<GA_Questions.Length)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[count].SetActive(true);
            GA_Questions[count].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            G_finalscreen.SetActive(true);
        }
       
       
    }
}
