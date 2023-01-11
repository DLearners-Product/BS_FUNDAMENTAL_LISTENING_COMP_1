using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Main_pattern_complete : MonoBehaviour
{
    public static Main_pattern_complete OBJ_main_Pattern_Complete;
    public int Q_count, Ans_count;
    public GameObject[] GA_Question;
    public GameObject G_final_screen;
    public float timer;
    public AudioSource AS_correct;

    private void Start()
    {
        OBJ_main_Pattern_Complete = this;
        G_final_screen.SetActive(false);

        for (int i = 0; i < GA_Question.Length; i++)
        {
            GA_Question[i].SetActive(false);

        }
        Q_count = 0;
        GA_Question[Q_count].SetActive(true);
       
        Ans_count = 0;

    }
    public void Update()
    {
       
    }
    public void IncreaseCount()
    {
        Debug.Log("increase count");
        Ans_count++;
        if (Ans_count == 2)
        {
            Invoke(nameof(OffBlur), 60f * Time.deltaTime);
        }
    }
   
    public void OffBlur()
    {
        Q_count++;
        Debug.Log("bluroff");
        if (Q_count < 5)
        {
            
            for (int i = 0; i < GA_Question.Length; i++)
            {
                GA_Question[i].SetActive(false);
            }
            GA_Question[Q_count].SetActive(true);
            Ans_count = 0;
        }
        else 
        {
            G_final_screen.SetActive(true);
        }
    }

}
