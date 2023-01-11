using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbowcount : MonoBehaviour
{
    public static Rainbowcount OBJ_rainbowcount;
    public int count;
    public GameObject G_final,G_panel;
    // Start is called before the first frame update
    void Start()
    {
        OBJ_rainbowcount = this;
        G_final.SetActive(false);
        G_panel.SetActive(true);
    }

    // Update is called once per frame
    public void countfunction()
    {
        count++;
        if (count == 7)
        {
            G_final.SetActive(true);
            G_panel.SetActive(false);
        }
    }
}
