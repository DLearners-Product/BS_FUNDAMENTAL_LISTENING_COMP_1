using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Findthesameshape : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public GameObject G_selected, G_final;
    public AudioSource AS_correct, AS_wrong;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        G_final.SetActive(false);
        for (int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[count].SetActive(true);
        
    }

    public void BUT_clicking()
    {
        G_selected = EventSystem.current.currentSelectedGameObject;
        if(G_selected.tag=="answer")
        {
            AS_correct.Play();
            Invoke("THI_next", AS_correct.clip.length);
        }
        else
        {
            AS_wrong.Play();
        }
    }
    public void THI_next()
    {
        count++;
        if (count < 5)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[count].SetActive(true);
        }
        else
        {
            G_final.SetActive(true);
        }
    }
}
