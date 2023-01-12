using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Bingo_game : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public int Q_count,Ans_count;
    public GameObject G_selected,G_Finalscreen;
    public TextMeshProUGUI TXT_Max, TXT_Current;
    public Button backButton;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        G_Finalscreen.SetActive(false);
        Q_count = 0;
        nextButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        TXT_Max.text = GA_Questions.Length.ToString();
        int j = Q_count + 1;
        TXT_Current.text = j.ToString(); 
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
        if (Q_count < GA_Questions.Length)
        {
            int j = Q_count + 1;
            TXT_Current.text = j.ToString();
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[Q_count].SetActive(true);

            for (int i = 0; i < GA_Questions[Q_count].transform.childCount; i++)
            {
                GA_Questions[Q_count].transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            BUT_Enabler();
        }
       
       /*  else
        {
            G_Finalscreen.SetActive(true);
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            nextButton.gameObject.SetActive(false);
        }*/
    }

    public void BUT_back()
    {
        Ans_count = 20;
        Q_count--;
        if (Q_count >= 0)
        {
            int j = Q_count + 1;
            TXT_Current.text = j.ToString();
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            GA_Questions[Q_count].SetActive(true);

            for (int i = 0; i < GA_Questions[Q_count].transform.childCount; i++)
            {
                GA_Questions[Q_count].transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            BUT_Enabler();
        }

        /*  else
        {
            G_Finalscreen.SetActive(true);
            for (int i = 0; i < GA_Questions.Length; i++)
            {
                GA_Questions[i].SetActive(false);
            }
            backButton.gameObject.SetActive(false);
        }*/

    }

    public void BUT_Enabler()
    {
        if (Q_count == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        else if (Q_count == GA_Questions.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }
}
