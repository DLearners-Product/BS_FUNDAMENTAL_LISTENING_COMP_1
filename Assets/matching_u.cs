using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matching_u : MonoBehaviour
{
    public int questionCount;
    public GameObject FinishLines;
    public GameObject lines;
    public GameObject FinishScreen;



    private void Start()
    {
        FinishScreen.SetActive(false);
        questionCount = 0;

        for(int i=0; i< FinishLines.transform.childCount; i++)
        {
            FinishLines.transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    public void IncreaseCount(string name)
    {
        questionCount++;

        FinishLines.transform.Find(name + "_lines").gameObject.SetActive(true);
        lines.transform.Find(name).gameObject.SetActive(false);


        if (questionCount >= 5)
        {
            FinishScreen.SetActive(true);
        }
    }
}
