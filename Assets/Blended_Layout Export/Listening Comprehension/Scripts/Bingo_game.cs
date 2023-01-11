using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bingo_game : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public int Q_count,Ans_count;
    public GameObject G_selected,G_Finalscreen,G_next;
    // Start is called before the first frame update
    void Start()
    {
        G_Finalscreen.SetActive(false);
        Q_count = 0;
        G_next.SetActive(true);
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);

        }
        GA_Questions[Q_count].SetActive(true);

        for (int i = 0; i < GA_Questions[Q_count].transform.childCount; i++)
        {
            GA_Questions[Q_count].transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    public void But_OnClicking()
    {
        Ans_count++;
        G_selected = EventSystem.current.currentSelectedGameObject;
        G_selected.transform.GetChild(0).gameObject.SetActive(true);
        if(Ans_count==20)
        {
            Invoke("BUT_next", 2f);
        }
    }
    public void BUT_next()
    {
        Ans_count = 0;
        Q_count ++;
        if (Q_count < 4)
        {
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[Q_count].SetActive(true);

            for (int i = 0; i < GA_Questions[Q_count].transform.childCount; i++)
            {
                GA_Questions[Q_count].transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            G_Finalscreen.SetActive(true);
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            G_next.SetActive(false);
        }
    }
}
