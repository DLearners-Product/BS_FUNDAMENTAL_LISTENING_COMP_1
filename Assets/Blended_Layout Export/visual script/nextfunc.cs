using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextfunc : MonoBehaviour
{
    public GameObject[] GA_Questions;
    int count;
    public GameObject G_finalscreen;
    // Start is called before the first frame update
    void Start()
    {
        G_finalscreen.SetActive(false);
        count = 0;
        for(int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[count].SetActive(true);
    }

    // Update is called once per frame
    public void next()
    {
        this.GetComponent<Draw>().BUT_erase();
        
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
