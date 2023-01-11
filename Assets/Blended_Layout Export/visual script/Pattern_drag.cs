using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_drag : MonoBehaviour
{
    public bool B_drag;

    public Vector2 pos_initial;
    public bool B_corret, B_callonce;

    private void Start()
    {
        pos_initial = this.transform.position;
        B_callonce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (B_drag)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepos);
        }
        if (!B_drag && !B_corret)
        {
            transform.position = pos_initial;
        }
    }

    void OnMouseDown()
    {
        B_drag = true;
    }
    void OnMouseUp()
    {
        B_drag = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == this.tag)
        {
            //Debug.Log()
            B_corret = true;
            Debug.Log("ans");



            if (!B_drag && B_corret)
            {
                this.transform.position = collision.transform.position;
                collision.GetComponent<Image>().enabled = false;
                this.GetComponent<Pattern_drag>().enabled = false;
                if (B_callonce)
                {
                    Main_pattern_complete.OBJ_main_Pattern_Complete.IncreaseCount();
                    B_callonce = false;
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        B_corret = false;
        this.transform.position = pos_initial;
    }
}

