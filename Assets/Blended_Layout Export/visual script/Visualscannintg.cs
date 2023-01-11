using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Visualscannintg : MonoBehaviour
{
    public GameObject[] GA_Pos;
    public GameObject square;
    public int count,Total_count;
    public float timer;
    public bool B_timer;
    public GameObject G_final;
    private GameObject G_selected;
    public Color red,blue,green, yellow;
    public Color color;
    public Text T_totalcount, T_yellowcount,T_timer;
    public AudioSource AS_correct, AS_wrong;
    // Update is called once per frame

    public void Start()
    {
        G_final.SetActive(false);
       
        Time.timeScale = 1;
        StartCoroutine(clone());
        count = 0;
        Total_count = 0;
        timer = 60;
    }
    public void Update()
    {
        if (B_timer)
        {
            timer = timer - 1 * Time.deltaTime;

            T_timer.text = "" + (int)timer;

            if (timer <= 0)
            {
                //StopCoroutine("clone");
                StopAllCoroutines();
                finalscreen();
                for (int i = 0; i < GA_Pos.Length; i++)
                {
                    Destroy(GA_Pos[i].gameObject);
                }

                T_yellowcount.text = "" + count;
                // Total_count = Total_count - count;
                T_totalcount.text = "" + Total_count;
                
                B_timer = false;
            }
        }
    }
    public IEnumerator clone()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if(B_timer==false)
            B_timer = true;
           // Destroy(Square.);
           
            for (int i = 0; i < 5; i++)
            {
                int randomint = Random.Range(0, GA_Pos.Length);

                Debug.Log(randomint);
                GameObject Square = Instantiate(square);
                Square.transform.SetParent(GA_Pos[i].transform, false);
                Square.transform.position = transform.Find("BG").gameObject.transform.Find("panel").gameObject.transform.Find("pos").transform.GetChild(randomint).transform.position;
                int randcol = Random.Range(1, 5);
                switch (randcol)
                {
                    case 1:
                        color = red;
                        break;
                    case 2:
                        color = blue;
                        break;
                    case 3:
                        color = green;
                        break;
                    case 4:
                        color = yellow;
                        break;
                }
                Square.GetComponent<Image>().color = color;
                // Square.AddComponent<Button>();
                Square.GetComponent<Button>().onClick.AddListener(() => Onclicking());
            }
            int randomint1 = Random.Range(0, GA_Pos.Length);
            GameObject Square1 = Instantiate(square);
            int j = Random.Range(4, 6);
            Square1.transform.SetParent(GA_Pos[j].transform, false);
            Square1.transform.position = transform.Find("BG").gameObject.transform.Find("panel").gameObject.transform.Find("pos").transform.GetChild(randomint1).transform.position;
            Square1.GetComponent<Image>().color = yellow;
            Square1.GetComponent<Button>().onClick.AddListener(() => Onclicking());
        }
        
    }

    public void finalscreen()
    {
        G_final.SetActive(true);
    }
    public void Onclicking()
    {
        G_selected = EventSystem.current.currentSelectedGameObject;
        G_selected.GetComponent<Image>().enabled = false;
        Total_count++;
        T_yellowcount.text = "" + count;
        T_totalcount.text = "" + Total_count;
       
        if (G_selected.GetComponent<Image>().color==yellow)
        {
            AS_correct.Play();
            count++;
        }
        else
        {
            AS_wrong.Play();
        }
    }

}
