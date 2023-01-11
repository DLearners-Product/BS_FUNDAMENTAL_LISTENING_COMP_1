using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class drag_recreate : MonoBehaviour
{
    public static drag_recreate OBJ_drag_recreate;
    public int Q_count,Ans_count;
    public GameObject[] GA_Question;
    public GameObject G_final_screen;
    public GameObject G_recreate;
    public float timer;
    public bool callonce;
   
    private void Start()
    {
        OBJ_drag_recreate = this;
        G_recreate.SetActive(false);
        Time.timeScale = 1;
        G_final_screen.SetActive(false);
        callonce = true;
        for (int i = 0; i < GA_Question.Length; i++)
        {
            GA_Question[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        

    }
    public void Update()
    {
        if (callonce)
        {
            timer = timer + 1 * Time.deltaTime;
            if (timer > 30)
            {
                for (int i = 0; i < GA_Question.Length; i++)
                {
                    GA_Question[i].transform.GetChild(0).gameObject.SetActive(false);
                }
                G_recreate.SetActive(true);
                callonce = false;
            }
        }
    }
    public void IncreaseCount()
    {
        Ans_count++;
        if(Ans_count==6)
        {
            Invoke("OffBlur", 2f);
        }
        
    }
   /* public void OnBlur()
    {
        G_Blur.SetActive(true);
        for(int i=0;i<GA_Blur_names.Length;i++)
        {
            GA_Blur_names[i].SetActive(false);
            GA_Question[i].SetActive(false);
        }
       GA_Blur_names[Ans_count].SetActive(true);
    }*/

    public void OffBlur()
    {
        
            G_final_screen.SetActive(true);
        
    }
   
}
