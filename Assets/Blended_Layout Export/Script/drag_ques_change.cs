using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class drag_ques_change : MonoBehaviour
{
    public static drag_ques_change OBJ_drag_ques_change;
    public int Q_count,Ans_count;
    public GameObject[] GA_Question;
    public GameObject G_final_screen;
    public float timer;
   
    private void Start()
    {
          OBJ_drag_ques_change = this;
        Time.timeScale = 1;
        G_final_screen.SetActive(false);
       
        for (int i = 0; i < GA_Question.Length; i++)
        {
            GA_Question[i].SetActive(false);
          
        }
        Q_count = 0;
        GA_Question[Q_count].SetActive(true);
        GA_Question[Q_count].transform.GetChild(0).gameObject.SetActive(true);
        GA_Question[Q_count].transform.GetChild(1).gameObject.SetActive(false);
        timer = 0;
        Ans_count = 0;

    }
    public void Update()
    {
        timer = timer + 1 * Time.deltaTime;
        if(timer>20)
        {
            GA_Question[Q_count].transform.GetChild(0).gameObject.SetActive(false);
            GA_Question[Q_count].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void IncreaseCount()
    {
        
            Debug.Log("increase count");
            Ans_count++;
            if (Ans_count == 4)
            {
                Invoke(nameof(OffBlur), 60f * Time.deltaTime);
            }
        
        
    }
    public void Next()
    {
        if (Q_count < 4)
        {
            Q_count++;
            for (int i = 0; i < GA_Question.Length; i++)
            {
                GA_Question[i].SetActive(false);

            }
            GA_Question[Q_count].SetActive(true);
            GA_Question[Q_count].transform.GetChild(0).gameObject.SetActive(true);
            GA_Question[Q_count].transform.GetChild(1).gameObject.SetActive(false);
            timer = 0;
            Ans_count = 0;
        }
        else
        {
            G_final_screen.SetActive(true);
        }
    }

    public void OffBlur()
    {
        Debug.Log("bluroff");
       // G_Blur.SetActive(false);
        if (Q_count < 4)
        {
            Q_count++;
            for (int i = 0; i < GA_Question.Length; i++)
            {
                GA_Question[i].SetActive(false);
            }
            GA_Question[Q_count].SetActive(true);
            GA_Question[Q_count].transform.GetChild(0).gameObject.SetActive(true);
            GA_Question[Q_count].transform.GetChild(1).gameObject.SetActive(false);
            timer = 0;
            Ans_count = 0;
        }
        else
        {
            G_final_screen.SetActive(true);
        }

    }
   
}
